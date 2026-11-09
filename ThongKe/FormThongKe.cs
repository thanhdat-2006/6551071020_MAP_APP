using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using FastReport;
using FastReport.Preview;
using HotelManagementApp.DangNhap;
using HotelManagementApp.Models;

namespace HotelManagementApp.ThongKe
{
    public partial class FormThongKe : Form
    {
        private PreviewControl? _previewControl;
        private ThongKeKetQuaDto? _currentKq;
        private Report? _currentReport;

        public FormThongKe()
        {
            InitializeComponent();
            KhoiTaoPreviewControl();
        }

        private void KhoiTaoPreviewControl()
        {
            try
            {
                _previewControl = new PreviewControl();
                _previewControl.Dock = DockStyle.Fill;
                panelPreviewHost.Controls.Add(_previewControl);
            }
            catch (Exception ex)
            {
                panelPreviewHost.Controls.Add(new Label
                {
                    Dock = DockStyle.Fill,
                    Text = "Không thể khởi tạo FastReport PreviewControl: " + ex.Message,
                    TextAlign = ContentAlignment.MiddleCenter,
                    ForeColor = Color.Red
                });
            }
        }

        private void FormThongKe_Load(object sender, EventArgs e)
        {
            // Thiết lập ngày mặc định:
            // Kiểm tra xem trong CSDL có hóa đơn hoặc CTDP năm 2025 không (để khớp với ảnh mẫu 01/05/2025 - 18/05/2025)
            try
            {
                using var db = new HotelManagementContext();
                bool coDuLieu2025 = db.HoaDons.Any(h => h.NgHd != null && h.NgHd.Value.Year == 2025)
                                    || db.Ctdps.Any(c => c.CheckIn.Year == 2025);

                if (coDuLieu2025)
                {
                    dtpTuNgay.Value = new DateTime(2025, 5, 1);
                    dtpDenNgay.Value = new DateTime(2025, 5, 18);
                }
                else
                {
                    // Lấy ngày đầu tháng hiện tại và hôm nay
                    DateTime now = DateTime.Now;
                    dtpTuNgay.Value = new DateTime(now.Year, now.Month, 1);
                    dtpDenNgay.Value = now;
                }
            }
            catch
            {
                dtpTuNgay.Value = new DateTime(2025, 5, 1);
                dtpDenNgay.Value = new DateTime(2025, 5, 18);
            }

            TaiDuLieuThongKe();
        }

        private void btnXemThongKe_Click(object sender, EventArgs e)
        {
            if (dtpTuNgay.Value.Date > dtpDenNgay.Value.Date)
            {
                MessageBox.Show("Từ ngày không thể lớn hơn đến ngày!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            TaiDuLieuThongKe();
        }

        private void TaiDuLieuThongKe()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                DateTime tuNgay = dtpTuNgay.Value;
                DateTime denNgay = dtpDenNgay.Value;

                _currentKq = ThongKeDataService.LayThongKe(tuNgay, denNgay);

                // 1. Cập nhật 3 KPI Cards
                lblValKpi1.Text = $"{_currentKq.DoanhThuThuePhong:N0} VNĐ";
                lblValKpi2.Text = $"{_currentKq.DoanhThuDichVu:N0} VNĐ";
                lblValKpi3.Text = $"{_currentKq.SoPhongDat}";

                // 2. Cập nhật Top Danh hiệu
                lblTop1Val.Text = _currentKq.TopLoaiPhongDoanhThu;
                lblTop2Val.Text = _currentKq.TopLoaiPhongDatNhieuNhat;
                lblTop3Val.Text = _currentKq.TopDichVuDoanhThu;

                // 3. Cập nhật Biểu đồ dịch vụ
                pieChartServices.SetData(_currentKq.DanhSachDichVu);

                // 4. Cập nhật 2 Biểu đồ cột
                var dataDoanhThu = _currentKq.DanhSachLoaiPhong
                    .Select(lp => (lp.TenLoaiPhong, lp.DoanhThu))
                    .ToList();
                barChartDoanhThuPhong.SetData(dataDoanhThu, "■ Doanh thu theo loại phòng", true);

                var dataSoPhong = _currentKq.DanhSachLoaiPhong
                    .Select(lp => (lp.TenLoaiPhong, (decimal)lp.SoLuongDat))
                    .ToList();
                barChartSoPhongDat.SetData(dataSoPhong, "■ Số lượng đặt", false);

                // 5. Cập nhật FastReport Preview
                CapNhatBaoCaoFastReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu thống kê: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void CapNhatBaoCaoFastReport()
        {
            if (_previewControl == null || _currentKq == null) return;

            try
            {
                string nguoiLap = string.IsNullOrWhiteSpace(FormDangNhap.TenNV_DangNhap)
                    ? "Quản trị viên"
                    : FormDangNhap.TenNV_DangNhap;

                // Chụp ảnh dashboard trực quan để nhúng vào báo cáo FastReport
                Image? hinhDashboard = ChupHinhDashboard();

                _currentReport?.Dispose();
                _currentReport = BaoCaoThongKeFastReport.TaoBaoCao(_currentKq, nguoiLap, hinhDashboard);
                _currentReport.Preview = _previewControl;
                _currentReport.Prepare();
                _currentReport.ShowPrepared();
            }
            catch (Exception ex)
            {
                // Không gián đoạn dashboard nếu FastReport gặp lỗi nhỏ
                System.Diagnostics.Debug.WriteLine("FastReport Preview error: " + ex.Message);
            }
        }

        private Image? ChupHinhDashboard()
        {
            try
            {
                int w = panelDashboardScroll.Width;
                int h = Math.Min(panelDashboardScroll.Height, 680);
                if (w <= 0 || h <= 0) return null;

                Bitmap bmp = new Bitmap(w, h);
                panelDashboardScroll.DrawToBitmap(bmp, new Rectangle(0, 0, w, h));
                return bmp;
            }
            catch
            {
                return null;
            }
        }

        private void btnBaoCaoFastReport_Click(object sender, EventArgs e)
        {
            MoCuaSoFastReport();
        }

        private void btnMoFastReportPopup_Click(object sender, EventArgs e)
        {
            MoCuaSoFastReport();
        }

        private void MoCuaSoFastReport()
        {
            if (_currentKq == null)
            {
                TaiDuLieuThongKe();
            }

            try
            {
                Cursor = Cursors.WaitCursor;
                string nguoiLap = string.IsNullOrWhiteSpace(FormDangNhap.TenNV_DangNhap)
                    ? "Quản trị viên"
                    : FormDangNhap.TenNV_DangNhap;

                Image? hinhDashboard = ChupHinhDashboard();

                using (Report report = BaoCaoThongKeFastReport.TaoBaoCao(_currentKq!, nguoiLap, hinhDashboard))
                {
                    report.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi mở báo cáo FastReport: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
    }
}
