namespace HotelManagementApp.PhieuThue
{
    partial class FormSuaChiTietPhieuThue
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
            lbMaCTDP = new Label();
            btnThoat = new Button();
            btnCapNhat = new Button();
            cbTrangThaiCTDP = new ComboBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // lbMaCTDP
            // 
            lbMaCTDP.AutoSize = true;
            lbMaCTDP.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbMaCTDP.ForeColor = Color.FromArgb(192, 64, 0);
            lbMaCTDP.Location = new Point(145, 30);
            lbMaCTDP.Name = "lbMaCTDP";
            lbMaCTDP.Size = new Size(718, 31);
            lbMaCTDP.TabIndex = 19;
            lbMaCTDP.Text = "Cập nhật thông chi tiết phiếu thuê {mã CT phiếu thuê}";
            // 
            // btnThoat
            // 
            btnThoat.BackColor = SystemColors.GradientActiveCaption;
            btnThoat.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnThoat.Location = new Point(512, 232);
            btnThoat.Margin = new Padding(3, 4, 3, 4);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(137, 59);
            btnThoat.TabIndex = 18;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = false;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnCapNhat
            // 
            btnCapNhat.BackColor = Color.Moccasin;
            btnCapNhat.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCapNhat.Location = new Point(301, 232);
            btnCapNhat.Margin = new Padding(3, 4, 3, 4);
            btnCapNhat.Name = "btnCapNhat";
            btnCapNhat.Size = new Size(137, 59);
            btnCapNhat.TabIndex = 17;
            btnCapNhat.Text = "Cập nhật";
            btnCapNhat.UseVisualStyleBackColor = false;
            btnCapNhat.Click += btnCapNhat_Click;
            // 
            // cbTrangThaiCTDP
            // 
            cbTrangThaiCTDP.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbTrangThaiCTDP.FormattingEnabled = true;
            cbTrangThaiCTDP.Items.AddRange(new object[] {
            "Đang thuê",
            "Đã thanh toán"});
            cbTrangThaiCTDP.Location = new Point(411, 116);
            cbTrangThaiCTDP.Margin = new Padding(3, 4, 3, 4);
            cbTrangThaiCTDP.Name = "cbTrangThaiCTDP";
            cbTrangThaiCTDP.Size = new Size(275, 33);
            cbTrangThaiCTDP.TabIndex = 21;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(281, 125);
            label1.Name = "label1";
            label1.Size = new Size(108, 26);
            label1.TabIndex = 20;
            label1.Text = "Trạng thái";
            // 
            // FormSuaChiTietPhieuThue
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(959, 345);
            Controls.Add(cbTrangThaiCTDP);
            Controls.Add(label1);
            Controls.Add(lbMaCTDP);
            Controls.Add(btnThoat);
            Controls.Add(btnCapNhat);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormSuaChiTietPhieuThue";
            Text = "FormSuaChiTietPhieuThue";
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbMaCTDP;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.ComboBox cbTrangThaiCTDP;
        private System.Windows.Forms.Label label1;
    }
}