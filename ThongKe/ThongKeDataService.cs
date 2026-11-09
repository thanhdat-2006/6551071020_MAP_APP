using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using HotelManagementApp.Models;

namespace HotelManagementApp.ThongKe
{
    public class ThongKeLoaiPhongDto
    {
        public string TenLoaiPhong { get; set; } = string.Empty;
        public decimal DoanhThu { get; set; }
        public int SoLuongDat { get; set; }
    }

    public class ThongKeDichVuDto
    {
        public string TenDichVu { get; set; } = string.Empty;
        public int SoLuong { get; set; }
        public decimal DoanhThu { get; set; }
    }

    public class ThongKeKetQuaDto
    {
        public DateTime TuNgay { get; set; }
        public DateTime DenNgay { get; set; }

        public decimal DoanhThuThuePhong { get; set; }
        public decimal DoanhThuDichVu { get; set; }
        public decimal TongDoanhThu => DoanhThuThuePhong + DoanhThuDichVu;
        public int SoPhongDat { get; set; }

        public string TopLoaiPhongDoanhThu { get; set; } = "(Chưa có dữ liệu)";
        public decimal TopLoaiPhongDoanhThuValue { get; set; }

        public string TopLoaiPhongDatNhieuNhat { get; set; } = "(Chưa có dữ liệu)";
        public int TopLoaiPhongDatNhieuNhatValue { get; set; }

        public string TopDichVuDoanhThu { get; set; } = "(Chưa có dữ liệu)";
        public decimal TopDichVuDoanhThuValue { get; set; }

        public List<ThongKeLoaiPhongDto> DanhSachLoaiPhong { get; set; } = new();
        public List<ThongKeDichVuDto> DanhSachDichVu { get; set; } = new();
    }

    public class ThongKeDataService
    {
        public static ThongKeKetQuaDto LayThongKe(DateTime tuNgay, DateTime denNgay)
        {
            DateTime from = tuNgay.Date;
            DateTime to = denNgay.Date.AddDays(1).AddTicks(-1);

            var kq = new ThongKeKetQuaDto
            {
                TuNgay = from,
                DenNgay = denNgay.Date
            };

            using var db = new HotelManagementContext();

            // 1. Thử lấy theo Hóa đơn trong khoảng thời gian
            var hoaDons = db.HoaDons
                .Include(h => h.MaCtdpNavigation)
                    .ThenInclude(c => c.MaPhNavigation)
                        .ThenInclude(p => p.MaLphNavigation)
                .Include(h => h.MaCtdpNavigation)
                    .ThenInclude(c => c.Ctdvs)
                        .ThenInclude(dv => dv.MaDvNavigation)
                .Where(h => h.DaXoa != true && h.NgHd >= from && h.NgHd <= to)
                .ToList();

            List<Ctdp> dsCtdp;
            if (hoaDons.Count > 0)
            {
                dsCtdp = hoaDons
                    .Select(h => h.MaCtdpNavigation)
                    .Where(c => c != null && c.DaXoa != true)
                    .Distinct()
                    .ToList();
            }
            else
            {
                // Fallback: Nếu chưa có hóa đơn trong khoảng thời gian, lấy theo CTDP có CheckIn/CheckOut trong khoảng này
                dsCtdp = db.Ctdps
                    .Include(c => c.MaPhNavigation)
                        .ThenInclude(p => p.MaLphNavigation)
                    .Include(c => c.Ctdvs)
                        .ThenInclude(dv => dv.MaDvNavigation)
                    .Where(c => c.DaXoa != true && (
                        (c.CheckIn >= from && c.CheckIn <= to) ||
                        (c.CheckOut >= from && c.CheckOut <= to)
                    ))
                    .ToList();
            }

            // Tính tổng tiền phòng và số phòng đặt
            kq.SoPhongDat = dsCtdp.Count;
            kq.DoanhThuThuePhong = dsCtdp.Sum(c => c.ThanhTien ?? 0);

            // Thu thập các chi tiết dịch vụ
            var dsCtdv = dsCtdp
                .SelectMany(c => c.Ctdvs)
                .Where(v => v.DaXoa != true)
                .ToList();

            kq.DoanhThuDichVu = dsCtdv.Sum(v => v.ThanhTien ?? ((v.DonGia ?? v.MaDvNavigation?.DonGia ?? 0) * v.Sl));

            // Thống kê theo loại phòng
            // Lấy tất cả loại phòng có trong danh sách đặt phòng hoặc database
            var loaiPhongGroups = dsCtdp
                .GroupBy(c => c.MaPhNavigation?.MaLphNavigation?.TenLph ?? "Khác")
                .Select(g => new ThongKeLoaiPhongDto
                {
                    TenLoaiPhong = g.Key,
                    DoanhThu = g.Sum(c => c.ThanhTien ?? 0),
                    SoLuongDat = g.Count()
                })
                .OrderByDescending(x => x.DoanhThu)
                .ToList();

            kq.DanhSachLoaiPhong = loaiPhongGroups;

            // Top Loại phòng doanh thu cao nhất
            var topLpDoanhThu = loaiPhongGroups.OrderByDescending(x => x.DoanhThu).FirstOrDefault();
            if (topLpDoanhThu != null && topLpDoanhThu.DoanhThu > 0)
            {
                kq.TopLoaiPhongDoanhThu = $"{topLpDoanhThu.TenLoaiPhong} ({topLpDoanhThu.DoanhThu:N0} VNĐ)";
                kq.TopLoaiPhongDoanhThuValue = topLpDoanhThu.DoanhThu;
            }
            else if (topLpDoanhThu != null)
            {
                kq.TopLoaiPhongDoanhThu = $"{topLpDoanhThu.TenLoaiPhong} (0 VNĐ)";
            }

            // Top Loại phòng được đặt nhiều nhất
            var topLpDat = loaiPhongGroups.OrderByDescending(x => x.SoLuongDat).FirstOrDefault();
            if (topLpDat != null && topLpDat.SoLuongDat > 0)
            {
                kq.TopLoaiPhongDatNhieuNhat = $"{topLpDat.TenLoaiPhong} ({topLpDat.SoLuongDat} lượt)";
                kq.TopLoaiPhongDatNhieuNhatValue = topLpDat.SoLuongDat;
            }

            // Thống kê theo dịch vụ
            var dichVuGroups = dsCtdv
                .GroupBy(v => v.MaDvNavigation?.TenDv ?? "Khác")
                .Select(g => new ThongKeDichVuDto
                {
                    TenDichVu = g.Key,
                    SoLuong = g.Sum(v => v.Sl),
                    DoanhThu = g.Sum(v => v.ThanhTien ?? ((v.DonGia ?? v.MaDvNavigation?.DonGia ?? 0) * v.Sl))
                })
                .OrderByDescending(x => x.DoanhThu)
                .ToList();

            kq.DanhSachDichVu = dichVuGroups;

            // Top Dịch vụ doanh thu cao nhất
            var topDv = dichVuGroups.OrderByDescending(x => x.DoanhThu).FirstOrDefault();
            if (topDv != null && topDv.DoanhThu > 0)
            {
                kq.TopDichVuDoanhThu = $"{topDv.TenDichVu} ({topDv.DoanhThu:N0} VNĐ)";
                kq.TopDichVuDoanhThuValue = topDv.DoanhThu;
            }
            else if (topDv != null)
            {
                kq.TopDichVuDoanhThu = $"{topDv.TenDichVu} (0 VNĐ)";
            }

            return kq;
        }
    }
}
