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
    public partial class FormThemTaiKhoan : Form
    {
        public FormThemTaiKhoan()
        {
            InitializeComponent();
        }

        private void FormThemTaiKhoan_Load(object sender, EventArgs e)
        {
            txtTenTK.MaxLength = 50;
            txtMatKhau.MaxLength = 100;
            cbMaNV.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCapDoQuyen.DropDownStyle = ComboBoxStyle.DropDownList;

            LoadDanhSachNhanVien();

            int viTriMacDinh = cbCapDoQuyen.FindStringExact("1");
            cbCapDoQuyen.SelectedIndex = viTriMacDinh >= 0 ? viTriMacDinh : 0;
        }

        private void LoadDanhSachNhanVien()
        {
            try
            {
                using var db = new HotelManagementContext();

                var danhSach = db.NhanViens
                    .AsNoTracking()
                    .Where(n => n.DaXoa != true)
                    .OrderBy(n => n.MaNv)
                    .Select(n => new
                    {
                        n.MaNv,
                        HienThi = n.MaNv + " - " + n.TenNv
                    })
                    .ToList();

                if (danhSach.Count == 0)
                {
                    MessageBox.Show("Chưa có nhân viên nào để tạo tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DialogResult = DialogResult.Cancel;
                    Close();
                    return;
                }

                cbMaNV.Items.Clear();
                cbMaNV.DataSource = danhSach;
                cbMaNV.DisplayMember = "HienThi";
                cbMaNV.ValueMember = "MaNv";
                cbMaNV.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load danh sách nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            string tenTK = txtTenTK.Text.Trim();
            string matKhau = txtMatKhau.Text;
            string maNV = cbMaNV.SelectedValue?.ToString() ?? "";

            if (tenTK == "" || matKhau == "" || maNV == "" || cbCapDoQuyen.SelectedItem == null)
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

                var taiKhoanCu = db.TaiKhoans.FirstOrDefault(t => t.TenTk == tenTK);
                if (taiKhoanCu == null)
                {
                    db.TaiKhoans.Add(new Models.TaiKhoan
                    {
                        TenTk = tenTK,
                        Password = matKhau,
                        CapDoQuyen = quyen,
                        MaNv = maNV,
                        DaXoa = false
                    });
                }
                else if (taiKhoanCu.DaXoa == true)
                {
                    taiKhoanCu.Password = matKhau;
                    taiKhoanCu.CapDoQuyen = quyen;
                    taiKhoanCu.MaNv = maNV;
                    taiKhoanCu.DaXoa = false;
                }
                else
                {
                    MessageBox.Show("Tên tài khoản đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTenTK.Focus();
                    return;
                }

                int kq = db.SaveChanges();

                if (kq > 0)
                {
                    MessageBox.Show("Thêm tài khoản thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("Thêm tài khoản thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm tài khoản: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}