using System;
using System.Drawing;
using System.IO;
using System.Linq;
using FastReport;
using FastReport.Table;
using FastReport.Utils;

namespace HotelManagementApp.ThongKe
{
    public class BaoCaoThongKeFastReport
    {
        public static Report TaoBaoCao(ThongKeKetQuaDto kq, string nguoiLap, Image? hinhDashboard = null)
        {
            Report report = new Report();

            ReportPage page = new ReportPage();
            page.Name = "PageBaoCao";
            page.PaperWidth = 210; // A4
            page.PaperHeight = 297;
            page.TopMargin = 10;
            page.BottomMargin = 10;
            page.LeftMargin = 12;
            page.RightMargin = 12;
            report.Pages.Add(page);

            // 1. ReportTitleBand: Tiêu đề báo cáo
            ReportTitleBand titleBand = new ReportTitleBand();
            titleBand.Name = "TitleBand";
            titleBand.Height = Units.Centimeters * 3.2f;
            page.ReportTitle = titleBand;

            // Tên khách sạn
            TextObject txtHotelName = new TextObject();
            txtHotelName.Bounds = new RectangleF(0, 0, Units.Centimeters * 18.5f, Units.Centimeters * 0.6f);
            txtHotelName.Text = "HỆ THỐNG QUẢN LÝ KHÁCH SẠN - HOTEL MANAGEMENT";
            txtHotelName.Font = new Font("Arial", 10, FontStyle.Bold);
            txtHotelName.TextColor = Color.DarkSlateGray;
            titleBand.Objects.Add(txtHotelName);

            // Tiêu đề chính
            TextObject txtTitle = new TextObject();
            txtTitle.Bounds = new RectangleF(0, Units.Centimeters * 0.8f, Units.Centimeters * 18.5f, Units.Centimeters * 1.0f);
            txtTitle.Text = "BÁO CÁO THỐNG KÊ TÌNH HÌNH KINH DOANH";
            txtTitle.Font = new Font("Arial", 16, FontStyle.Bold);
            txtTitle.HorzAlign = HorzAlign.Center;
            txtTitle.TextColor = Color.FromArgb(16, 44, 87);
            titleBand.Objects.Add(txtTitle);

            // Thời gian
            TextObject txtSubtitle = new TextObject();
            txtSubtitle.Bounds = new RectangleF(0, Units.Centimeters * 1.8f, Units.Centimeters * 18.5f, Units.Centimeters * 0.6f);
            txtSubtitle.Text = $"Khoảng thời gian: Từ ngày {kq.TuNgay:dd/MM/yyyy} đến ngày {kq.DenNgay:dd/MM/yyyy}";
            txtSubtitle.Font = new Font("Arial", 10.5f, FontStyle.Italic);
            txtSubtitle.HorzAlign = HorzAlign.Center;
            txtSubtitle.TextColor = Color.FromArgb(50, 50, 50);
            titleBand.Objects.Add(txtSubtitle);

            // Người lập & ngày giờ
            TextObject txtMeta = new TextObject();
            txtMeta.Bounds = new RectangleF(0, Units.Centimeters * 2.5f, Units.Centimeters * 18.5f, Units.Centimeters * 0.5f);
            txtMeta.Text = $"Ngày lập báo cáo: {DateTime.Now:dd/MM/yyyy HH:mm}   |   Người lập: {nguoiLap}";
            txtMeta.Font = new Font("Arial", 9.5f, FontStyle.Regular);
            txtMeta.HorzAlign = HorzAlign.Right;
            txtMeta.TextColor = Color.DimGray;
            titleBand.Objects.Add(txtMeta);

            // 2. DataBand chứa nội dung chính
            DataBand dataBand = new DataBand();
            dataBand.Name = "DataMain";
            dataBand.Height = Units.Centimeters * 18f;
            page.Bands.Add(dataBand);

            float currentY = 0;

            // --- BẢNG 1: TỔNG QUAN CHỈ SỐ DOANH THU & ĐẶT PHÒNG ---
            TextObject txtSection1 = new TextObject();
            txtSection1.Bounds = new RectangleF(0, currentY, Units.Centimeters * 18.5f, Units.Centimeters * 0.6f);
            txtSection1.Text = "I. CHỈ SỐ DOANH THU & KINH DOANH TỔNG QUAN";
            txtSection1.Font = new Font("Arial", 11, FontStyle.Bold);
            txtSection1.TextColor = Color.DarkCyan;
            dataBand.Objects.Add(txtSection1);
            currentY += Units.Centimeters * 0.7f;

            TableObject tableKPI = new TableObject();
            tableKPI.Name = "TableKPI";
            tableKPI.Bounds = new RectangleF(0, currentY, Units.Centimeters * 18.5f, Units.Centimeters * 1.5f);
            tableKPI.ColumnCount = 4;
            tableKPI.RowCount = 2;

            float colW = Units.Centimeters * 18.5f / 4f;
            for (int i = 0; i < 4; i++)
                tableKPI.Columns[i].Width = colW;

            tableKPI[0, 0].Text = "Doanh thu thuê phòng";
            tableKPI[1, 0].Text = "Doanh thu dịch vụ";
            tableKPI[2, 0].Text = "TỔNG DOANH THU";
            tableKPI[3, 0].Text = "Số phòng đặt";

            tableKPI[0, 1].Text = $"{kq.DoanhThuThuePhong:N0} VNĐ";
            tableKPI[1, 1].Text = $"{kq.DoanhThuDichVu:N0} VNĐ";
            tableKPI[2, 1].Text = $"{kq.TongDoanhThu:N0} VNĐ";
            tableKPI[3, 1].Text = $"{kq.SoPhongDat} lượt";

            for (int c = 0; c < 4; c++)
            {
                tableKPI[c, 0].Font = new Font("Arial", 9.5f, FontStyle.Bold);
                tableKPI[c, 0].FillColor = Color.FromArgb(235, 243, 250);
                tableKPI[c, 0].HorzAlign = HorzAlign.Center;
                tableKPI[c, 0].VertAlign = VertAlign.Center;
                tableKPI[c, 0].Border.Lines = BorderLines.All;
                tableKPI[c, 0].Border.Color = Color.LightGray;

                tableKPI[c, 1].Font = new Font("Arial", 11f, FontStyle.Bold);
                tableKPI[c, 1].FillColor = (c == 2) ? Color.FromArgb(255, 248, 225) : Color.White;
                tableKPI[c, 1].TextColor = (c == 0) ? Color.FromArgb(204, 51, 51) :
                                            (c == 1) ? Color.FromArgb(170, 130, 20) :
                                            (c == 2) ? Color.FromArgb(0, 102, 204) :
                                            Color.FromArgb(46, 125, 50);
                tableKPI[c, 1].HorzAlign = HorzAlign.Center;
                tableKPI[c, 1].VertAlign = VertAlign.Center;
                tableKPI[c, 1].Border.Lines = BorderLines.All;
                tableKPI[c, 1].Border.Color = Color.LightGray;
            }

            dataBand.Objects.Add(tableKPI);
            currentY += Units.Centimeters * 1.8f;

            // --- BẢNG TOP TIÊU BIỂU ---
            TextObject txtSectionTop = new TextObject();
            txtSectionTop.Bounds = new RectangleF(0, currentY, Units.Centimeters * 18.5f, Units.Centimeters * 0.6f);
            txtSectionTop.Text = "II. DANH HIỆU & ĐIỂM SÁNG NỔI BẬT";
            txtSectionTop.Font = new Font("Arial", 11, FontStyle.Bold);
            txtSectionTop.TextColor = Color.DarkCyan;
            dataBand.Objects.Add(txtSectionTop);
            currentY += Units.Centimeters * 0.7f;

            TableObject tableTop = new TableObject();
            tableTop.Name = "TableTop";
            tableTop.Bounds = new RectangleF(0, currentY, Units.Centimeters * 18.5f, Units.Centimeters * 2.1f);
            tableTop.ColumnCount = 2;
            tableTop.RowCount = 3;
            tableTop.Columns[0].Width = Units.Centimeters * 7.5f;
            tableTop.Columns[1].Width = Units.Centimeters * 11.0f;

            string[,] topData = new string[3, 2]
            {
                { " Loại phòng doanh thu cao nhất:", kq.TopLoaiPhongDoanhThu },
                { " Loại phòng được đặt nhiều nhất:", kq.TopLoaiPhongDatNhieuNhat },
                { " Dịch vụ doanh thu cao nhất:", kq.TopDichVuDoanhThu }
            };

            for (int r = 0; r < 3; r++)
            {
                tableTop[0, r].Text = topData[r, 0];
                tableTop[0, r].Font = new Font("Arial", 9.5f, FontStyle.Bold);
                tableTop[0, r].FillColor = Color.FromArgb(245, 243, 248);
                tableTop[0, r].VertAlign = VertAlign.Center;
                tableTop[0, r].Border.Lines = BorderLines.All;
                tableTop[0, r].Border.Color = Color.LightGray;

                tableTop[1, r].Text = topData[r, 1];
                tableTop[1, r].Font = new Font("Arial", 10f, FontStyle.Bold);
                tableTop[1, r].TextColor = Color.FromArgb(40, 40, 100);
                tableTop[1, r].FillColor = Color.White;
                tableTop[1, r].VertAlign = VertAlign.Center;
                tableTop[1, r].Border.Lines = BorderLines.All;
                tableTop[1, r].Border.Color = Color.LightGray;
            }

            dataBand.Objects.Add(tableTop);
            currentY += Units.Centimeters * 2.3f;

            // --- BẢNG CHI TIẾT THEO LOẠI PHÒNG ---
            TextObject txtSection2 = new TextObject();
            txtSection2.Bounds = new RectangleF(0, currentY, Units.Centimeters * 18.5f, Units.Centimeters * 0.6f);
            txtSection2.Text = "III. CHI TIẾT DOANH THU & LƯỢT ĐẶT THEO TỪNG LOẠI PHÒNG";
            txtSection2.Font = new Font("Arial", 11, FontStyle.Bold);
            txtSection2.TextColor = Color.DarkCyan;
            dataBand.Objects.Add(txtSection2);
            currentY += Units.Centimeters * 0.7f;

            int rowCountLp = kq.DanhSachLoaiPhong.Count;
            int totalRowsLp = Math.Max(1, rowCountLp) + 2; // header + rows + total
            TableObject tableLP = new TableObject();
            tableLP.Name = "TableLP";
            tableLP.ColumnCount = 5;
            tableLP.RowCount = totalRowsLp;
            tableLP.Bounds = new RectangleF(0, currentY, Units.Centimeters * 18.5f, Units.Centimeters * 0.6f * totalRowsLp);
            tableLP.Columns[0].Width = Units.Centimeters * 1.5f; // STT
            tableLP.Columns[1].Width = Units.Centimeters * 6.5f; // Tên loại phòng
            tableLP.Columns[2].Width = Units.Centimeters * 3.5f; // Số lượt đặt
            tableLP.Columns[3].Width = Units.Centimeters * 4.5f; // Doanh thu
            tableLP.Columns[4].Width = Units.Centimeters * 2.5f; // Tỷ lệ %

            // Header
            string[] headerLP = { "STT", "Tên loại phòng", "Số lượt đặt", "Doanh thu phòng", "Tỷ trọng" };
            for (int c = 0; c < 5; c++)
            {
                tableLP[c, 0].Text = headerLP[c];
                tableLP[c, 0].Font = new Font("Arial", 9.5f, FontStyle.Bold);
                tableLP[c, 0].FillColor = Color.FromArgb(64, 116, 179);
                tableLP[c, 0].TextColor = Color.White;
                tableLP[c, 0].HorzAlign = HorzAlign.Center;
                tableLP[c, 0].VertAlign = VertAlign.Center;
                tableLP[c, 0].Border.Lines = BorderLines.All;
                tableLP[c, 0].Border.Color = Color.DarkGray;
            }

            decimal tongDtPhong = kq.DoanhThuThuePhong > 0 ? kq.DoanhThuThuePhong : 1;
            int sttLp = 1;
            int currentRow = 1;

            if (rowCountLp == 0)
            {
                tableLP[0, currentRow].Text = "-";
                tableLP[1, currentRow].Text = "(Không có dữ liệu đặt phòng trong khoảng thời gian này)";
                tableLP[2, currentRow].Text = "0";
                tableLP[3, currentRow].Text = "0 VNĐ";
                tableLP[4, currentRow].Text = "0%";
                for (int c = 0; c < 5; c++)
                {
                    tableLP[c, currentRow].Font = new Font("Arial", 9f, FontStyle.Italic);
                    tableLP[c, currentRow].Border.Lines = BorderLines.All;
                    tableLP[c, currentRow].Border.Color = Color.LightGray;
                }
                currentRow++;
            }
            else
            {
                foreach (var lp in kq.DanhSachLoaiPhong)
                {
                    decimal tyTrong = (lp.DoanhThu / tongDtPhong) * 100m;
                    tableLP[0, currentRow].Text = (sttLp++).ToString();
                    tableLP[0, currentRow].HorzAlign = HorzAlign.Center;

                    tableLP[1, currentRow].Text = lp.TenLoaiPhong;
                    tableLP[1, currentRow].HorzAlign = HorzAlign.Left;

                    tableLP[2, currentRow].Text = $"{lp.SoLuongDat} lượt";
                    tableLP[2, currentRow].HorzAlign = HorzAlign.Center;

                    tableLP[3, currentRow].Text = $"{lp.DoanhThu:N0} VNĐ";
                    tableLP[3, currentRow].HorzAlign = HorzAlign.Right;

                    tableLP[4, currentRow].Text = $"{tyTrong:F1}%";
                    tableLP[4, currentRow].HorzAlign = HorzAlign.Center;

                    for (int c = 0; c < 5; c++)
                    {
                        tableLP[c, currentRow].Font = new Font("Arial", 9f, FontStyle.Regular);
                        tableLP[c, currentRow].VertAlign = VertAlign.Center;
                        tableLP[c, currentRow].FillColor = (currentRow % 2 == 1) ? Color.White : Color.FromArgb(248, 250, 252);
                        tableLP[c, currentRow].Border.Lines = BorderLines.All;
                        tableLP[c, currentRow].Border.Color = Color.LightGray;
                    }
                    currentRow++;
                }
            }

            // Dòng tổng cộng
            tableLP[0, currentRow].Text = "";
            tableLP[1, currentRow].Text = "TỔNG CỘNG";
            tableLP[1, currentRow].Font = new Font("Arial", 9.5f, FontStyle.Bold);
            tableLP[2, currentRow].Text = $"{kq.SoPhongDat} lượt";
            tableLP[2, currentRow].Font = new Font("Arial", 9.5f, FontStyle.Bold);
            tableLP[2, currentRow].HorzAlign = HorzAlign.Center;
            tableLP[3, currentRow].Text = $"{kq.DoanhThuThuePhong:N0} VNĐ";
            tableLP[3, currentRow].Font = new Font("Arial", 9.5f, FontStyle.Bold);
            tableLP[3, currentRow].HorzAlign = HorzAlign.Right;
            tableLP[4, currentRow].Text = "100%";
            tableLP[4, currentRow].Font = new Font("Arial", 9.5f, FontStyle.Bold);
            tableLP[4, currentRow].HorzAlign = HorzAlign.Center;

            for (int c = 0; c < 5; c++)
            {
                tableLP[c, currentRow].FillColor = Color.FromArgb(235, 240, 248);
                tableLP[c, currentRow].VertAlign = VertAlign.Center;
                tableLP[c, currentRow].Border.Lines = BorderLines.All;
                tableLP[c, currentRow].Border.Color = Color.DarkGray;
            }

            dataBand.Objects.Add(tableLP);
            currentY += tableLP.Height + Units.Centimeters * 0.4f;

            // --- BẢNG CHI TIẾT DỊCH VỤ ---
            TextObject txtSection3 = new TextObject();
            txtSection3.Bounds = new RectangleF(0, currentY, Units.Centimeters * 18.5f, Units.Centimeters * 0.6f);
            txtSection3.Text = "IV. CHI TIẾT TÌNH HÌNH SỬ DỤNG DỊCH VỤ";
            txtSection3.Font = new Font("Arial", 11, FontStyle.Bold);
            txtSection3.TextColor = Color.DarkCyan;
            dataBand.Objects.Add(txtSection3);
            currentY += Units.Centimeters * 0.7f;

            int rowCountDv = kq.DanhSachDichVu.Count;
            int totalRowsDv = Math.Max(1, rowCountDv) + 2;
            TableObject tableDV = new TableObject();
            tableDV.Name = "TableDV";
            tableDV.ColumnCount = 5;
            tableDV.RowCount = totalRowsDv;
            tableDV.Bounds = new RectangleF(0, currentY, Units.Centimeters * 18.5f, Units.Centimeters * 0.6f * totalRowsDv);
            tableDV.Columns[0].Width = Units.Centimeters * 1.5f;
            tableDV.Columns[1].Width = Units.Centimeters * 6.5f;
            tableDV.Columns[2].Width = Units.Centimeters * 3.5f;
            tableDV.Columns[3].Width = Units.Centimeters * 4.5f;
            tableDV.Columns[4].Width = Units.Centimeters * 2.5f;

            string[] headerDV = { "STT", "Tên dịch vụ", "Số lượng sử dụng", "Doanh thu dịch vụ", "Tỷ trọng" };
            for (int c = 0; c < 5; c++)
            {
                tableDV[c, 0].Text = headerDV[c];
                tableDV[c, 0].Font = new Font("Arial", 9.5f, FontStyle.Bold);
                tableDV[c, 0].FillColor = Color.FromArgb(70, 130, 110);
                tableDV[c, 0].TextColor = Color.White;
                tableDV[c, 0].HorzAlign = HorzAlign.Center;
                tableDV[c, 0].VertAlign = VertAlign.Center;
                tableDV[c, 0].Border.Lines = BorderLines.All;
                tableDV[c, 0].Border.Color = Color.DarkGray;
            }

            decimal tongDtDv = kq.DoanhThuDichVu > 0 ? kq.DoanhThuDichVu : 1;
            int sttDv = 1;
            int currentRowDv = 1;

            if (rowCountDv == 0)
            {
                tableDV[0, currentRowDv].Text = "-";
                tableDV[1, currentRowDv].Text = "(Không có dịch vụ nào được sử dụng trong khoảng thời gian này)";
                tableDV[2, currentRowDv].Text = "0";
                tableDV[3, currentRowDv].Text = "0 VNĐ";
                tableDV[4, currentRowDv].Text = "0%";
                for (int c = 0; c < 5; c++)
                {
                    tableDV[c, currentRowDv].Font = new Font("Arial", 9f, FontStyle.Italic);
                    tableDV[c, currentRowDv].Border.Lines = BorderLines.All;
                    tableDV[c, currentRowDv].Border.Color = Color.LightGray;
                }
                currentRowDv++;
            }
            else
            {
                foreach (var dv in kq.DanhSachDichVu)
                {
                    decimal tyTrong = (dv.DoanhThu / tongDtDv) * 100m;
                    tableDV[0, currentRowDv].Text = (sttDv++).ToString();
                    tableDV[0, currentRowDv].HorzAlign = HorzAlign.Center;

                    tableDV[1, currentRowDv].Text = dv.TenDichVu;
                    tableDV[1, currentRowDv].HorzAlign = HorzAlign.Left;

                    tableDV[2, currentRowDv].Text = $"{dv.SoLuong}";
                    tableDV[2, currentRowDv].HorzAlign = HorzAlign.Center;

                    tableDV[3, currentRowDv].Text = $"{dv.DoanhThu:N0} VNĐ";
                    tableDV[3, currentRowDv].HorzAlign = HorzAlign.Right;

                    tableDV[4, currentRowDv].Text = $"{tyTrong:F1}%";
                    tableDV[4, currentRowDv].HorzAlign = HorzAlign.Center;

                    for (int c = 0; c < 5; c++)
                    {
                        tableDV[c, currentRowDv].Font = new Font("Arial", 9f, FontStyle.Regular);
                        tableDV[c, currentRowDv].VertAlign = VertAlign.Center;
                        tableDV[c, currentRowDv].FillColor = (currentRowDv % 2 == 1) ? Color.White : Color.FromArgb(246, 252, 248);
                        tableDV[c, currentRowDv].Border.Lines = BorderLines.All;
                        tableDV[c, currentRowDv].Border.Color = Color.LightGray;
                    }
                    currentRowDv++;
                }
            }

            // Dòng tổng cộng dịch vụ
            tableDV[0, currentRowDv].Text = "";
            tableDV[1, currentRowDv].Text = "TỔNG CỘNG";
            tableDV[1, currentRowDv].Font = new Font("Arial", 9.5f, FontStyle.Bold);
            tableDV[2, currentRowDv].Text = $"{kq.DanhSachDichVu.Sum(x => x.SoLuong)}";
            tableDV[2, currentRowDv].Font = new Font("Arial", 9.5f, FontStyle.Bold);
            tableDV[2, currentRowDv].HorzAlign = HorzAlign.Center;
            tableDV[3, currentRowDv].Text = $"{kq.DoanhThuDichVu:N0} VNĐ";
            tableDV[3, currentRowDv].Font = new Font("Arial", 9.5f, FontStyle.Bold);
            tableDV[3, currentRowDv].HorzAlign = HorzAlign.Right;
            tableDV[4, currentRowDv].Text = "100%";
            tableDV[4, currentRowDv].Font = new Font("Arial", 9.5f, FontStyle.Bold);
            tableDV[4, currentRowDv].HorzAlign = HorzAlign.Center;

            for (int c = 0; c < 5; c++)
            {
                tableDV[c, currentRowDv].FillColor = Color.FromArgb(235, 245, 240);
                tableDV[c, currentRowDv].VertAlign = VertAlign.Center;
                tableDV[c, currentRowDv].Border.Lines = BorderLines.All;
                tableDV[c, currentRowDv].Border.Color = Color.DarkGray;
            }

            dataBand.Objects.Add(tableDV);
            currentY += tableDV.Height + Units.Centimeters * 0.6f;

            // --- HÌNH ẢNH BIỂU ĐỒ DASHBOARD (NẾU CÓ) ---
            if (hinhDashboard != null)
            {
                TextObject txtSection4 = new TextObject();
                txtSection4.Bounds = new RectangleF(0, currentY, Units.Centimeters * 18.5f, Units.Centimeters * 0.6f);
                txtSection4.Text = "V. BIỂU ĐỒ TRỰC QUAN DASHBOARD";
                txtSection4.Font = new Font("Arial", 11, FontStyle.Bold);
                txtSection4.TextColor = Color.DarkCyan;
                dataBand.Objects.Add(txtSection4);
                currentY += Units.Centimeters * 0.7f;

                PictureObject picDashboard = new PictureObject();
                picDashboard.Bounds = new RectangleF(0, currentY, Units.Centimeters * 18.5f, Units.Centimeters * 8.5f);
                picDashboard.SizeMode = PictureBoxSizeMode.Zoom;
                picDashboard.Image = hinhDashboard;
                dataBand.Objects.Add(picDashboard);
                currentY += Units.Centimeters * 8.8f;
            }

            // Đặt chiều cao chính xác cho dataBand
            dataBand.Height = currentY + Units.Centimeters * 0.5f;

            // 3. PageFooterBand: Chữ ký & chân trang
            PageFooterBand footerBand = new PageFooterBand();
            footerBand.Name = "PageFooter";
            footerBand.Height = Units.Centimeters * 3.2f;
            page.PageFooter = footerBand;

            TextObject txtSignLeft = new TextObject();
            txtSignLeft.Bounds = new RectangleF(Units.Centimeters * 1.5f, 0, Units.Centimeters * 6f, Units.Centimeters * 2.2f);
            txtSignLeft.Text = "NGƯỜI LẬP BÁO CÁO\n(Ký và ghi rõ họ tên)\n\n\n" + nguoiLap;
            txtSignLeft.Font = new Font("Arial", 9.5f, FontStyle.Bold);
            txtSignLeft.HorzAlign = HorzAlign.Center;
            footerBand.Objects.Add(txtSignLeft);

            TextObject txtSignRight = new TextObject();
            txtSignRight.Bounds = new RectangleF(Units.Centimeters * 11.0f, 0, Units.Centimeters * 6f, Units.Centimeters * 2.2f);
            txtSignRight.Text = "GIÁM ĐỐC KHÁCH SẠN\n(Ký và đóng dấu)\n\n\n";
            txtSignRight.Font = new Font("Arial", 9.5f, FontStyle.Bold);
            txtSignRight.HorzAlign = HorzAlign.Center;
            footerBand.Objects.Add(txtSignRight);

            TextObject txtPageNum = new TextObject();
            txtPageNum.Bounds = new RectangleF(0, Units.Centimeters * 2.6f, Units.Centimeters * 18.5f, Units.Centimeters * 0.5f);
            txtPageNum.Text = "Trang [Page#] / [TotalPages#]";
            txtPageNum.Font = new Font("Arial", 8.5f, FontStyle.Italic);
            txtPageNum.HorzAlign = HorzAlign.Right;
            txtPageNum.TextColor = Color.Gray;
            footerBand.Objects.Add(txtPageNum);

            return report;
        }
    }
}
