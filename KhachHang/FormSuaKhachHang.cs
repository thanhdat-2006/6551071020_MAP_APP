using DocumentFormat.OpenXml.Office2010.Drawing;
using HotelManagementApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HotelManagementApp.KhachHang
{
    public partial class FormSuaKhachHang : Form
    {
        private string maKH = string.Empty;

        public FormSuaKhachHang()
        {
            InitializeComponent();
        }

        public FormSuaKhachHang(string maKH) : this()
        {
            this.maKH = maKH;
        }

        private void FormSuaKhachHang_Load(object sender, EventArgs e)
        {
            txtHoVaTen.MaxLength = 50;
            txtCCCD.MaxLength = 12;
            txtSoDienThoai.MaxLength = 10;
            txtQuocTich.MaxLength = 30;
            cbGioiTinh.DropDownStyle = ComboBoxStyle.DropDownList;
            txtSoDienThoai.KeyPress += OnlyAllowDigits;

            if (string.IsNullOrEmpty(maKH))
            {
                MessageBox.Show("Không xác định được khách hàng cần cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.Cancel;
                Close();
                return;
            }

            try
            {
                using var db = new HotelManagementContext();

                var khachHang = db.KhachHangs
                    .Where(k => k.MaKh == maKH && k.DaXoa != true)
                    .Select(k => new
                    {
                        k.MaKh,
                        k.TenKh,
                        k.Sdt,
                        k.CccdPassport,
                        k.QuocTich,
                        k.GioiTinh
                    })
                    .FirstOrDefault();

                if (khachHang == null)
                {
                    MessageBox.Show("Không tìm thấy khách hàng cần cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DialogResult = DialogResult.Cancel;
                    Close();
                    return;
                }

                txtMaKH.Text = khachHang.MaKh;
                txtHoVaTen.Text = khachHang.TenKh;
                txtSoDienThoai.Text = khachHang.Sdt ?? "";
                txtCCCD.Text = khachHang.CccdPassport;
                txtQuocTich.Text = khachHang.QuocTich;

                int viTri = cbGioiTinh.FindStringExact(khachHang.GioiTinh);
                cbGioiTinh.SelectedIndex = viTri >= 0 ? viTri : 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            string tenKH = txtHoVaTen.Text.Trim();
            string sdt = txtSoDienThoai.Text.Trim();
            string cccd = txtCCCD.Text.Trim();
            string quocTich = txtQuocTich.Text.Trim();
            string gioiTinh = cbGioiTinh.Text.Trim();

            if (string.IsNullOrEmpty(tenKH))
            {
                MessageBox.Show("Vui lòng nhập họ và tên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoVaTen.Focus();
                return;
            }

            if (string.IsNullOrEmpty(cccd))
            {
                MessageBox.Show("Vui lòng nhập số CCCD/Passport!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCCCD.Focus();
                return;
            }

            if (string.IsNullOrEmpty(quocTich))
            {
                MessageBox.Show("Vui lòng nhập quốc tịch!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQuocTich.Focus();
                return;
            }

            if (string.IsNullOrEmpty(gioiTinh))
            {
                MessageBox.Show("Vui lòng chọn giới tính!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbGioiTinh.Focus();
                return;
            }

            try
            {
                using var db = new HotelManagementContext();

                var khachHang = db.KhachHangs.FirstOrDefault(k => k.MaKh == maKH && k.DaXoa != true);
                if (khachHang == null)
                {
                    MessageBox.Show("Không tìm thấy khách hàng cần cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DialogResult = DialogResult.Cancel;
                    Close();
                    return;
                }

                if (db.KhachHangs.Any(k => k.MaKh != maKH && k.CccdPassport == cccd))
                {
                    MessageBox.Show("Số CCCD/Passport đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCCCD.Focus();
                    return;
                }

                khachHang.TenKh = tenKH;
                khachHang.Sdt = string.IsNullOrEmpty(sdt) ? null : sdt;
                khachHang.CccdPassport = cccd;
                khachHang.QuocTich = quocTich;
                khachHang.GioiTinh = gioiTinh;

                int kq = db.SaveChanges();

                if (kq > 0)
                {
                    MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("Không có thay đổi nào để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void OnlyAllowDigits(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}