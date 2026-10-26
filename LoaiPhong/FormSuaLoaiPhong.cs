using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HotelManagementApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementApp.LoaiPhong
{
    public partial class FormSuaLoaiPhong : Form
    {
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string? MaLoaiPhong { get; set; }

        public FormSuaLoaiPhong()
        {
            InitializeComponent();

            Text = "Cập nhật thông tin loại phòng";
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            AcceptButton = btnCapNhat;
            CancelButton = btnThoat;

            txtTenLP.MaxLength = 20;
            txtSoGiuong.MaxLength = 2;
            txtSoNguoiToiDa.MaxLength = 2;

            txtSoGiuong.KeyPress += ChiChonNhapSo;
            txtSoNguoiToiDa.KeyPress += ChiChonNhapSo;

            Load += FormSuaLoaiPhong_Load;
        }

        private void FormSuaLoaiPhong_Load(object sender, EventArgs e)
        {
            string? ma = MaLoaiPhong;

            if (string.IsNullOrEmpty(ma))
            {
                MessageBox.Show("Chưa xác định được loại phòng cấn cập nhật.", "Lỗi",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnCapNhat.Enabled = false;
                return;
            }

            Text = "Cập nhật loại phòng " + ma;

            try
            {
                using var db = new HotelManagementContext();

                var thongTin = db.LoaiPhongs
                    .AsNoTracking()
                    .Where(l => l.MaLph == ma)
                    .Select(l => new {
                        l.TenLph,
                        l.SoGiuong,
                        l.SoNguoiToiDa,
                        l.GiaNgay,
                        l.GiaGio
                    })
                    .FirstOrDefault();

                if (thongTin == null)
                {
                    MessageBox.Show("Không tìm thấy loại phòng " + ma + ".", "Lỗi",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnCapNhat.Enabled = false;
                    return;
                }

                txtTenLP.Text = thongTin.TenLph;
                txtSoGiuong.Text = thongTin.SoGiuong.ToString();
                txtSoNguoiToiDa.Text = thongTin.SoNguoiToiDa.ToString();
                txtGiaNgay.Text = thongTin.GiaNgay.ToString("0.##");
                txtGiaGio.Text = thongTin.GiaGio.ToString("0.##");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải thông tin loại phòng: " + ex.Message, "Lỗi",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnCapNhat.Enabled = false;
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            string? ma = MaLoaiPhong;

            if (string.IsNullOrEmpty(ma))
            {
                MessageBox.Show("Chưa xác định được loại phòng cấn cập nhật.", "Lỗi",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string tenLPH = txtTenLP.Text.Trim();

            if (tenLPH.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập tên loại phòng.", "Thông báo",
    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenLP.Focus();
                return;
            }

            if (!int.TryParse(txtSoGiuong.Text.Trim(), out int soGiuong) || soGiuong <=
    0)
            {
                MessageBox.Show("Số giường không hợp lệ!", "Thông báo",
    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoGiuong.Focus();
                return;
            }

            if (!int.TryParse(txtSoNguoiToiDa.Text.Trim(), out int soNguoiToiDa) ||
    soNguoiToiDa <= 0)
            {
                MessageBox.Show("Số người tối đa không hợp lệ!", "Thông báo",
    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoNguoiToiDa.Focus();
                return;
            }

            if (!decimal.TryParse(txtGiaNgay.Text.Trim(), out decimal giaNgay) ||
    giaNgay <= 0)
            {
                MessageBox.Show("Giá ngày không hợp lệ!", "Thông báo",
    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGiaNgay.Focus();
                return;
            }

            if (!decimal.TryParse(txtGiaGio.Text.Trim(), out decimal giaGio) || giaGio
    <= 0)
            {
                MessageBox.Show("Giá giờ không hợp lệ!", "Thông báo",
    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGiaGio.Focus();
                return;
            }
            try
            {
                using var db = new HotelManagementContext();

                var loiPhong = db.LoaiPhongs.FirstOrDefault(l => l.MaLph == ma);

                if (loiPhong == null)
                {
                    MessageBox.Show("Không tìm thấy loại phòng cấn cập nhật.", "Lỗi",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                loiPhong.TenLph = tenLPH;
                loiPhong.SoGiuong = soGiuong;
                loiPhong.SoNguoiToiDa = soNguoiToiDa;
                loiPhong.GiaNgay = giaNgay;
                loiPhong.GiaGio = giaGio;

                int rows = db.SaveChanges();
                if (rows > 0)
                {
                    MessageBox.Show("Cập nhật thành công!", "Thông báo",
    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thông tin không thay đổi nên không có gì để cập nhật.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + (ex.InnerException?.Message ??
    ex.Message), "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message, "Lỗi",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ChiChonNhapSo(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
    }
}