using DocumentFormat.OpenXml.Office2010.Drawing;
using HotelManagementApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HotelManagementApp.TienNghi
{
    public partial class FormThemTienNghi : Form
    {
        public FormThemTienNghi()
        {
            InitializeComponent();
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            string maTN = txtMaTN.Text.Trim().ToUpper();
            string tenTN = txtTenTN.Text.Trim();

            if (string.IsNullOrEmpty(maTN))
            {
                MessageBox.Show("Vui lòng nhập mã tiện nghi!", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaTN.Focus();
                return;
            }

            if (maTN.Length > 5)
            {
                MessageBox.Show("Mã tiện nghi tối đa 5 ký tự!", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaTN.Focus();
                return;
            }

            if (string.IsNullOrEmpty(tenTN))
            {
                MessageBox.Show("Vui lòng nhập tên tiện nghi!", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenTN.Focus();
                return;
            }

            if (tenTN.Length > 50)
            {
                MessageBox.Show("Tên tiện nghi tối đa 50 ký tự!", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenTN.Focus();
                return;
            }

            try
            {
                using var db = new HotelManagementContext();

                if (db.TienNghis.Any(t => t.MaTn == maTN))
                {
                    MessageBox.Show("Mã tiện nghi đã tồn tại!", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaTN.Focus();
                    return;
                }

                if (db.TienNghis.Any(t => t.DaXoa != true && t.TenTn == tenTN))
                {
                    MessageBox.Show("Tên tiện nghi đã tồn tại!", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenTN.Focus();
                    return;
                }

                var tienNghi = new Models.TienNghi
                {
                    MaTn = maTN,
                    TenTn = tenTN,
                    DaXoa = false
                };

                db.TienNghis.Add(tienNghi);
                int kq = db.SaveChanges();

                if (kq > 0)
                {
                    MessageBox.Show("Thêm tiện nghi thành công!", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("Thêm tiện nghi thất bại!", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
