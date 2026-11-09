namespace HotelManagementApp.PhieuThue
{
    partial class FormChiTietPhieuThue
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lbSoPhieu = new Label();
            lbHoTenKH = new Label();
            lbThoiGianLP = new Label();
            lbHoTenNV = new Label();
            dtgDanhSachCTPT = new DataGridView();
            btnThoat = new Button();
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dtgDanhSachCTPT).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lbSoPhieu
            // 
            lbSoPhieu.AutoSize = true;
            lbSoPhieu.BackColor = Color.Transparent;
            lbSoPhieu.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbSoPhieu.Location = new Point(351, 29);
            lbSoPhieu.Margin = new Padding(4, 0, 4, 0);
            lbSoPhieu.Name = "lbSoPhieu";
            lbSoPhieu.Size = new Size(484, 46);
            lbSoPhieu.TabIndex = 6;
            lbSoPhieu.Text = "Chi tiết phiếu thuê {số phiếu}";
            // 
            // lbHoTenKH
            // 
            lbHoTenKH.AutoSize = true;
            lbHoTenKH.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbHoTenKH.ForeColor = Color.FromArgb(0, 0, 192);
            lbHoTenKH.Location = new Point(83, 141);
            lbHoTenKH.Name = "lbHoTenKH";
            lbHoTenKH.Size = new Size(194, 26);
            lbHoTenKH.TabIndex = 8;
            lbHoTenKH.Text = "Họ tên khách hàng";
            // 
            // lbThoiGianLP
            // 
            lbThoiGianLP.AutoSize = true;
            lbThoiGianLP.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbThoiGianLP.ForeColor = Color.FromArgb(0, 0, 192);
            lbThoiGianLP.Location = new Point(515, 141);
            lbThoiGianLP.Name = "lbThoiGianLP";
            lbThoiGianLP.Size = new Size(194, 26);
            lbThoiGianLP.TabIndex = 10;
            lbThoiGianLP.Text = "Thời gian lập phiếu";
            // 
            // lbHoTenNV
            // 
            lbHoTenNV.AutoSize = true;
            lbHoTenNV.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbHoTenNV.ForeColor = Color.FromArgb(0, 0, 192);
            lbHoTenNV.Location = new Point(905, 141);
            lbHoTenNV.Name = "lbHoTenNV";
            lbHoTenNV.Size = new Size(176, 26);
            lbHoTenNV.TabIndex = 12;
            lbHoTenNV.Text = "Họ tên nhân viên";
            // 
            // dtgDanhSachCTPT
            // 
            dtgDanhSachCTPT.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgDanhSachCTPT.Location = new Point(12, 221);
            dtgDanhSachCTPT.Margin = new Padding(3, 4, 3, 4);
            dtgDanhSachCTPT.Name = "dtgDanhSachCTPT";
            dtgDanhSachCTPT.RowHeadersWidth = 51;
            dtgDanhSachCTPT.RowTemplate.Height = 24;
            dtgDanhSachCTPT.Size = new Size(1150, 554);
            dtgDanhSachCTPT.TabIndex = 13;
            // 
            // btnThoat
            // 
            btnThoat.BackColor = SystemColors.GradientActiveCaption;
            btnThoat.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnThoat.Location = new Point(499, 808);
            btnThoat.Margin = new Padding(3, 4, 3, 4);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(137, 59);
            btnThoat.TabIndex = 15;
            btnThoat.Text = "OK";
            btnThoat.UseVisualStyleBackColor = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.NhanVien1;
            pictureBox3.Location = new Point(834, 124);
            pictureBox3.Margin = new Padding(3, 4, 3, 4);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(55, 62);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 11;
            pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.CalendarPick;
            pictureBox2.Location = new Point(444, 124);
            pictureBox2.Margin = new Padding(3, 4, 3, 4);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(55, 62);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 9;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Name;
            pictureBox1.Location = new Point(12, 124);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(55, 62);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // FormChiTietPhieuThue
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1174, 881);
            Controls.Add(btnThoat);
            Controls.Add(dtgDanhSachCTPT);
            Controls.Add(lbHoTenNV);
            Controls.Add(pictureBox3);
            Controls.Add(lbThoiGianLP);
            Controls.Add(pictureBox2);
            Controls.Add(lbHoTenKH);
            Controls.Add(pictureBox1);
            Controls.Add(lbSoPhieu);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormChiTietPhieuThue";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Chi tiết phiếu thuê";
            ((System.ComponentModel.ISupportInitialize)dtgDanhSachCTPT).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbSoPhieu;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbHoTenKH;
        private System.Windows.Forms.Label lbThoiGianLP;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lbHoTenNV;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.DataGridView dtgDanhSachCTPT;
        private System.Windows.Forms.Button btnThoat;
    }
}