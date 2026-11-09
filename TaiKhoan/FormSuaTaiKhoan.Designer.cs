namespace HotelManagementApp.TaiKhoan
{
    partial class FormSuaTaiKhoan
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
            txtMaNV = new TextBox();
            cbCapDoQuyen = new ComboBox();
            label5 = new Label();
            txtMatKhau = new TextBox();
            txtTenTK = new TextBox();
            label1 = new Label();
            label7 = new Label();
            label2 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.FromArgb(192, 0, 0);
            label6.Location = new Point(141, 25);
            label6.Name = "label6";
            label6.Size = new Size(357, 29);
            label6.TabIndex = 50;
            label6.Text = "Cập nhật thông tin tài khoản";
            // 
            // btnThoat
            // 
            btnThoat.BackColor = SystemColors.GradientActiveCaption;
            btnThoat.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnThoat.Location = new Point(303, 419);
            btnThoat.Margin = new Padding(3, 4, 3, 4);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(137, 59);
            btnThoat.TabIndex = 49;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = false;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnCapNhat
            // 
            btnCapNhat.BackColor = Color.Moccasin;
            btnCapNhat.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCapNhat.Location = new Point(108, 419);
            btnCapNhat.Margin = new Padding(3, 4, 3, 4);
            btnCapNhat.Name = "btnCapNhat";
            btnCapNhat.Size = new Size(137, 59);
            btnCapNhat.TabIndex = 48;
            btnCapNhat.Text = "Cập nhật";
            btnCapNhat.UseVisualStyleBackColor = false;
            btnCapNhat.Click += btnCapNhat_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(txtMaNV);
            panel1.Controls.Add(cbCapDoQuyen);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(txtMatKhau);
            panel1.Controls.Add(txtTenTK);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(16, 84);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(541, 304);
            panel1.TabIndex = 51;
            // 
            // txtMaNV
            // 
            txtMaNV.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMaNV.Location = new Point(172, 34);
            txtMaNV.Margin = new Padding(3, 4, 3, 4);
            txtMaNV.Name = "txtMaNV";
            txtMaNV.ReadOnly = true;
            txtMaNV.Size = new Size(290, 30);
            txtMaNV.TabIndex = 47;
            // 
            // cbCapDoQuyen
            // 
            cbCapDoQuyen.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbCapDoQuyen.FormattingEnabled = true;
            cbCapDoQuyen.Items.AddRange(new object[] { "3", "2", "1", "0" });
            cbCapDoQuyen.Location = new Point(172, 230);
            cbCapDoQuyen.Margin = new Padding(3, 4, 3, 4);
            cbCapDoQuyen.Name = "cbCapDoQuyen";
            cbCapDoQuyen.Size = new Size(290, 30);
            cbCapDoQuyen.TabIndex = 46;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(7, 34);
            label5.Name = "label5";
            label5.Size = new Size(142, 26);
            label5.TabIndex = 37;
            label5.Text = "Mã nhân viên";
            // 
            // txtMatKhau
            // 
            txtMatKhau.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMatKhau.Location = new Point(172, 164);
            txtMatKhau.Margin = new Padding(3, 4, 3, 4);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.PasswordChar = '*';
            txtMatKhau.Size = new Size(290, 30);
            txtMatKhau.TabIndex = 41;
            // 
            // txtTenTK
            // 
            txtTenTK.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTenTK.Location = new Point(172, 94);
            txtTenTK.Margin = new Padding(3, 4, 3, 4);
            txtTenTK.Name = "txtTenTK";
            txtTenTK.Size = new Size(290, 30);
            txtTenTK.TabIndex = 44;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(10, 94);
            label1.Name = "label1";
            label1.Size = new Size(142, 26);
            label1.TabIndex = 39;
            label1.Text = "Tên tài khoản";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(48, 164);
            label7.Name = "label7";
            label7.Size = new Size(101, 26);
            label7.TabIndex = 42;
            label7.Text = "Mật khẩu";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(10, 230);
            label2.Name = "label2";
            label2.Size = new Size(147, 26);
            label2.TabIndex = 40;
            label2.Text = "Cấp độ quyền";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // FormSuaTaiKhoan
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(577, 520);
            Controls.Add(label6);
            Controls.Add(btnThoat);
            Controls.Add(btnCapNhat);
            Controls.Add(panel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormSuaTaiKhoan";
            Text = "FormSuaTaiKhoan";
            Load += FormSuaTaiKhoan_Load;
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
        private System.Windows.Forms.ComboBox cbCapDoQuyen;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.TextBox txtTenTK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaNV;
    }
}