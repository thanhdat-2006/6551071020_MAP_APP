namespace HotelManagementApp.HoaDon
{
    partial class FormDanhSachHoaDon
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
            dtgDanhSachHoaDon = new DataGridView();
            txtTimKiem = new TextBox();
            pictureBox1 = new PictureBox();
            btnXuatExcel = new Button();
            dtpNgayLap = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)dtgDanhSachHoaDon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // dtgDanhSachHoaDon
            // 
            dtgDanhSachHoaDon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgDanhSachHoaDon.Location = new Point(13, 118);
            dtgDanhSachHoaDon.Margin = new Padding(3, 4, 3, 4);
            dtgDanhSachHoaDon.Name = "dtgDanhSachHoaDon";
            dtgDanhSachHoaDon.RowHeadersWidth = 51;
            dtgDanhSachHoaDon.RowTemplate.Height = 24;
            dtgDanhSachHoaDon.Size = new Size(1187, 624);
            dtgDanhSachHoaDon.TabIndex = 0;
            // 
            // txtTimKiem
            // 
            // txtTimKiem
            // 
            txtTimKiem.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTimKiem.Location = new Point(138, 29);
            txtTimKiem.Margin = new Padding(3, 4, 3, 4);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(187, 32);
            txtTimKiem.TabIndex = 26;
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.search;
            pictureBox1.Location = new Point(93, 22);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(39, 46);
            pictureBox1.TabIndex = 27;
            pictureBox1.TabStop = false;
            // 
            // btnXuatExcel
            // 
            btnXuatExcel.BackColor = Color.DarkTurquoise;
            btnXuatExcel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnXuatExcel.Location = new Point(946, 29);
            btnXuatExcel.Margin = new Padding(3, 4, 3, 4);
            btnXuatExcel.Name = "btnXuatExcel";
            btnXuatExcel.Size = new Size(167, 46);
            btnXuatExcel.TabIndex = 28;
            btnXuatExcel.Text = "Xuất file Excel";
            btnXuatExcel.UseVisualStyleBackColor = false;
            btnXuatExcel.Click += btnXuatExcel_Click;
            // 
            // dtpNgayLap
            // 
            dtpNgayLap.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpNgayLap.Location = new Point(450, 29);
            dtpNgayLap.Margin = new Padding(3, 4, 3, 4);
            dtpNgayLap.Name = "dtpNgayLap";
            dtpNgayLap.Size = new Size(361, 32);
            dtpNgayLap.TabIndex = 29;
            // 
            // FormDanhSachHoaDon
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1212, 756);
            Controls.Add(dtpNgayLap);
            Controls.Add(btnXuatExcel);
            Controls.Add(pictureBox1);
            Controls.Add(txtTimKiem);
            Controls.Add(dtgDanhSachHoaDon);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormDanhSachHoaDon";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Danh sách hóa đơn";
            Load += FormDanhSachHoaDon_Load;
            ((System.ComponentModel.ISupportInitialize)dtgDanhSachHoaDon).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }
        #endregion

        private System.Windows.Forms.DataGridView dtgDanhSachHoaDon;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnXuatExcel;
        private System.Windows.Forms.DateTimePicker dtpNgayLap;
    }
}