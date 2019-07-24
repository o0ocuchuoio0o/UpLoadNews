namespace UpLoadNews
{
    partial class FormReupFacebook
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
            this.components = new System.ComponentModel.Container();
            this.btninputfolder = new System.Windows.Forms.Button();
            this.txtfoldervideo = new System.Windows.Forms.TextBox();
            this.dataListFile = new System.Windows.Forms.DataGridView();
            this.txtvideomax = new System.Windows.Forms.NumericUpDown();
            this.checkdelfolder = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtvideoupload = new System.Windows.Forms.NumericUpDown();
            this.btnrender = new System.Windows.Forms.Button();
            this.txtlinkpage = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnsavelink = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.prs = new System.Windows.Forms.ToolStripProgressBar();
            this.lblxuly = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.bgwrender = new System.ComponentModel.BackgroundWorker();
            this.timerrender = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataListFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtvideomax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtvideoupload)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btninputfolder
            // 
            this.btninputfolder.Location = new System.Drawing.Point(55, 38);
            this.btninputfolder.Name = "btninputfolder";
            this.btninputfolder.Size = new System.Drawing.Size(95, 23);
            this.btninputfolder.TabIndex = 260;
            this.btninputfolder.Text = "&Input Video";
            this.btninputfolder.UseVisualStyleBackColor = true;
            this.btninputfolder.Click += new System.EventHandler(this.btninputfolder_Click);
            // 
            // txtfoldervideo
            // 
            this.txtfoldervideo.BackColor = System.Drawing.Color.Yellow;
            this.txtfoldervideo.Enabled = false;
            this.txtfoldervideo.Location = new System.Drawing.Point(156, 38);
            this.txtfoldervideo.Name = "txtfoldervideo";
            this.txtfoldervideo.Size = new System.Drawing.Size(668, 20);
            this.txtfoldervideo.TabIndex = 261;
            // 
            // dataListFile
            // 
            this.dataListFile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataListFile.Location = new System.Drawing.Point(55, 66);
            this.dataListFile.Name = "dataListFile";
            this.dataListFile.Size = new System.Drawing.Size(769, 334);
            this.dataListFile.TabIndex = 262;
            // 
            // txtvideomax
            // 
            this.txtvideomax.Location = new System.Drawing.Point(132, 464);
            this.txtvideomax.Name = "txtvideomax";
            this.txtvideomax.Size = new System.Drawing.Size(66, 20);
            this.txtvideomax.TabIndex = 348;
            this.txtvideomax.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // checkdelfolder
            // 
            this.checkdelfolder.AutoSize = true;
            this.checkdelfolder.Checked = true;
            this.checkdelfolder.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkdelfolder.Location = new System.Drawing.Point(132, 441);
            this.checkdelfolder.Name = "checkdelfolder";
            this.checkdelfolder.Size = new System.Drawing.Size(86, 17);
            this.checkdelfolder.TabIndex = 347;
            this.checkdelfolder.Text = "Delete video";
            this.checkdelfolder.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(51, 438);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 13);
            this.label8.TabIndex = 346;
            this.label8.Text = "Video upload :";
            // 
            // txtvideoupload
            // 
            this.txtvideoupload.Location = new System.Drawing.Point(50, 464);
            this.txtvideoupload.Name = "txtvideoupload";
            this.txtvideoupload.Size = new System.Drawing.Size(66, 20);
            this.txtvideoupload.TabIndex = 345;
            // 
            // btnrender
            // 
            this.btnrender.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnrender.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnrender.Location = new System.Drawing.Point(722, 420);
            this.btnrender.Name = "btnrender";
            this.btnrender.Size = new System.Drawing.Size(102, 48);
            this.btnrender.TabIndex = 349;
            this.btnrender.Text = "Begin upload";
            this.btnrender.UseVisualStyleBackColor = true;
            this.btnrender.Click += new System.EventHandler(this.btnrender_Click);
            // 
            // txtlinkpage
            // 
            this.txtlinkpage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.txtlinkpage.Location = new System.Drawing.Point(132, 529);
            this.txtlinkpage.Name = "txtlinkpage";
            this.txtlinkpage.Size = new System.Drawing.Size(586, 20);
            this.txtlinkpage.TabIndex = 350;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 532);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 351;
            this.label1.Text = "Link page :";
            // 
            // btnsavelink
            // 
            this.btnsavelink.Location = new System.Drawing.Point(724, 527);
            this.btnsavelink.Name = "btnsavelink";
            this.btnsavelink.Size = new System.Drawing.Size(50, 23);
            this.btnsavelink.TabIndex = 352;
            this.btnsavelink.Text = "&SAVE";
            this.btnsavelink.UseVisualStyleBackColor = true;
            this.btnsavelink.Click += new System.EventHandler(this.btnsavelink_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.prs,
            this.lblxuly,
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 556);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(878, 36);
            this.statusStrip1.TabIndex = 353;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // prs
            // 
            this.prs.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.prs.Name = "prs";
            this.prs.Size = new System.Drawing.Size(200, 30);
            // 
            // lblxuly
            // 
            this.lblxuly.Name = "lblxuly";
            this.lblxuly.Size = new System.Drawing.Size(0, 31);
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 30);
            // 
            // bgwrender
            // 
            this.bgwrender.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwrender_DoWork);
            this.bgwrender.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwrender_RunWorkerCompleted);
            // 
            // timerrender
            // 
            this.timerrender.Tick += new System.EventHandler(this.timerrender_Tick);
            // 
            // FormReupFacebook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 592);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnsavelink);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtlinkpage);
            this.Controls.Add(this.btnrender);
            this.Controls.Add(this.txtvideomax);
            this.Controls.Add(this.checkdelfolder);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtvideoupload);
            this.Controls.Add(this.dataListFile);
            this.Controls.Add(this.btninputfolder);
            this.Controls.Add(this.txtfoldervideo);
            this.Name = "FormReupFacebook";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormReupFacebook";
            this.Load += new System.EventHandler(this.FormReupFacebook_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataListFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtvideomax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtvideoupload)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btninputfolder;
        private System.Windows.Forms.TextBox txtfoldervideo;
        private System.Windows.Forms.DataGridView dataListFile;
        private System.Windows.Forms.NumericUpDown txtvideomax;
        private System.Windows.Forms.CheckBox checkdelfolder;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown txtvideoupload;
        private System.Windows.Forms.Button btnrender;
        private System.Windows.Forms.TextBox txtlinkpage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnsavelink;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar prs;
        private System.Windows.Forms.ToolStripStatusLabel lblxuly;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.ComponentModel.BackgroundWorker bgwrender;
        private System.Windows.Forms.Timer timerrender;
    }
}