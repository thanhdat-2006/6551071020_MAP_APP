using HotelManagementApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HotelManagementApp.PhieuThue
{
    public partial class FormThemDichVuPhongDaDung : Form
    {
        private sealed class MucDichVu
        {
            public string MaDV { get; set; } = "";
            public string TenDV { get; set; } = "";
            public decimal DonGia { get; set; }
            public int? SLConLai { get; set; }
        }

        private List<MucDichVu> _danhSachDichVu = new List<MucDichVu>();
        private bool _dangNapDuLieu;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string? MaChiTietDatPhong { get; set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string? MaPhong { get; set; }

        public FormThemDichVuPhongDaDung()
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            AcceptButton = btnThemDV;
            CancelButton = btnThoat;

            cbTenDV.DropDownStyle = ComboBoxStyle.DropDownList;
            txtSoLuong.MaxLength = 6;
            txtSoLuong.KeyPress += txtSoLuong_KeyPress;
        }

        private void FormThemDichVuPhongDaDung_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(MaChiTietDatPhong) || string.IsNullOrEmpty(MaPhong))
            {
                MessageBox.Show("Chưa xác định được chi tiết phiếu thuê cần thêm dịch vụ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnThemDV.Enabled = false;
                return;
            }

            lbSoCTPhieu.Text = "Mã CTDP: " + MaChiTietDatPhong;
            lbSoPhong.Text = "Số phòng: " + MaPhong;
            lbThanhTien.Text = "Thành tiền: 0";

            try
            {
                using var db = new HotelManagementContext();

                _danhSachDichVu = db.DichVus
                    .AsNoTracking()
                    .Where(d => d.DaXoa != true)
                    .OrderBy(d => d.TenDv)
                    .Select(d => new MucDichVu
                    {
                        MaDV = d.MaDv,
                        TenDV = d.TenDv,
                        DonGia = d.DonGia,
                        SLConLai = d.SlconLai
                    })
                    .ToList();

                _dangNapDuLieu = true;
                cbTenDV.DataSource = null;
                cbTenDV.DisplayMember = "TenDV";
                cbTenDV.ValueMember = "MaDV";
                cbTenDV.DataSource = _danhSachDichVu;
                cbTenDV.SelectedIndex = -1;
                _dangNapDuLieu = false;

                txtMaDV.Text = "";
                txtDonGia.Text = "";
            }
            catch (Exception ex)
            {
                _dangNapDuLieu = false;
                MessageBox.Show("Lỗi tải danh sách dịch vụ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnThemDV.Enabled = false;
            }
        }

        private MucDichVu? LayDichVuDangChon()
        {
            return cbTenDV.SelectedItem as MucDichVu;
        }

        private void cbTenDV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_dangNapDuLieu)
                return;

            var dv = LayDichVuDangChon();

            if (dv == null)
            {
                txtMaDV.Text = "";
                txtDonGia.Text = "";
            }
            else
            {
                txtMaDV.Text = dv.MaDV;
                txtDonGia.Text = dv.DonGia.ToString("N0");
            }

            TinhThanhTien();
        }

        private void txtSoLuong_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            TinhThanhTien();
        }

        private void TinhThanhTien()
        {
            var dv = LayDichVuDangChon();

            if (dv != null && int.TryParse(txtSoLuong.Text, out int soLuong) && soLuong > 0)
            {
                decimal thanhTien = soLuong * dv.DonGia;
                lbThanhTien.Text = "Thành tiền: " + thanhTien.ToString("N0");
            }
            else
            {
                lbThanhTien.Text = "Thành tiền: 0";
            }
        }

        private void btnThemDV_Click(object sender, EventArgs e)
        {
            string? maCTDP = MaChiTietDatPhong;

            if (string.IsNullOrEmpty(maCTDP))
            {
                MessageBox.Show("Chưa xác định được chi tiết phiếu thuê.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var dichVuChon = LayDichVuDangChon();

            if (dichVuChon == null)
            {
                MessageBox.Show("Vui lòng chọn dịch vụ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbTenDV.Focus();
                return;
            }

            if (!int.TryParse(txtSoLuong.Text, out int soLuong) || soLuong <= 0)
            {
                MessageBox.Show("Số lượng không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoLuong.Focus();
                return;
            }

            string maDV = dichVuChon.MaDV;

            try
            {
                using var db = new HotelManagementContext();

                var chiTietPhong = db.Ctdps
                    .AsNoTracking()
                    .Where(c => c.MaCtdp == maCTDP && c.DaXoa != true)
                    .Select(c => new { c.TrangThai })
                    .FirstOrDefault();

                if (chiTietPhong == null)
                {
                    MessageBox.Show("Không tìm thấy chi tiết phiếu thuê " + maCTDP + ".", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (chiTietPhong.TrangThai != "Đang thuê")
                {
                    MessageBox.Show("Chỉ có thể thêm dịch vụ cho phòng đang thuê!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var dichVu = db.DichVus.FirstOrDefault(d => d.MaDv == maDV && d.DaXoa != true);

                if (dichVu == null)
                {
                    MessageBox.Show("Dịch vụ không còn tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                bool gioiHanSoLuong = dichVu.SlconLai.HasValue && dichVu.SlconLai.Value >= 0;

                if (gioiHanSoLuong && soLuong > dichVu.SlconLai!.Value)
                {
                    MessageBox.Show($"Dịch vụ \"{dichVu.TenDv}\" chỉ còn {dichVu.SlconLai.Value} phần.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSoLuong.Focus();
                    return;
                }

                var daCo = db.Ctdvs.FirstOrDefault(v => v.MaCtdp == maCTDP && v.MaDv == maDV);

                if (daCo == null)
                {
                    db.Ctdvs.Add(new Ctdv
                    {
                        MaCtdp = maCTDP,
                        MaDv = maDV,
                        Sl = soLuong,
                        ThanhTien = soLuong * dichVu.DonGia,
                        DaXoa = false
                    });
                }
                else if (daCo.DaXoa == true)
                {
                    daCo.Sl = soLuong;
                    daCo.ThanhTien = soLuong * dichVu.DonGia;
                    daCo.DaXoa = false;
                }
                else
                {
                    daCo.Sl += soLuong;
                    daCo.ThanhTien = daCo.Sl * dichVu.DonGia;
                }

                if (gioiHanSoLuong)
                    dichVu.SlconLai = dichVu.SlconLai!.Value - soLuong;

                db.SaveChanges();

                MessageBox.Show("Thêm dịch vụ thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show("Thêm thất bại: " + (ex.InnerException?.Message ?? ex.Message), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm thất bại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}