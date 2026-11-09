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
    public partial class FormSuaChiTietPhieuThue : Form
    {
        private string? _maCtdp;
        private string? _trangThaiHienTai;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string? MaPhieuThue { get; set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string? MaPhong { get; set; }

        public FormSuaChiTietPhieuThue()
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            AcceptButton = btnCapNhat;
            CancelButton = btnThoat;

            cbTrangThaiCTDP.DropDownStyle = ComboBoxStyle.DropDownList;
            if (cbTrangThaiCTDP.Items.Count > 0)
                cbTrangThaiCTDP.SelectedIndex = 0;

            Load += FormSuaChiTietPhieuThue_Load;
        }

        private void FormSuaChiTietPhieuThue_Load(object? sender, EventArgs e)
        {
            string? maPT = MaPhieuThue;
            string? maPH = MaPhong;

            if (string.IsNullOrEmpty(maPT) || string.IsNullOrEmpty(maPH))
            {
                MessageBox.Show("Chưa xác định được chi tiết phiếu thuê cần cập nhật.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnCapNhat.Enabled = false;
                return;
            }

            try
            {
                using var db = new HotelManagementContext();

                var chiTiet = db.Ctdps
                    .AsNoTracking()
                    .Where(c => c.MaPt == maPT && c.MaPh == maPH && c.DaXoa != true)
                    .OrderByDescending(c => c.MaCtdp)
                    .Select(c => new { c.MaCtdp, c.TrangThai })
                    .FirstOrDefault();

                if (chiTiet == null)
                {
                    MessageBox.Show("Không tìm thấy chi tiết phiếu thuê của phòng " + maPH + ".", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnCapNhat.Enabled = false;
                    return;
                }

                _maCtdp = chiTiet.MaCtdp;
                _trangThaiHienTai = chiTiet.TrangThai;

                lbMaCTDP.Text = "Cập nhật trạng thái CTDP " + _maCtdp;

                int viTri = cbTrangThaiCTDP.Items.IndexOf(_trangThaiHienTai ?? "");
                cbTrangThaiCTDP.SelectedIndex = viTri >= 0 ? viTri : 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải thông tin chi tiết phiếu thuê: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnCapNhat.Enabled = false;
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_maCtdp))
            {
                MessageBox.Show("Chưa xác định được chi tiết phiếu thuê cần cập nhật.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string? trangThaiMoi = cbTrangThaiCTDP.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(trangThaiMoi))
            {
                MessageBox.Show("Vui lòng chọn trạng thái!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbTrangThaiCTDP.Focus();
                return;
            }

            try
            {
                using var db = new HotelManagementContext();

                var chiTiet = db.Ctdps.FirstOrDefault(c => c.MaCtdp == _maCtdp && c.DaXoa != true);

                if (chiTiet == null)
                {
                    MessageBox.Show("Không tìm thấy chi tiết phiếu thuê cần cập nhật.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (chiTiet.TrangThai != "Đã đặt" && chiTiet.TrangThai != "Đang thuê")
                {
                    MessageBox.Show("Chỉ có thể cập nhật chi tiết phiếu đang ở trạng thái \"Đã đặt\" hoặc \"Đang thuê\"!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (chiTiet.TrangThai == trangThaiMoi)
                {
                    MessageBox.Show("Trạng thái không thay đổi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                chiTiet.TrangThai = trangThaiMoi;

                var phong = db.Phongs.FirstOrDefault(p => p.MaPh == chiTiet.MaPh);

                if (phong != null)
                {
                    if (trangThaiMoi == "Đang thuê")
                    {
                        phong.Ttph = "Đang thuê";
                    }
                    else if (trangThaiMoi == "Đã thanh toán")
                    {
                        bool conPhieuKhac = db.Ctdps.Any(c => c.MaPh == chiTiet.MaPh
                            && c.MaCtdp != chiTiet.MaCtdp
                            && c.DaXoa != true
                            && (c.TrangThai == "Đã đặt" || c.TrangThai == "Đang thuê"));

                        if (!conPhieuKhac && (phong.Ttph == "Đang thuê" || phong.Ttph == "Đã đặt"))
                        {
                            phong.Ttph = "Bình thường";
                        }
                    }
                }

                db.SaveChanges();

                MessageBox.Show("Cập nhật trạng thái thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + (ex.InnerException?.Message ?? ex.Message), "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message, "Lỗi",
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