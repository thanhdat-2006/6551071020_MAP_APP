using HotelManagementApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HotelManagementApp.ChiTietTienNghi
{
    public partial class FormDanhSachChiTietTienNghi : Form
    {
        private string maLPH = string.Empty;
        private string tenLoaiPhong = string.Empty;

        public FormDanhSachChiTietTienNghi()
        {
            InitializeComponent();
        }

        public FormDanhSachChiTietTienNghi(string maLPH, string tenLoaiPhong) : this()
        {
            this.maLPH = maLPH;
            this.tenLoaiPhong = tenLoaiPhong;
        }

        private void FormDanhSachChiTietTienNghi_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(maLPH))
            {
                MessageBox.Show("Không xác định được loại phòng!", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
                return;
            }

            lblTenLoaiPhong.Text = $"Loại phòng: {tenLoaiPhong}";
            LoadChiTietTienNghi();
        }

        private void KhoiTaoBangDuLieu()
        {
            dtgDanhSachTienNghiTheoLoaiPhong.AllowUserToAddRows = false;
            dtgDanhSachTienNghiTheoLoaiPhong.AllowUserToDeleteRows = false;
            dtgDanhSachTienNghiTheoLoaiPhong.AllowUserToResizeRows = false;
            dtgDanhSachTienNghiTheoLoaiPhong.ReadOnly = true;
            dtgDanhSachTienNghiTheoLoaiPhong.MultiSelect = false;
            dtgDanhSachTienNghiTheoLoaiPhong.RowHeadersVisible = false;
            dtgDanhSachTienNghiTheoLoaiPhong.SelectionMode =
DataGridViewSelectionMode.FullRowSelect;
            dtgDanhSachTienNghiTheoLoaiPhong.AutoSizeColumnsMode =
DataGridViewAutoSizeColumnsMode.Fill;
            dtgDanhSachTienNghiTheoLoaiPhong.RowTemplate.Height = 36;

            dtgDanhSachTienNghiTheoLoaiPhong.Columns.Add("MaTN", "Mã tiện nghi");
            dtgDanhSachTienNghiTheoLoaiPhong.Columns["MaTN"].Visible = false;

            dtgDanhSachTienNghiTheoLoaiPhong.Columns.Add("TenTN", "Tên tiện nghi");
            dtgDanhSachTienNghiTheoLoaiPhong.Columns.Add("SL", "Số lượng");
            dtgDanhSachTienNghiTheoLoaiPhong.Columns.Add("GhiChu", "Ghi chú");

            dtgDanhSachTienNghiTheoLoaiPhong.Columns["TenTN"].FillWeight = 45;
            dtgDanhSachTienNghiTheoLoaiPhong.Columns["SL"].FillWeight = 15;
            dtgDanhSachTienNghiTheoLoaiPhong.Columns["GhiChu"].FillWeight = 40;
            dtgDanhSachTienNghiTheoLoaiPhong.Columns["SL"].DefaultCellStyle.Alignment =
DataGridViewContentAlignment.MiddleCenter;

            DataGridViewImageColumn suaCol = new DataGridViewImageColumn();
            suaCol.Name = "Sua";
            suaCol.HeaderText = "Sửa";
            suaCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
            suaCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            suaCol.Width = 50;
            dtgDanhSachTienNghiTheoLoaiPhong.Columns.Add(suaCol);

            DataGridViewImageColumn xoaCol = new DataGridViewImageColumn();
            xoaCol.Name = "Xoa";
            xoaCol.HeaderText = "Xóa";
            xoaCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
            xoaCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            xoaCol.Width = 50;
            dtgDanhSachTienNghiTheoLoaiPhong.Columns.Add(xoaCol);
        }

        private void LoadChiTietTienNghi()
        {
            try
            {
                if (dtgDanhSachTienNghiTheoLoaiPhong.Columns.Count == 0)
                {
                    KhoiTaoBangDuLieu();
                }

                using var db = new HotelManagementContext();

                var danhSach = db.Cttns
                    .AsNoTracking()
                    .Where(c => c.MaLph == maLPH && c.DaXoa != true &&
c.MaTnNavigation.DaXoa != true)
                    .OrderBy(c => c.MaTn)
                    .Select(c => new
                    {
                        c.MaTn,
                        c.MaTnNavigation.TenTn,
                        c.Sl
                    })
                    .ToList();

                Image iconSua = Properties.Resources.edit;
                Image iconXoa = Properties.Resources.delete;

                dtgDanhSachTienNghiTheoLoaiPhong.Rows.Clear();
                foreach (var tn in danhSach)
                {
                    int soLuong = tn.Sl ?? 0;
                    bool dungDuoc = soLuong >= 1;

                    int viTri = dtgDanhSachTienNghiTheoLoaiPhong.Rows.Add(
                        tn.MaTn,
                        tn.TenTn,
                        soLuong,
                        dungDuoc ? "Có thể sử dụng tốt" : "Đang không sử dụng được",
                        iconSua,
                        iconXoa
                    );

                    if (!dungDuoc)
                    {
                        dtgDanhSachTienNghiTheoLoaiPhong.Rows[viTri].Cells["GhiChu"].Style.ForeColor =
Color.Red;
                    }
                }

                dtgDanhSachTienNghiTheoLoaiPhong.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load tiện nghi của loại phòng: " + ex.Message,
"Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtgDanhSachTienNghiTheoLoaiPhong_CellClick(object sender,
DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }

            string tenCot =
dtgDanhSachTienNghiTheoLoaiPhong.Columns[e.ColumnIndex].Name;
            if (tenCot != "Sua" && tenCot != "Xoa")
            {
                return;
            }

            DataGridViewRow dong = dtgDanhSachTienNghiTheoLoaiPhong.Rows[e.RowIndex];
            string maTN = dong.Cells["MaTN"].Value?.ToString();
            string tenTN = dong.Cells["TenTN"].Value?.ToString() ?? "";
            if (string.IsNullOrEmpty(maTN))
            {
                return;
            }

            if (tenCot == "Sua")
            {
                int.TryParse(dong.Cells["SL"].Value?.ToString(), out int sl);

                using (FormSuaChiTietTienNghi f = new FormSuaChiTietTienNghi(maLPH,
maTN, tenTN, sl))
                {
                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        LoadChiTietTienNghi();
                    }
                }
                return;
            }

            if (MessageBox.Show($"Bạn có chắc muốn xóa tiện nghi '{tenTN}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                using var db = new HotelManagementContext();

                var chiTiet = db.Cttns.FirstOrDefault(c => c.MaLph == maLPH && c.MaTn
== maTN);
                if (chiTiet == null)
                {
                    MessageBox.Show("Không tìm thấy tiện nghi cần xóa!", "Lỗi",
MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    db.Cttns.Remove(chiTiet);
                    int kq = db.SaveChanges();

                    if (kq > 0)
                    {
                        MessageBox.Show("Xóa thành công!", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại!", "Lỗi", MessageBoxButtons.OK,
MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa tiện nghi: " + ex.Message, "Lỗi",
MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LoadChiTietTienNghi();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            using (FormThemChiTietTienNghi f = new FormThemChiTietTienNghi(maLPH))
            {
                f.ShowDialog();
            }

            LoadChiTietTienNghi();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}