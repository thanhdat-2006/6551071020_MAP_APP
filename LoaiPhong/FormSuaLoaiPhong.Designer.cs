namespace HotelManagementApp.LoaiPhong
{
    partial class FormSuaLoaiPhong
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
        panel1 = new Panel();
        txtGiaGio = new TextBox();
        labell = new Label();
        txtGiaNgay = new TextBox();
        label4 = new Label();
        txtSoNguoiToiDa = new TextBox();
        label3 = new Label();
        txtSoGiuong = new TextBox();
        label2 = new Label();
        txtTenLP = new TextBox();
        label1 = new Label();
        label5 = new Label();
        panel1.SuspendLayout();
        SuspendLayout();
        // 
        // btnThoat
        // 
        btnThoat.BackColor = SystemColors.GradientActiveCaption;
        btnThoat.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        btnThoat.Location = new Point(336, 519);
        btnThoat.Margin = new Padding(3, 4, 3, 4);
        btnThoat.Name = "btnThoat";
        btnThoat.Size = new Size(137, 59);
        btnThoat.TabIndex = 13;
        btnThoat.Text = "Thoát";
        btnThoat.UseVisualStyleBackColor = false;
        btnThoat.Click += btnThoat_Click;
        // 
        // btnCapNhat
        // 
        btnCapNhat.BackColor = Color.Moccasin;
        btnCapNhat.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCapNhat.Location = new Point(136, 519);
            btnCapNhat.Margin = new Padding(3, 4, 3, 4);
            btnCapNhat.Name = "btnCapNhat";
            btnCapNhat.Size = new Size(137, 59);
            btnCapNhat.TabIndex = 12;
            btnCapNhat.Text = "Cập nhật";
            btnCapNhat.UseVisualStyleBackColor = false;
            btnCapNhat.Click += btnCapNhat_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(txtGiaGio);
            panel1.Controls.Add(labell);
            panel1.Controls.Add(txtGiaNgay);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(txtSoNguoiToiDa);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txtSoGiuong);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtTenLP);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(48, 121);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(507, 375);
            panel1.TabIndex = 11;
            // 
            // txtGiaGio
            // 
            txtGiaGio.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtGiaGio.Location = new Point(211, 308);
            txtGiaGio.Margin = new Padding(3, 4, 3, 4);
            txtGiaGio.Name = "txtGiaGio";
            txtGiaGio.Size = new Size(275, 30);
            txtGiaGio.TabIndex = 24;
            // 
            // labell
            // 
            labell.AutoSize = true;
            labell.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labell.Location = new Point(112, 312);
            labell.Name = "labell";
            labell.Size = new Size(81, 26);
            labell.TabIndex = 23;
            labell.Text = "Giá giờ";
            // 
            // txtGiaNgay
            // 
            txtGiaNgay.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtGiaNgay.Location = new Point(208, 244);
            txtGiaNgay.Margin = new Padding(3, 4, 3, 4);
            txtGiaNgay.Name = "txtGiaNgay";
            txtGiaNgay.Size = new Size(275, 30);
            txtGiaNgay.TabIndex = 22;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(94, 244);
            label4.Name = "label4";
            label4.Size = new Size(99, 26);
            label4.TabIndex = 21;
            label4.Text = "Giá ngày";
            // 
            // txtSoNguoiToiDa
            // 
            txtSoNguoiToiDa.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSoNguoiToiDa.Location = new Point(208, 179);
            txtSoNguoiToiDa.Margin = new Padding(3, 4, 3, 4);
            txtSoNguoiToiDa.Name = "txtSoNguoiToiDa";
            txtSoNguoiToiDa.Size = new Size(275, 30);
            txtSoNguoiToiDa.TabIndex = 20;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(39, 179);
            label3.Name = "label3";
            label3.Size = new Size(157, 26);
            label3.TabIndex = 19;
            label3.Text = "Số người tối đa";
            // 
            // txtSoGiuong
            // 
            txtSoGiuong.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSoGiuong.Location = new Point(208, 110);
            txtSoGiuong.Margin = new Padding(3, 4, 3, 4);
            txtSoGiuong.Name = "txtSoGiuong";
            txtSoGiuong.Size = new Size(275, 30);
            txtSoGiuong.TabIndex = 18;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(81, 110);
            label2.Name = "label2";
            label2.Size = new Size(110, 26);
            label2.TabIndex = 17;
            label2.Text = "Số giường";
            // 
            // txtTenLP
            // 
            txtTenLP.AcceptsReturn = true;
            txtTenLP.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTenLP.Location = new Point(208, 45);
            txtTenLP.Margin = new Padding(3, 4, 3, 4);
            txtTenLP.Name = "txtTenLP";
            txtTenLP.Size = new Size(275, 30);
            txtTenLP.TabIndex = 16;
            // 
            // labell
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(39, 45);
            label1.Name = "label1";
            label1.Size = new Size(154, 26);
            label1.TabIndex = 8;
            label1.Text = "Tên loại phòng";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(192, 64, 0);
            label5.Location = new Point(113, 49);
            label5.Name = "label5";
            label5.Size = new Size(395, 31);
            label5.TabIndex = 14;
            label5.Text = "Cập nhật thông tin loại phòng";
            // 
            // FormSuaLoaiPhong
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(604, 626);
            Controls.Add(label5);
            Controls.Add(btnThoat);
            Controls.Add(btnCapNhat);
            Controls.Add(panel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormSuaLoaiPhong";
            Text = "FormSuaLoaiPhong";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGiaGio;
        private System.Windows.Forms.Label labell;
        private System.Windows.Forms.TextBox txtGiaNgay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSoNguoiToiDa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSoGiuong;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTenLP;
        private System.Windows.Forms.Label label5;
    }
}