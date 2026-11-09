using System;
using System.Drawing;
using System.Windows.Forms;

namespace HotelManagementApp.Utils
{
    public static class UiHelper
    {
        public static readonly Color MauChuDao = Color.FromArgb(0, 128, 128); // Dark Cyan
        public static readonly Color MauChuDaoHover = Color.FromArgb(0, 150, 150);
        public static readonly Color MauNenHeader = Color.FromArgb(15, 60, 90);
        public static readonly Color MauNenDongChan = Color.FromArgb(255, 255, 255);
        public static readonly Color MauNenDongLe = Color.FromArgb(246, 250, 254);
        public static readonly Color MauChonDong = Color.FromArgb(218, 236, 252);
        public static readonly Color MauChuChonDong = Color.FromArgb(20, 30, 45);

        /// <summary>
        /// Định dạng DataGridView theo phong cách phẳng, hiện đại và trực quan
        /// </summary>
        public static void DinhDangLuoi(DataGridView dgv)
        {
            if (dgv == null) return;

            dgv.EnableHeadersVisualStyles = false;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = Color.FromArgb(232, 237, 242);
            dgv.BackgroundColor = Color.White;

            // Tiêu đề cột
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.ColumnHeadersHeight = 44;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = MauNenHeader;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(6, 0, 6, 0);

            // Tự động đảm bảo các cột khi thêm vào đều không bị ngắt dòng tiêu đề
            dgv.ColumnAdded += (s, e) =>
            {
                if (e.Column != null)
                {
                    e.Column.HeaderCell.Style.WrapMode = DataGridViewTriState.False;
                }
            };

            // Dòng dữ liệu
            dgv.RowTemplate.Height = 38;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            dgv.DefaultCellStyle.ForeColor = Color.FromArgb(35, 45, 60);
            dgv.DefaultCellStyle.BackColor = MauNenDongChan;
            dgv.DefaultCellStyle.SelectionBackColor = MauChonDong;
            dgv.DefaultCellStyle.SelectionForeColor = MauChuChonDong;
            dgv.DefaultCellStyle.Padding = new Padding(8, 0, 8, 0);

            // Dòng so le (Zebra stripe)
            dgv.AlternatingRowsDefaultCellStyle.BackColor = MauNenDongLe;
            dgv.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(35, 45, 60);
            dgv.AlternatingRowsDefaultCellStyle.SelectionBackColor = MauChonDong;
            dgv.AlternatingRowsDefaultCellStyle.SelectionForeColor = MauChuChonDong;
            dgv.AlternatingRowsDefaultCellStyle.Padding = new Padding(8, 0, 8, 0);

            // Tùy chọn khác
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeRows = false;
        }

        /// <summary>
        /// Đảm bảo tất cả tiêu đề cột hiển thị đầy đủ trên 1 dòng, không bao giờ bị cắt hay xuống dòng.
        /// Tự động đo độ dài HeaderText và tính toán MinimumWidth / Width phù hợp.
        /// </summary>
        public static void TuDongChinhDoRongCotVaTieuDe(DataGridView dgv)
        {
            if (dgv == null) return;

            dgv.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            Font font = dgv.ColumnHeadersDefaultCellStyle.Font ?? dgv.Font ?? SystemFonts.DefaultFont;

            foreach (DataGridViewColumn col in dgv.Columns)
            {
                col.HeaderCell.Style.WrapMode = DataGridViewTriState.False;

                if (!string.IsNullOrEmpty(col.HeaderText))
                {
                    // Đo kích thước văn bản tiêu đề
                    Size textSize = TextRenderer.MeasureText(col.HeaderText, font);
                    // Khoảng trống cần thiết: Chiều rộng chữ + padding trái/phải (12px) + khoảng dự phòng sort glyph / viền (16px)
                    int minNeeded = textSize.Width + 28;

                    if (col.MinimumWidth < minNeeded)
                    {
                        col.MinimumWidth = minNeeded;
                    }

                    // Đối với các cột cố định (như các cột chức năng icon Sửa, Xóa, Chi tiết, Tiện nghi có AutoSizeMode = None)
                    if (col.AutoSizeMode == DataGridViewAutoSizeColumnMode.None && col.Width < minNeeded)
                    {
                        col.Width = minNeeded;
                    }
                }
            }
        }

