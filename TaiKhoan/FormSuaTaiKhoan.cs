using HotelManagementApp.Models;
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
    public partial class FormSuaTaiKhoan : Form
    {
        private string tenTK = string.Empty;

        public FormSuaTaiKhoan()
        {
            InitializeComponent();
        }

        public FormSuaTaiKhoan(string tenTK) : this()
        {
            this.tenTK = tenTK;
        }

        private void FormSuaTaiKhoan_Load(object sender, EventArgs e)
        {
            txtTenTK.MaxLength = 50;
            txtMatKhau.MaxLength = 100;
            txtMaNV.ReadOnly = true;
            cbCapDoQuyen.DropDownStyle = ComboBoxStyle.DropDownList;

            if (string.IsNullOrEmpty(tenTK))
            {
                MessageBox.Show("Không xác định được tài khoản cần cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.Cancel;
                Close();
                return;
            }

            LoadThongTinTaiKhoan();
        }

        private void LoadThongTinTaiKhoan()
        {
            try
            {
                using var db = new HotelManagementContext();

                var taiKhoan = db.TaiKhoans
                    .AsNoTracking()
                    .Where(t => t.TenTk == tenTK && t.DaXoa != true)
                    .Select(t => new
                    {
                        t.TenTk,
                        t.Password,
                        t.CapDoQuyen,
                        t.MaNv
                    })
                    .FirstOrDefault();

                if (taiKhoan == null)
                {
                    MessageBox.Show("Không tìm thấy tài khoản cần cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DialogResult = DialogResult.Cancel;
                    Close();
                    return;
                }

                tenTK = taiKhoan.TenTk;
                txtTenTK.Text = taiKhoan.TenTk;
                txtMatKhau.Text = taiKhoan.Password;
                txtMaNV.Text = taiKhoan.MaNv;

                string capDo = taiKhoan.CapDoQuyen.ToString();
                int viTri = cbCapDoQuyen.FindStringExact(capDo);
                if (viTri < 0)
                {
                    viTri = cbCapDoQuyen.Items.Add(capDo);
                }
                cbCapDoQuyen.SelectedIndex = viTri;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load tài khoản: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            string tenTKMoi = txtTenTK.Text.Trim();
            string matKhau = txtMatKhau.Text;

            if (tenTKMoi == "" || matKhau == "" || cbCapDoQuyen.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(cbCapDoQuyen.SelectedItem.ToString(), out int quyen))
            {
                MessageBox.Show("Cấp độ quyền không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using var db = new HotelManagementContext();

                if (db.TaiKhoans.Any(t => t.TenTk == tenTKMoi && t.TenTk != tenTK))
                {
                    MessageBox.Show("Tên tài khoản đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTenTK.Focus();
                    return;
                }

                int kq = db.TaiKhoans
                    .Where(t => t.TenTk == tenTK && t.DaXoa != true)
                    .ExecuteUpdate(s => s
                        .SetProperty(t => t.TenTk, tenTKMoi)
                        .SetProperty(t => t.Password, matKhau)
                        .SetProperty(t => t.CapDoQuyen, quyen));

                if (kq > 0)
                {
                    MessageBox.Show("Cập nhật tài khoản thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật tài khoản: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}