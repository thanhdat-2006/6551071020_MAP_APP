using HotelManagementApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace HotelManagementApp.NhanVien
{
    public partial class FormThemNhanVien : Form
    {
        public FormThemNhanVien()
        {
            InitializeComponent();
        }

        private void FormThemNhanVien_Load(object sender, EventArgs e)
        {
            txtMaNV.MaxLength = 5;
            txtHoTenNV.MaxLength = 50;
            txtLuong.MaxLength = 15;
            txtSoDT.MaxLength = 10;
            txtSoCCCD.MaxLength = 12;
            txtDiaChi.MaxLength = 100;
            txtEmail.MaxLength = 100;

            cbChucVu.DropDownStyle = ComboBoxStyle.DropDownList;
            cbGioiTinh.DropDownStyle = ComboBoxStyle.DropDownList;
            cbGioiTinh.SelectedIndex = 0;

            dtNgaySinh.Format = DateTimePickerFormat.Short;
            dtNgaySinh.Value = DateTime.Today.AddYears(-18);

            txtLuong.KeyPress += ChiNhapSo;
            txtSoDT.KeyPress += ChiNhapSo;
            txtSoCCCD.KeyPress += ChiNhapSo;
        }

        private void ChiNhapSo(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        private bool ToanChuSo(string chuoi)
        {
            foreach (char c in chuoi)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNV.Text.Trim().ToUpper();
            string tenNV = txtHoTenNV.Text.Trim();
            string chucVu = cbChucVu.SelectedItem?.ToString() ?? "";
            string luong = txtLuong.Text.Trim();
            string sdt = txtSoDT.Text.Trim();
            string cccd = txtSoCCCD.Text.Trim();
            DateTime ngaySinh = dtNgaySinh.Value.Date;
            string gioiTinh = cbGioiTinh.SelectedItem?.ToString() ?? "";
            string diaChi = txtDiaChi.Text.Trim();
            string email = txtEmail.Text.Trim();

            if (maNV == "" || tenNV == "" || chucVu == "" || luong == "" || sdt == "" || cccd == "" || diaChi == "" || email == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin bắt buộc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(luong, NumberStyles.None, CultureInfo.InvariantCulture, out decimal luongSo) || luongSo <= 0)
            {
                MessageBox.Show("Lương phải là số lớn hơn 0.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLuong.Focus();
                return;
            }

            if (!ToanChuSo(sdt) || sdt.Length < 9)
            {
                MessageBox.Show("Số điện thoại phải gồm 9 đến 10 chữ số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoDT.Focus();
                return;
            }

            if (!ToanChuSo(cccd) || cccd.Length != 12)
            {
                MessageBox.Show("Số CCCD phải gồm đúng 12 chữ số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoCCCD.Focus();
                return;
            }

            if (!IsValidEmail(email))
            {
                MessageBox.Show("Email không đúng định dạng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            if (ngaySinh > DateTime.Today.AddYears(-18))
            {
                MessageBox.Show("Nhân viên phải đủ 18 tuổi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtNgaySinh.Focus();
                return;
            }

            try
            {
                using var db = new HotelManagementContext();

                if (db.NhanViens.Any(n => n.MaNv == maNV))
                {
                    MessageBox.Show("Mã nhân viên đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaNV.Focus();
                    return;
                }

                if (db.NhanViens.Any(n => n.Sdt == sdt))
                {
                    MessageBox.Show("Số điện thoại đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSoDT.Focus();
                    return;
                }

                if (db.NhanViens.Any(n => n.Cccd == cccd))
                {
                    MessageBox.Show("Số CCCD đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSoCCCD.Focus();
                    return;
                }

                if (db.NhanViens.Any(n => n.Email == email))
                {
                    MessageBox.Show("Email đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return;
                }

                var nhanVien = new Models.NhanVien
                {
                    MaNv = maNV,
                    TenNv = tenNV,
                    ChucVu = chucVu,
                    Luong = luongSo,
                    Sdt = sdt,
                    Cccd = cccd,
                    NgaySinh = DateOnly.FromDateTime(ngaySinh),
                    GioiTinh = gioiTinh,
                    DiaChi = diaChi,
                    Email = email,
                    DaXoa = false
                };

                db.NhanViens.Add(nhanVien);
                int kq = db.SaveChanges();

                if (kq > 0)
                {
                    MessageBox.Show("Thêm nhân viên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("Thêm nhân viên thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}