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

namespace HotelManagementApp.KhachHang
{
    public partial class FormDanhSachKhachHang : Form
    {
        public FormDanhSachKhachHang()
        {
            InitializeComponent();
        }

        private void FormDanhSachKhachHang_Load(object sender, EventArgs e)
        {
            LoadDanhSachKhachHang();
        }

        private void KhoiTaoBangDuLieu()
        {
            UiHelper.DinhDangLuoi(dtgDanhSachKhachHang);
            dtgDanhSachKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            DataGridViewImageColumn iconCol = new DataGridViewImageColumn();
            iconCol.Name = "Icon";
            iconCol.HeaderText = "";
            iconCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
            iconCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            iconCol.Width = 40;
            dtgDanhSachKhachHang.Columns.Add(iconCol);

            dtgDanhSachKhachHang.Columns.Add("MaKH", "Mã KH");
            dtgDanhSachKhachHang.Columns.Add("TenKH", "Tên khách hàng");
            dtgDanhSachKhachHang.Columns.Add("SDT", "SĐT");
            dtgDanhSachKhachHang.Columns.Add("CCCD", "CCCD/Passport");
            dtgDanhSachKhachHang.Columns.Add("QuocTich", "Quốc tịch");
            dtgDanhSachKhachHang.Columns.Add("GioiTinh", "Giới tính");

            dtgDanhSachKhachHang.Columns["MaKH"].FillWeight = 10;
            dtgDanhSachKhachHang.Columns["TenKH"].FillWeight = 25;
            dtgDanhSachKhachHang.Columns["SDT"].FillWeight = 15;
            dtgDanhSachKhachHang.Columns["CCCD"].FillWeight = 20;
            dtgDanhSachKhachHang.Columns["QuocTich"].FillWeight = 15;
            dtgDanhSachKhachHang.Columns["GioiTinh"].FillWeight = 10;

            DataGridViewImageColumn suaCol = new DataGridViewImageColumn();
            suaCol.Name = "Sua";
            suaCol.HeaderText = "Sửa";
            suaCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
            suaCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            suaCol.Width = 70;
            suaCol.MinimumWidth = 70;
            dtgDanhSachKhachHang.Columns.Add(suaCol);

            DataGridViewImageColumn xoaCol = new DataGridViewImageColumn();
            xoaCol.Name = "Xoa";
            xoaCol.HeaderText = "Xóa";
            xoaCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
            xoaCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            xoaCol.Width = 70;
            xoaCol.MinimumWidth = 70;
            dtgDanhSachKhachHang.Columns.Add(xoaCol);

            UiHelper.TuDongChinhDoRongCotVaTieuDe(dtgDanhSachKhachHang);
        }

        private void LoadDanhSachKhachHang(string tuKhoa = "")
        {
            try
            {
                if (dtgDanhSachKhachHang.Columns.Count == 0)
                {
                    KhoiTaoBangDuLieu();
                }

                using var db = new HotelManagementContext();

                var query = db.KhachHangs
                    .AsNoTracking()
                    .Where(k => k.DaXoa != true);

                if (!string.IsNullOrWhiteSpace(tuKhoa))
                {
                    query = query.Where(k =>
                        k.MaKh.Contains(tuKhoa) ||
                        k.TenKh.Contains(tuKhoa) ||
                        k.Sdt.Contains(tuKhoa) ||
                        k.CccdPassport.Contains(tuKhoa));
                }

                var danhSach = query
                    .OrderBy(k => k.MaKh)
                    .Select(k => new
                    {
                        k.MaKh,
                        k.TenKh,
                        k.Sdt,
                        k.CccdPassport,
                        k.QuocTich,
                        k.GioiTinh
                    })
                    .ToList();

                Image iconKhachHang = Properties.Resources.KhachHang;
                Image iconSua = Properties.Resources.edit;
                Image iconXoa = Properties.Resources.delete;

                dtgDanhSachKhachHang.Rows.Clear();
                foreach (var kh in danhSach)
                {
                    dtgDanhSachKhachHang.Rows.Add(
                        iconKhachHang,
                        kh.MaKh,
                        kh.TenKh,
                        kh.Sdt,
                        kh.CccdPassport,
                        kh.QuocTich,
                        kh.GioiTinh,
                        iconSua,
                        iconXoa
                    );
                }

                dtgDanhSachKhachHang.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            LoadDanhSachKhachHang(txtTimKiem.Text.Trim());
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (dtgDanhSachKhachHang.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Title = "Xuất danh sách khách hàng";
            saveDialog.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
            saveDialog.FileName = "DanhSachKhachHang_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx";

            if (saveDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            try
            {
                string[] tenCot = { "MaKH", "TenKH", "SDT", "CCCD", "QuocTich", "GioiTinh" };

                using (XLWorkbook workbook = new XLWorkbook())
                {
                    IXLWorksheet worksheet = workbook.Worksheets.Add("Danh sách khách hàng");

                    for (int j = 0; j < tenCot.Length; j++)
                    {
                        worksheet.Cell(1, j + 1).Value = dtgDanhSachKhachHang.Columns[tenCot[j]].HeaderText;
                    }
                    worksheet.Range(1, 1, 1, tenCot.Length).Style.Font.Bold = true;

                    for (int i = 0; i < dtgDanhSachKhachHang.Rows.Count; i++)
                    {
                        for (int j = 0; j < tenCot.Length; j++)
                        {
                            worksheet.Cell(i + 2, j + 1).Value = dtgDanhSachKhachHang.Rows[i].Cells[tenCot[j]].Value?.ToString() ?? "";
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
            using (FormThemKhachHang f = new FormThemKhachHang())
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    LoadDanhSachKhachHang(txtTimKiem.Text.Trim());
                }
            }
        }

        private void dtgDanhSachKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }

            string tenCot = dtgDanhSachKhachHang.Columns[e.ColumnIndex].Name;
            if (tenCot != "Sua" && tenCot != "Xoa")
            {
                return;
            }

            string maKH = dtgDanhSachKhachHang.Rows[e.RowIndex].Cells["MaKH"].Value?.ToString();
            if (string.IsNullOrEmpty(maKH))
            {
                return;
            }

            if (tenCot == "Sua")
            {
                using (FormSuaKhachHang f = new FormSuaKhachHang(maKH))
                {
                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        LoadDanhSachKhachHang(txtTimKiem.Text.Trim());
                    }
                }
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                using var db = new HotelManagementContext();

                var khachHang = db.KhachHangs.FirstOrDefault(k => k.MaKh == maKH);
                if (khachHang == null)
                {
                    MessageBox.Show("Không tìm thấy khách hàng cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    khachHang.DaXoa = true;
                    int kq = db.SaveChanges();

                    if (kq > 0)
                    {
                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LoadDanhSachKhachHang(txtTimKiem.Text.Trim());
        }
    }
}