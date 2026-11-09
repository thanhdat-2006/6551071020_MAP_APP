using HotelManagementApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HotelManagementApp.DichVu
{
    public partial class FormThemDichVu : Form
    {
        private static readonly string[] LoaiMacDinh = { "Thức uống", "Đồ ăn", "Dịch vụ" };

        public FormThemDichVu()
        {
            InitializeComponent();

            Text = "Thêm mới dịch vụ";
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            AcceptButton = btnThemMoi;
            CancelButton = btnThoat;

            txtMaDV.MaxLength = 5;
            txtTenDV.MaxLength = 20;
            txtDonGia.MaxLength = 12;
            txtSoLuongConLai.MaxLength = 6;
            txtSoLuongConLai.PlaceholderText = "Để trống = không giới hạn";
            cbLoaiDV.DropDownStyle = ComboBoxStyle.DropDownList;

            Load += FormThemDichVu_Load;
        }

        private void FormThemDichVu_Load(object? sender, EventArgs e)
        {
            var dsLoai = new List<string>(LoaiMacDinh);

            try
            {
                using var db = new HotelManagementContext();

                var loaiTrongCsdl = db.DichVus
                    .AsNoTracking()
                    .Select(d => d.LoaiDv)
                    .Distinct()
                    .ToList();

                foreach (var loai in loaiTrongCsdl)
                {
                    string ten = (loai ?? "").Trim();

                    if (ten.Length > 0 && !dsLoai.Contains(ten, StringComparer.OrdinalIgnoreCase))
                        dsLoai.Add(ten);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải loại dịch vụ: " + ex.Message, "Lỗi",
MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            cbLoaiDV.Items.Clear();
            cbLoaiDV.Items.AddRange(dsLoai.ToArray());
            cbLoaiDV.SelectedIndex = -1;
        }

        private void txtDonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSoLuongConLai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            string maDV = txtMaDV.Text.Trim().ToUpper();
            string tenDV = txtTenDV.Text.Trim();
            string donGiaText = txtDonGia.Text.Trim();
            string soLuongText = txtSoLuongConLai.Text.Trim();
            string loaiDV = cbLoaiDV.SelectedItem?.ToString()?.Trim() ?? "";

            if (maDV.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập mã dịch vụ.", "Thiếu thông tin",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaDV.Focus();
                return;
            }

            if (tenDV.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập tên dịch vụ.", "Thiếu thông tin",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDV.Focus();
                return;
            }

            if (loaiDV.Length == 0)
            {
                MessageBox.Show("Vui lòng chọn loại dịch vụ.", "Thiếu thông tin",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbLoaiDV.Focus();
                return;
            }

            if (loaiDV.Length > 20)
            {
                MessageBox.Show("Tên loại dịch vụ tối đa 20 ký tự.", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbLoaiDV.Focus();
                return;
            }

            if (!decimal.TryParse(donGiaText, out decimal donGia) || donGia <= 0)
            {
                MessageBox.Show("Đơn giá không hợp lệ!", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDonGia.Focus();
                return;
            }

            int soLuongConLai = -1;

            if (soLuongText.Length > 0 && (!int.TryParse(soLuongText, out soLuongConLai) || soLuongConLai < 0))
            {
                MessageBox.Show("Số lượng còn lại không hợp lệ!", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoLuongConLai.Focus();
                return;
            }

            try
            {
                using var db = new HotelManagementContext();

                var daCo = db.DichVus.FirstOrDefault(d => d.MaDv == maDV);

                if (daCo != null)
                {
                    if (daCo.DaXoa != true)
                    {
                        MessageBox.Show("Mã dịch vụ đã tồn tại. Vui lòng nhập mã khác.", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtMaDV.Focus();
                        return;
                    }

                    var traLoi = MessageBox.Show(
                        $"Mã {maDV} từng thuộc dịch vụ \"{daCo.TenDv}\" đã bị xóa.\nBạn có muốn khôi phục mã này với thông tin vừa nhập không?",
                        "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (traLoi != DialogResult.Yes)
                    {
                        txtMaDV.Focus();
                        return;
                    }

                    daCo.TenDv = tenDV;
                    daCo.DonGia = donGia;
                    daCo.SlconLai = soLuongConLai;
                    daCo.LoaiDv = loaiDV;
                    daCo.DaXoa = false;
                }
                else
                {
                    db.DichVus.Add(new Models.DichVu
                    {
                        MaDv = maDV,
                        TenDv = tenDV,
                        DonGia = donGia,
                        SlconLai = soLuongConLai,
                        LoaiDv = loaiDV,
                        DaXoa = false
                    });
                }

                int rows = db.SaveChanges();
                if (rows > 0)
                {
                    MessageBox.Show("Thêm dịch vụ thành công!", "Thành công",
MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại!", "Lỗi", MessageBoxButtons.OK,
MessageBoxIcon.Error);
                }
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show("Lỗi: " + (ex.InnerException?.Message ?? ex.Message),
"Lỗi khi thêm",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi khi thêm",
MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}