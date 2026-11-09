using ClosedXML.Excel;
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

namespace HotelManagementApp.NhanVien
{
    public partial class FormDanhSachNhanVien : Form
    {
        public FormDanhSachNhanVien()
        {
            InitializeComponent();
        }

        private void FormDanhSachNhanVien_Load(object sender, EventArgs e)
        {
            btnThemMoi.Click += btnThemMoi_Click;
            LoadDanhSachNhanVien();
        }

        private void KhoiTaoBangDuLieu()
        {
            UiHelper.DinhDangLuoi(dtgDanhSachNhanVien);
            dtgDanhSachNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            DataGridViewImageColumn iconCol = new DataGridViewImageColumn();
            iconCol.Name = "Icon";
            iconCol.HeaderText = "";
            iconCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
            iconCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            iconCol.Width = 40;
            dtgDanhSachNhanVien.Columns.Add(iconCol);

            dtgDanhSachNhanVien.Columns.Add("MaNV", "Mã NV");
            dtgDanhSachNhanVien.Columns.Add("TenNV", "Tên nhân viên");
            dtgDanhSachNhanVien.Columns.Add("ChucVu", "Chức vụ");
            dtgDanhSachNhanVien.Columns.Add("Luong", "Lương");
            dtgDanhSachNhanVien.Columns.Add("SDT", "Số điện thoại");
            dtgDanhSachNhanVien.Columns.Add("Email", "Email");
            dtgDanhSachNhanVien.Columns.Add("DiaChi", "Địa chỉ");

            dtgDanhSachNhanVien.Columns["MaNV"].FillWeight = 10;
            dtgDanhSachNhanVien.Columns["MaNV"].MinimumWidth = 90;
            dtgDanhSachNhanVien.Columns["TenNV"].FillWeight = 20;
            dtgDanhSachNhanVien.Columns["TenNV"].MinimumWidth = 130;
            dtgDanhSachNhanVien.Columns["ChucVu"].FillWeight = 12;
            dtgDanhSachNhanVien.Columns["ChucVu"].MinimumWidth = 90;
            dtgDanhSachNhanVien.Columns["Luong"].FillWeight = 13;
            dtgDanhSachNhanVien.Columns["Luong"].MinimumWidth = 100;
            dtgDanhSachNhanVien.Columns["SDT"].FillWeight = 14;
            dtgDanhSachNhanVien.Columns["SDT"].MinimumWidth = 120;
            dtgDanhSachNhanVien.Columns["Email"].FillWeight = 18;
            dtgDanhSachNhanVien.Columns["Email"].MinimumWidth = 130;
            dtgDanhSachNhanVien.Columns["DiaChi"].FillWeight = 20;
            dtgDanhSachNhanVien.Columns["DiaChi"].MinimumWidth = 120;
            dtgDanhSachNhanVien.Columns["Luong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridViewImageColumn suaCol = new DataGridViewImageColumn();
            suaCol.Name = "Sua";
            suaCol.HeaderText = "Sửa";
            suaCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
            suaCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            suaCol.Width = 70;
            suaCol.MinimumWidth = 70;
            dtgDanhSachNhanVien.Columns.Add(suaCol);

            DataGridViewImageColumn xoaCol = new DataGridViewImageColumn();
            xoaCol.Name = "Xoa";
            xoaCol.HeaderText = "Xóa";
            xoaCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
            xoaCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            xoaCol.Width = 70;
            xoaCol.MinimumWidth = 70;
            dtgDanhSachNhanVien.Columns.Add(xoaCol);

            UiHelper.TuDongChinhDoRongCotVaTieuDe(dtgDanhSachNhanVien);
        }

        private void LoadDanhSachNhanVien(string tuKhoa = "")
        {
            try
            {
                if (dtgDanhSachNhanVien.Columns.Count == 0)
                {
                    KhoiTaoBangDuLieu();
                }

                using var db = new HotelManagementContext();

                var query = db.NhanViens
                    .AsNoTracking()
                    .Where(n => n.DaXoa != true);

                if (!string.IsNullOrWhiteSpace(tuKhoa))
                {
                    query = query.Where(n =>
                        n.MaNv.Contains(tuKhoa) ||
                        n.TenNv.Contains(tuKhoa) ||
                        n.Sdt.Contains(tuKhoa) ||
                        n.Cccd.Contains(tuKhoa));
                }

                var danhSach = query
                    .OrderBy(n => n.MaNv)
                    .Select(n => new
                    {
                        n.MaNv,
                        n.TenNv,
                        n.ChucVu,
                        n.Luong,
                        n.Sdt,
                        n.Email,
                        n.DiaChi
                    })
                    .ToList();

                Image iconNhanVien = Properties.Resources.NhanVien;
                Image iconSua = Properties.Resources.edit;
                Image iconXoa = Properties.Resources.delete;
                System.Globalization.CultureInfo viVN = new System.Globalization.CultureInfo("vi-VN");

                dtgDanhSachNhanVien.Rows.Clear();
                foreach (var nv in danhSach)
                {
                    dtgDanhSachNhanVien.Rows.Add(
                        iconNhanVien,
                        nv.MaNv,
                        nv.TenNv,
                        nv.ChucVu,
                        nv.Luong.ToString("C0", viVN),
                        nv.Sdt,
                        nv.Email ?? "",
                        nv.DiaChi,
                        iconSua,
                        iconXoa
                    );
                }

                dtgDanhSachNhanVien.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            LoadDanhSachNhanVien(txtTimKiem.Text.Trim());
        }

        private void dtgDanhSachNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }

            string tenCot = dtgDanhSachNhanVien.Columns[e.ColumnIndex].Name;
            if (tenCot != "Sua" && tenCot != "Xoa")
            {
                return;
            }

            string maNV = dtgDanhSachNhanVien.Rows[e.RowIndex].Cells["MaNV"].Value?.ToString();
            if (string.IsNullOrEmpty(maNV))
            {
                return;
            }

            if (tenCot == "Sua")
            {
                using (FormSuaNhanVien f = new FormSuaNhanVien(maNV))
                {
                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        LoadDanhSachNhanVien(txtTimKiem.Text.Trim());
                    }
                }
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                XoaNhanVien(maNV);
            }
        }

