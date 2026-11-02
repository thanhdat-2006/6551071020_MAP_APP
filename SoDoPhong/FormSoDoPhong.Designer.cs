namespace HotelManagementApp.SoDoPhong
{
    partial class FormSoDoPhong
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
            components = new System.ComponentModel.Container();
            panel1 = new Panel();
            panel4 = new Panel();
            rdbTatCaPhong = new RadioButton();
            rdbPhongChuaDon = new RadioButton();
            rdbPhongDaDonDep = new RadioButton();
            label2 = new Label();
            panel3 = new Panel();
            rdbTatCaLoaiPhong = new RadioButton();
            rdbPhongVipDoi = new RadioButton();
            rdbPhongVipDon = new RadioButton();
            rdbPhongThuongDoi = new RadioButton();
            rdbPhongThuongDon = new RadioButton();
            label1 = new Label();
            panel2 = new Panel();
            rdbTatCaTrangThaiPhong = new RadioButton();
            rdbPhongDangSuaChua = new RadioButton();
            rdbPhongDangThue = new RadioButton();
            rdbPhongDaDat = new RadioButton();
            rdbPhongTrong = new RadioButton();
            LabelTrangThaiPhong = new Label();
            panel5 = new Panel();
            pictureBox1 = new PictureBox();
            txtSearchMaPhong = new TextBox();
            label4 = new Label();
            dateTimePicker2 = new DateTimePicker();
            label3 = new Label();
            dtNgayChon = new DateTimePicker();
            toolTip1 = new ToolTip(components);
            btnDatPhong = new Button();
            dataGridViewPhong = new DataGridView();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPhong).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.GreenYellow;
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panel1.Location = new Point(0, -1);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(267, 788);
            panel1.TabIndex = 0;
            // 
            // panel4
            // 
            panel4.Controls.Add(rdbTatCaPhong);
            panel4.Controls.Add(rdbPhongChuaDon);
            panel4.Controls.Add(rdbPhongDaDonDep);
            panel4.Controls.Add(label2);
            panel4.Location = new Point(12, 595);
            panel4.Margin = new Padding(3, 4, 3, 4);
            panel4.Name = "panel4";
            panel4.Size = new Size(246, 188);
            panel4.TabIndex = 8;
            // 
            // rdbTatCaPhong
            // 
            rdbTatCaPhong.AutoSize = true;
            rdbTatCaPhong.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rdbTatCaPhong.Location = new Point(9, 149);
            rdbTatCaPhong.Margin = new Padding(3, 4, 3, 4);
            rdbTatCaPhong.Name = "rdbTatCaPhong";
            rdbTatCaPhong.Size = new Size(88, 29);
            rdbTatCaPhong.TabIndex = 4;
            rdbTatCaPhong.TabStop = true;
            rdbTatCaPhong.Text = "Tất cả";
            rdbTatCaPhong.UseVisualStyleBackColor = true;
            // 
            // rdbPhongChuaDon
            // 
            rdbPhongChuaDon.AutoSize = true;
            rdbPhongChuaDon.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rdbPhongChuaDon.Location = new Point(9, 105);
            rdbPhongChuaDon.Margin = new Padding(3, 4, 3, 4);
            rdbPhongChuaDon.Name = "rdbPhongChuaDon";
            rdbPhongChuaDon.Size = new Size(157, 29);
            rdbPhongChuaDon.TabIndex = 3;
            rdbPhongChuaDon.TabStop = true;
            rdbPhongChuaDon.Text = "Chưa dọn dẹp";
            rdbPhongChuaDon.UseVisualStyleBackColor = true;
            // 
            // rdbPhongDaDonDep
            // 
            rdbPhongDaDonDep.AutoSize = true;
            rdbPhongDaDonDep.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rdbPhongDaDonDep.Location = new Point(9, 61);
            rdbPhongDaDonDep.Margin = new Padding(3, 4, 3, 4);
            rdbPhongDaDonDep.Name = "rdbPhongDaDonDep";
            rdbPhongDaDonDep.Size = new Size(134, 29);
            rdbPhongDaDonDep.TabIndex = 2;
            rdbPhongDaDonDep.TabStop = true;
            rdbPhongDaDonDep.Text = "Đã dọn dẹp";
            rdbPhongDaDonDep.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(11, 18);
            label2.Name = "label2";
            label2.Size = new Size(235, 32);
            label2.TabIndex = 1;
            label2.Text = "Tình trạng dọn dẹp";
            // 
            // panel3
            // 
            panel3.Controls.Add(rdbTatCaLoaiPhong);
            panel3.Controls.Add(rdbPhongVipDoi);
            panel3.Controls.Add(rdbPhongVipDon);
            panel3.Controls.Add(rdbPhongThuongDoi);
            panel3.Controls.Add(rdbPhongThuongDon);
            panel3.Controls.Add(label1);
            panel3.Location = new Point(6, 298);
            panel3.Margin = new Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(255, 279);
            panel3.TabIndex = 7;
            // 
            // rdbTatCaLoaiPhong
            // 
            rdbTatCaLoaiPhong.AutoSize = true;
            rdbTatCaLoaiPhong.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rdbTatCaLoaiPhong.Location = new Point(9, 236);
            rdbTatCaLoaiPhong.Margin = new Padding(3, 4, 3, 4);
            rdbTatCaLoaiPhong.Name = "rdbTatCaLoaiPhong";
            rdbTatCaLoaiPhong.Size = new Size(148, 29);
            rdbTatCaLoaiPhong.TabIndex = 7;
            rdbTatCaLoaiPhong.TabStop = true;
            rdbTatCaLoaiPhong.Text = "Tất cả phòng";
            rdbTatCaLoaiPhong.UseVisualStyleBackColor = true;
            // 
            // rdbPhongVipDoi
            // 
            rdbPhongVipDoi.AutoSize = true;
            rdbPhongVipDoi.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rdbPhongVipDoi.Location = new Point(9, 192);
            rdbPhongVipDoi.Margin = new Padding(3, 4, 3, 4);
            rdbPhongVipDoi.Name = "rdbPhongVipDoi";
            rdbPhongVipDoi.Size = new Size(158, 29);
            rdbPhongVipDoi.TabIndex = 5;
            rdbPhongVipDoi.TabStop = true;
            rdbPhongVipDoi.Text = "Phòng VIP đôi";
            rdbPhongVipDoi.UseVisualStyleBackColor = true;
            // 
            // rdbPhongVipDon
            // 
            rdbPhongVipDon.AutoSize = true;
            rdbPhongVipDon.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rdbPhongVipDon.Location = new Point(9, 149);
            rdbPhongVipDon.Margin = new Padding(3, 4, 3, 4);
            rdbPhongVipDon.Name = "rdbPhongVipDon";
            rdbPhongVipDon.Size = new Size(165, 29);
            rdbPhongVipDon.TabIndex = 4;
            rdbPhongVipDon.TabStop = true;
            rdbPhongVipDon.Text = "Phòng VIP đơn";
            rdbPhongVipDon.UseVisualStyleBackColor = true;
            // 
            // rdbPhongThuongDoi
            // 
            rdbPhongThuongDoi.AutoSize = true;
            rdbPhongThuongDoi.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rdbPhongThuongDoi.Location = new Point(9, 105);
            rdbPhongThuongDoi.Margin = new Padding(3, 4, 3, 4);
            rdbPhongThuongDoi.Name = "rdbPhongThuongDoi";
            rdbPhongThuongDoi.Size = new Size(186, 29);
            rdbPhongThuongDoi.TabIndex = 3;
            rdbPhongThuongDoi.TabStop = true;
            rdbPhongThuongDoi.Text = "Phòng thường đôi";
            rdbPhongThuongDoi.UseVisualStyleBackColor = true;
            // 
            // rdbPhongThuongDon
            // 
            rdbPhongThuongDon.AutoSize = true;
            rdbPhongThuongDon.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rdbPhongThuongDon.Location = new Point(9, 61);
            rdbPhongThuongDon.Margin = new Padding(3, 4, 3, 4);
            rdbPhongThuongDon.Name = "rdbPhongThuongDon";
            rdbPhongThuongDon.Size = new Size(193, 29);
            rdbPhongThuongDon.TabIndex = 2;
            rdbPhongThuongDon.TabStop = true;
            rdbPhongThuongDon.Text = "Phòng thường đơn";
            rdbPhongThuongDon.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(24, 12);
            label1.Name = "label1";
            label1.Size = new Size(142, 32);
            label1.TabIndex = 1;
            label1.Text = "Loại phòng";
            // 
            // panel2
            // 
            panel2.Controls.Add(rdbTatCaTrangThaiPhong);
            panel2.Controls.Add(rdbPhongDangSuaChua);
            panel2.Controls.Add(rdbPhongDangThue);
            panel2.Controls.Add(rdbPhongDaDat);
            panel2.Controls.Add(rdbPhongTrong);
            panel2.Controls.Add(LabelTrangThaiPhong);
            panel2.Location = new Point(3, 0);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(255, 279);
            panel2.TabIndex = 1;
            // 
            // rdbTatCaTrangThaiPhong
            //
            rdbTatCaTrangThaiPhong.AutoSize = true;
            rdbTatCaTrangThaiPhong.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rdbTatCaTrangThaiPhong.Location = new Point(9, 236);
            rdbTatCaTrangThaiPhong.Margin = new Padding(3, 4, 3, 4);
            rdbTatCaTrangThaiPhong.Name = "rdbTatCaTrangThaiPhong";
            rdbTatCaTrangThaiPhong.Size = new Size(148, 29);
            rdbTatCaTrangThaiPhong.TabIndex = 6;
            rdbTatCaTrangThaiPhong.TabStop = true;
            rdbTatCaTrangThaiPhong.Text = "Tất cả phòng";
            rdbTatCaTrangThaiPhong.UseVisualStyleBackColor = true;
            // 
            // rdbPhongDangSuaChua
            // 
            rdbPhongDangSuaChua.AutoSize = true;
            rdbPhongDangSuaChua.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rdbPhongDangSuaChua.Location = new Point(9, 192);
            rdbPhongDangSuaChua.Margin = new Padding(3, 4, 3, 4);
            rdbPhongDangSuaChua.Name = "rdbPhongDangSuaChua";
            rdbPhongDangSuaChua.Size = new Size(224, 29);
            rdbPhongDangSuaChua.TabIndex = 5;
            rdbPhongDangSuaChua.TabStop = true;
            rdbPhongDangSuaChua.Text = "Phòng đang sửa chữa";
            rdbPhongDangSuaChua.UseVisualStyleBackColor = true;
            // 
            // rdbPhongDangThue
            // 
            rdbPhongDangThue.AutoSize = true;
            rdbPhongDangThue.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rdbPhongDangThue.Location = new Point(9, 149);
            rdbPhongDangThue.Margin = new Padding(3, 4, 3, 4);
            rdbPhongDangThue.Name = "rdbPhongDangThue";
            rdbPhongDangThue.Size = new Size(182, 29);
            rdbPhongDangThue.TabIndex = 4;
            rdbPhongDangThue.TabStop = true;
            rdbPhongDangThue.Text = "Phòng đang thuê";
            rdbPhongDangThue.UseVisualStyleBackColor = true;
            // 
            // rdbPhongDaDat
            // 
            rdbPhongDaDat.AutoSize = true;
            rdbPhongDaDat.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rdbPhongDaDat.Location = new Point(9, 105);
            rdbPhongDaDat.Margin = new Padding(3, 4, 3, 4);
            rdbPhongDaDat.Name = "rdbPhongDaDat";
            rdbPhongDaDat.Size = new Size(149, 29);
            rdbPhongDaDat.TabIndex = 3;
            rdbPhongDaDat.TabStop = true;
            rdbPhongDaDat.Text = "Phòng đã đặt";
            rdbPhongDaDat.UseVisualStyleBackColor = true;
            // 
            // rdbPhongTrong
            // 
            rdbPhongTrong.AutoSize = true;
            rdbPhongTrong.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rdbPhongTrong.Location = new Point(9, 61);
            rdbPhongTrong.Margin = new Padding(3, 4, 3, 4);
            rdbPhongTrong.Name = "rdbPhongTrong";
            rdbPhongTrong.Size = new Size(139, 29);
            rdbPhongTrong.TabIndex = 2;
            rdbPhongTrong.TabStop = true;
            rdbPhongTrong.Text = "Phòng trống";
            rdbPhongTrong.UseVisualStyleBackColor = true;
            // 
            // LabelTrangThaiPhong
            // 
            LabelTrangThaiPhong.AutoSize = true;
            LabelTrangThaiPhong.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelTrangThaiPhong.Location = new Point(24, 12);
            LabelTrangThaiPhong.Name = "LabelTrangThaiPhong";
            LabelTrangThaiPhong.Size = new Size(210, 32);
            LabelTrangThaiPhong.TabIndex = 1;
            LabelTrangThaiPhong.Text = "Trạng thái phòng";
            // 
            // panel5
            // 
            panel5.Controls.Add(pictureBox1);
            panel5.Controls.Add(txtSearchMaPhong);
            panel5.Controls.Add(label4);
            panel5.Controls.Add(dateTimePicker2);
            panel5.Controls.Add(label3);
            panel5.Controls.Add(dtNgayChon);
            panel5.Location = new Point(274, -1);
            panel5.Margin = new Padding(3, 4, 3, 4);
            panel5.Name = "panel5";
            panel5.Size = new Size(724, 66);
            panel5.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.search;
            pictureBox1.Location = new Point(522, 16);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(30, 40);
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // txtSearchMaPhong
            // 
            txtSearchMaPhong.Location = new Point(563, 25);
            txtSearchMaPhong.Margin = new Padding(3, 4, 3, 4);
            txtSearchMaPhong.Name = "txtSearchMaPhong";
            txtSearchMaPhong.Size = new Size(149, 27);
            txtSearchMaPhong.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(323, 11);
            label4.Name = "label4";
            label4.Size = new Size(69, 20);
            label4.TabIndex = 3;
            label4.Text = "Chọn giờ";
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(269, 35);
            dateTimePicker2.Margin = new Padding(3, 4, 3, 4);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(200, 27);
            dateTimePicker2.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(85, 11);
            label3.Name = "label3";
            label3.Size = new Size(79, 20);
            label3.TabIndex = 1;
            label3.Text = "Chọn ngày";
            // 
            // dtNgayChon
            // 
            dtNgayChon.Location = new Point(31, 35);
            dtNgayChon.Margin = new Padding(3, 4, 3, 4);
            dtNgayChon.Name = "dtNgayChon";
            dtNgayChon.Size = new Size(200, 27);
            dtNgayChon.TabIndex = 0;
            // 
            // toolTip1
            // 
            toolTip1.ToolTipTitle = "Nhập số phòng";
            // 
            // btnDatPhong
            // 
            btnDatPhong.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDatPhong.ForeColor = Color.Blue;
            btnDatPhong.Location = new Point(1031, 10);
            btnDatPhong.Margin = new Padding(3, 4, 3, 4);
            btnDatPhong.Name = "btnDatPhong";
            btnDatPhong.Size = new Size(166, 54);
            btnDatPhong.TabIndex = 3;
            btnDatPhong.Text = "Đặt phòng";
            btnDatPhong.UseVisualStyleBackColor = true;
            // 
            // dataGridViewPhong
            // 
            dataGridViewPhong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPhong.Location = new Point(274, 74);
            dataGridViewPhong.Margin = new Padding(3, 4, 3, 4);
            dataGridViewPhong.Name = "dataGridViewPhong";
            dataGridViewPhong.RowHeadersWidth = 51;
            dataGridViewPhong.RowTemplate.Height = 24;
            dataGridViewPhong.Size = new Size(990, 713);
            dataGridViewPhong.TabIndex = 4;
            // 
            // FormSoDoPhong
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Honeydew;
            ClientSize = new Size(1276, 851);
            Controls.Add(dataGridViewPhong);
            Controls.Add(btnDatPhong);
            Controls.Add(panel5);
            Controls.Add(panel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormSoDoPhong";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sơ đồ phòng";
            panel1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPhong).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label LabelTrangThaiPhong;
        private System.Windows.Forms.RadioButton rdbPhongDangSuaChua;
        private System.Windows.Forms.RadioButton rdbPhongDangThue;
        private System.Windows.Forms.RadioButton rdbPhongDaDat;
        private System.Windows.Forms.RadioButton rdbPhongTrong;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RadioButton rdbTatCaPhong;
        private System.Windows.Forms.RadioButton rdbPhongChuaDon;
        private System.Windows.Forms.RadioButton rdbPhongDaDonDep;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton rdbPhongVipDoi;
        private System.Windows.Forms.RadioButton rdbPhongVipDon;
        private System.Windows.Forms.RadioButton rdbPhongThuongDoi;
        private System.Windows.Forms.RadioButton rdbPhongThuongDon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdbTatCaTrangThaiPhong;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtSearchMaPhong;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtNgayChon;
        private System.Windows.Forms.RadioButton rdbTatCaLoaiPhong;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnDatPhong;
        private System.Windows.Forms.DataGridView dataGridViewPhong;
    }
}