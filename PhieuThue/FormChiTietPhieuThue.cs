using HotelManagementApp.DangNhap;
using HotelManagementApp.Models;
using HotelManagementApp.PhieuThue;
using HotelManagementApp.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HotelManagementApp.PhieuThue
{
    public partial class FormChiTietPhieuThue : Form
    {
        private readonly Image _iconHuy = Properties.Resources.delete;
        private readonly Image _iconSua = Properties.Resources.edit;
        private readonly Image _iconDichVu = Properties.Resources.DichVu1;
        private readonly Image _iconThanhToan = Properties.Resources.money;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string? MaPhieuThue { get; set; }

        public FormChiTietPhieuThue()
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            AcceptButton = btnThoat;
            CancelButton = btnThoat;

            Load += FormChiTietPhieuThue_Load;
            btnThoat.Click += btnThoat_Click;
            dtgDanhSachCTPT.CellClick += dtgDanhSachCTPT_CellClick;
        }

        public FormChiTietPhieuThue(string maPhieuThue) : this()
        {
            MaPhieuThue = maPhieuThue;
        }

        private void FormChiTietPhieuThue_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(MaPhieuThue))
            {
                MessageBox.Show("Chưa xác định được phiếu thuê cần xem.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CauHinhLuoi();
            LoadThongTinPhieuThue();
            LoadDanhSachChiTietPhieuThue();
        }

        private void LoadThongTinPhieuThue()
        {
            string? maPT = MaPhieuThue;

            try
            {
                using var db = new HotelManagementContext();

                var phieu = db.PhieuThues
                    .AsNoTracking()
                    .Where(p => p.MaPt == maPT)
                    .Select(p => new
                    {
                        p.MaPt,
                        TenKh = p.MaKhNavigation.TenKh,
                        p.NgPt,
                        TenNv = p.MaNvNavigation.TenNv
                    })
                    .FirstOrDefault();

                if (phieu == null)
                {
                    MessageBox.Show("Không tìm thấy phiếu thuê " + maPT + ".", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                lbSoPhieu.Text = "Chi tiết phiếu thuê " + phieu.MaPt;
                lbSoPhieu.Left = (ClientSize.Width - lbSoPhieu.PreferredWidth) / 2;
                lbHoTenKH.Text = phieu.TenKh;
                lbThoiGianLP.Text = phieu.NgPt.ToString("dd/MM/yyyy");
                lbHoTenNV.Text = phieu.TenNv;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải thông tin phiếu thuê: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CauHinhLuoi()
        {
            if (dtgDanhSachCTPT.Columns.Count > 0)
                return;

            UiHelper.DinhDangLuoi(dtgDanhSachCTPT);
            UiHelper.ToMauTrangThai(dtgDanhSachCTPT, "TrangThai");
            dtgDanhSachCTPT.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dtgDanhSachCTPT.Columns.Add("maCTDP", "Mã CT Phiếu");
            dtgDanhSachCTPT.Columns.Add("MapH", "Số phòng");
            dtgDanhSachCTPT.Columns.Add("CheckIn", "Ngày đến KS");
            dtgDanhSachCTPT.Columns.Add("CheckOut", "Ngày đi");
            dtgDanhSachCTPT.Columns.Add("TrangThai", "Trạng thái");
            dtgDanhSachCTPT.Columns.Add("ThanhTien", "Thành tiền");

            dtgDanhSachCTPT.Columns["CheckIn"]!.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            dtgDanhSachCTPT.Columns["CheckOut"]!.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            dtgDanhSachCTPT.Columns["ThanhTien"]!.DefaultCellStyle.Format = "N0";
            dtgDanhSachCTPT.Columns["ThanhTien"]!.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dtgDanhSachCTPT.Columns.Add(TaoCotAnh("Huy", "", "Hủy thông tin chi tiết phiếu", 60));
            dtgDanhSachCTPT.Columns.Add(TaoCotAnh("Sua", "", "Cập nhật trạng thái của chi tiết phiếu", 60));
            dtgDanhSachCTPT.Columns.Add(TaoCotAnh("DichVu", "Dịch vụ đã dùng", "Quản lý dịch vụ đã dùng của phòng", 135));
            dtgDanhSachCTPT.Columns.Add(TaoCotAnh("ThanhToan", "Thanh toán", "Thanh toán hóa đơn cho phòng này", 110));

            UiHelper.TuDongChinhDoRongCotVaTieuDe(dtgDanhSachCTPT);
        }

        private DataGridViewImageColumn TaoCotAnh(string ten, string tieuDe, string goiY, int doRong)
        {
            var cot = new DataGridViewImageColumn
            {
                Name = ten,
                HeaderText = tieuDe,
                ToolTipText = goiY,
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                Width = doRong,
                MinimumWidth = doRong,
                Resizable = DataGridViewTriState.False,
                SortMode = DataGridViewColumnSortMode.NotSortable
            };

            cot.DefaultCellStyle.NullValue = null;

            return cot;
        }

        private void LoadDanhSachChiTietPhieuThue()
        {
            string? maPT = MaPhieuThue;

            try
            {
                using var db = new HotelManagementContext();

                var dsChiTiet = db.Ctdps
                    .AsNoTracking()
                    .Where(c => c.MaPt == maPT && c.DaXoa != true)
                    .OrderBy(c => c.MaCtdp)
                    .Select(c => new
                    {
                        c.MaCtdp,
                        c.MaPh,
                        c.CheckIn,
                        c.CheckOut,
                        c.TrangThai,
                        c.ThanhTien
                    })
                    .ToList();

                dtgDanhSachCTPT.Rows.Clear();

                foreach (var c in dsChiTiet)
                {
                    bool daDat = c.TrangThai == "Đã đặt";
                    bool dangThue = c.TrangThai == "Đang thuê";

                    dtgDanhSachCTPT.Rows.Add(
                        c.MaCtdp,
                        c.MaPh,
                        c.CheckIn,
                        c.CheckOut,
                        c.TrangThai,
                        c.ThanhTien,
                        daDat ? _iconHuy : null,
                        daDat ? _iconSua : null,
                        dangThue ? _iconDichVu : null,
                        dangThue ? _iconThanhToan : null
                    );
                }

                dtgDanhSachCTPT.CurrentCell = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách chi tiết phiếu thuê: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void dtgDanhSachCTPT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            var dong = dtgDanhSachCTPT.Rows[e.RowIndex];
            string? maPH = dong.Cells["MapH"].Value?.ToString();
            string? trangThai = dong.Cells["TrangThai"].Value?.ToString();
            string? maCTDP = dong.Cells["maCTDP"].Value?.ToString();

            if (string.IsNullOrEmpty(maPH) || string.IsNullOrEmpty(maCTDP))
                return;

            string tenCot = dtgDanhSachCTPT.Columns[e.ColumnIndex].Name;

            if (tenCot == "Huy")
            {
                if (trangThai != "Đã đặt")
                {
                    MessageBox.Show("Chỉ có thể huỷ những phòng đã đặt!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn huỷ phòng {maPH} không?", "Xác nhận huỷ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (HuyChiTietDatPhong(maCTDP, maPH))
                        LoadDanhSachChiTietPhieuThue();
                }
            }
            else if (tenCot == "Sua")
            {
                if (trangThai != "Đã đặt")
                    return;

                using (var frm = new FormSuaChiTietPhieuThue())
                {
                    frm.MaPhieuThue = MaPhieuThue;
                    frm.MaPhong = maPH;
                    frm.ShowDialog();
                }

                LoadDanhSachChiTietPhieuThue();
            }
            else if (tenCot == "DichVu")
            {
                if (trangThai != "Đang thuê")
                    return;

                using (var frmDV = new FormDanhSachDichVuPhongDaDung())
                {
                    frmDV.MaChiTietDatPhong = maCTDP;
                    frmDV.MaPhong = maPH;
                    frmDV.ShowDialog();
                }

                LoadDanhSachChiTietPhieuThue();
            }
            else if (tenCot == "ThanhToan")
            {
                if (trangThai != "Đang thuê")
                    return;

                DialogResult result = MessageBox.Show($"Xác nhận thanh toán cho phòng {maPH}?", "Xác nhận thanh toán", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    TinhTienVaThanhToanHoaDon(maCTDP);
                    LoadDanhSachChiTietPhieuThue();
                }
            }
        }

        private bool HuyChiTietDatPhong(string maCTDP, string maPH)
        {
            try
            {
                using var db = new HotelManagementContext();

                var chiTiet = db.Ctdps.FirstOrDefault(c => c.MaCtdp == maCTDP && c.DaXoa != true);

                if (chiTiet == null)
                {
                    MessageBox.Show("Không tìm thấy chi tiết phiếu cần huỷ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (chiTiet.TrangThai != "Đã đặt")
                {
                    MessageBox.Show("Chỉ có thể huỷ những phòng đã đặt!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                chiTiet.DaXoa = true;

                bool conPhieuKhac = db.Ctdps.Any(c => c.MaPh == maPH
                    && c.MaCtdp != maCTDP
                    && c.DaXoa != true
                    && (c.TrangThai == "Đã đặt" || c.TrangThai == "Đang thuê"));

                if (!conPhieuKhac)
                {
                    var phong = db.Phongs.FirstOrDefault(p => p.MaPh == maPH);

                    if (phong != null && phong.Ttph == "Đã đặt")
                        phong.Ttph = "Bình thường";
                }

                db.SaveChanges();

                MessageBox.Show($"Phòng {maPH} đã được huỷ.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show("Lỗi khi huỷ phòng: " + (ex.InnerException?.Message ?? ex.Message), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi huỷ phòng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private static string TaoMaTiepTheo(IEnumerable<string> cacMa, string tienTo, int soChuSo, int doDaiToiDa)
        {
            int lonNhat = 0;

            foreach (string ma in cacMa)
            {
                if (ma.Length > tienTo.Length
                    && ma.StartsWith(tienTo, StringComparison.OrdinalIgnoreCase)
                    && int.TryParse(ma.Substring(tienTo.Length), out int so)
                    && so > lonNhat)
                {
                    lonNhat = so;
                }
            }

            string maMoi = tienTo + (lonNhat + 1).ToString("D" + soChuSo);

            if (maMoi.Length > doDaiToiDa)
                throw new InvalidOperationException($"Đã hết mã có tiền tố {tienTo} (tối đa {doDaiToiDa} ký tự).");

            return maMoi;
        }

        private void TinhTienVaThanhToanHoaDon(string maCTDP)
        {
            string maNV = FormDangNhap.MaNV_DangNhap;

            if (string.IsNullOrWhiteSpace(maNV))
            {
                MessageBox.Show("Chưa xác định được nhân viên đang đăng nhập. Vui lòng đăng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using var db = new HotelManagementContext();
                using var giaoDich = db.Database.BeginTransaction(IsolationLevel.Serializable);

                var chiTiet = db.Ctdps.FirstOrDefault(c => c.MaCtdp == maCTDP && c.DaXoa != true);

                if (chiTiet == null)
                {
                    MessageBox.Show("Không tìm thấy chi tiết phiếu cần thanh toán.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (chiTiet.TrangThai != "Đang thuê")
                {
                    MessageBox.Show("Chỉ có thể thanh toán những phòng đang thuê!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string maPhong = chiTiet.MaPh;
                decimal tienPhong = chiTiet.ThanhTien ?? 0m;

                decimal tienDV = db.Ctdvs
                    .Where(v => v.MaCtdp == maCTDP && v.DaXoa != true)
                    .Sum(v => v.ThanhTien ?? 0m);

                decimal tongTien = tienPhong + tienDV;

                string maHD = TaoMaTiepTheo(db.HoaDons.Select(h => h.MaHd).ToList(), "HD", 3, 5);

                db.HoaDons.Add(new Models.HoaDon
                {
                    MaHd = maHD,
                    NgHd = DateTime.Now,
                    TriGia = tongTien,
                    MaNv = maNV,
                    TrangThai = "Chờ KH xác nhận",
                    MaCtdp = maCTDP,
                    DaXoa = false
                });

                chiTiet.TrangThai = "Đã thanh toán";

                var phong = db.Phongs.FirstOrDefault(p => p.MaPh == maPhong);

                if (phong != null)
                    phong.Ttph = "Bình thường";

                db.SaveChanges();
                giaoDich.Commit();

                MessageBox.Show("Thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show("Lỗi thanh toán: " + (ex.InnerException?.Message ?? ex.Message), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thanh toán: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}