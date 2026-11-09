using HotelManagementApp.Models;
using HotelManagementApp.Utils;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace HotelManagementApp.HoaDon
{
    public partial class FormHoaDon : Form
    {
        private string maHD = string.Empty;
        private readonly CultureInfo viVN = new CultureInfo("vi-VN");

        public FormHoaDon()
        {
            InitializeComponent();
        }

        public FormHoaDon(string maHD) : this()
        {
            this.maHD = maHD;
        }

        private void FormHoaDon_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(maHD))
            {
                MessageBox.Show("Không xác định được hóa đơn cần xem!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.Cancel;
                Close();
                return;
            }

            LoadThongTinHoaDon();
        }

        private string DinhDangTien(decimal soTien)
        {
            return soTien.ToString("N0", viVN) + " VND";
        }

        private void LoadThongTinHoaDon()
        {
            try
            {
                using var db = new HotelManagementContext();

                var hoaDon = db.HoaDons
                    .AsNoTracking()
                    .Where(h => h.MaHd == maHD && h.DaXoa != true)
                    .Select(h => new
                    {
                        h.MaHd,
                        h.NgHd,
                        h.MaCtdp,
                        TenNV = h.MaNvNavigation.TenNv,
                        TenKH = h.MaCtdpNavigation.MaPtNavigation.MaKhNavigation.TenKh,
                        MaPH = h.MaCtdpNavigation.MaPh,
                        TenLPH = h.MaCtdpNavigation.MaPhNavigation.MaLphNavigation.TenLph,
                        h.MaCtdpNavigation.ThanhTien,
                        h.MaCtdpNavigation.CheckIn,
                        h.MaCtdpNavigation.CheckOut,
                        h.MaCtdpNavigation.TheoGio
                    })
                    .FirstOrDefault();

                if (hoaDon == null)
                {
                    MessageBox.Show("Không tìm thấy hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DialogResult = DialogResult.Cancel;
                    Close();
                    return;
                }

                var dichVu = db.Ctdvs
                    .AsNoTracking()
                    .Where(c => c.MaCtdp == hoaDon.MaCtdp && c.DaXoa != true)
                    .OrderBy(c => c.MaDv)
                    .Select(c => new
                    {
                        TenDV = c.MaDvNavigation.TenDv,
                        DonGia = c.MaDvNavigation.DonGia,
                        SL = c.Sl,
                        ThanhTien = c.MaDvNavigation.DonGia * c.Sl
                    })
                    .ToList();

                decimal tienPhong = hoaDon.ThanhTien ?? 0;
                decimal tienDichVu = dichVu.Sum(d => d.ThanhTien);
                decimal tongTien = tienPhong + tienDichVu;

                txtMaHoaDon.Text = hoaDon.MaHd;
                dtpNgayHD.Value = hoaDon.NgHd ?? DateTime.Today;
                txtTenNV.Text = hoaDon.TenNV ?? "";
                txtTenKH.Text = hoaDon.TenKH ?? "";
                txtMaPhong.Text = hoaDon.MaPH;
                txtTenLP.Text = hoaDon.TenLPH ?? "";
                txtTienThuePhong.Text = DinhDangTien(tienPhong);
                lbTongTriGia.Text = "Tổng tiền: " + DinhDangTien(tongTien);

                TimeSpan thoiGianThue = hoaDon.CheckOut - hoaDon.CheckIn;
                if (hoaDon.TheoGio == true || thoiGianThue.Days < 1)
                {
                    txtSoNgayThuePhong.Text = Math.Max(1, (int)Math.Ceiling(thoiGianThue.TotalHours)) + " giờ";
                }
                else
                {
                    txtSoNgayThuePhong.Text = thoiGianThue.Days.ToString();
                }

                dtgDichVuDaDung.DataSource = dichVu;

                dtgDichVuDaDung.Columns["TenDV"].HeaderText = "Tên dịch vụ";
                dtgDichVuDaDung.Columns["DonGia"].HeaderText = "Đơn giá";
                dtgDichVuDaDung.Columns["SL"].HeaderText = "Số lượng";
                dtgDichVuDaDung.Columns["ThanhTien"].HeaderText = "Thành tiền";

                dtgDichVuDaDung.Columns["DonGia"].DefaultCellStyle.Format = "N0";
                dtgDichVuDaDung.Columns["DonGia"].DefaultCellStyle.FormatProvider = viVN;
                dtgDichVuDaDung.Columns["DonGia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dtgDichVuDaDung.Columns["SL"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtgDichVuDaDung.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
                dtgDichVuDaDung.Columns["ThanhTien"].DefaultCellStyle.FormatProvider = viVN;
                dtgDichVuDaDung.Columns["ThanhTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                UiHelper.TuDongChinhDoRongCotVaTieuDe(dtgDichVuDaDung);

                dtgDichVuDaDung.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }

        private void Printer_Click(object sender, EventArgs e)
        {
            if (!XuatHoaDonRaPDF())
            {
                return;
            }

            try
            {
                using var db = new HotelManagementContext();

                db.HoaDons
                    .Where(h => h.MaHd == maHD && h.DaXoa != true)
                    .ExecuteUpdate(s => s.SetProperty(h => h.TrangThai, "Đã thanh toán"));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xuất PDF nhưng không cập nhật được trạng thái thanh toán: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private BaseFont TaoFontTiengViet()
        {
            string thuMucFont = Environment.GetFolderPath(Environment.SpecialFolder.Fonts);
            string[] danhSachFont = { "arial.ttf", "tahoma.ttf", "segoeui.ttf", "times.ttf" };

            foreach (string tenFile in danhSachFont)
            {
                string duongDan = Path.Combine(thuMucFont, tenFile);
                if (File.Exists(duongDan))
                {
                    return BaseFont.CreateFont(duongDan, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                }
            }

            throw new FileNotFoundException("Không tìm thấy font hỗ trợ tiếng Việt trong thư mục Fonts của Windows.");
        }

        private PdfPCell TaoO(string noiDung, iTextSharp.text.Font font, int canLe, bool coVien)
        {
            PdfPCell o = new PdfPCell(new Phrase(noiDung, font));
            o.HorizontalAlignment = canLe;
            o.VerticalAlignment = Element.ALIGN_MIDDLE;
            o.Padding = 5;
            if (!coVien)
            {
                o.Border = iTextSharp.text.Rectangle.NO_BORDER;
            }
            return o;
        }

        private bool XuatHoaDonRaPDF()
        {
            using SaveFileDialog save = new SaveFileDialog();
            save.Title = "Xuất hóa đơn";
            save.Filter = "PDF files (*.pdf)|*.pdf";
            save.FileName = "HoaDon_" + txtMaHoaDon.Text + ".pdf";

            if (save.ShowDialog() != DialogResult.OK)
            {
                return false;
            }

            try
            {
                BaseFont baseFont = TaoFontTiengViet();
                iTextSharp.text.Font fontTieuDe = new iTextSharp.text.Font(baseFont, 18, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font fontDam = new iTextSharp.text.Font(baseFont, 12, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font fontThuong = new iTextSharp.text.Font(baseFont, 12, iTextSharp.text.Font.NORMAL);
                iTextSharp.text.Font fontNghieng = new iTextSharp.text.Font(baseFont, 12, iTextSharp.text.Font.ITALIC);
                iTextSharp.text.Font fontTong = new iTextSharp.text.Font(baseFont, 14, iTextSharp.text.Font.BOLD);

                Document doc = new Document(PageSize.A4, 25, 25, 30, 30);

                using (FileStream stream = new FileStream(save.FileName, FileMode.Create))
                {
                    PdfWriter.GetInstance(doc, stream);
                    doc.Open();
                    Paragraph title = new Paragraph("HÓA ĐƠN THANH TOÁN", fontTieuDe);
                    title.Alignment = Element.ALIGN_CENTER;
                    title.SpacingAfter = 20;
                    doc.Add(title);

                    PdfPTable tableInfo = new PdfPTable(2);
                    tableInfo.WidthPercentage = 100;
                    tableInfo.SetWidths(new float[] { 1.2f, 2.8f });

                    string[,] thongTin =
                    {
                { "Mã hóa đơn:", txtMaHoaDon.Text },
                { "Ngày lập:", dtpNgayHD.Value.ToString("dd/MM/yyyy") },
                { "Khách hàng:", txtTenKH.Text },
                { "Nhân viên lập:", txtTenNV.Text },
                { "Phòng:", txtMaPhong.Text },
                { "Loại phòng:", txtTenLP.Text },
                { "Thời gian thuê:", txtSoNgayThuePhong.Text },
                { "Tiền thuê phòng:", txtTienThuePhong.Text }
            };

                    for (int i = 0; i < thongTin.GetLength(0); i++)
                    {
                        tableInfo.AddCell(TaoO(thongTin[i, 0], fontDam, Element.ALIGN_LEFT, false));
                        tableInfo.AddCell(TaoO(thongTin[i, 1], fontThuong, Element.ALIGN_LEFT, false));
                    }
                    doc.Add(tableInfo);

                    Paragraph tieuDeDichVu = new Paragraph("DỊCH VỤ ĐÃ SỬ DỤNG:", fontNghieng);
                    tieuDeDichVu.SpacingBefore = 15;
                    tieuDeDichVu.SpacingAfter = 8;
                    doc.Add(tieuDeDichVu);

                    PdfPTable tableDV = new PdfPTable(4);
                    tableDV.WidthPercentage = 100;
                    tableDV.SetWidths(new float[] { 3, 2, 1.5f, 2 });

                    BaseColor mauTieuDe = new BaseColor(230, 230, 230);
                    string[] tieuDeCot = { "Tên dịch vụ", "Đơn giá", "Số lượng", "Thành tiền" };

                    foreach (string tieuDeCotDV in tieuDeCot)
                    {
                        PdfPCell oTieuDe = TaoO(tieuDeCotDV, fontDam, Element.ALIGN_CENTER, true);
                        oTieuDe.BackgroundColor = mauTieuDe;
                        tableDV.AddCell(oTieuDe);
                    }

                    int soDong = 0;
                    foreach (DataGridViewRow row in dtgDichVuDaDung.Rows)
                    {
                        if (row.IsNewRow)
                        {
                            continue;
                        }

                        decimal donGia = Convert.ToDecimal(row.Cells["DonGia"].Value ?? 0);
                        decimal thanhTien = Convert.ToDecimal(row.Cells["ThanhTien"].Value ?? 0);
                        tableDV.AddCell(TaoO(row.Cells["TenDV"].Value?.ToString() ?? "", fontThuong, Element.ALIGN_LEFT, true));
                        tableDV.AddCell(TaoO(donGia.ToString("N0", viVN), fontThuong, Element.ALIGN_RIGHT, true));
                        tableDV.AddCell(TaoO(row.Cells["SL"].Value?.ToString() ?? "", fontThuong, Element.ALIGN_CENTER, true));
                        tableDV.AddCell(TaoO(thanhTien.ToString("N0", viVN), fontThuong, Element.ALIGN_RIGHT, true));
                        soDong++;
                    }

                    if (soDong == 0)
                    {
                        PdfPCell oTrong = TaoO("Không sử dụng dịch vụ", fontNghieng, Element.ALIGN_CENTER, true);
                        oTrong.Colspan = 4;
                        tableDV.AddCell(oTrong);
                    }

                    doc.Add(tableDV);

                    Paragraph total = new Paragraph(lbTongTriGia.Text, fontTong);
                    total.Alignment = Element.ALIGN_RIGHT;
                    total.SpacingBefore = 15;
                    doc.Add(total);

                    Paragraph camOn = new Paragraph("Cảm ơn quý khách!", fontNghieng);
                    camOn.Alignment = Element.ALIGN_CENTER;
                    camOn.SpacingBefore = 30;
                    doc.Add(camOn);

                    doc.Close();
                }

                MessageBox.Show("Xuất hóa đơn PDF thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (IOException)
            {
                MessageBox.Show("Không ghi được file. Có thể file đang được mở, hãy đóng lại rồi thử lần nữa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất hóa đơn PDF: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}