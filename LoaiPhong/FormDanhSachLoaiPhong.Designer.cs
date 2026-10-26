namespace HotelManagementApp.LoaiPhong
{
    partial class FormDanhSachLoaiPhong
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
            this.dtgDanhSachLoaiPhong = new System.Windows.Forms.DataGridView();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnThemMoi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDanhSachLoaiPhong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            //
            // dtgDanhSachLoaiPhong
            //
            this.dtgDanhSachLoaiPhong.ColumnHeadersHeightSizeMode =
System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDanhSachLoaiPhong.Location = new System.Drawing.Point(-71, 66);
            this.dtgDanhSachLoaiPhong.Name = "dtgDanhSachLoaiPhong";
            this.dtgDanhSachLoaiPhong.RowHeadersWidth = 51;
            this.dtgDanhSachLoaiPhong.RowTemplate.Height = 24;
            this.dtgDanhSachLoaiPhong.Size = new System.Drawing.Size(1015, 615);
            this.dtgDanhSachLoaiPhong.TabIndex = 9;
            this.dtgDanhSachLoaiPhong.CellClick += new
            System.Windows.Forms.DataGridViewCellEventHandler(this.dtgDanhSachLoaiPhong_CellClick);
            //
            // btnXuatExcel
            //
            this.btnXuatExcel.BackColor = System.Drawing.Color.DarkTurquoise;
            this.btnXuatExcel.Font = new System.Drawing.Font("Microsoft Sans Serif",
12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuatExcel.Location = new System.Drawing.Point(546, 12);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(167, 37);
            this.btnXuatExcel.TabIndex = 7;
            this.btnXuatExcel.Text = "Xuất file Excel";
            this.btnXuatExcel.UseVisualStyleBackColor = false;
            this.btnXuatExcel.Click += new
            System.EventHandler(this.btnXuatExcel_Click);
            //
            // txtTimKiem
            //
            this.txtTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F,
System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiem.Location = new System.Drawing.Point(105, 17);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(187, 32);
            this.txtTimKiem.TabIndex = 5;
            this.txtTimKiem.TextChanged += new
            System.EventHandler(this.txtTimKiem_TextChanged);
            //
            // pictureBox1
            //
            this.pictureBox1.Image = global::HotelManagementApp.Properties.Resources.search;
            this.pictureBox1.Location = new System.Drawing.Point(60, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(39, 37);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            //
            // btnThemMoi
            //
            this.btnThemMoi.BackColor = System.Drawing.Color.LightPink;
            this.btnThemMoi.Font = new System.Drawing.Font("Microsoft Sans Serif",
12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemMoi.Location = new System.Drawing.Point(747, 12);
            this.btnThemMoi.Name = "btnThemMoi";
            this.btnThemMoi.Size = new System.Drawing.Size(167, 37);
            this.btnThemMoi.TabIndex = 10;
            this.btnThemMoi.Text = "Thêm mới";
            this.btnThemMoi.UseVisualStyleBackColor = false;
            this.btnThemMoi.Click += new
            System.EventHandler(this.btnThemMoi_Click);
            //
            // FormDanhSachLoaiPhong
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 683);
            this.Controls.Add(this.btnThemMoi);
            this.Controls.Add(this.dtgDanhSachLoaiPhong);
            this.Controls.Add(this.btnXuatExcel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtTimKiem);
            this.Name = "FormDanhSachLoaiPhong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý thông tin loại phòng";
            //this.Load += new System.EventHandler(this.FormDanhSachLoaiPhong_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dtgDanhSachLoaiPhong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgDanhSachLoaiPhong;
        private System.Windows.Forms.Button btnXuatExcel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnThemMoi;
    }
}