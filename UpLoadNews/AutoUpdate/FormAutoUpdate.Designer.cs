namespace AutoUpdate
{
    partial class FormAutoUpdate
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.prc = new System.Windows.Forms.ToolStripProgressBar();
            this.lblDangTai = new System.Windows.Forms.ToolStripStatusLabel();
            this.btncapnhat = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txthostfileupdate = new System.Windows.Forms.TextBox();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.prc,
            this.lblDangTai});
            this.statusStrip1.Location = new System.Drawing.Point(0, 130);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(559, 22);
            this.statusStrip1.TabIndex = 17;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // prc
            // 
            this.prc.Name = "prc";
            this.prc.Size = new System.Drawing.Size(250, 16);
            // 
            // lblDangTai
            // 
            this.lblDangTai.Name = "lblDangTai";
            this.lblDangTai.Size = new System.Drawing.Size(63, 17);
            this.lblDangTai.Text = "lblDangTai";
            // 
            // btncapnhat
            // 
            this.btncapnhat.Location = new System.Drawing.Point(121, 51);
            this.btncapnhat.Name = "btncapnhat";
            this.btncapnhat.Size = new System.Drawing.Size(83, 37);
            this.btncapnhat.TabIndex = 16;
            this.btncapnhat.Text = "Cập nhật";
            this.btncapnhat.UseVisualStyleBackColor = true;
            this.btncapnhat.Click += new System.EventHandler(this.btncapnhat_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "HOST_FILE_UPDATE:";
            // 
            // txthostfileupdate
            // 
            this.txthostfileupdate.Location = new System.Drawing.Point(121, 6);
            this.txthostfileupdate.Name = "txthostfileupdate";
            this.txthostfileupdate.Size = new System.Drawing.Size(425, 20);
            this.txthostfileupdate.TabIndex = 14;
            // 
            // FormAutoUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 152);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btncapnhat);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txthostfileupdate);
            this.Name = "FormAutoUpdate";
            this.Text = "FormAutoUpdate";
            this.Load += new System.EventHandler(this.FormAutoUpdate_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar prc;
        private System.Windows.Forms.ToolStripStatusLabel lblDangTai;
        private System.Windows.Forms.Button btncapnhat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txthostfileupdate;
    }
}