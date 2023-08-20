namespace HQTCSDL
{
    partial class Form_DangKi
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
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.check_DT = new Guna.UI2.WinForms.Guna2CheckBox();
            this.check_KH = new Guna.UI2.WinForms.Guna2CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.check_TX = new Guna.UI2.WinForms.Guna2CheckBox();
            this.check_NV = new Guna.UI2.WinForms.Guna2CheckBox();
            this.button_dangki = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_xacnhanmk = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtUserName = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.guna2PictureBox1);
            this.guna2Panel1.Location = new System.Drawing.Point(349, -2);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(590, 667);
            this.guna2Panel1.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.label3.Location = new System.Drawing.Point(66, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(201, 57);
            this.label3.TabIndex = 6;
            this.label3.Text = "ĐĂNG KÍ";
            // 
            // check_DT
            // 
            this.check_DT.AutoSize = true;
            this.check_DT.Checked = true;
            this.check_DT.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(160)))), ((int)(((byte)(145)))));
            this.check_DT.CheckedState.BorderRadius = 0;
            this.check_DT.CheckedState.BorderThickness = 1;
            this.check_DT.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(160)))), ((int)(((byte)(145)))));
            this.check_DT.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_DT.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.check_DT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(72)))), ((int)(((byte)(38)))));
            this.check_DT.Location = new System.Drawing.Point(33, 362);
            this.check_DT.Name = "check_DT";
            this.check_DT.Size = new System.Drawing.Size(86, 27);
            this.check_DT.TabIndex = 25;
            this.check_DT.Text = "Đối tác";
            this.check_DT.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(160)))), ((int)(((byte)(145)))));
            this.check_DT.UncheckedState.BorderRadius = 0;
            this.check_DT.UncheckedState.BorderThickness = 1;
            this.check_DT.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(233)))), ((int)(((byte)(223)))));
            this.check_DT.CheckedChanged += new System.EventHandler(this.check_DT_CheckedChanged);
            // 
            // check_KH
            // 
            this.check_KH.AutoSize = true;
            this.check_KH.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(160)))), ((int)(((byte)(145)))));
            this.check_KH.CheckedState.BorderRadius = 0;
            this.check_KH.CheckedState.BorderThickness = 1;
            this.check_KH.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(160)))), ((int)(((byte)(145)))));
            this.check_KH.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.check_KH.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(72)))), ((int)(((byte)(38)))));
            this.check_KH.Location = new System.Drawing.Point(157, 362);
            this.check_KH.Name = "check_KH";
            this.check_KH.Size = new System.Drawing.Size(123, 27);
            this.check_KH.TabIndex = 26;
            this.check_KH.Text = "Khách hàng";
            this.check_KH.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(160)))), ((int)(((byte)(145)))));
            this.check_KH.UncheckedState.BorderRadius = 0;
            this.check_KH.UncheckedState.BorderThickness = 1;
            this.check_KH.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(233)))), ((int)(((byte)(223)))));
            this.check_KH.CheckedChanged += new System.EventHandler(this.check_KH_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.label1.Location = new System.Drawing.Point(28, 325);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Chọn vai trò";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // check_TX
            // 
            this.check_TX.AutoSize = true;
            this.check_TX.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(160)))), ((int)(((byte)(145)))));
            this.check_TX.CheckedState.BorderRadius = 0;
            this.check_TX.CheckedState.BorderThickness = 1;
            this.check_TX.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(160)))), ((int)(((byte)(145)))));
            this.check_TX.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.check_TX.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(72)))), ((int)(((byte)(38)))));
            this.check_TX.Location = new System.Drawing.Point(34, 395);
            this.check_TX.Name = "check_TX";
            this.check_TX.Size = new System.Drawing.Size(74, 27);
            this.check_TX.TabIndex = 27;
            this.check_TX.Text = "Tài xế";
            this.check_TX.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(160)))), ((int)(((byte)(145)))));
            this.check_TX.UncheckedState.BorderRadius = 0;
            this.check_TX.UncheckedState.BorderThickness = 1;
            this.check_TX.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(233)))), ((int)(((byte)(223)))));
            this.check_TX.CheckedChanged += new System.EventHandler(this.check_TX_CheckedChanged);
            // 
            // check_NV
            // 
            this.check_NV.AutoSize = true;
            this.check_NV.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(160)))), ((int)(((byte)(145)))));
            this.check_NV.CheckedState.BorderRadius = 0;
            this.check_NV.CheckedState.BorderThickness = 1;
            this.check_NV.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(160)))), ((int)(((byte)(145)))));
            this.check_NV.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.check_NV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(72)))), ((int)(((byte)(38)))));
            this.check_NV.Location = new System.Drawing.Point(157, 395);
            this.check_NV.Name = "check_NV";
            this.check_NV.Size = new System.Drawing.Size(110, 27);
            this.check_NV.TabIndex = 29;
            this.check_NV.Text = "Nhân viên";
            this.check_NV.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(160)))), ((int)(((byte)(145)))));
            this.check_NV.UncheckedState.BorderRadius = 0;
            this.check_NV.UncheckedState.BorderThickness = 1;
            this.check_NV.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(233)))), ((int)(((byte)(223)))));
            this.check_NV.CheckedChanged += new System.EventHandler(this.check_NV_CheckedChanged);
            // 
            // button_dangki
            // 
            this.button_dangki.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(140)))), ((int)(((byte)(165)))));
            this.button_dangki.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button_dangki.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(140)))), ((int)(((byte)(165)))));
            this.button_dangki.BorderRadius = 10;
            this.button_dangki.BorderThickness = 10;
            this.button_dangki.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.button_dangki.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.button_dangki.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.button_dangki.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.button_dangki.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(140)))), ((int)(((byte)(165)))));
            this.button_dangki.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.button_dangki.ForeColor = System.Drawing.Color.White;
            this.button_dangki.Location = new System.Drawing.Point(23, 472);
            this.button_dangki.Name = "button_dangki";
            this.button_dangki.Size = new System.Drawing.Size(117, 36);
            this.button_dangki.TabIndex = 30;
            this.button_dangki.Text = "Đăng kí";
            this.button_dangki.Click += new System.EventHandler(this.button_dangki_Click);
            // 
            // guna2Button2
            // 
            this.guna2Button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(140)))), ((int)(((byte)(165)))));
            this.guna2Button2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(140)))), ((int)(((byte)(165)))));
            this.guna2Button2.BorderRadius = 10;
            this.guna2Button2.BorderThickness = 10;
            this.guna2Button2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(140)))), ((int)(((byte)(165)))));
            this.guna2Button2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.guna2Button2.ForeColor = System.Drawing.Color.White;
            this.guna2Button2.Location = new System.Drawing.Point(200, 472);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.Size = new System.Drawing.Size(117, 36);
            this.guna2Button2.TabIndex = 31;
            this.guna2Button2.Text = "Thoát";
            this.guna2Button2.Click += new System.EventHandler(this.guna2Button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(72)))), ((int)(((byte)(38)))));
            this.label2.Location = new System.Drawing.Point(107, 557);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 20);
            this.label2.TabIndex = 32;
            this.label2.Text = "Đã có tài khoản";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(72)))), ((int)(((byte)(38)))));
            this.label4.Location = new System.Drawing.Point(131, 588);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 18);
            this.label4.TabIndex = 33;
            this.label4.Text = "Quay lại ";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // txt_xacnhanmk
            // 
            this.txt_xacnhanmk.AutoRoundedCorners = true;
            this.txt_xacnhanmk.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(140)))), ((int)(((byte)(165)))));
            this.txt_xacnhanmk.BorderRadius = 24;
            this.txt_xacnhanmk.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_xacnhanmk.DefaultText = "";
            this.txt_xacnhanmk.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_xacnhanmk.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_xacnhanmk.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_xacnhanmk.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_xacnhanmk.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.txt_xacnhanmk.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_xacnhanmk.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_xacnhanmk.ForeColor = System.Drawing.Color.Black;
            this.txt_xacnhanmk.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_xacnhanmk.IconLeft = global::HQTCSDL.Properties.Resources.icons8_forgot_password_50__1_;
            this.txt_xacnhanmk.Location = new System.Drawing.Point(23, 262);
            this.txt_xacnhanmk.Name = "txt_xacnhanmk";
            this.txt_xacnhanmk.PasswordChar = '●';
            this.txt_xacnhanmk.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(72)))), ((int)(((byte)(38)))));
            this.txt_xacnhanmk.PlaceholderText = "Xác nhận lại mật khẩu";
            this.txt_xacnhanmk.SelectedText = "";
            this.txt_xacnhanmk.Size = new System.Drawing.Size(297, 50);
            this.txt_xacnhanmk.TabIndex = 24;
            this.txt_xacnhanmk.UseSystemPasswordChar = true;
            // 
            // txtPassword
            // 
            this.txtPassword.AutoRoundedCorners = true;
            this.txtPassword.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(140)))), ((int)(((byte)(165)))));
            this.txtPassword.BorderRadius = 24;
            this.txtPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPassword.DefaultText = "";
            this.txtPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPassword.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.txtPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPassword.ForeColor = System.Drawing.Color.Black;
            this.txtPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPassword.IconLeft = global::HQTCSDL.Properties.Resources.icons8_forgot_password_50__1_;
            this.txtPassword.Location = new System.Drawing.Point(23, 189);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(72)))), ((int)(((byte)(38)))));
            this.txtPassword.PlaceholderText = "Mật khẩu";
            this.txtPassword.SelectedText = "";
            this.txtPassword.Size = new System.Drawing.Size(294, 50);
            this.txtPassword.TabIndex = 23;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // txtUserName
            // 
            this.txtUserName.AutoRoundedCorners = true;
            this.txtUserName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(140)))), ((int)(((byte)(165)))));
            this.txtUserName.BorderRadius = 24;
            this.txtUserName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUserName.DefaultText = "";
            this.txtUserName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtUserName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtUserName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUserName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUserName.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.txtUserName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUserName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtUserName.ForeColor = System.Drawing.Color.Black;
            this.txtUserName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUserName.IconLeft = global::HQTCSDL.Properties.Resources.icons8_account_100;
            this.txtUserName.Location = new System.Drawing.Point(23, 121);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.PasswordChar = '\0';
            this.txtUserName.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(72)))), ((int)(((byte)(38)))));
            this.txtUserName.PlaceholderText = "Tên đăng kí";
            this.txtUserName.SelectedText = "";
            this.txtUserName.Size = new System.Drawing.Size(294, 50);
            this.txtUserName.TabIndex = 22;
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = global::HQTCSDL.Properties.Resources._1;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(-36, -207);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(673, 1033);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 0;
            this.guna2PictureBox1.TabStop = false;
            // 
            // Form_DangKi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(233)))), ((int)(((byte)(223)))));
            this.ClientSize = new System.Drawing.Size(940, 625);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.guna2Button2);
            this.Controls.Add(this.button_dangki);
            this.Controls.Add(this.check_NV);
            this.Controls.Add(this.check_TX);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.check_KH);
            this.Controls.Add(this.check_DT);
            this.Controls.Add(this.txt_xacnhanmk);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_DangKi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng Kí";
            this.Load += new System.EventHandler(this.Form_DangKi_Load);
            this.guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2TextBox txtUserName;
        private Guna.UI2.WinForms.Guna2TextBox txtPassword;
        private Guna.UI2.WinForms.Guna2TextBox txt_xacnhanmk;
        private Guna.UI2.WinForms.Guna2CheckBox check_DT;
        private Guna.UI2.WinForms.Guna2CheckBox check_KH;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2CheckBox check_TX;
        private Guna.UI2.WinForms.Guna2CheckBox check_NV;
        private Guna.UI2.WinForms.Guna2Button button_dangki;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
    }
}