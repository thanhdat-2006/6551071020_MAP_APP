namespace HotelManagementApp.PhieuThue
{
    partial class FormDanhSachDichVuPhongDaDung
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
            LabelThemTienNghi = new Label();
            lbSoPhong = new Label();
            lbSoCTPhieu = new Label();
            dtgDanhSachDichVu = new DataGridView();
            btnThemDV = new Button();
            btnThoat = new Button();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dtgDanhSachDichVu).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // LabelThemTienNghi
            // 
            LabelThemTienNghi.AutoSize = true;
            LabelThemTienNghi.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelThemTienNghi.ForeColor = Color.FromArgb(192, 0, 0);
            LabelThemTienNghi.Location = new Point(214, 11);
            LabelThemTienNghi.Margin = new Padding(4, 0, 4, 0);
            LabelThemTienNghi.Name = "LabelThemTienNghi";
            LabelThemTienNghi.Size = new Size(448, 46);
            LabelThemTienNghi.TabIndex = 19;
            LabelThemTienNghi.Text = "Danh sách dịch vụ đã dùng";
            // 
            // lbSoPhong
            // 
            lbSoPhong.AutoSize = true;
            lbSoPhong.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbSoPhong.ForeColor = Color.FromArgb(192, 64, 0);
            lbSoPhong.Location = new Point(82, 101);
            lbSoPhong.Name = "lbSoPhong";
            lbSoPhong.Size = new Size(76, 26);
            lbSoPhong.TabIndex = 22;
            lbSoPhong.Text = "label1";
            // 
            // lbSoCTPhieu
            // 
            lbSoCTPhieu.AutoSize = true;
            lbSoCTPhieu.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbSoCTPhieu.ForeColor = Color.Green;
            lbSoCTPhieu.Location = new Point(483, 101);
            lbSoCTPhieu.Name = "lbSoCTPhieu";
            lbSoCTPhieu.Size = new Size(76, 26);
            lbSoCTPhieu.TabIndex = 23;
            lbSoCTPhieu.Text = "label2";
            // 
            // dtgDanhSachDichVu
            // 
            dtgDanhSachDichVu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgDanhSachDichVu.Location = new Point(12, 166);
            dtgDanhSachDichVu.Margin = new Padding(3, 4, 3, 4);
            dtgDanhSachDichVu.Name = "dtgDanhSachDichVu";
            dtgDanhSachDichVu.RowHeadersWidth = 51;
            dtgDanhSachDichVu.RowTemplate.Height = 24;
            dtgDanhSachDichVu.Size = new Size(859, 391);
            dtgDanhSachDichVu.TabIndex = 24;
            // 
            // btnThemDV
            // 
            btnThemDV.BackColor = Color.Orchid;
            btnThemDV.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnThemDV.Location = new Point(180, 584);
            btnThemDV.Margin = new Padding(3, 4, 3, 4);
            btnThemDV.Name = "btnThemDV";
            btnThemDV.Size = new Size(193, 59);
            btnThemDV.TabIndex = 25;
            btnThemDV.Text = "Thêm dịch vụ";
            btnThemDV.UseVisualStyleBackColor = false;
            btnThemDV.Click += btnThemDV_Click;
            // 
            // btnThoat
            // 
            btnThoat.BackColor = SystemColors.GradientActiveCaption;
            btnThoat.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnThoat.Location = new Point(434, 584);
            btnThoat.Margin = new Padding(3, 4, 3, 4);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(137, 59);
            btnThoat.TabIndex = 26;
            btnThoat.Text = "OK";
            btnThoat.UseVisualStyleBackColor = false;
            btnThoat.Click += btnThoat_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.PhieuThue;
            pictureBox2.Location = new Point(434, 84);
            pictureBox2.Margin = new Padding(3, 4, 3, 4);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(43, 59);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 21;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Phong;
            pictureBox1.Location = new Point(12, 84);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(64, 59);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 20;
            pictureBox1.TabStop = false;
            // 
            // FormDanhSachDichVuPhongDaDung
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(883, 658);
            Controls.Add(btnThoat);
            Controls.Add(btnThemDV);
            Controls.Add(dtgDanhSachDichVu);
            Controls.Add(lbSoCTPhieu);
            Controls.Add(lbSoPhong);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(LabelThemTienNghi);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormDanhSachDichVuPhongDaDung";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý dịch vụ đã dùng theo phòng";
            ((System.ComponentModel.ISupportInitialize)dtgDanhSachDichVu).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelThemTienNghi;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lbSoPhong;
        private System.Windows.Forms.Label lbSoCTPhieu;
        private System.Windows.Forms.DataGridView dtgDanhSachDichVu;
        private System.Windows.Forms.Button btnThemDV;
        private System.Windows.Forms.Button btnThoat;
    }
}