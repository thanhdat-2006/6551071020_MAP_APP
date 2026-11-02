namespace HotelManagementApp.ChiTietTienNghi
{
    partial class FormSuaChiTietTienNghi
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
            btnThoat = new Button();
            btnCapNhat = new Button();
            label5 = new Label();
            txtSoLuong = new TextBox();
            label2 = new Label();
            txtTenTN = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnThoat
            // 
            btnThoat.BackColor = SystemColors.GradientActiveCaption;
            btnThoat.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnThoat.Location = new Point(327, 431);
            btnThoat.Margin = new Padding(3, 4, 3, 4);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(137, 59);
            btnThoat.TabIndex = 15;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = false;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnCapNhat
            // 
            btnCapNhat.BackColor = Color.Moccasin;
            btnCapNhat.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCapNhat.Location = new Point(127, 431);
            btnCapNhat.Margin = new Padding(3, 4, 3, 4);
            btnCapNhat.Name = "btnCapNhat";
            btnCapNhat.Size = new Size(137, 59);
            btnCapNhat.TabIndex = 14;
            btnCapNhat.Text = "Cập nhật";
            btnCapNhat.UseVisualStyleBackColor = false;
            btnCapNhat.Click += btnCapNhat_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(192, 64, 0);
            label5.Location = new Point(12, 45);
            label5.Name = "label5";
            label5.Size = new Size(569, 31);
            label5.TabIndex = 16;
            label5.Text = "Cập nhật thông tin tiện nghi của loại phòng";
            // 
            // txtSoLuong
            // 
            txtSoLuong.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSoLuong.Location = new Point(253, 294);
            txtSoLuong.Margin = new Padding(3, 4, 3, 4);
            txtSoLuong.Name = "txtSoLuong";
            txtSoLuong.Size = new Size(275, 30);
            txtSoLuong.TabIndex = 22;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(126, 294);
            label2.Name = "label2";
            label2.Size = new Size(98, 26);
            label2.TabIndex = 21;
            label2.Text = "Số lượng";
            // 
            // txtTenTN
            // 
            txtTenTN.AcceptsReturn = true;
            txtTenTN.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTenTN.Location = new Point(253, 170);
            txtTenTN.Margin = new Padding(3, 4, 3, 4);
            txtTenTN.Name = "txtTenTN";
            txtTenTN.ReadOnly = true;
            txtTenTN.Size = new Size(275, 30);
            txtTenTN.TabIndex = 20;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(84, 170);
            label1.Name = "label1";
            label1.Size = new Size(136, 26);
            label1.TabIndex = 19;
            label1.Text = "Tên tiện nghi";
            // 
            // FormSuaChiTietTienNghi
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(613, 576);
            Controls.Add(txtSoLuong);
            Controls.Add(label2);
            Controls.Add(txtTenTN);
            Controls.Add(label1);
            Controls.Add(label5);
            Controls.Add(btnThoat);
            Controls.Add(btnCapNhat);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormSuaChiTietTienNghi";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormSuaChiTietTienNghi";
            Load += FormSuaChiTietTienNghi_Load;
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTenTN;
        private System.Windows.Forms.Label label1;
    }
}