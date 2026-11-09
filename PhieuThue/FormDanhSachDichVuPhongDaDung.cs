using HotelManagementApp.Models;
using HotelManagementApp.PhieuThue;
using HotelManagementApp.Utils;
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
    public partial class FormDanhSachDichVuPhongDaDung : Form
    {
        private sealed class DongDichVu
        {
            public string MaDV { get; set; } = "";
            public string TenDV { get; set; } = "";
            public decimal DonGia { get; set; }
            public int SL { get; set; }
            public decimal ThanhTien { get; set; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string? MaChiTietDatPhong { get; set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string? MaPhong { get; set; }

        public FormDanhSachDichVuPhongDaDung()
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            AcceptButton = btnThoat;
            CancelButton = btnThoat;

            Load += FormDanhSachDichVuPhongDaDung_Load;
        }

        private void FormDanhSachDichVuPhongDaDung_Load(object? sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(MaChiTietDatPhong) || string.IsNullOrEmpty(MaPhong))
            {
                MessageBox.Show("Chưa xác định được chi tiết phiếu thuê cần xem.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnThemDV.Enabled = false;
                return;
            }

            lbSoCTPhieu.Text = "Mã chi tiết phiếu: " + MaChiTietDatPhong;
            lbSoPhong.Text = "Số phòng: " + MaPhong;

            CauHinhLuoi();
            LoadDanhSachDichVu();
        }

        private void CauHinhLuoi()
        {
            if (dtgDanhSachDichVu.Columns.Count > 0)
                return;

            UiHelper.DinhDangLuoi(dtgDanhSachDichVu);
            dtgDanhSachDichVu.AutoGenerateColumns = false;
            dtgDanhSachDichVu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dtgDanhSachDichVu.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MaDV",
                DataPropertyName = "MaDV",
                HeaderText = "Mã dịch vụ"
            });

            dtgDanhSachDichVu.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TenDV",
                DataPropertyName = "TenDV",
                HeaderText = "Tên dịch vụ"
            });

            var cotDonGia = new DataGridViewTextBoxColumn
            {
                Name = "DonGia",
                DataPropertyName = "DonGia",
                HeaderText = "Đơn giá"
            };
            cotDonGia.DefaultCellStyle.Format = "N0";
            cotDonGia.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgDanhSachDichVu.Columns.Add(cotDonGia);

            var cotSoLuong = new DataGridViewTextBoxColumn
            {
                Name = "SL",
                DataPropertyName = "SL",
                HeaderText = "Số lượng"
            };
            cotSoLuong.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgDanhSachDichVu.Columns.Add(cotSoLuong);

            var cotThanhTien = new DataGridViewTextBoxColumn
            {
                Name = "ThanhTien",
                DataPropertyName = "ThanhTien",
                HeaderText = "Thành tiền"
            };
            cotThanhTien.DefaultCellStyle.Format = "N0";
            cotThanhTien.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgDanhSachDichVu.Columns.Add(cotThanhTien);

            UiHelper.TuDongChinhDoRongCotVaTieuDe(dtgDanhSachDichVu);
        }

        private void LoadDanhSachDichVu()
        {
            string? maCTDP = MaChiTietDatPhong;

            try
            {
                using var db = new HotelManagementContext();

                var danhSach = db.Ctdvs
                    .AsNoTracking()
                    .Where(v => v.MaCtdp == maCTDP && v.DaXoa != true)
                    .OrderBy(v => v.MaDv)
                    .Select(v => new DongDichVu
                    {
                        MaDV = v.MaDv,
                        TenDV = v.MaDvNavigation.TenDv,
                        DonGia = v.MaDvNavigation.DonGia,
                        SL = v.Sl,
                        ThanhTien = v.ThanhTien ?? (v.Sl * v.MaDvNavigation.DonGia)
                    })
                    .ToList();

                dtgDanhSachDichVu.DataSource = null;
                dtgDanhSachDichVu.DataSource = danhSach;
                dtgDanhSachDichVu.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách dịch vụ đã dùng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThemDV_Click(object sender, EventArgs e)
        {
            using (var frm = new FormThemDichVuPhongDaDung())
            {
                frm.MaChiTietDatPhong = MaChiTietDatPhong;
                frm.MaPhong = MaPhong;
                frm.ShowDialog();
            }

            LoadDanhSachDichVu();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}