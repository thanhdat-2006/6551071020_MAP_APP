namespace HotelManagementApp.KhachHang
{
    partial class FormSuaKhachHang
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
            btnCapNhat = new Button();
            panel1 = new Panel();
            txtMaKH = new TextBox();
            label4 = new Label();
            cbGioiTinh = new ComboBox();
            label7 = new Label();
            txtSoDienThoai = new TextBox();
            label3 = new Label();
            txtQuocTich = new TextBox();
            label2 = new Label();
            txtCCCD = new TextBox();
            label1 = new Label();
            txtHoVaTen = new TextBox();
            label5 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.FromArgb(192, 0, 0);
            label6.Location = new Point(144, 31);
            label6.Name = "label6";
            label6.Size = new Size(386, 29);
            label6.TabIndex = 25;
            label6.Text = "Cập nhật thông tin khách hàng";
            // 
            // btnThoat
            // 
            btnThoat.BackColor = SystemColors.GradientActiveCaption;
            btnThoat.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnThoat.Location = new Point(345, 531);
            btnThoat.Margin = new Padding(3, 4, 3, 4);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(137, 59);
            btnThoat.TabIndex = 24;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = false;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnCapNhat
            // 
            btnCapNhat.BackColor = Color.Moccasin;
            btnCapNhat.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCapNhat.Location = new Point(145, 531);
            btnCapNhat.Margin = new Padding(3, 4, 3, 4);
            btnCapNhat.Name = "btnCapNhat";
            btnCapNhat.Size = new Size(137, 59);
            btnCapNhat.TabIndex = 23;
            btnCapNhat.Text = "Cập nhật";
            btnCapNhat.UseVisualStyleBackColor = false;
            btnCapNhat.Click += btnCapNhat_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(txtMaKH);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(cbGioiTinh);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(txtSoDienThoai);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txtQuocTich);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtCCCD);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtHoVaTen);
            panel1.Controls.Add(label5);
            panel1.Location = new Point(40, 98);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(548, 426);
            panel1.TabIndex = 22;
            // 
            // txtMaKH
            // 
            txtMaKH.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMaKH.Location = new Point(243, 30);
            txtMaKH.Margin = new Padding(3, 4, 3, 4);
            txtMaKH.Name = "txtMaKH";
            txtMaKH.ReadOnly = true;
            txtMaKH.Size = new Size(290, 30);
            txtMaKH.TabIndex = 27;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(104, 32);
            label4.Name = "label4";
            label4.Size = new Size(79, 26);
            label4.TabIndex = 26;
            label4.Text = "Mã KH";
            // 
            // cbGioiTinh
            // 
            cbGioiTinh.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbGioiTinh.FormattingEnabled = true;
            cbGioiTinh.Items.AddRange(new object[] { "Nam", "Nữ" });
            cbGioiTinh.Location = new Point(243, 348);
            cbGioiTinh.Margin = new Padding(3, 4, 3, 4);
            cbGioiTinh.Name = "cbGioiTinh";
            cbGioiTinh.Size = new Size(290, 30);
            cbGioiTinh.TabIndex = 25;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(83, 226);
            label7.Name = "label7";
            label7.Size = new Size(139, 26);
            label7.TabIndex = 24;
            label7.Text = "Số điện thoại";
            // 
            // txtSoDienThoai
            // 
            txtSoDienThoai.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSoDienThoai.Location = new Point(243, 221);
            txtSoDienThoai.Margin = new Padding(3, 4, 3, 4);
            txtSoDienThoai.Name = "txtSoDienThoai";
            txtSoDienThoai.Size = new Size(290, 30);
            txtSoDienThoai.TabIndex = 23;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(130, 352);
            label3.Name = "label3";
            label3.Size = new Size(92, 26);
            label3.TabIndex = 22;
            label3.Text = "Giới tính";
            // 
            // txtQuocTich
            // 
            txtQuocTich.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtQuocTich.Location = new Point(243, 288);
            txtQuocTich.Margin = new Padding(3, 4, 3, 4);
            txtQuocTich.Name = "txtQuocTich";
            txtQuocTich.Size = new Size(290, 30);
            txtQuocTich.TabIndex = 21;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(124, 288);
            label2.Name = "label2";
            label2.Size = new Size(104, 26);
            label2.TabIndex = 20;
            label2.Text = "Quốc tịch";
            // 
            // txtCCCD
            // 
            txtCCCD.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCCCD.Location = new Point(243, 156);
            txtCCCD.Margin = new Padding(3, 4, 3, 4);
            txtCCCD.Name = "txtCCCD";
            txtCCCD.Size = new Size(290, 30);
            txtCCCD.TabIndex = 19;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(14, 159);
            label1.Name = "label1";
            label1.Size = new Size(201, 26);
            label1.TabIndex = 18;
            label1.Text = "Số CCCD/Passport";
            // 
            // txtHoVaTen
            // 
            txtHoVaTen.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtHoVaTen.Location = new Point(243, 96);
            txtHoVaTen.Margin = new Padding(3, 4, 3, 4);
            txtHoVaTen.Name = "txtHoVaTen";
            txtHoVaTen.Size = new Size(290, 30);
            txtHoVaTen.TabIndex = 17;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(104, 99);
            label5.Name = "label5";
            label5.Size = new Size(105, 26);
            label5.TabIndex = 16;
            label5.Text = "Họ và tên";
            // 
            // FormSuaKhachHang
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(628, 620);
            Controls.Add(label6);
            Controls.Add(btnThoat);
            Controls.Add(btnCapNhat);
            Controls.Add(panel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormSuaKhachHang";
            Text = "FormSuaKhachHang";
            Load += FormSuaKhachHang_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtMaKH;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbGioiTinh;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSoDienThoai;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtQuocTich;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCCCD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtHoVaTen;
        private System.Windows.Forms.Label label5;
    }
}