using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace HotelManagementApp.ThongKe
{
    public class PieChartControl : Control
    {
        private List<ThongKeDichVuDto> _data = new();
        private static readonly Color[] Palette = new Color[]
        {
            Color.FromArgb(77, 161, 255),   // Xanh dương
            Color.FromArgb(255, 149, 0),    // Cam
            Color.FromArgb(175, 82, 222),   // Tím
            Color.FromArgb(52, 199, 89),    // Xanh lá
            Color.FromArgb(255, 59, 48),    // Đỏ
            Color.FromArgb(255, 204, 0),    // Vàng
            Color.FromArgb(90, 200, 250),   // Xanh ngọc
            Color.FromArgb(142, 142, 147)   // Xám
        };

        public PieChartControl()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            BackColor = Color.White;
        }

        public void SetData(List<ThongKeDichVuDto> data)
        {
            _data = data ?? new List<ThongKeDichVuDto>();
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            int totalCount = _data.Sum(x => x.SoLuong);
            if (totalCount <= 0 || _data.Count == 0)
            {
                using var font = new Font("Segoe UI", 10F, FontStyle.Italic);
                using var brush = new SolidBrush(Color.Gray);
                using var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                g.DrawString("(Chưa có dữ liệu dịch vụ trong kỳ)", font, brush, ClientRectangle, sf);
                return;
            }

            int w = Width;
            int h = Height;

            // Bố cục: Bên trái vẽ biểu đồ tròn, bên phải vẽ Legend
            int pieSize = Math.Min(w / 2 - 20, h - 30);
            if (pieSize < 60) pieSize = 60;

            int pieX = 20;
            int pieY = (h - pieSize) / 2;
            Rectangle pieRect = new Rectangle(pieX, pieY, pieSize, pieSize);

            float startAngle = -90f;
            int colorIdx = 0;

            for (int i = 0; i < _data.Count; i++)
            {
                var item = _data[i];
                float sweepAngle = ((float)item.SoLuong / totalCount) * 360f;
                Color c = Palette[colorIdx % Palette.Length];
                colorIdx++;

                using (var brush = new SolidBrush(c))
                {
                    g.FillPie(brush, pieRect, startAngle, sweepAngle);
                }
                using (var pen = new Pen(Color.White, 2f))
                {
                    g.DrawPie(pen, pieRect, startAngle, sweepAngle);
                }

                startAngle += sweepAngle;
            }

            // Vẽ Legend bên phải
            int legendX = pieX + pieSize + 25;
            int legendY = Math.Max(15, (h - _data.Count * 24) / 2);

            using var fontLegend = new Font("Segoe UI", 9F, FontStyle.Regular);
            using var brushText = new SolidBrush(Color.FromArgb(40, 40, 40));

            colorIdx = 0;
            for (int i = 0; i < _data.Count; i++)
            {
                var item = _data[i];
                Color c = Palette[colorIdx % Palette.Length];
                colorIdx++;

                int curY = legendY + i * 22;
                if (curY + 20 > h) break; // Tránh tràn giao diện nếu quá nhiều dịch vụ

                using (var bBox = new SolidBrush(c))
                {
                    g.FillRectangle(bBox, legendX, curY + 2, 14, 14);
                }
                using (var pBox = new Pen(Color.FromArgb(180, 180, 180)))
                {
                    g.DrawRectangle(pBox, legendX, curY + 2, 14, 14);
                }

                string label = $"{item.TenDichVu} ({item.SoLuong})";
                g.DrawString(label, fontLegend, brushText, legendX + 22, curY);
            }
        }
    }

    public class BarChartControl : Control
    {
        private List<(string Label, decimal Value)> _data = new();
        private string _legendText = "";
        private bool _isCurrency = false;

        public BarChartControl()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            BackColor = Color.White;
        }

        public void SetData(List<(string Label, decimal Value)> data, string legendText, bool isCurrency)
        {
            _data = data ?? new List<(string Label, decimal Value)>();
            _legendText = legendText ?? "";
            _isCurrency = isCurrency;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            int w = Width;
            int h = Height;

            // Header Legend ở góc trên bên phải
            if (!string.IsNullOrEmpty(_legendText))
            {
                using var fontLeg = new Font("Segoe UI", 8.5F, FontStyle.Regular);
                using var brushLeg = new SolidBrush(Color.FromArgb(60, 60, 60));
                using var brushBox = new SolidBrush(Color.FromArgb(56, 139, 242));

                int legBoxW = 12;
                int legBoxH = 12;
                int legY = 8;
                SizeF txtSize = g.MeasureString(_legendText, fontLeg);
                int legX = w - (int)txtSize.Width - legBoxW - 20;

                g.FillRectangle(brushBox, legX, legY + 2, legBoxW, legBoxH);
                g.DrawString(_legendText, fontLeg, brushLeg, legX + legBoxW + 6, legY);
            }

            // Tọa độ vùng vẽ đồ thị
            int padLeft = _isCurrency ? 85 : 50;
            int padRight = 30;
            int padTop = 32;
            int padBottom = 45;

            int chartW = w - padLeft - padRight;
            int chartH = h - padTop - padBottom;

            if (chartW <= 20 || chartH <= 20) return;

            // Xác định MaxValue
            decimal maxVal = _data.Count > 0 ? _data.Max(x => x.Value) : 0;
            if (maxVal <= 0)
            {
                maxVal = _isCurrency ? 3000000m : 3.5m;
            }
            else
            {
                // Làm tròn đẹp cho trục Y
                maxVal = CalculateNiceMax(maxVal, _isCurrency);
            }

            int stepCount = _isCurrency ? 6 : 7;
            decimal stepVal = maxVal / stepCount;

            using var penGrid = new Pen(Color.FromArgb(230, 230, 230), 1f);
            using var penAxis = new Pen(Color.FromArgb(120, 120, 120), 1.2f);
            using var fontAxis = new Font("Segoe UI", 8F, FontStyle.Regular);
            using var brushAxis = new SolidBrush(Color.FromArgb(90, 90, 90));
            using var sfRight = new StringFormat { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Center };

            // Vẽ các đường lưới ngang và nhãn trục Y
            for (int i = 0; i <= stepCount; i++)
            {
                decimal currentVal = stepVal * i;
                int yPos = padTop + chartH - (int)((currentVal / maxVal) * chartH);

                // Đường lưới
                g.DrawLine(penGrid, padLeft, yPos, padLeft + chartW, yPos);

                // Nhãn trục Y
                string yLabel = _isCurrency ? currentVal.ToString("N0", CultureInfo.InvariantCulture) : currentVal.ToString("0.#");
                g.DrawString(yLabel, fontAxis, brushAxis, new RectangleF(0, yPos - 10, padLeft - 6, 20), sfRight);
            }

            // Trục tọa độ X và Y
            g.DrawLine(penAxis, padLeft, padTop + chartH, padLeft + chartW, padTop + chartH); // Trục X
            g.DrawLine(penAxis, padLeft, padTop, padLeft, padTop + chartH); // Trục Y

            if (_data.Count == 0)
            {
                using var fontEmpty = new Font("Segoe UI", 9.5F, FontStyle.Italic);
                using var brushEmpty = new SolidBrush(Color.Gray);
                using var sfMid = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                g.DrawString("(Không có dữ liệu trong khoảng thời gian này)", fontEmpty, brushEmpty, new Rectangle(padLeft, padTop, chartW, chartH), sfMid);
                return;
            }

            // Vẽ các cột (Bars)
            int numItems = _data.Count;
            float colSlot = (float)chartW / numItems;
            float barW = Math.Min(colSlot * 0.45f, 65f);

            using var brushBar = new SolidBrush(Color.FromArgb(56, 139, 242));
            using var penBarBorder = new Pen(Color.FromArgb(30, 110, 210), 1f);
            using var sfX = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Near };
            using var fontX = new Font("Segoe UI", 8.5F, FontStyle.Regular);

            for (int i = 0; i < numItems; i++)
            {
                var item = _data[i];
                float centerX = padLeft + (i + 0.5f) * colSlot;
                float barLeft = centerX - barW / 2;

                int barHeight = (int)((item.Value / maxVal) * chartH);
                if (barHeight < 0) barHeight = 0;
                if (barHeight > chartH) barHeight = chartH;

                float barTop = padTop + chartH - barHeight;

                if (barHeight > 0)
                {
                    g.FillRectangle(brushBar, barLeft, barTop, barW, barHeight);
                    g.DrawRectangle(penBarBorder, barLeft, barTop, barW, barHeight);
                }

                // Nhãn loại phòng trục X
                RectangleF xRect = new RectangleF(centerX - colSlot / 2, padTop + chartH + 6, colSlot, padBottom - 6);
                g.DrawString(item.Label, fontX, brushAxis, xRect, sfX);
            }
        }

        private static decimal CalculateNiceMax(decimal val, bool isCurrency)
        {
            if (isCurrency)
            {
                if (val <= 500000) return 500000;
                if (val <= 1000000) return 1000000;
                if (val <= 2000000) return 2000000;
                if (val <= 3000000) return 3000000;
                if (val <= 5000000) return 5000000;
                if (val <= 10000000) return 10000000;
                return Math.Ceiling(val / 1000000m) * 1000000m;
            }
            else
            {
                if (val <= 1) return 1.5m;
                if (val <= 2) return 2.5m;
                if (val <= 3) return 3.5m;
                if (val <= 5) return 5.0m;
                return Math.Ceiling(val + 1);
            }
        }
    }
}
