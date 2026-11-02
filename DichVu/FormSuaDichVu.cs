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
    public partial class FormSuaDichVu : Form
    {
        private static readonly string[] LoaiMacDinh = { "Thức uống", "Đồ ăn", "Dịch vụ" };

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string? MaDichVu { get; set; }

        public FormSuaDichVu()
        {
            InitializeComponent();

            Text = "Cập nhật thông tin dịch vụ";
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            AcceptButton = btnCapNhat;
            CancelButton = btnThoat;

            txtTenDV.MaxLength = 20;
            txtDonGia.MaxLength = 12;
            txtSoLuongConLai.MaxLength = 6;
            txtSoLuongConLai.PlaceholderText = "Để trống = không giới hạn";
            cbLoaiDV.DropDownStyle = ComboBoxStyle.DropDownList;

            Load += FormSuaDichVu_Load;
        }

        private void FormSuaDichVu_Load(object? sender, EventArgs e)
        {
            string? ma = MaDichVu;

            if (string.IsNullOrEmpty(ma))
            {
                MessageBox.Show("Chưa xác định được dịch vụ cần cập nhật.", "Lỗi",
MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnCapNhat.Enabled = false;
                return;
            }

            Text = "Cập nhật dịch vụ " + ma;

            try
            {
                using var db = new HotelManagementContext();

                var dsLoai = new List<string>(LoaiMacDinh);

                var loaiTrongCsdl = db.DichVus
                    .AsNoTracking()
                    .Select(d => d.LoaiDv)
                    .Distinct()
                    .ToList();

                foreach (var loai in loaiTrongCsdl)
                {
                    string ten = (loai ?? "").Trim();

                    if (ten.Length > 0 && !dsLoai.Contains(ten,
StringComparer.OrdinalIgnoreCase))
                    {
                        dsLoai.Add(ten);
                    }
                }

                cbLoaiDV.Items.Clear();
                cbLoaiDV.Items.AddRange(dsLoai.ToArray());

                var thongTin = db.DichVus
                    .AsNoTracking()
                    .Where(d => d.MaDv == ma && d.DaXoa != true)
                    .Select(d => new { d.TenDv, d.DonGia, d.SlconLai, d.LoaiDv })
                    .FirstOrDefault();

                if (thongTin == null)
                {
                    MessageBox.Show("Không tìm thấy dịch vụ " + ma + ".", "Lỗi",
MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnCapNhat.Enabled = false;
                    return;
                }

                txtTenDV.Text = thongTin.TenDv;
                txtDonGia.Text = thongTin.DonGia.ToString("0");
                txtSoLuongConLai.Text = thongTin.SlconLai == null || thongTin.SlconLai
< 0
                    ? ""
                    : thongTin.SlconLai.Value.ToString();
                cbLoaiDV.SelectedIndex = cbLoaiDV.FindStringExact((thongTin.LoaiDv ??
"").Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải thông tin dịch vụ: " + ex.Message, "Lỗi",
MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnCapNhat.Enabled = false;
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            string? ma = MaDichVu;

            if (string.IsNullOrEmpty(ma))
            {
                MessageBox.Show("Chưa xác định được dịch vụ cần cập nhật.", "Lỗi",
MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string tenDV = txtTenDV.Text.Trim();
            string donGiaText = txtDonGia.Text.Trim();
            string soLuongText = txtSoLuongConLai.Text.Trim();
            string loaiDV = cbLoaiDV.SelectedItem?.ToString()?.Trim() ?? "";

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

            if (!decimal.TryParse(donGiaText, out decimal donGia) || donGia <= 0)
            {
                MessageBox.Show("Đơn giá không hợp lệ!", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDonGia.Focus();
                return;
            }

            int soLuongConLai = -1;

            if (soLuongText.Length > 0 && (!int.TryParse(soLuongText, out
soLuongConLai) || soLuongConLai < 0))
            {
                MessageBox.Show("Số lượng còn lại không hợp lệ!", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoLuongConLai.Focus();
                return;
            }

            try
            {
                using var db = new HotelManagementContext();

                var dichVu = db.DichVus.FirstOrDefault(d => d.MaDv == ma && d.DaXoa !=
true);

                if (dichVu == null)
                {
                    MessageBox.Show("Không tìm thấy dịch vụ cần cập nhật.", "Lỗi",
MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                dichVu.TenDv = tenDV;
                dichVu.DonGia = donGia;
                dichVu.SlconLai = soLuongConLai;
                dichVu.LoaiDv = loaiDV;

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

        private void txtSoLuongConLai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}