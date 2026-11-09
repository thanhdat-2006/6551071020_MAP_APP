using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using ClosedXML.Excel;
using HotelManagementApp.Models;
using HotelManagementApp.Utils;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementApp.HoaDon
{
    public partial class FormDanhSachHoaDon : Form
    {
        private readonly CultureInfo viVN = new CultureInfo("vi-VN");

        public FormDanhSachHoaDon()
        {
            InitializeComponent();
        }

        private void FormDanhSachHoaDon_Load(object sender, EventArgs e)
        {
            dtpNgayLap.Format = DateTimePickerFormat.Short;
            dtpNgayLap.ShowCheckBox = true;
            dtpNgayLap.Checked = false;

            dtpNgayLap.ValueChanged += dtpNgayLap_ValueChanged;
            dtgDanhSachHoaDon.CellClick += dtgDanhSachHoaDon_CellClick;

            LoadDanhSachHoaDon();
        }

        private void KhoiTaoBangDuLieu()
        {
            UiHelper.DinhDangLuoi(dtgDanhSachHoaDon);
            UiHelper.ToMauTrangThai(dtgDanhSachHoaDon, "TrangThai");
            dtgDanhSachHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dtgDanhSachHoaDon.Columns.Add("MaHD", "Mã hóa đơn");
            dtgDanhSachHoaDon.Columns.Add("NgHD", "Ngày lập");
            dtgDanhSachHoaDon.Columns.Add("TenNV", "Nhân viên");
            dtgDanhSachHoaDon.Columns.Add("MaCTDP", "Mã chi tiết phiếu");
            dtgDanhSachHoaDon.Columns.Add("TriGia", "Trị giá");
            dtgDanhSachHoaDon.Columns.Add("TrangThai", "Trạng thái");

            dtgDanhSachHoaDon.Columns["MaHD"].FillWeight = 14;
            dtgDanhSachHoaDon.Columns["NgHD"].FillWeight = 14;
            dtgDanhSachHoaDon.Columns["TenNV"].FillWeight = 20;
            dtgDanhSachHoaDon.Columns["MaCTDP"].FillWeight = 16;
            dtgDanhSachHoaDon.Columns["TriGia"].FillWeight = 16;
            dtgDanhSachHoaDon.Columns["TrangThai"].FillWeight = 16;

            dtgDanhSachHoaDon.Columns["NgHD"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dtgDanhSachHoaDon.Columns["TriGia"].DefaultCellStyle.Format = "N0";
            dtgDanhSachHoaDon.Columns["TriGia"].DefaultCellStyle.FormatProvider = viVN;
            dtgDanhSachHoaDon.Columns["TriGia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridViewImageColumn colXemChiTiet = new DataGridViewImageColumn();
            colXemChiTiet.Name = "XemChiTiet";
            colXemChiTiet.HeaderText = "Chi tiết";
            colXemChiTiet.ToolTipText = "Xem thông tin chi tiết hóa đơn";
            colXemChiTiet.ImageLayout = DataGridViewImageCellLayout.Zoom;
            colXemChiTiet.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colXemChiTiet.Width = 95;
            colXemChiTiet.MinimumWidth = 95;
            dtgDanhSachHoaDon.Columns.Add(colXemChiTiet);

            UiHelper.TuDongChinhDoRongCotVaTieuDe(dtgDanhSachHoaDon);
        }

        public void LoadDanhSachHoaDon()
        {
            try
            {
                if (dtgDanhSachHoaDon.Columns.Count == 0)
                {
                    KhoiTaoBangDuLieu();
                }

                string tuKhoa = txtTimKiem.Text.Trim();

                using var db = new HotelManagementContext();

                var query = db.HoaDons
                    .AsNoTracking()
                    .Where(h => h.DaXoa != true);

                if (tuKhoa.Length > 0)
                {
                    query = query.Where(h =>
                        h.MaHd.Contains(tuKhoa) ||
                        h.MaCtdpNavigation.MaPtNavigation.MaKhNavigation.CccdPassport.Contains(tuKhoa) ||
                        h.MaCtdpNavigation.MaPtNavigation.MaKhNavigation.TenKh.Contains(tuKhoa));
                }

                if (dtpNgayLap.Checked)
                {
                    DateTime ngayBatDau = dtpNgayLap.Value.Date;
                    DateTime ngayKetThuc = ngayBatDau.AddDays(1);
                    query = query.Where(h => h.NgHd >= ngayBatDau && h.NgHd < ngayKetThuc);
                }

                var danhSach = query
                    .OrderByDescending(h => h.NgHd)
                    .ThenBy(h => h.MaHd)
                    .Select(h => new
                    {
                        h.MaHd,
                        h.NgHd,
                        TenNV = h.MaNvNavigation.TenNv,
                        h.MaCtdp,
                        TriGia = (h.MaCtdpNavigation.ThanhTien ?? 0)
                            + h.MaCtdpNavigation.Ctdvs
                                .Where(c => c.DaXoa != true)
                                .Sum(c => c.MaDvNavigation.DonGia * c.Sl),
                        h.TrangThai
                    })
                    .ToList();

                Image iconChiTiet = Properties.Resources.details;

                dtgDanhSachHoaDon.Rows.Clear();
                foreach (var hd in danhSach)
                {
                    dtgDanhSachHoaDon.Rows.Add(
                        hd.MaHd,
                        hd.NgHd,
                        hd.TenNV ?? "",
                        hd.MaCtdp,
                        hd.TriGia,
                        hd.TrangThai,
                        iconChiTiet
                    );
                }

                dtgDanhSachHoaDon.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load danh sách hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (dtgDanhSachHoaDon.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Title = "Xuất danh sách hóa đơn";
            saveDialog.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
            saveDialog.FileName = "DanhSachHoaDon_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx";

            if (saveDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            try
            {
                string[] tenCot = { "MaHD", "NgHD", "TenNV", "MaCTDP", "TriGia", "TrangThai" };

                using (XLWorkbook workbook = new XLWorkbook())
                {
                    IXLWorksheet worksheet = workbook.Worksheets.Add("Danh sách hóa đơn");
                    for (int j = 0; j < tenCot.Length; j++)
                    {
                        worksheet.Cell(1, j + 1).Value = dtgDanhSachHoaDon.Columns[tenCot[j]].HeaderText;
                    }
                    worksheet.Range(1, 1, 1, tenCot.Length).Style.Font.Bold = true;

                    for (int i = 0; i < dtgDanhSachHoaDon.Rows.Count; i++)
                    {
                        for (int j = 0; j < tenCot.Length; j++)
                        {
                            IXLCell o = worksheet.Cell(i + 2, j + 1);
                            object giaTri = dtgDanhSachHoaDon.Rows[i].Cells[tenCot[j]].Value;

                            switch (giaTri)
                            {
                                case DateTime ngay:
                                    o.Value = ngay;
                                    o.Style.NumberFormat.Format = "dd/MM/yyyy";
                                    break;
                                case decimal soTien:
                                    o.Value = soTien;
                                    o.Style.NumberFormat.Format = "#,##0";
                                    break;
                                default:
                                    o.Value = giaTri?.ToString() ?? "";
                                    break;
                            }
                        }
                    }

                    worksheet.Columns().AdjustToContents();
                    workbook.SaveAs(saveDialog.FileName);
                }

                DialogResult moFile = MessageBox.Show(
                    "Xuất dữ liệu thành công!\nBạn có muốn mở file vừa xuất không?",
                    "Thông báo",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);

                if (moFile == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(saveDialog.FileName)
                    {
                        UseShellExecute = true
                    });
                }
            }
            catch (IOException)
            {
                MessageBox.Show("Không ghi được file. Có thể file đang được mở trong Excel, hãy đóng lại rồi thử lần nữa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất file Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TimKiemHoaDon()
        {
            LoadDanhSachHoaDon();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            TimKiemHoaDon();
        }

        private void dtpNgayLap_ValueChanged(object sender, EventArgs e)
        {
            TimKiemHoaDon();
        }

        private void dtgDanhSachHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }

            if (dtgDanhSachHoaDon.Columns[e.ColumnIndex].Name != "XemChiTiet")
            {
                return;
            }

            string maHD = dtgDanhSachHoaDon.Rows[e.RowIndex].Cells["MaHD"].Value?.ToString();
            if (string.IsNullOrEmpty(maHD))
            {
                return;
            }

            using (FormHoaDon frm = new FormHoaDon(maHD))
            {
                frm.ShowDialog();
            }

            LoadDanhSachHoaDon();
        }
    }
}