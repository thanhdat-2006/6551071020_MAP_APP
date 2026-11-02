namespace HotelManagementApp.NhanVien
{
    partial class FormThemNhanVien
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
            label6 = new Label();
            btnThoat = new Button();
            btnThemMoi = new Button();
            panel1 = new Panel();
            txtMaNV = new TextBox();
            label11 = new Label();
            cbGioiTinh = new ComboBox();
            label10 = new Label();
            txtEmail = new TextBox();
            label9 = new Label();
            txtDiaChi = new TextBox();
            label8 = new Label();
            txtSoCCCD = new TextBox();
            label4 = new Label();
            dtNgaySinh = new DateTimePicker();
            txtLuong = new TextBox();
            cbChucVu = new ComboBox();
            label7 = new Label();
            label3 = new Label();
            txtSoDT = new TextBox();
            label2 = new Label();
            label1 = new Label();
            txtHoTenNV = new TextBox();
            label5 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.FromArgb(192, 0, 0);
            label6.Location = new Point(400, 31);
            label6.Name = "label6";
            label6.Size = new Size(323, 29);
            label6.TabIndex = 21;
            label6.Text = "Thêm thông tin nhân viên";
            // 
            // btnThoat
            // 
            btnThoat.BackColor = SystemColors.GradientActiveCaption;
            btnThoat.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnThoat.Location = new Point(555, 475);
            btnThoat.Margin = new Padding(3, 4, 3, 4);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(137, 59);
            btnThoat.TabIndex = 20;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = false;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnThemMoi
            // 
            btnThemMoi.BackColor = Color.Moccasin;
            btnThemMoi.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnThemMoi.Location = new Point(355, 475);
            btnThemMoi.Margin = new Padding(3, 4, 3, 4);
            btnThemMoi.Name = "btnThemMoi";
            btnThemMoi.Size = new Size(137, 59);
            btnThemMoi.TabIndex = 19;
            btnThemMoi.Text = "Thêm mới";
            btnThemMoi.UseVisualStyleBackColor = false;
            btnThemMoi.Click += btnThemMoi_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(txtMaNV);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(cbGioiTinh);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(txtEmail);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(txtDiaChi);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(txtSoCCCD);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(dtNgaySinh);
            panel1.Controls.Add(txtLuong);
            panel1.Controls.Add(cbChucVu);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txtSoDT);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtHoTenNV);
            panel1.Controls.Add(label5);
            panel1.Location = new Point(12, 84);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1020, 355);
            panel1.TabIndex = 18;
            // 
            // txtMaNV
            // 
            txtMaNV.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMaNV.Location = new Point(696, 289);
            txtMaNV.Margin = new Padding(3, 4, 3, 4);
            txtMaNV.Name = "txtMaNV";
            txtMaNV.Size = new Size(290, 30);
            txtMaNV.TabIndex = 38;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.Location = new Point(601, 291);
            label11.Name = "label11";
            label11.Size = new Size(79, 26);
            label11.TabIndex = 37;
            label11.Text = "Mã NV";
            // 
            // cbGioiTinh
            // 
            cbGioiTinh.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbGioiTinh.FormattingEnabled = true;
            cbGioiTinh.Items.AddRange(new object[] { "Nam", "Nữ" });
            cbGioiTinh.Location = new Point(202, 294);
            cbGioiTinh.Margin = new Padding(3, 4, 3, 4);
            cbGioiTinh.Name = "cbGioiTinh";
            cbGioiTinh.Size = new Size(290, 30);
            cbGioiTinh.TabIndex = 36;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(72, 294);
            label10.Name = "label10";
            label10.Size = new Size(92, 26);
            label10.TabIndex = 35;
            label10.Text = "Giới tính";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEmail.Location = new Point(696, 211);
            txtEmail.Margin = new Padding(3, 4, 3, 4);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(290, 30);
            txtEmail.TabIndex = 34;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(612, 214);
            label9.Name = "label9";
            label9.Size = new Size(68, 26);
            label9.TabIndex = 33;
            label9.Text = "Email";
            // 
            // txtDiaChi
            // 
            txtDiaChi.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDiaChi.Location = new Point(696, 152);
            txtDiaChi.Margin = new Padding(3, 4, 3, 4);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(290, 30);
            txtDiaChi.TabIndex = 32;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(601, 152);
            label8.Name = "label8";
            label8.Size = new Size(79, 26);
            label8.TabIndex = 31;
            label8.Text = "Địa chỉ";
            // 
            // txtSoCCCD
            // 
            txtSoCCCD.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSoCCCD.Location = new Point(696, 80);
            txtSoCCCD.Margin = new Padding(3, 4, 3, 4);
            txtSoCCCD.Name = "txtSoCCCD";
            txtSoCCCD.Size = new Size(290, 30);
            txtSoCCCD.TabIndex = 30;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(571, 88);
            label4.Name = "label4";
            label4.Size = new Size(109, 26);
            label4.TabIndex = 29;
            label4.Text = "Số CCCD";
            // 
            // dtNgaySinh
            // 
            dtNgaySinh.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtNgaySinh.Location = new Point(696, 19);
            dtNgaySinh.Margin = new Padding(3, 4, 3, 4);
            dtNgaySinh.Name = "dtNgaySinh";
            dtNgaySinh.Size = new Size(290, 28);
            dtNgaySinh.TabIndex = 28;
            // 
            // txtLuong
            // 
            txtLuong.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtLuong.Location = new Point(202, 150);
            txtLuong.Margin = new Padding(3, 4, 3, 4);
            txtLuong.Name = "txtLuong";
            txtLuong.Size = new Size(290, 30);
            txtLuong.TabIndex = 27;
            // 
            // cbChucVu
            // 
            cbChucVu.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbChucVu.FormattingEnabled = true;
            cbChucVu.Items.AddRange(new object[] { "Người quản trị hệ thống", "Quản lý khách sạn", "Nhân viên" });
            cbChucVu.Location = new Point(202, 82);
            cbChucVu.Margin = new Padding(3, 4, 3, 4);
            cbChucVu.Name = "cbChucVu";
            cbChucVu.Size = new Size(290, 30);
            cbChucVu.TabIndex = 26;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(89, 152);
            label7.Name = "label7";
            label7.Size = new Size(72, 26);
            label7.TabIndex = 24;
            label7.Text = "Lương";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(571, 21);
            label3.Name = "label3";
            label3.Size = new Size(109, 26);
            label3.TabIndex = 22;
            label3.Text = "Ngày sinh";
            // 
            // txtSoDT
            // 
            txtSoDT.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSoDT.Location = new Point(202, 214);
            txtSoDT.Margin = new Padding(3, 4, 3, 4);
            txtSoDT.Name = "txtSoDT";
            txtSoDT.Size = new Size(290, 30);
            txtSoDT.TabIndex = 21;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(25, 216);
            label2.Name = "label2";
            label2.Size = new Size(139, 26);
            label2.TabIndex = 20;
            label2.Text = "Số điện thoại";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(72, 82);
            label1.Name = "label1";
            label1.Size = new Size(92, 26);
            label1.TabIndex = 18;
            label1.Text = "Chức vụ";
            // 
            // txtHoTenNV
            // 
            txtHoTenNV.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtHoTenNV.Location = new Point(202, 22);
            txtHoTenNV.Margin = new Padding(3, 4, 3, 4);
            txtHoTenNV.Name = "txtHoTenNV";
            txtHoTenNV.Size = new Size(290, 30);
            txtHoTenNV.TabIndex = 17;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(59, 19);
            label5.Name = "label5";
            label5.Size = new Size(105, 26);
            label5.TabIndex = 16;
            label5.Text = "Họ và tên";
            // 
            // FormThemNhanVien
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1076, 558);
            Controls.Add(label6);
            Controls.Add(btnThoat);
            Controls.Add(btnThemMoi);
            Controls.Add(panel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormThemNhanVien";
            Text = "FormThemNhanVien";
            Load += FormThemNhanVien_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnThemMoi;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSoDT;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtHoTenNV;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSoCCCD;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtNgaySinh;
        private System.Windows.Forms.TextBox txtLuong;
        private System.Windows.Forms.ComboBox cbChucVu;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbGioiTinh;
        private System.Windows.Forms.Label label10;
    }
}