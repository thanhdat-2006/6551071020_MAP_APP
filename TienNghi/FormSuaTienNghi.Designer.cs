namespace HotelManagementApp.TienNghi
{
    partial class FormSuaTienNghi
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
            txtTenTN = new TextBox();
            label1 = new Label();
            LabelThemTienNghi = new Label();
            SuspendLayout();
            // 
            // btnThoat
            // 
            btnThoat.BackColor = SystemColors.GradientActiveCaption;
            btnThoat.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnThoat.Location = new Point(333, 234);
            btnThoat.Margin = new Padding(3, 4, 3, 4);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(137, 59);
            btnThoat.TabIndex = 22;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = false;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnCapNhat
            // 
            btnCapNhat.BackColor = Color.Moccasin;
            btnCapNhat.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCapNhat.Location = new Point(133, 234);
            btnCapNhat.Margin = new Padding(3, 4, 3, 4);
            btnCapNhat.Name = "btnCapNhat";
            btnCapNhat.Size = new Size(137, 59);
            btnCapNhat.TabIndex = 21;
            btnCapNhat.Text = "Cập nhật";
            btnCapNhat.UseVisualStyleBackColor = false;
            btnCapNhat.Click += btnCapNhat_Click;
            // 
            // txtTenTN
            // 
            txtTenTN.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTenTN.Location = new Point(213, 164);
            txtTenTN.Margin = new Padding(3, 4, 3, 4);
            txtTenTN.Name = "txtTenTN";
            txtTenTN.Size = new Size(298, 34);
            txtTenTN.TabIndex = 20;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(59, 170);
            label1.Name = "label1";
            label1.Size = new Size(136, 26);
            label1.TabIndex = 19;
            label1.Text = "Tên tiện nghi";
            // 
            // LabelThemTienNghi
            // 
            LabelThemTienNghi.AutoSize = true;
            LabelThemTienNghi.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelThemTienNghi.ForeColor = Color.FromArgb(192, 0, 0);
            LabelThemTienNghi.Location = new Point(136, 51);
            LabelThemTienNghi.Margin = new Padding(4, 0, 4, 0);
            LabelThemTienNghi.Name = "LabelThemTienNghi";
            LabelThemTienNghi.Size = new Size(313, 46);
            LabelThemTienNghi.TabIndex = 18;
            LabelThemTienNghi.Text = "Cập nhật tiện nghi";
            // 
            // FormSuaTienNghi
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(549, 400);
            Controls.Add(btnThoat);
            Controls.Add(btnCapNhat);
            Controls.Add(txtTenTN);
            Controls.Add(label1);
            Controls.Add(LabelThemTienNghi);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormSuaTienNghi";
            Text = "FormSuaTienNghi";
            Load += FormSuaTienNghi_Load;
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.TextBox txtTenTN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LabelThemTienNghi;
    }
}