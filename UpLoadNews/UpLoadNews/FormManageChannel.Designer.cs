namespace UpLoadNews
{
    partial class FormManageChannel
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
            this.dataListVideo = new System.Windows.Forms.DataGridView();
            this.txttextchannel = new System.Windows.Forms.TextBox();
            this.btngetlist = new System.Windows.Forms.Button();
            this.txtidchannel = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btndeletevideo = new System.Windows.Forms.Button();
            this.btnvideotrunglap = new System.Windows.Forms.Button();
            this.dataListtrunglap = new System.Windows.Forms.DataGridView();
            this.txtpage = new System.Windows.Forms.TextBox();
            this.checkbyselenium = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataListVideo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataListtrunglap)).BeginInit();
            this.SuspendLayout();
            // 
            // dataListVideo
            // 
            this.dataListVideo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataListVideo.Location = new System.Drawing.Point(28, 105);
            this.dataListVideo.Name = "dataListVideo";
            this.dataListVideo.Size = new System.Drawing.Size(432, 421);
            this.dataListVideo.TabIndex = 0;
            // 
            // txttextchannel
            // 
            this.txttextchannel.Location = new System.Drawing.Point(28, 532);
            this.txttextchannel.Name = "txttextchannel";
            this.txttextchannel.Size = new System.Drawing.Size(765, 20);
            this.txttextchannel.TabIndex = 311;
            this.txttextchannel.Text = "AIzaSyCEz6I2fcRJXeDxx0fnKEWI9TBcLdpRZfo";
            // 
            // btngetlist
            // 
            this.btngetlist.Location = new System.Drawing.Point(422, 37);
            this.btngetlist.Name = "btngetlist";
            this.btngetlist.Size = new System.Drawing.Size(75, 23);
            this.btngetlist.TabIndex = 312;
            this.btngetlist.Text = "Get listvideo";
            this.btngetlist.UseVisualStyleBackColor = true;
            this.btngetlist.Click += new System.EventHandler(this.btngetlist_Click);
            // 
            // txtidchannel
            // 
            this.txtidchannel.Location = new System.Drawing.Point(28, 39);
            this.txtidchannel.Name = "txtidchannel";
            this.txtidchannel.Size = new System.Drawing.Size(388, 20);
            this.txtidchannel.TabIndex = 313;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 314;
            this.label1.Text = "ID channel";
            // 
            // btndeletevideo
            // 
            this.btndeletevideo.Location = new System.Drawing.Point(28, 76);
            this.btndeletevideo.Name = "btndeletevideo";
            this.btndeletevideo.Size = new System.Drawing.Size(83, 23);
            this.btndeletevideo.TabIndex = 315;
            this.btndeletevideo.Text = "Delete video";
            this.btndeletevideo.UseVisualStyleBackColor = true;
            this.btndeletevideo.Visible = false;
            this.btndeletevideo.Click += new System.EventHandler(this.btndeletevideo_Click);
            // 
            // btnvideotrunglap
            // 
            this.btnvideotrunglap.Location = new System.Drawing.Point(639, 39);
            this.btnvideotrunglap.Name = "btnvideotrunglap";
            this.btnvideotrunglap.Size = new System.Drawing.Size(93, 23);
            this.btnvideotrunglap.TabIndex = 316;
            this.btnvideotrunglap.Text = "Title count >1";
            this.btnvideotrunglap.UseVisualStyleBackColor = true;
            this.btnvideotrunglap.Click += new System.EventHandler(this.btnvideotrunglap_Click);
            // 
            // dataListtrunglap
            // 
            this.dataListtrunglap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataListtrunglap.Location = new System.Drawing.Point(466, 105);
            this.dataListtrunglap.Name = "dataListtrunglap";
            this.dataListtrunglap.Size = new System.Drawing.Size(508, 421);
            this.dataListtrunglap.TabIndex = 317;
            // 
            // txtpage
            // 
            this.txtpage.Location = new System.Drawing.Point(820, 532);
            this.txtpage.Name = "txtpage";
            this.txtpage.Size = new System.Drawing.Size(154, 20);
            this.txtpage.TabIndex = 318;
            // 
            // checkbyselenium
            // 
            this.checkbyselenium.AutoSize = true;
            this.checkbyselenium.Location = new System.Drawing.Point(503, 43);
            this.checkbyselenium.Name = "checkbyselenium";
            this.checkbyselenium.Size = new System.Drawing.Size(114, 17);
            this.checkbyselenium.TabIndex = 319;
            this.checkbyselenium.Text = "check by selenium";
            this.checkbyselenium.UseVisualStyleBackColor = true;
            // 
            // FormManageChannel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 569);
            this.Controls.Add(this.checkbyselenium);
            this.Controls.Add(this.txtpage);
            this.Controls.Add(this.dataListtrunglap);
            this.Controls.Add(this.btnvideotrunglap);
            this.Controls.Add(this.btndeletevideo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtidchannel);
            this.Controls.Add(this.btngetlist);
            this.Controls.Add(this.txttextchannel);
            this.Controls.Add(this.dataListVideo);
            this.Name = "FormManageChannel";
            this.Text = "FormManageChannel";
            this.Load += new System.EventHandler(this.FormManageChannel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataListVideo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataListtrunglap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataListVideo;
        private System.Windows.Forms.TextBox txttextchannel;
        private System.Windows.Forms.Button btngetlist;
        private System.Windows.Forms.TextBox txtidchannel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btndeletevideo;
        private System.Windows.Forms.Button btnvideotrunglap;
        private System.Windows.Forms.DataGridView dataListtrunglap;
        private System.Windows.Forms.TextBox txtpage;
        private System.Windows.Forms.CheckBox checkbyselenium;
    }
}