namespace UpLoadNews
{
    partial class FormEmulator
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
            this.btncloseall = new System.Windows.Forms.Button();
            this.dataGridViewList = new System.Windows.Forms.DataGridView();
            this.txtpathldplayer = new System.Windows.Forms.TextBox();
            this.btnrefesh = new System.Windows.Forms.Button();
            this.btnopenemulator = new System.Windows.Forms.Button();
            this.btnsub = new System.Windows.Forms.Button();
            this.btnview = new System.Windows.Forms.Button();
            this.btncaiapp = new System.Windows.Forms.Button();
            this.btnfakeip = new System.Windows.Forms.Button();
            this.txtlinkvideo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txttime = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txttime)).BeginInit();
            this.SuspendLayout();
            // 
            // btncloseall
            // 
            this.btncloseall.Location = new System.Drawing.Point(1207, 5);
            this.btncloseall.Name = "btncloseall";
            this.btncloseall.Size = new System.Drawing.Size(75, 23);
            this.btncloseall.TabIndex = 5;
            this.btncloseall.Text = "Close all";
            this.btncloseall.UseVisualStyleBackColor = true;
            this.btncloseall.Click += new System.EventHandler(this.btncloseall_Click);
            // 
            // dataGridViewList
            // 
            this.dataGridViewList.AllowUserToAddRows = false;
            this.dataGridViewList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewList.Location = new System.Drawing.Point(12, 176);
            this.dataGridViewList.Name = "dataGridViewList";
            this.dataGridViewList.Size = new System.Drawing.Size(246, 576);
            this.dataGridViewList.TabIndex = 6;
            // 
            // txtpathldplayer
            // 
            this.txtpathldplayer.BackColor = System.Drawing.SystemColors.Info;
            this.txtpathldplayer.Location = new System.Drawing.Point(13, 8);
            this.txtpathldplayer.Name = "txtpathldplayer";
            this.txtpathldplayer.Size = new System.Drawing.Size(245, 20);
            this.txtpathldplayer.TabIndex = 7;
            // 
            // btnrefesh
            // 
            this.btnrefesh.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnrefesh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnrefesh.Location = new System.Drawing.Point(264, 6);
            this.btnrefesh.Name = "btnrefesh";
            this.btnrefesh.Size = new System.Drawing.Size(94, 22);
            this.btnrefesh.TabIndex = 339;
            this.btnrefesh.Text = "Refesh";
            this.btnrefesh.UseVisualStyleBackColor = true;
            this.btnrefesh.Click += new System.EventHandler(this.btnrefesh_Click);
            // 
            // btnopenemulator
            // 
            this.btnopenemulator.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnopenemulator.ForeColor = System.Drawing.Color.Red;
            this.btnopenemulator.Location = new System.Drawing.Point(13, 50);
            this.btnopenemulator.Name = "btnopenemulator";
            this.btnopenemulator.Size = new System.Drawing.Size(103, 22);
            this.btnopenemulator.TabIndex = 340;
            this.btnopenemulator.Text = "Open emulator";
            this.btnopenemulator.UseVisualStyleBackColor = true;
            this.btnopenemulator.Click += new System.EventHandler(this.btnopenemulator_Click);
            // 
            // btnsub
            // 
            this.btnsub.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnsub.Location = new System.Drawing.Point(156, 81);
            this.btnsub.Name = "btnsub";
            this.btnsub.Size = new System.Drawing.Size(103, 22);
            this.btnsub.TabIndex = 346;
            this.btnsub.Text = "Sub";
            this.btnsub.UseVisualStyleBackColor = true;
            this.btnsub.Click += new System.EventHandler(this.btnsub_Click);
            // 
            // btnview
            // 
            this.btnview.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnview.Location = new System.Drawing.Point(155, 115);
            this.btnview.Name = "btnview";
            this.btnview.Size = new System.Drawing.Size(103, 22);
            this.btnview.TabIndex = 347;
            this.btnview.Text = "View";
            this.btnview.UseVisualStyleBackColor = true;
            this.btnview.Click += new System.EventHandler(this.btnview_Click);
            // 
            // btncaiapp
            // 
            this.btncaiapp.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncaiapp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btncaiapp.Location = new System.Drawing.Point(155, 148);
            this.btncaiapp.Name = "btncaiapp";
            this.btncaiapp.Size = new System.Drawing.Size(103, 22);
            this.btncaiapp.TabIndex = 348;
            this.btncaiapp.Text = "App";
            this.btncaiapp.UseVisualStyleBackColor = true;
            // 
            // btnfakeip
            // 
            this.btnfakeip.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnfakeip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnfakeip.Location = new System.Drawing.Point(155, 50);
            this.btnfakeip.Name = "btnfakeip";
            this.btnfakeip.Size = new System.Drawing.Size(103, 22);
            this.btnfakeip.TabIndex = 349;
            this.btnfakeip.Text = "Fake IP";
            this.btnfakeip.UseVisualStyleBackColor = true;
            this.btnfakeip.Click += new System.EventHandler(this.btnfakeip_Click);
            // 
            // txtlinkvideo
            // 
            this.txtlinkvideo.BackColor = System.Drawing.SystemColors.Info;
            this.txtlinkvideo.Location = new System.Drawing.Point(614, 5);
            this.txtlinkvideo.Name = "txtlinkvideo";
            this.txtlinkvideo.Size = new System.Drawing.Size(302, 20);
            this.txtlinkvideo.TabIndex = 350;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(546, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 351;
            this.label1.Text = "Link video :";
            // 
            // txttime
            // 
            this.txttime.Location = new System.Drawing.Point(13, 118);
            this.txttime.Maximum = new decimal(new int[] {
            276447232,
            23283,
            0,
            0});
            this.txttime.Name = "txttime";
            this.txttime.Size = new System.Drawing.Size(94, 20);
            this.txttime.TabIndex = 352;
            this.txttime.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(113, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 353;
            this.label2.Text = "giây(s)";
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.Location = new System.Drawing.Point(265, 176);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(1052, 576);
            this.flowLayoutPanel.TabIndex = 354;
            // 
            // FormEmulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1329, 770);
            this.Controls.Add(this.flowLayoutPanel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txttime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtlinkvideo);
            this.Controls.Add(this.btnfakeip);
            this.Controls.Add(this.btncaiapp);
            this.Controls.Add(this.btnview);
            this.Controls.Add(this.btnsub);
            this.Controls.Add(this.btnopenemulator);
            this.Controls.Add(this.btnrefesh);
            this.Controls.Add(this.txtpathldplayer);
            this.Controls.Add(this.dataGridViewList);
            this.Controls.Add(this.btncloseall);
            this.Name = "FormEmulator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormEmulator";
            this.Load += new System.EventHandler(this.FormEmulator_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txttime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btncloseall;
        private System.Windows.Forms.DataGridView dataGridViewList;
        private System.Windows.Forms.TextBox txtpathldplayer;
        private System.Windows.Forms.Button btnrefesh;
        private System.Windows.Forms.Button btnopenemulator;
        private System.Windows.Forms.Button btnsub;
        private System.Windows.Forms.Button btnview;
        private System.Windows.Forms.Button btncaiapp;
        private System.Windows.Forms.Button btnfakeip;
        private System.Windows.Forms.TextBox txtlinkvideo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown txttime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
    }
}