        /// <summary>
        /// Tự động tô màu badge/chip cho các cột trạng thái (TrangThai, TTPH, TTDD, v.v.)
        /// </summary>
        public static void ToMauTrangThai(DataGridView dgv, params string[] tenCacCot)
        {
            if (dgv == null || tenCacCot == null || tenCacCot.Length == 0) return;

            dgv.CellFormatting += (sender, e) =>
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

                string columnName = dgv.Columns[e.ColumnIndex].Name;
                bool match = false;
                foreach (var cot in tenCacCot)
                {
                    if (string.Equals(columnName, cot, StringComparison.OrdinalIgnoreCase))
                    {
                        match = true;
                        break;
                    }
                }

                if (!match) return;

                string val = e.Value?.ToString()?.Trim() ?? "";
                if (string.IsNullOrEmpty(val)) return;

                // Kiểm tra các trường hợp trạng thái
                if (val.Equals("Đã thanh toán", StringComparison.OrdinalIgnoreCase) ||
                    val.Equals("Đã dọn dẹp", StringComparison.OrdinalIgnoreCase) ||
                    val.Equals("Bình thường", StringComparison.OrdinalIgnoreCase) ||
                    val.Equals("Phòng trống", StringComparison.OrdinalIgnoreCase) ||
                    val.Equals("Đang hoạt động", StringComparison.OrdinalIgnoreCase) ||
                    val.Equals("Hoạt động", StringComparison.OrdinalIgnoreCase))
                {
                    // Xanh lá (Hoàn thành, Sẵn sàng, Hợp lệ)
                    e.CellStyle.ForeColor = Color.FromArgb(21, 128, 61);
                    e.CellStyle.BackColor = Color.FromArgb(220, 252, 231);
                    e.CellStyle.Font = new Font(dgv.Font.FontFamily, 9F, FontStyle.Bold);
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                else if (val.Equals("Đang thuê", StringComparison.OrdinalIgnoreCase) ||
                         val.Equals("Bị khóa", StringComparison.OrdinalIgnoreCase) ||
                         val.Equals("Đã hủy", StringComparison.OrdinalIgnoreCase))
                {
                    // Đỏ (Đang có khách, Nguy hiểm, Bị khóa)
                    e.CellStyle.ForeColor = Color.FromArgb(185, 28, 28);
                    e.CellStyle.BackColor = Color.FromArgb(254, 226, 226);
                    e.CellStyle.Font = new Font(dgv.Font.FontFamily, 9F, FontStyle.Bold);
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                else if (val.Equals("Đã đặt", StringComparison.OrdinalIgnoreCase) ||
                         val.Equals("Chờ nhận phòng", StringComparison.OrdinalIgnoreCase))
                {
                    // Xanh dương (Đã đặt trước)
                    e.CellStyle.ForeColor = Color.FromArgb(29, 78, 216);
                    e.CellStyle.BackColor = Color.FromArgb(219, 234, 254);
                    e.CellStyle.Font = new Font(dgv.Font.FontFamily, 9F, FontStyle.Bold);
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                else if (val.Equals("Chưa dọn dẹp", StringComparison.OrdinalIgnoreCase) ||
                         val.Equals("Chưa thanh toán", StringComparison.OrdinalIgnoreCase) ||
                         val.Equals("Đang sửa chữa", StringComparison.OrdinalIgnoreCase) ||
                         val.Equals("Tạm ngưng", StringComparison.OrdinalIgnoreCase))
                {
                    // Vàng cam (Cần chú ý, Chưa xong, Đang sửa)
                    e.CellStyle.ForeColor = Color.FromArgb(180, 83, 9);
                    e.CellStyle.BackColor = Color.FromArgb(254, 243, 199);
                    e.CellStyle.Font = new Font(dgv.Font.FontFamily, 9F, FontStyle.Bold);
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            };
        }
    }
}
