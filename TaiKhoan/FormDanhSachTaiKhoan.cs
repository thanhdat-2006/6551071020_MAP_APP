using ClosedXML.Excel;
using HotelManagementApp.DangNhap;
using HotelManagementApp.Models;
using HotelManagementApp.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HotelManagementApp.TaiKhoan
{
    public partial class FormDanhSachTaiKhoan : Form
    {
        public FormDanhSachTaiKhoan()
        {
            InitializeComponent();

            Load += FormDanhSachTaiKhoan_Load;
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
            btnXuatExcel.Click += btnXuatExcel_Click;
            btnThemMoi.Click += btnThemMoi_Click;
            dtgDanhSachTaiKhoan.CellClick += dtgDanhSachTaiKhoan_CellClick;
        }

        private void FormDanhSachTaiKhoan_Load(object sender, EventArgs e)
        {
            LoadDanhSachTaiKhoan();
        }

        private void KhoiTaoBangDuLieu()
        {
            UiHelper.DinhDangLuoi(dtgDanhSachTaiKhoan);
            dtgDanhSachTaiKhoan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            DataGridViewImageColumn iconCol = new DataGridViewImageColumn();
            iconCol.Name = "Icon";
            iconCol.HeaderText = "";
            iconCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
            iconCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            iconCol.Width = 40;
            dtgDanhSachTaiKhoan.Columns.Add(iconCol);

            dtgDanhSachTaiKhoan.Columns.Add("TenTK", "Tên tài khoản");
            dtgDanhSachTaiKhoan.Columns.Add("TenNV", "Họ và tên NV");
            dtgDanhSachTaiKhoan.Columns.Add("CapDoQuyen", "Cấp độ quyền");

            dtgDanhSachTaiKhoan.Columns["TenTK"].FillWeight = 35;
            dtgDanhSachTaiKhoan.Columns["TenNV"].FillWeight = 40;
            dtgDanhSachTaiKhoan.Columns["CapDoQuyen"].FillWeight = 25;

            DataGridViewImageColumn suaCol = new DataGridViewImageColumn();
            suaCol.Name = "Sua";
            suaCol.HeaderText = "Sửa";
            suaCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
            suaCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            suaCol.Width = 70;
            suaCol.MinimumWidth = 70;
            dtgDanhSachTaiKhoan.Columns.Add(suaCol);

            DataGridViewImageColumn xoaCol = new DataGridViewImageColumn();
            xoaCol.Name = "Xoa";
            xoaCol.HeaderText = "Xóa";
            xoaCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
            xoaCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            xoaCol.Width = 70;
            xoaCol.MinimumWidth = 70;
            dtgDanhSachTaiKhoan.Columns.Add(xoaCol);

            UiHelper.TuDongChinhDoRongCotVaTieuDe(dtgDanhSachTaiKhoan);
        }

        private string TenQuyen(int capDo)
        {
            switch (capDo)
            {
                case 1:
                    return "Cấp 1 - Nhân viên";
                case 2:
                    return "Cấp 2 - Quản lý";
                case 3:
                    return "Cấp 3 - Admin";
                default:
                    return "Cấp " + capDo;
            }
        }

        private void LoadDanhSachTaiKhoan(string tuKhoa = "")
        {
            try
            {
                if (dtgDanhSachTaiKhoan.Columns.Count == 0)
                {
                    KhoiTaoBangDuLieu();
                }

                using var db = new HotelManagementContext();
                var query = db.TaiKhoans
    .AsNoTracking()
    .Where(t => t.DaXoa != true);

                if (!string.IsNullOrWhiteSpace(tuKhoa))
                {
                    query = query.Where(t =>
                        t.TenTk.Contains(tuKhoa) ||
                        t.MaNv.Contains(tuKhoa) ||
                        t.MaNvNavigation.TenNv.Contains(tuKhoa));
                }

                var danhSach = query
                    .OrderByDescending(t => t.CapDoQuyen)
                    .ThenBy(t => t.TenTk)
                    .Select(t => new
                    {
                        t.TenTk,
                        TenNV = t.MaNvNavigation.TenNv,
                        t.CapDoQuyen
                    })
                    .ToList();

                Image iconTaiKhoan = Properties.Resources.TaiKhoan;
                Image iconSua = Properties.Resources.edit;
                Image iconXoa = Properties.Resources.delete;

                dtgDanhSachTaiKhoan.Rows.Clear();
                foreach (var tk in danhSach)
                {
                    dtgDanhSachTaiKhoan.Rows.Add(
                        iconTaiKhoan,
                        tk.TenTk,
                        tk.TenNV ?? "",
                        TenQuyen(tk.CapDoQuyen),
                        iconSua,
                        iconXoa
                    );
                }

                dtgDanhSachTaiKhoan.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load danh sách tài khoản: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            LoadDanhSachTaiKhoan(txtTimKiem.Text.Trim());
        }

        private void dtgDanhSachTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }

            string tenCot = dtgDanhSachTaiKhoan.Columns[e.ColumnIndex].Name;
            if (tenCot != "Sua" && tenCot != "Xoa")
            {
                return;
            }

            string tenTK = dtgDanhSachTaiKhoan.Rows[e.RowIndex].Cells["TenTK"].Value?.ToString();
            if (string.IsNullOrEmpty(tenTK))
            {
                return;
            }

            if (tenCot == "Sua")
            {
                using (FormSuaTaiKhoan frmSua = new FormSuaTaiKhoan(tenTK))
                {
                    if (frmSua.ShowDialog() == DialogResult.OK)
                    {
                        LoadDanhSachTaiKhoan(txtTimKiem.Text.Trim());
                    }
                }
                return;
            }

            if (MessageBox.Show($"Bạn có chắc chắn muốn xóa tài khoản '{tenTK}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                XoaTaiKhoan(tenTK);
            }
        }

        private void XoaTaiKhoan(string tenTK)
        {
            try
            {
                using var db = new HotelManagementContext();

                var taiKhoan = db.TaiKhoans.FirstOrDefault(t => t.TenTk == tenTK && t.DaXoa != true);

                if (taiKhoan == null)
                {
                    MessageBox.Show("Không tìm thấy tài khoản cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (!string.IsNullOrEmpty(FormDangNhap.MaNV_DangNhap) && taiKhoan.MaNv == FormDangNhap.MaNV_DangNhap)
                {
                    MessageBox.Show("Không thể xóa tài khoản đang đăng nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    taiKhoan.DaXoa = true;
                    int kq = db.SaveChanges();

                    if (kq > 0)
                    {
                        MessageBox.Show("Xóa tài khoản thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Xóa tài khoản thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa tài khoản: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LoadDanhSachTaiKhoan(txtTimKiem.Text.Trim());
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (dtgDanhSachTaiKhoan.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Title = "Xuất danh sách tài khoản";
            saveDialog.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
            saveDialog.FileName = "DanhSachTaiKhoan_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx";

            if (saveDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            try
            {
                string[] tenCot = { "TenTK", "TenNV", "CapDoQuyen" };

                using (XLWorkbook workbook = new XLWorkbook())
                {
                    IXLWorksheet worksheet = workbook.Worksheets.Add("Danh sách tài khoản");

                    for (int j = 0; j < tenCot.Length; j++)
                    {
                        worksheet.Cell(1, j + 1).Value = dtgDanhSachTaiKhoan.Columns[tenCot[j]].HeaderText;
                    }
                    worksheet.Range(1, 1, 1, tenCot.Length).Style.Font.Bold = true;

                    for (int i = 0; i < dtgDanhSachTaiKhoan.Rows.Count; i++)
                    {
                        for (int j = 0; j < tenCot.Length; j++)
                        {
                            worksheet.Cell(i + 2, j + 1).Value = dtgDanhSachTaiKhoan.Rows[i].Cells[tenCot[j]].Value?.ToString() ?? "";
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

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            using (FormThemTaiKhoan f = new FormThemTaiKhoan())
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    LoadDanhSachTaiKhoan(txtTimKiem.Text.Trim());
                }
            }
        }
    }
}