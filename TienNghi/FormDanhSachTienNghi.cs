using ClosedXML.Excel;
using HotelManagementApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HotelManagementApp.TienNghi
{
    public partial class FormDanhSachTienNghi : Form
    {
        public FormDanhSachTienNghi()
        {
            InitializeComponent();
        }

        private void FormDanhSachTienNghi_Load(object sender, EventArgs e)
        {
            LoadDanhSachTienNghi();
        }

        private void KhoiTaoBangDuLieu()
        {
            dtgDanhSachTienNghi.AllowUserToAddRows = false;
            dtgDanhSachTienNghi.AllowUserToDeleteRows = false;
            dtgDanhSachTienNghi.AllowUserToResizeRows = false;
            dtgDanhSachTienNghi.ReadOnly = true;
            dtgDanhSachTienNghi.MultiSelect = false;
            dtgDanhSachTienNghi.RowHeadersVisible = false;
            dtgDanhSachTienNghi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgDanhSachTienNghi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgDanhSachTienNghi.RowTemplate.Height = 40;

            DataGridViewImageColumn iconCol = new DataGridViewImageColumn();
            iconCol.Name = "Icon";
            iconCol.HeaderText = "";
            iconCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
            iconCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            iconCol.Width = 50;
            dtgDanhSachTienNghi.Columns.Add(iconCol);

            dtgDanhSachTienNghi.Columns.Add("MaTN", "Mã tiện nghi");
            dtgDanhSachTienNghi.Columns.Add("TenTN", "Tên tiện nghi");
            dtgDanhSachTienNghi.Columns["MaTN"].FillWeight = 30;
            dtgDanhSachTienNghi.Columns["TenTN"].FillWeight = 70;

            DataGridViewImageColumn suaCol = new DataGridViewImageColumn();
            suaCol.Name = "Sua";
            suaCol.HeaderText = "Sửa";
            suaCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
            suaCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            suaCol.Width = 50;
            dtgDanhSachTienNghi.Columns.Add(suaCol);

            DataGridViewImageColumn xoaCol = new DataGridViewImageColumn();
            xoaCol.Name = "Xoa";
            xoaCol.HeaderText = "Xóa";
            xoaCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
            xoaCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            xoaCol.Width = 50;
            dtgDanhSachTienNghi.Columns.Add(xoaCol);
        }

        private void LoadDanhSachTienNghi(string tuKhoa = "")
        {
            try
            {
                if (dtgDanhSachTienNghi.Columns.Count == 0)
                {
                    KhoiTaoBangDuLieu();
                }

                using var db = new HotelManagementContext();

                var query = db.TienNghis
                    .AsNoTracking()
                    .Where(t => t.DaXoa != true);

                if (!string.IsNullOrWhiteSpace(tuKhoa))
                {
                    query = query.Where(t => t.TenTn.Contains(tuKhoa));
                }

                var danhSach = query
                    .OrderBy(t => t.MaTn)
                    .Select(t => new { t.MaTn, t.TenTn })
                    .ToList();

                Image iconTienNghi = Properties.Resources.TienNghi;
                Image iconSua = Properties.Resources.edit;
                Image iconXoa = Properties.Resources.delete;

                dtgDanhSachTienNghi.Rows.Clear();
                foreach (var tn in danhSach)
                {
                    dtgDanhSachTienNghi.Rows.Add(
                        iconTienNghi,
                        tn.MaTn,
                        tn.TenTn,
                        iconSua,
                        iconXoa
                    );
                }

                dtgDanhSachTienNghi.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load tiện nghi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            LoadDanhSachTienNghi(txtTimKiem.Text.Trim());
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (dtgDanhSachTienNghi.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Title = "Xuất danh sách tiện nghi";
            saveDialog.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
            saveDialog.FileName = "DanhSachTienNghi_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx";

            if (saveDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            try
            {
                using (XLWorkbook workbook = new XLWorkbook())
                {
                    IXLWorksheet worksheet = workbook.Worksheets.Add("Danh sách tiện nghi");

                    worksheet.Cell(1, 1).Value = "Mã tiện nghi";
                    worksheet.Cell(1, 2).Value = "Tên tiện nghi";
                    worksheet.Range(1, 1, 1, 2).Style.Font.Bold = true;

                    for (int i = 0; i < dtgDanhSachTienNghi.Rows.Count; i++)
                    {
                        worksheet.Cell(i + 2, 1).Value = dtgDanhSachTienNghi.Rows[i].Cells["MaTN"].Value?.ToString() ?? "";
                        worksheet.Cell(i + 2, 2).Value = dtgDanhSachTienNghi.Rows[i].Cells["TenTN"].Value?.ToString() ?? "";
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
            using (FormThemTienNghi f = new FormThemTienNghi())
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    LoadDanhSachTienNghi(txtTimKiem.Text.Trim());
                }
            }
        }

        private void dtgDanhSachTienNghi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }

            string tenCot = dtgDanhSachTienNghi.Columns[e.ColumnIndex].Name;
            if (tenCot != "Sua" && tenCot != "Xoa")
            {
                return;
            }

            string maTN = dtgDanhSachTienNghi.Rows[e.RowIndex].Cells["MaTN"].Value?.ToString();
            if (string.IsNullOrEmpty(maTN))
            {
                return;
            }

            if (tenCot == "Sua")
            {
                using (FormSuaTienNghi f = new FormSuaTienNghi(maTN))
                {
                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        LoadDanhSachTienNghi(txtTimKiem.Text.Trim());
                    }
                }
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa tiện nghi này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                using var db = new HotelManagementContext();

                var tienNghi = db.TienNghis.FirstOrDefault(t => t.MaTn == maTN);
                if (tienNghi == null)
                {
                    MessageBox.Show("Không tìm thấy tiện nghi cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    tienNghi.DaXoa = true;
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
                MessageBox.Show("Lỗi khi xóa tiện nghi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LoadDanhSachTienNghi(txtTimKiem.Text.Trim());
        }
    }
}