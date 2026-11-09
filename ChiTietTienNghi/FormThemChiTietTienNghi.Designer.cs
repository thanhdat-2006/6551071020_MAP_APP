namespace HotelManagementApp.ChiTietTienNghi
{
    partial class FormThemChiTietTienNghi
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
            txtSoLuong = new TextBox();
            label2 = new Label();
            label1 = new Label();
            label5 = new Label();
            btnThoat = new Button();
            btnCapNhat = new Button();
            cbTenTN = new ComboBox();
            SuspendLayout();
            // 
            // txtSoLuong
            // 
            txtSoLuong.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSoLuong.Location = new Point(242, 271);
            txtSoLuong.Margin = new Padding(3, 4, 3, 4);
            txtSoLuong.Name = "txtSoLuong";
            txtSoLuong.Size = new Size(275, 30);
            txtSoLuong.TabIndex = 29;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(115, 271);
            label2.Name = "label2";
            label2.Size = new Size(98, 26);
            label2.TabIndex = 28;
            label2.Text = "Số lượng";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(73, 148);
            label1.Name = "label1";
            label1.Size = new Size(136, 26);
            label1.TabIndex = 26;
            label1.Text = "Tên tiện nghi";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(192, 64, 0);
            label5.Location = new Point(29, 39);
            label5.Name = "label5";
            label5.Size = new Size(578, 31);
            label5.TabIndex = 25;
            label5.Text = "Thêm mới thông tin tiện nghi của loại phòng";
            // 
            // btnThoat
            // 
            btnThoat.BackColor = SystemColors.GradientActiveCaption;
            btnThoat.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnThoat.Location = new Point(361, 371);
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
            btnCapNhat.Location = new Point(161, 371);
            btnCapNhat.Margin = new Padding(3, 4, 3, 4);
            btnCapNhat.Name = "btnCapNhat";
            btnCapNhat.Size = new Size(137, 59);
            btnCapNhat.TabIndex = 23;
            btnCapNhat.Text = "Thêm mới";
            btnCapNhat.UseVisualStyleBackColor = false;
            btnCapNhat.Click += btnCapNhat_Click;
            // 
            // cbTenTN
            // 
            cbTenTN.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbTenTN.FormattingEnabled = true;
            cbTenTN.Location = new Point(242, 149);
            cbTenTN.Margin = new Padding(3, 4, 3, 4);
            cbTenTN.Name = "cbTenTN";
            cbTenTN.Size = new Size(275, 34);
            cbTenTN.TabIndex = 30;
            // 
            // FormThemChiTietTienNghi
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(610, 445);
            Controls.Add(cbTenTN);
            Controls.Add(txtSoLuong);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(label5);
            Controls.Add(btnThoat);
            Controls.Add(btnCapNhat);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormThemChiTietTienNghi";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormThemChiTietTienNghi";
            Load += FormThemChiTietTienNghi_Load;
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.ComboBox cbTenTN;
    }
}