        private void XoaNhanVien(string maNV)
        {
            try
            {
                using var db = new HotelManagementContext();

                var nhanVien = db.NhanViens
                    .Include(n => n.TaiKhoans)
                    .FirstOrDefault(n => n.MaNv == maNV);

                if (nhanVien == null)
                {
                    MessageBox.Show("Không tìm thấy nhân viên cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    nhanVien.DaXoa = true;
                    foreach (var taiKhoan in nhanVien.TaiKhoans)
                    {
                        taiKhoan.DaXoa = true;
                    }

                    int kq = db.SaveChanges();
                    if (kq > 0)
                    {
                        MessageBox.Show("Xóa nhân viên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Xóa nhân viên thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LoadDanhSachNhanVien(txtTimKiem.Text.Trim());
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (dtgDanhSachNhanVien.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Title = "Xuất danh sách nhân viên";
            saveDialog.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
            saveDialog.FileName = "DanhSachNhanVien_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx";

            if (saveDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            try
            {
                string[] tenCot = { "MaNV", "TenNV", "ChucVu", "Luong", "SDT", "Email", "DiaChi" };

                using (XLWorkbook workbook = new XLWorkbook())
                {
                    IXLWorksheet worksheet = workbook.Worksheets.Add("Danh sách nhân viên");

                    for (int j = 0; j < tenCot.Length; j++)
                    {
                        worksheet.Cell(1, j + 1).Value = dtgDanhSachNhanVien.Columns[tenCot[j]].HeaderText;
                    }
                    worksheet.Range(1, 1, 1, tenCot.Length).Style.Font.Bold = true;

                    for (int i = 0; i < dtgDanhSachNhanVien.Rows.Count; i++)
                    {
                        for (int j = 0; j < tenCot.Length; j++)
                        {
                            worksheet.Cell(i + 2, j + 1).Value = dtgDanhSachNhanVien.Rows[i].Cells[tenCot[j]].Value?.ToString() ?? "";
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
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất file Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            using (FormThemNhanVien f = new FormThemNhanVien())
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    LoadDanhSachNhanVien(txtTimKiem.Text.Trim());
                }
            }
        }
    }
}