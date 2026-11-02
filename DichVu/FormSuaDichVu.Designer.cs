namespace HotelManagementApp.DichVu
{
    partial class FormSuaDichVu
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
            cbLoaiDV = new ComboBox();
            label7 = new Label();
            txtSoLuongConLai = new TextBox();
            label3 = new Label();
            txtDonGia = new TextBox();
            label2 = new Label();
            txtTenDV = new TextBox();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.FromArgb(192, 0, 0);
            label6.Location = new Point(124, 29);
            label6.Name = "label6";
            label6.Size = new Size(333, 29);
            label6.TabIndex = 21;
            label6.Text = "Cập nhật thông tin dịch vụ";
            // 
            // btnThoat
            // 
            btnThoat.BackColor = SystemColors.GradientActiveCaption;
            btnThoat.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnThoat.Location = new Point(323, 429);
            btnThoat.Margin = new Padding(3, 4, 3, 4);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(137, 59);
            btnThoat.TabIndex = 20;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = false;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnCapNhat
            // 
            btnCapNhat.BackColor = Color.Moccasin;
            btnCapNhat.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCapNhat.Location = new Point(123, 429);
            btnCapNhat.Margin = new Padding(3, 4, 3, 4);
            btnCapNhat.Name = "btnCapNhat";
            btnCapNhat.Size = new Size(137, 59);
            btnCapNhat.TabIndex = 19;
            btnCapNhat.Text = "Cập nhật";
            btnCapNhat.UseVisualStyleBackColor = false;
            btnCapNhat.Click += btnCapNhat_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(cbLoaiDV);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(txtSoLuongConLai);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txtDonGia);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtTenDV);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(35, 94);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(507, 288);
            panel1.TabIndex = 18;
            // 
            // cbLoaiDV
            // 
            cbLoaiDV.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbLoaiDV.FormattingEnabled = true;
            cbLoaiDV.Items.AddRange(new object[] { "Dịch vụ giặt ủi quần áo", "Dịch vụ xe đưa đón ", "Dịch vụ cho thuê xe máy tự lái", "Dịch vụ đặt vé máy bay, tour du lịch", "Dịch vụ trông trẻ", "Bơi 4 mùa ", "Dịch vụ karaoke", "Dịch vụ phục vụ phòng 24/24", "Dịch vụ thu đổi ngoại tệ", "Nhà hàng", "Dịch vụ hội họp, văn phòng", "Dịch vụ Spa" });
            cbLoaiDV.Location = new Point(202, 95);
            cbLoaiDV.Margin = new Padding(3, 4, 3, 4);
            cbLoaiDV.Name = "cbLoaiDV";
            cbLoaiDV.Size = new Size(284, 30);
            cbLoaiDV.TabIndex = 25;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(48, 94);
            label7.Name = "label7";
            label7.Size = new Size(128, 26);
            label7.TabIndex = 24;
            label7.Text = "Loại dịch vụ";
            // 
            // txtSoLuongConLai
            // 
            txtSoLuongConLai.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSoLuongConLai.Location = new Point(202, 219);
            txtSoLuongConLai.Margin = new Padding(3, 4, 3, 4);
            txtSoLuongConLai.Name = "txtSoLuongConLai";
            txtSoLuongConLai.Size = new Size(284, 30);
            txtSoLuongConLai.TabIndex = 23;
            txtSoLuongConLai.KeyPress += txtSoLuongConLai_KeyPress;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(15, 221);
            label3.Name = "label3";
            label3.Size = new Size(167, 26);
            label3.TabIndex = 22;
            label3.Text = "Số lượng còn lại";
            // 
            // txtDonGia
            // 
            txtDonGia.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDonGia.Location = new Point(202, 156);
            txtDonGia.Margin = new Padding(3, 4, 3, 4);
            txtDonGia.Name = "txtDonGia";
            txtDonGia.Size = new Size(284, 30);
            txtDonGia.TabIndex = 21;
            txtDonGia.KeyPress += txtDonGia_KeyPress;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(89, 156);
            label2.Name = "label2";
            label2.Size = new Size(87, 26);
            label2.TabIndex = 20;
            label2.Text = "Đơn giá";
            // 
            // txtTenDV
            // 
            txtTenDV.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTenDV.Location = new Point(202, 25);
            txtTenDV.Margin = new Padding(3, 4, 3, 4);
            txtTenDV.Name = "txtTenDV";
            txtTenDV.Size = new Size(284, 30);
            txtTenDV.TabIndex = 19;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(59, 21);
            label1.Name = "label1";
            label1.Size = new Size(123, 26);
            label1.TabIndex = 18;
            label1.Text = "Tên dịch vụ";
            // 
            // FormSuaDichVu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(540, 522);
            Controls.Add(label6);
            Controls.Add(btnThoat);
            Controls.Add(btnCapNhat);
            Controls.Add(panel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormSuaDichVu";
            Text = "FormSuaDichVu";
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
        private System.Windows.Forms.ComboBox cbLoaiDV;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSoLuongConLai;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDonGia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTenDV;
        private System.Windows.Forms.Label label1;
    }
}