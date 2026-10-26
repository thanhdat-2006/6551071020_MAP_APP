using HotelManagementApp.Models;

namespace HotelManagementApp.Phong
{
    partial class FormSuaPhong
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
            cbTrangThaiPhong = new ComboBox();
            label2 = new Label();
            cbTinhTrangDonDep = new ComboBox();
            label3 = new Label();
            cbLoaiPhong = new ComboBox();
            label4 = new Label();
            txtGhiChu = new RichTextBox();
            panel1 = new Panel();
            label1 = new Label();
            btnCapNhat = new Button();
            btnThoat = new Button();
            label5 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // cbTrangThaiPhong
            // 
            cbTrangThaiPhong.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbTrangThaiPhong.FormattingEnabled = true;
            cbTrangThaiPhong.Items.AddRange(new object[] { "Bình thường", "Đã đặt", "Đang thuê", "Đang sửa chữa" });
            cbTrangThaiPhong.Location = new Point(208, 36);
            cbTrangThaiPhong.Margin = new Padding(3, 4, 3, 4);
            cbTrangThaiPhong.Name = "cbTrangThaiPhong";
            cbTrangThaiPhong.Size = new Size(275, 33);
            cbTrangThaiPhong.TabIndex = 9;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(10, 170);
            label2.Name = "label2";
            label2.Size = new Size(192, 26);
            label2.TabIndex = 10;
            label2.Text = "Tình trạng dọn dẹp";
            // 
            // cbTinhTrangDonDep
            // 
            cbTinhTrangDonDep.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbTinhTrangDonDep.FormattingEnabled = true;
            cbTinhTrangDonDep.Items.AddRange(new object[] { "Đã dọn dẹp", "Chưa dọn dẹp" });
            cbTinhTrangDonDep.Location = new Point(208, 168);
            cbTinhTrangDonDep.Margin = new Padding(3, 4, 3, 4);
            cbTinhTrangDonDep.Name = "cbTinhTrangDonDep";
            cbTinhTrangDonDep.Size = new Size(275, 33);
            cbTinhTrangDonDep.TabIndex = 11;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(83, 101);
            label3.Name = "label3";
            label3.Size = new Size(119, 26);
            label3.TabIndex = 12;
            label3.Text = "Loại phòng";
            // 
            // cbLoaiPhong
            // 
            cbLoaiPhong.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbLoaiPhong.FormattingEnabled = true;
            cbLoaiPhong.Items.AddRange(new object[] { "Đã dọn dẹp", "Chưa dọn dẹp" });
            cbLoaiPhong.Location = new Point(208, 101);
            cbLoaiPhong.Margin = new Padding(3, 4, 3, 4);
            cbLoaiPhong.Name = "cbLoaiPhong";
            cbLoaiPhong.Size = new Size(275, 33);
            cbLoaiPhong.TabIndex = 13;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(115, 230);
            label4.Name = "label4";
            label4.Size = new Size(87, 26);
            label4.TabIndex = 14;
            label4.Text = "Ghi chú";
            // 
            // txtGhiChu
            // 
            txtGhiChu.Location = new Point(208, 230);
            txtGhiChu.Margin = new Padding(3, 4, 3, 4);
            txtGhiChu.Name = "txtGhiChu";
            txtGhiChu.Size = new Size(275, 119);
            txtGhiChu.TabIndex = 15;
            txtGhiChu.Text = "";
            // 
            // panel1
            // 
            panel1.Controls.Add(txtGhiChu);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(cbLoaiPhong);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(cbTinhTrangDonDep);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(cbTrangThaiPhong);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(65, 100);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(507, 375);
            panel1.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(28, 39);
            label1.Name = "label1";
            label1.Size = new Size(174, 26);
            label1.TabIndex = 8;
            label1.Text = "Trạng thái phòng";
            // 
            // btnCapNhat
            // 
            btnCapNhat.BackColor = Color.Moccasin;
            btnCapNhat.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCapNhat.Location = new Point(153, 498);
            btnCapNhat.Margin = new Padding(3, 4, 3, 4);
            btnCapNhat.Name = "btnCapNhat";
            btnCapNhat.Size = new Size(137, 59);
            btnCapNhat.TabIndex = 9;
            btnCapNhat.Text = "Cập nhật";
            btnCapNhat.UseVisualStyleBackColor = false;
            btnCapNhat.Click += btnCapNhat_Click;
            // 
            // btnThoat
            // 
            btnThoat.BackColor = SystemColors.GradientActiveCaption;
            btnThoat.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnThoat.Location = new Point(353, 498);
            btnThoat.Margin = new Padding(3, 4, 3, 4);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(137, 59);
            btnThoat.TabIndex = 10;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = false;
            btnThoat.Click += btnThoat_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(192, 64, 0);
            label5.Location = new Point(123, 30);
            label5.Name = "label5";
            label5.Size = new Size(341, 31);
            label5.TabIndex = 15;
            label5.Text = "Cập nhật thông tin phòng";
            // 
            // FormSuaPhong
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(626, 615);
            Controls.Add(label5);
            Controls.Add(btnThoat);
            Controls.Add(btnCapNhat);
            Controls.Add(panel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormSuaPhong";
            Text = "FormSuaPhong";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbTrangThaiPhong;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbTinhTrangDonDep;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbLoaiPhong;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox txtGhiChu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Label label5;
    }
}