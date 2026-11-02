namespace HotelManagementApp.DichVu
{
    partial class FormDanhSachDichVu
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
            btnThemMoi = new Button();
            dtgDanhSachDichVu = new DataGridView();
            btnXuatExcel = new Button();
            txtTimKiem = new TextBox();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dtgDanhSachDichVu).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnThemMoi
            // 
            btnThemMoi.BackColor = Color.LightPink;
            btnThemMoi.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThemMoi.Location = new Point(673, 28);
            btnThemMoi.Margin = new Padding(3, 4, 3, 4);
            btnThemMoi.Name = "btnThemMoi";
            btnThemMoi.Size = new Size(167, 46);
            btnThemMoi.TabIndex = 15;
            btnThemMoi.Text = "Thêm mới";
            btnThemMoi.UseVisualStyleBackColor = false;
            btnThemMoi.Click += btnThemMoi_Click;
            // 
            // dtgDanhSachDichVu
            // 
            dtgDanhSachDichVu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgDanhSachDichVu.Location = new Point(12, 90);
            dtgDanhSachDichVu.Margin = new Padding(3, 4, 3, 4);
            dtgDanhSachDichVu.Name = "dtgDanhSachDichVu";
            dtgDanhSachDichVu.RowHeadersWidth = 51;
            dtgDanhSachDichVu.RowTemplate.Height = 24;
            dtgDanhSachDichVu.Size = new Size(945, 679);
            dtgDanhSachDichVu.TabIndex = 14;
            dtgDanhSachDichVu.CellClick += dtgDanhSachDichVu_CellClick;
            // 
            // btnXuatExcel
            // 
            btnXuatExcel.BackColor = Color.DarkTurquoise;
            btnXuatExcel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnXuatExcel.Location = new Point(475, 28);
            btnXuatExcel.Margin = new Padding(3, 4, 3, 4);
            btnXuatExcel.Name = "btnXuatExcel";
            btnXuatExcel.Size = new Size(167, 46);
            btnXuatExcel.TabIndex = 13;
            btnXuatExcel.Text = "Xuất file Excel";
            btnXuatExcel.UseVisualStyleBackColor = false;
            btnXuatExcel.Click += btnXuatExcel_Click;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTimKiem.Location = new Point(73, 34);
            txtTimKiem.Margin = new Padding(3, 4, 3, 4);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(187, 32);
            txtTimKiem.TabIndex = 11;
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.search;
            pictureBox1.Location = new Point(28, 28);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(39, 46);
            pictureBox1.TabIndex = 12;
            pictureBox1.TabStop = false;
            // 
            // FormDanhSachDichVu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(961, 784);
            Controls.Add(btnThemMoi);
            Controls.Add(dtgDanhSachDichVu);
            Controls.Add(btnXuatExcel);
            Controls.Add(pictureBox1);
            Controls.Add(txtTimKiem);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormDanhSachDichVu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý thông tin dịch vụ";
            ((System.ComponentModel.ISupportInitialize)dtgDanhSachDichVu).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnThemMoi;
        private System.Windows.Forms.DataGridView dtgDanhSachDichVu;
        private System.Windows.Forms.Button btnXuatExcel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtTimKiem;
    }
}