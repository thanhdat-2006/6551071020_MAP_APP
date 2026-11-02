using ClosedXML.Excel;
using HotelManagementApp.Models;
using HotelManagementApp.Phong;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HotelManagementApp.Phong
{
    partial class FormDanhSachPhong : Form
    {
        private readonly Image _iconPhong = Properties.Resources.Phong;
        private readonly Image _iconSua = Properties.Resources.edit;
        private readonly Image _iconXoa = Properties.Resources.delete;

        public FormDanhSachPhong()
        {
            InitializeComponent();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            LocTheoTuKhoa();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            var cacDong = dtgDanhSachPhong.Rows.Cast<DataGridViewRow>()
                .Where(r => r.Visible && !r.IsNewRow)
                .ToList();

            if (cacDong.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo",
    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var hopLuu = new SaveFileDialog())
            {
                hopLuu.Title = "Xuất danh sách phòng";
                hopLuu.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
                hopLuu.FileName = $"DanhSachPhong_{DateTime.Now:yyyyMMdd_HHmm}.xlsx";

                if (hopLuu.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    using (var wb = new XLWorkbook())
                    {
                        var ws = wb.Worksheets.Add("Danh sách phòng");

                        string[] tenCot = { "MaPH", "TTPH", "TTDD", "TenLPH" };
                        string[] tieuDe = { "Mã phòng", "Tình trạng phòng", "Dọn dẹp", "Loại phòng" };

                        for (int c = 0; c < tenCot.Length; c++)
                            ws.Cell(1, c + 1).Value = tieuDe[c];
                        ws.Row(1).Style.Font.Bold = true;

                        for (int i = 0; i < cacDong.Count; i++)
                        {
                            for (int c = 0; c < tenCot.Length; c++)
                                ws.Cell(i + 2, c + 1).Value =
    cacDong[i].Cells[tenCot[c]].Value?.ToString() ?? "";
                        }

                        ws.Columns().AdjustToContents();
                        wb.SaveAs(hopLuu.FileName);
                    }

                    var traLoi = MessageBox.Show("Xuất dữ liệu thành công!\nBạn có muốn mở file ngay không?", "Thông báo",
    MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (traLoi == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(
                            new System.Diagnostics.ProcessStartInfo(hopLuu.FileName)
                            {
                                UseShellExecute = true
                            });
                    }
                }
                catch (IOException)
                {
                    MessageBox.Show("Không ghi được file. Có thể file đang được mở trong Excel, hãy đóng lại rồi thử lần nữa.",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xuất Excel: " + ex.Message, "Lỗi",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnThemMoiPhong_Click(object sender, EventArgs e)
        {
            using (var form = new FormThemPhong())
            {
                form.ShowDialog();
            }

            LoadDanhSachPhong();
        }
        private void dtgDanhSachPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            string? maPhong =
    dtgDanhSachPhong.Rows[e.RowIndex].Cells["MaPH"].Value?.ToString();
            if (string.IsNullOrEmpty(maPhong))
                return;

            string tenCot = dtgDanhSachPhong.Columns[e.ColumnIndex].Name;

            if (tenCot == "colSua")
            {
                using (var formSua = new FormSuaPhong(maPhong))
                {
                    formSua.ShowDialog();
                }
                LoadDanhSachPhong();
            }
            else if (tenCot == "colXoa")
            {
                DialogResult result = MessageBox.Show($"Bạn có muốn xóa phòng {maPhong} không?", "Xác nhận",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    XoaPhong(maPhong);
                    LoadDanhSachPhong();
                }
            }
        }

        private void FormDanhSachPhong_Load(object sender, EventArgs e)
        {
            CauHinhLuoi();
            LoadDanhSachPhong();
        }

        private void CauHinhLuoi()
        {
            if (dtgDanhSachPhong.Columns.Count > 0)
                return;

            dtgDanhSachPhong.ReadOnly = true;
            dtgDanhSachPhong.AllowUserToAddRows = false;
            dtgDanhSachPhong.AllowUserToDeleteRows = false;
            dtgDanhSachPhong.AllowUserToResizeRows = false;
            dtgDanhSachPhong.MultiSelect = false;
            dtgDanhSachPhong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgDanhSachPhong.RowHeadersVisible = false;
            dtgDanhSachPhong.AutoSizeColumnsMode =
    DataGridViewAutoSizeColumnsMode.Fill;
            dtgDanhSachPhong.RowTemplate.Height = 40;

            dtgDanhSachPhong.Columns.Add(TaoCotAnh("colIcon", "", _iconPhong));
            dtgDanhSachPhong.Columns.Add("MaPH", "Mã phòng");
            dtgDanhSachPhong.Columns.Add("TTPH", "Tình trạng phòng");
            dtgDanhSachPhong.Columns.Add("TTDD", "Dọn dẹp");
            dtgDanhSachPhong.Columns.Add("TenLPH", "Loại phòng");
            dtgDanhSachPhong.Columns.Add(TaoCotAnh("colSua", "Sửa", _iconSua));
            dtgDanhSachPhong.Columns.Add(TaoCotAnh("colXoa", "Xóa", _iconXoa));
        }

        private DataGridViewImageColumn TaoCotAnh(string ten, string tieuDe, Image anh)
        {
            return new DataGridViewImageColumn
            {
                Name = ten,
                HeaderText = tieuDe,
                Image = anh,
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                Width = 50,
                Resizable = DataGridViewTriState.False,
                SortMode = DataGridViewColumnSortMode.NotSortable
            };
        }

        private void LoadDanhSachPhong()
        {
            try
            {
                using var db = new HotelManagementContext();

                var dsPhong = db.Phongs
                    .AsNoTracking()
                    .Where(p => p.DaXoa != true)
                    .OrderBy(p => p.MaPh)
                    .Select(p => new
                    {
                        p.MaPh,
                        p.Ttph,
                        p.Ttdd,
                        TenLph = p.MaLphNavigation.TenLph
                    })
                    .ToList();

                dtgDanhSachPhong.Rows.Clear();

                foreach (var p in dsPhong)
                {
                    dtgDanhSachPhong.Rows.Add(
                        _iconPhong,
                        p.MaPh,
                        p.Ttph,
                        p.Ttdd,
                        p.TenLph,
                        _iconSua,
                        _iconXoa
                    );
                }

                LocTheoTuKhoa();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách phòng: " + ex.Message);
            }
        }

        private void LocTheoTuKhoa()
        {
            string keyword = txtTimKiem.Text.Trim();

            dtgDanhSachPhong.CurrentCell = null;

            foreach (DataGridViewRow row in dtgDanhSachPhong.Rows)
            {
                string maPhong = row.Cells["MaPH"].Value?.ToString() ?? "";
                row.Visible = keyword.Length == 0
                    || maPhong.Contains(keyword,
    StringComparison.OrdinalIgnoreCase);
            }
        }

        private void XoaPhong(string maPhong)
        {
            try
            {
                using var db = new HotelManagementContext();

                var phong = db.Phongs.FirstOrDefault(p => p.MaPh == maPhong && p.DaXoa != true);

                if (phong == null)
                {
                    MessageBox.Show("Không tìm thấy phòng để xóa.", "Lỗi",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (phong.Ttph == "Đang thuê" || phong.Ttph == "Đã đặt")
                {
                    MessageBox.Show($"Phòng {maPhong} đang ở trạng thái \"{phong.Ttph}\" nên không thể xóa.",
                        "Không thể xóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                phong.DaXoa = true;
                db.SaveChanges();

                MessageBox.Show("Đã xóa phòng thành công!", "Thông báo",
    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa phòng: " + ex.Message, "Lỗi",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}