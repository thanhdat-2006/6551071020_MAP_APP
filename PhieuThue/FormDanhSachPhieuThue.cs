using ClosedXML.Excel;
using HotelManagementApp.Models;
using HotelManagementApp.PhieuThue;
using HotelManagementApp.SoDoPhong;
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
    public partial class FormDanhSachPhieuThue : Form
    {
        private sealed class DongPhieuThue
        {
            public string MaPT { get; set; } = "";
            public string TenKH { get; set; } = "";
            public DateTime NgPT { get; set; }
            public string TenNV { get; set; } = "";
        }

        private List<DongPhieuThue> _danhSach = new List<DongPhieuThue>();
        private List<DongPhieuThue> _dangHienThi = new List<DongPhieuThue>();

        public FormDanhSachPhieuThue()
        {
            InitializeComponent();
            dtgDanhSachPhieuThue.CellClick += dtgDanhSachPhieuThue_CellContentClick;
        }

        private void FormDanhSachPhieuThue_Load(object sender, EventArgs e)
        {
            CauHinhLuoi();
            LoadDanhSachPhieuThue();
        }

        private void CauHinhLuoi()
        {
            if (dtgDanhSachPhieuThue.Columns.Count > 0)
                return;

            UiHelper.DinhDangLuoi(dtgDanhSachPhieuThue);
            dtgDanhSachPhieuThue.AutoGenerateColumns = false;
            dtgDanhSachPhieuThue.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dtgDanhSachPhieuThue.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MaPT",
                DataPropertyName = "MaPT",
                HeaderText = "Mã phiếu thuê"
            });

            dtgDanhSachPhieuThue.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TenKH",
                DataPropertyName = "TenKH",
                HeaderText = "Tên khách hàng"
            });

            var cotNgayLap = new DataGridViewTextBoxColumn
            {
                Name = "NgPT",
                DataPropertyName = "NgPT",
                HeaderText = "Ngày lập phiếu"
            };
            cotNgayLap.DefaultCellStyle.Format = "dd/MM/yyyy";
            dtgDanhSachPhieuThue.Columns.Add(cotNgayLap);

            dtgDanhSachPhieuThue.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TenNV",
                DataPropertyName = "TenNV",
                HeaderText = "Nhân viên lập"
            });

            var imgCol = new DataGridViewImageColumn
            {
                Name = "ChiTiet",
                HeaderText = "Chi tiết",
                Image = Properties.Resources.details,
                ToolTipText = "Xem chi tiết",
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                Width = 95,
                MinimumWidth = 95,
                Resizable = DataGridViewTriState.False
            };
            dtgDanhSachPhieuThue.Columns.Add(imgCol);

            UiHelper.TuDongChinhDoRongCotVaTieuDe(dtgDanhSachPhieuThue);
        }

        private void LoadDanhSachPhieuThue()
        {
            try
            {
                using var db = new HotelManagementContext();

                _danhSach = db.PhieuThues
                    .AsNoTracking()
                    .Where(p => p.DaXoa != true)
                    .OrderBy(p => p.MaPt)
                    .Select(p => new DongPhieuThue
                    {
                        MaPT = p.MaPt,
                        TenKH = p.MaKhNavigation.TenKh,
                        NgPT = p.NgPt,
                        TenNV = p.MaNvNavigation.TenNv
                    })
                    .ToList();

                HienThiDanhSach();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách phiếu thuê: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HienThiDanhSach()
        {
            string tuKhoa = txtTimKiem.Text.Trim();

            _dangHienThi = string.IsNullOrEmpty(tuKhoa)
                ? _danhSach.ToList()
                : _danhSach
                    .Where(d => d.MaPT.Contains(tuKhoa, StringComparison.OrdinalIgnoreCase)
                        || d.TenKH.Contains(tuKhoa, StringComparison.OrdinalIgnoreCase))
                    .ToList();

            dtgDanhSachPhieuThue.DataSource = null;
            dtgDanhSachPhieuThue.DataSource = _dangHienThi;
            dtgDanhSachPhieuThue.ClearSelection();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            HienThiDanhSach();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (_dangHienThi.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var hopLuu = new SaveFileDialog
            {
                Filter = "Excel Workbook (*.xlsx)|*.xlsx",
                FileName = "DanhSachPhieuThue_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx",
                Title = "Lưu danh sách phiếu thuê"
            };

            if (hopLuu.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                using var workbook = new XLWorkbook();
                var worksheet = workbook.Worksheets.Add("Danh sách phiếu thuê");

                string[] tieuDe = { "Mã phiếu thuê", "Tên khách hàng", "Ngày lập phiếu", "Nhân viên lập" };

                for (int i = 0; i < tieuDe.Length; i++)
                {
                    var o = worksheet.Cell(1, i + 1);
                    o.Value = tieuDe[i];
                    o.Style.Font.Bold = true;
                    o.Style.Fill.BackgroundColor = XLColor.LightGray;
                }

                int dong = 2;

                foreach (var d in _dangHienThi)
                {
                    worksheet.Cell(dong, 1).Value = d.MaPT;
                    worksheet.Cell(dong, 2).Value = d.TenKH;
                    worksheet.Cell(dong, 3).Value = d.NgPT;
                    worksheet.Cell(dong, 3).Style.DateFormat.Format = "dd/MM/yyyy";
                    worksheet.Cell(dong, 4).Value = d.TenNV;
                    dong++;
                }

                worksheet.Columns().AdjustToContents();
                workbook.SaveAs(hopLuu.FileName);

                MessageBox.Show("Xuất dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (IOException ex)
            {
                MessageBox.Show("Không thể ghi file, hãy kiểm tra file có đang được mở không: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDatPhong_Click(object sender, EventArgs e)
        {
            using (var formDatPhong = new FormDatPhong())
            {
                formDatPhong.ShowDialog();
            }

            LoadDanhSachPhieuThue();
        }

        private void dtgDanhSachPhieuThue_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (dtgDanhSachPhieuThue.Columns[e.ColumnIndex].Name != "ChiTiet")
                return;

            string? maPT = dtgDanhSachPhieuThue.Rows[e.RowIndex].Cells["MaPT"].Value?.ToString();

            if (string.IsNullOrEmpty(maPT))
                return;

            using (var formChiTiet = new FormChiTietPhieuThue(maPT))
            {
                formChiTiet.ShowDialog();
            }

            LoadDanhSachPhieuThue();
        }
    }
}