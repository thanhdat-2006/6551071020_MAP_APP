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
    public partial class FormSuaNhanVien : Form
    {
        private string maNV = string.Empty;

        public FormSuaNhanVien()
        {
            InitializeComponent();
        }

        public FormSuaNhanVien(string maNV) : this()
        {
            this.maNV = maNV;
        }

        private void FormSuaNhanVien_Load(object sender, EventArgs e)
        {
            txtHoTenNV.MaxLength = 50;
            txtLuong.MaxLength = 15;
            txtSoDT.MaxLength = 10;
            txtSoCCCD.MaxLength = 12;
            txtDiaChi.MaxLength = 100;
            txtEmail.MaxLength = 100;

            cbChucVu.DropDownStyle = ComboBoxStyle.DropDownList;
            cbGioiTinh.DropDownStyle = ComboBoxStyle.DropDownList;
            dtNgaySinh.Format = DateTimePickerFormat.Short;

            txtLuong.KeyPress += ChiNhapSo;
            txtSoDT.KeyPress += ChiNhapSo;
            txtSoCCCD.KeyPress += ChiNhapSo;

            if (string.IsNullOrEmpty(maNV))
            {
                MessageBox.Show("Không xác định được nhân viên cần cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.Cancel;
                Close();
                return;
            }

            LoadThongTinNhanVien();
        }

        private void LoadThongTinNhanVien()
        {
            try
            {
                using var db = new HotelManagementContext();

                var nhanVien = db.NhanViens
                    .Where(n => n.MaNv == maNV && n.DaXoa != true)
                    .Select(n => new
                    {
                        n.MaNv,
                        n.TenNv,
                        n.ChucVu,
                        n.Luong,
                        n.Sdt,
                        n.Cccd,
                        n.NgaySinh,
                        n.GioiTinh,
                        n.DiaChi,
                        n.Email
                    })
                    .FirstOrDefault();

                if (nhanVien == null)
                {
                    MessageBox.Show("Không tìm thấy nhân viên cần cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DialogResult = DialogResult.Cancel;
                    Close();
                    return;
                }

                txtMaNV.Text = nhanVien.MaNv;
                txtHoTenNV.Text = nhanVien.TenNv;
                ChonGiaTri(cbChucVu, nhanVien.ChucVu);
                txtLuong.Text = nhanVien.Luong.ToString("0", CultureInfo.InvariantCulture);
                txtSoDT.Text = nhanVien.Sdt;
                txtSoCCCD.Text = nhanVien.Cccd;
                dtNgaySinh.Value = nhanVien.NgaySinh.ToDateTime(TimeOnly.MinValue);
                ChonGiaTri(cbGioiTinh, nhanVien.GioiTinh);
                txtDiaChi.Text = nhanVien.DiaChi;
                txtEmail.Text = nhanVien.Email ?? "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }

        private void ChonGiaTri(ComboBox comboBox, string giaTri)
        {
            if (string.IsNullOrEmpty(giaTri))
            {
                return;
            }

            int viTri = comboBox.FindStringExact(giaTri);
            if (viTri < 0)
            {
                viTri = comboBox.Items.Add(giaTri);
            }
            comboBox.SelectedIndex = viTri;
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

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            string tenNV = txtHoTenNV.Text.Trim();
            string chucVu = cbChucVu.SelectedItem?.ToString() ?? "";
            string luong = txtLuong.Text.Trim();
            string sdt = txtSoDT.Text.Trim();
            string cccd = txtSoCCCD.Text.Trim();
            DateTime ngaySinh = dtNgaySinh.Value.Date;
            string gioiTinh = cbGioiTinh.SelectedItem?.ToString() ?? "";
            string diaChi = txtDiaChi.Text.Trim();
            string email = txtEmail.Text.Trim();

            if (tenNV == "" || chucVu == "" || luong == "" || sdt == "" || cccd == "" || gioiTinh == "" || diaChi == "" || email == "")
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

                var nhanVien = db.NhanViens.FirstOrDefault(n => n.MaNv == maNV && n.DaXoa != true);
                if (nhanVien == null)
                {
                    MessageBox.Show("Không tìm thấy nhân viên cần cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DialogResult = DialogResult.Cancel;
                    Close();
                    return;
                }

                if (db.NhanViens.Any(n => n.MaNv != maNV && n.Sdt == sdt))
                {
                    MessageBox.Show("Số điện thoại đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSoDT.Focus();
                    return;
                }

                if (db.NhanViens.Any(n => n.MaNv != maNV && n.Cccd == cccd))
                {
                    MessageBox.Show("Số CCCD đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSoCCCD.Focus();
                    return;
                }

                if (db.NhanViens.Any(n => n.MaNv != maNV && n.Email == email))
                {
                    MessageBox.Show("Email đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return;
                }

                nhanVien.TenNv = tenNV;
                nhanVien.ChucVu = chucVu;
                nhanVien.Luong = luongSo;
                nhanVien.Sdt = sdt;
                nhanVien.Cccd = cccd;
                nhanVien.NgaySinh = DateOnly.FromDateTime(ngaySinh);
                nhanVien.GioiTinh = gioiTinh;
                nhanVien.DiaChi = diaChi;
                nhanVien.Email = email;

                int kq = db.SaveChanges();
                if (kq > 0)
                {
                    MessageBox.Show("Cập nhật nhân viên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Lỗi khi cập nhật nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}