namespace UpLoadNews
{
    partial class Login
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
            this.txtaikhoan = new System.Windows.Forms.TextBox();
            this.txtatkhau = new System.Windows.Forms.TextBox();
            this.btndangnhap = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnsdk = new System.Windows.Forms.Button();
            this.radrender = new System.Windows.Forms.RadioButton();
            this.radupload = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.radmanagerchannel = new System.Windows.Forms.RadioButton();
            this.radreupfacebook = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // txtaikhoan
            // 
            this.txtaikhoan.Location = new System.Drawing.Point(115, 32);
            this.txtaikhoan.Name = "txtaikhoan";
            this.txtaikhoan.Size = new System.Drawing.Size(226, 20);
            this.txtaikhoan.TabIndex = 0;
            // 
            // txtatkhau
            // 
            this.txtatkhau.Location = new System.Drawing.Point(115, 71);
            this.txtatkhau.Name = "txtatkhau";
            this.txtatkhau.PasswordChar = '*';
            this.txtatkhau.Size = new System.Drawing.Size(226, 20);
            this.txtatkhau.TabIndex = 1;
            // 
            // btndangnhap
            // 
            this.btndangnhap.Location = new System.Drawing.Point(210, 165);
            this.btndangnhap.Name = "btndangnhap";
            this.btndangnhap.Size = new System.Drawing.Size(96, 23);
            this.btndangnhap.TabIndex = 2;
            this.btndangnhap.Text = "Đăng nhập";
            this.btndangnhap.UseVisualStyleBackColor = true;
            this.btndangnhap.Click += new System.EventHandler(this.btndangnhap_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tài khoản :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Mật khẩu :";
            // 
            // btnsdk
            // 
            this.btnsdk.Location = new System.Drawing.Point(377, 12);
            this.btnsdk.Name = "btnsdk";
            this.btnsdk.Size = new System.Drawing.Size(53, 23);
            this.btnsdk.TabIndex = 5;
            this.btnsdk.Text = "SDK";
            this.btnsdk.UseVisualStyleBackColor = true;
            this.btnsdk.Visible = false;
            this.btnsdk.Click += new System.EventHandler(this.btnsdk_Click);
            // 
            // radrender
            // 
            this.radrender.AutoSize = true;
            this.radrender.Checked = true;
            this.radrender.Location = new System.Drawing.Point(63, 115);
            this.radrender.Name = "radrender";
            this.radrender.Size = new System.Drawing.Size(60, 17);
            this.radrender.TabIndex = 6;
            this.radrender.TabStop = true;
            this.radrender.Text = "Render";
            this.radrender.UseVisualStyleBackColor = true;
            // 
            // radupload
            // 
            this.radupload.AutoSize = true;
            this.radupload.Location = new System.Drawing.Point(141, 115);
            this.radupload.Name = "radupload";
            this.radupload.Size = new System.Drawing.Size(59, 17);
            this.radupload.TabIndex = 7;
            this.radupload.Text = "Upload";
            this.radupload.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(451, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // radmanagerchannel
            // 
            this.radmanagerchannel.AutoSize = true;
            this.radmanagerchannel.Location = new System.Drawing.Point(224, 115);
            this.radmanagerchannel.Name = "radmanagerchannel";
            this.radmanagerchannel.Size = new System.Drawing.Size(139, 17);
            this.radmanagerchannel.TabIndex = 9;
            this.radmanagerchannel.Text = "Manager channel by api";
            this.radmanagerchannel.UseVisualStyleBackColor = true;
            // 
            // radreupfacebook
            // 
            this.radreupfacebook.AutoSize = true;
            this.radreupfacebook.Location = new System.Drawing.Point(377, 115);
            this.radreupfacebook.Name = "radreupfacebook";
            this.radreupfacebook.Size = new System.Drawing.Size(99, 17);
            this.radreupfacebook.TabIndex = 10;
            this.radreupfacebook.Text = "Reup facebook";
            this.radreupfacebook.UseVisualStyleBackColor = true;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 227);
            this.Controls.Add(this.radreupfacebook);
            this.Controls.Add(this.radmanagerchannel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.radupload);
            this.Controls.Add(this.radrender);
            this.Controls.Add(this.btnsdk);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btndangnhap);
            this.Controls.Add(this.txtatkhau);
            this.Controls.Add(this.txtaikhoan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtaikhoan;
        private System.Windows.Forms.TextBox txtatkhau;
        private System.Windows.Forms.Button btndangnhap;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnsdk;
        private System.Windows.Forms.RadioButton radrender;
        private System.Windows.Forms.RadioButton radupload;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton radmanagerchannel;
        private System.Windows.Forms.RadioButton radreupfacebook;
    }
}