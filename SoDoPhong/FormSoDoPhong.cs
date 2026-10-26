using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HotelManagementApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementApp.SoDoPhong
{
    partial class FormSoDoPhong : Form
    {
        public FormSoDoPhong()
        {
            InitializeComponent();
        }

        private void FormSoDoPhong_Load(object sender, EventArgs e)
        {
            // Đặt trạng thái ban đầu của các control, trong lúc này chưa cho các sự kiện lọc chạy
            _dangKhoiTao = true;

            // Mỗi nhóm lọc mặc định chọn "Tất cả"
            rdbTatCaTrangThaiPhong.Checked = true;
            rdbTatCaLoaiPhong.Checked = true;
            rdbTatCaPhong.Checked = true;

            // Ô chọn ngày có thêm checkbox: tick mới lọc "phòng còn trống theo ngày", bỏ tick thì xem tất cả
            dtNgayChon.ShowCheckBox = true;
            dtNgayChon.Checked = false;

            // Gợi ý cho ô tìm kiếm (toolTip1 đã có sẵn trong Designer)
            toolTip1.SetToolTip(txtSearchMaPhong, "Ví dụ: 101, P20...");

            // Cấu hình lưới
            dataGridViewPhong.ReadOnly = true;
            dataGridViewPhong.AllowUserToAddRows = false;
            dataGridViewPhong.AllowUserToDeleteRows = false;
            dataGridViewPhong.MultiSelect = false;
            dataGridViewPhong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewPhong.AutoSizeColumnsMode =
DataGridViewAutoSizeColumnsMode.Fill;

            _dangKhoiTao = false;
            TaiLaiDanhSach();                       // Load dữ liệu khi form được mở
        }

        // ===== 13 radio button: cùng gọi LocTheoRadio, mọi tiêu chí được gom lại trong TaiLaiDanhSach() =====
        private void rdbTatCaPhong_CheckedChanged(object sender, EventArgs e)
        {
            LocTheoRadio(sender);
        }

        private void rdbPhongChuaDon_CheckedChanged(object sender, EventArgs e)
        {
            LocTheoRadio(sender);
        }

        private void rdbPhongDaDonDep_CheckedChanged(object sender, EventArgs e)
        {
            LocTheoRadio(sender);
        }

        private void rdbTatCaLoaiPhong_CheckedChanged(object sender, EventArgs e)
        {
            LocTheoRadio(sender);
        }

        private void rdbPhongVipDoi_CheckedChanged(object sender, EventArgs e)
        {
            LocTheoRadio(sender);
        }

        private void rdbPhongVipDon_CheckedChanged(object sender, EventArgs e)
        {
            LocTheoRadio(sender);
        }

        private void rdbPhongThuongDoi_CheckedChanged(object sender, EventArgs e)
        {
            LocTheoRadio(sender);
        }

        private void rdbPhongThuongDon_CheckedChanged(object sender, EventArgs e)
        {
            LocTheoRadio(sender);
        }

        private void rdbTatCaTrangThaiPhong_CheckedChanged(object sender, EventArgs e)
        {
            LocTheoRadio(sender);
        }

        private void rdbPhongDangSuaChua_CheckedChanged(object sender, EventArgs e)
        {
            LocTheoRadio(sender);
        }

        private void rdbPhongDangThue_CheckedChanged(object sender, EventArgs e)
        {
            LocTheoRadio(sender);
        }

        private void rdbPhongDaDat_CheckedChanged(object sender, EventArgs e)
        {
            LocTheoRadio(sender);
        }

        private void rdbPhongTrong_CheckedChanged(object sender, EventArgs e)
        {
            LocTheoRadio(sender);
        }

        private void txtSearchMaPhong_TextChanged(object sender, EventArgs e)
        {
            // Gõ tới đâu lọc tới đó; ô rỗng thì tự hiện lại danh sách theo các tiêu chí đang chọn
            if (_dangKhoiTao) return;
            TaiLaiDanhSach();
        }

        private void dtNgayChon_ValueChanged(object sender, EventArgs e)
        {
            // Đổi ngày hoặc tick/bỏ tick checkbox đều chạy vào đây
            if (_dangKhoiTao) return;
            TaiLaiDanhSach();
        }

        private void btnDatPhong_Click(object sender, EventArgs e)
        {
            string? maPhong = MaPhongDangChon();     // Phòng đang chọn trong lưới (có thể null)

            // Khi đã tạo FormDatPhong, thay MessageBox bên dưới bằng:
            //       using (var fDatPhong = new FormDatPhong())
            //       {
            //               // fDatPhong.MaPhong = maPhong;    // nếu cần truyền mã phòng đang chọn
            //               fDatPhong.ShowDialog();
            //       }
            //       TaiLaiDanhSach();                       // đặt xong thì tải lại trạng thái các phòng
            MessageBox.Show(
                "Chức năng đặt phòng đang được xây dựng."
                + (maPhong != null ? Environment.NewLine + "Phòng đang chọn: " + maPhong : ""),
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ==================== Các hàm hỗ trợ (viết thêm) ====================

        // true trong lúc khởi tạo giá trị mặc định ở Load, để các sự kiện không chạy truy vấn nhiều lần
        private bool _dangKhoiTao;

        // Mỗi lần đổi radio, CheckedChanged chạy 2 lần (bỏ chọn nút cũ + chọn nút mới) => chỉ xử lý khi nút được chọn
        private void LocTheoRadio(object sender)
        {
            if (_dangKhoiTao) return;
            if (sender is RadioButton rdb && !rdb.Checked) return;
            TaiLaiDanhSach();
        }

        // Nhóm "Trạng thái phòng" -> giá trị cột TTPH (null = tất cả)
        private string? TrangThaiPhongDangChon()
        {
            if (rdbPhongTrong.Checked) return "Bình thường";
            if (rdbPhongDaDat.Checked) return "Đã đặt";
            if (rdbPhongDangThue.Checked) return "Đang thuê";
            if (rdbPhongDangSuaChua.Checked) return "Đang sửa chữa";
            return null;
        }

        // Nhóm "Loại phòng" -> mã loại phòng MaLPH (null = tất cả)
        private string? MaLoaiPhongDangChon()
        {
            if (rdbPhongThuongDon.Checked) return "NOR01";
            if (rdbPhongThuongDoi.Checked) return "NOR02";
            if (rdbPhongVipDon.Checked) return "VIP01";
            if (rdbPhongVipDoi.Checked) return "VIP02";
            return null;
        }

        // Nhóm "Tình trạng dọn dẹp" -> giá trị cột TTDD (null = tất cả)
        private string? TinhTrangDonDepDangChon()
        {
            if (rdbPhongDaDonDep.Checked) return "Đã dọn dẹp";
            if (rdbPhongChuaDon.Checked) return "Chưa dọn dẹp";
            return null;
        }

        // Mã phòng của dòng đang chọn trong lưới
        private string? MaPhongDangChon()
        {
            return dataGridViewPhong.CurrentRow?.Cells["MaPH"].Value?.ToString();
        }

        // Tải lại lưới theo TẤT CẢ tiêu chí đang chọn: 3 nhóm radio + ô tìm kiếm mã phòng + (nếu tick) ngày còn trống
        private void TaiLaiDanhSach()
        {
            try
            {
                string? ttph = TrangThaiPhongDangChon();
                string? maLph = MaLoaiPhongDangChon();
                string? ttdd = TinhTrangDonDepDangChon();
                string maPhong = txtSearchMaPhong.Text.Trim();

                using var db = new HotelManagementContext();

                // Phòng chưa bị xóa mềm (DaXoa là bool? nên "!= true" nhận cả NULL lẫn false)
                var query = db.Phongs.AsNoTracking().Where(p => p.DaXoa != true);

                if (ttph != null) query = query.Where(p => p.Ttph == ttph);
                if (maLph != null) query = query.Where(p => p.MaLph == maLph);
                if (ttdd != null) query = query.Where(p => p.Ttdd == ttdd);
                if (maPhong.Length > 0) query = query.Where(p =>
p.MaPh.Contains(maPhong));

                // Lọc phòng còn trống vào ngày đã chọn: phòng "Bình thường" và không có phiếu đặt nào bao trùm ngày đó
                if (dtNgayChon.Checked)
                {
                    DateTime ngayChon = dtNgayChon.Value.Date;
                    query = query.Where(p => p.Ttph == "Bình thường"
                                          && !p.Ctdps.Any(c => c.DaXoa != true
                                                            && ngayChon >= c.CheckIn.Date
                                                            && ngayChon < c.CheckOut.Date));
                }

                var dsPhong = query
                    .OrderBy(p => p.MaPh)
                    .Select(p => new
                    {
                        p.MaPh,
                        TenLph = p.MaLphNavigation.TenLph,
                        p.Ttph,
                        p.Ttdd,
                        p.GhiChu
                    })
                    .ToList();

                // Tầng = ký tự thứ 2 của mã phòng (P101 -> 1), giống SUBSTRING(MaPH, 2, 1) ở bản cũ
                dataGridViewPhong.DataSource = dsPhong
                    .Select(p => new
                    {
                        MaPH = p.MaPh,
                        Tang = p.MaPh.Length > 1 ? p.MaPh.Substring(1, 1) : "",
                        TenLPH = p.TenLph,
                        TTPH = p.Ttph,
                        TTDD = p.Ttdd,
                        GhiChu = p.GhiChu
                    })
                    .ToList();

                // Cập nhật tên cột hiển thị
                DatTieuDeCot("MaPH", "Mã phòng");
                DatTieuDeCot("Tang", "Tầng");
                DatTieuDeCot("TenLPH", "Loại phòng");
                DatTieuDeCot("TTPH", "Trạng thái phòng");
                DatTieuDeCot("TTDD", "Tình trạng dọn dẹp");
                DatTieuDeCot("GhiChu", "Ghi chú");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách phòng: " + ex.Message);
            }
        }

        private void DatTieuDeCot(string tenCot, string tieuDe)
        {
            if (dataGridViewPhong.Columns.Contains(tenCot))
                dataGridViewPhong.Columns[tenCot].HeaderText = tieuDe;
        }
    }
}