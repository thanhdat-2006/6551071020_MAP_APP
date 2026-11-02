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
    public partial class FormThemChiTietTienNghi : Form
    {
        private string maLPH = string.Empty;

        public FormThemChiTietTienNghi()
        {
            InitializeComponent();
        }

        public FormThemChiTietTienNghi(string maLPH) : this()
        {
            this.maLPH = maLPH;
        }

        private void FormThemChiTietTienNghi_Load(object sender, EventArgs e)
        {
            cbTenTN.DropDownStyle = ComboBoxStyle.DropDownList;
            txtSoLuong.MaxLength = 4;
            txtSoLuong.KeyPress += ChiNhapSo;

            if (string.IsNullOrEmpty(maLPH))
            {
                MessageBox.Show("Không xác định được loại phòng!", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.Cancel;
                Close();
                return;
            }

            LoadTienNghiChuaThem();
        }

        private void ChiNhapSo(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void LoadTienNghiChuaThem()
        {
            try
            {
                using var db = new HotelManagementContext();

                var daCo = db.Cttns
                    .AsNoTracking()
                    .Where(c => c.MaLph == maLPH && c.DaXoa != true)
                    .Select(c => c.MaTn);

                var danhSach = db.TienNghis
                    .AsNoTracking()
                    .Where(t => t.DaXoa != true && !daCo.Contains(t.MaTn))
                    .OrderBy(t => t.TenTn)
                    .Select(t => new
                    {
                        t.MaTn,
                        t.TenTn
                    })
                    .ToList();

                if (danhSach.Count == 0)
                {
                    MessageBox.Show("Loại phòng này đã có đầy đủ các tiện nghi, không còn tiện nghi nào để thêm!", "Thông báo", MessageBoxButtons.OK,
MessageBoxIcon.Information);
                    DialogResult = DialogResult.Cancel;
                    Close();
                    return;
                }

                cbTenTN.DataSource = danhSach;
                cbTenTN.DisplayMember = "TenTn";
                cbTenTN.ValueMember = "MaTn";
                cbTenTN.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load danh sách tiện nghi: " + ex.Message,
"Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSoLuong.Text) || cbTenTN.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtSoLuong.Text.Trim(), out int soLuong) || soLuong < 0)
            {
                MessageBox.Show("Số lượng không hợp lệ!", "Lỗi", MessageBoxButtons.OK,
MessageBoxIcon.Error);
                txtSoLuong.Focus();
                return;
            }

            string maTN = cbTenTN.SelectedValue?.ToString() ?? "";
            if (maTN == "")
            {
                MessageBox.Show("Vui lòng chọn tiện nghi!", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using var db = new HotelManagementContext();

                var chiTiet = db.Cttns.FirstOrDefault(c => c.MaLph == maLPH && c.MaTn == maTN);

                if (chiTiet == null)
                {
                    db.Cttns.Add(new Cttn
                    {
                        MaLph = maLPH,
                        MaTn = maTN,
                        Sl = soLuong,
                        DaXoa = false
                    });
                }
                else if (chiTiet.DaXoa == true)
                {
                    chiTiet.Sl = soLuong;
                    chiTiet.DaXoa = false;
                }
                else
                {
                    MessageBox.Show("Tiện nghi này đã có trong loại phòng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LoadTienNghiChuaThem();
                    return;
                }

                int kq = db.SaveChanges();

                if (kq > 0)
                {
                    MessageBox.Show("Thêm thành công!", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại!", "Lỗi", MessageBoxButtons.OK,
MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm tiện nghi: " + ex.Message, "Lỗi",
MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}