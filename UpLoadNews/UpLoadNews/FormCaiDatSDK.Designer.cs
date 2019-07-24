namespace UpLoadNews
{
    partial class FormCaiDatSDK
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
            this.btnbuoc1 = new System.Windows.Forms.Button();
            this.btnbuoc2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnbuoc3 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnbuoc1
            // 
            this.btnbuoc1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnbuoc1.ForeColor = System.Drawing.Color.Red;
            this.btnbuoc1.Location = new System.Drawing.Point(45, 45);
            this.btnbuoc1.Name = "btnbuoc1";
            this.btnbuoc1.Size = new System.Drawing.Size(150, 51);
            this.btnbuoc1.TabIndex = 0;
            this.btnbuoc1.Text = "Bước 1 cài SDK";
            this.btnbuoc1.UseVisualStyleBackColor = true;
            this.btnbuoc1.Click += new System.EventHandler(this.btnbuoc1_Click);
            // 
            // btnbuoc2
            // 
            this.btnbuoc2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnbuoc2.ForeColor = System.Drawing.Color.Red;
            this.btnbuoc2.Location = new System.Drawing.Point(45, 137);
            this.btnbuoc2.Name = "btnbuoc2";
            this.btnbuoc2.Size = new System.Drawing.Size(150, 51);
            this.btnbuoc2.TabIndex = 1;
            this.btnbuoc2.Text = "Bước 2 pack SDK";
            this.btnbuoc2.UseVisualStyleBackColor = true;
            this.btnbuoc2.Click += new System.EventHandler(this.btnbuoc2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(210, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Chỉ việc ấn rồi next cài đặt";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label2.Location = new System.Drawing.Point(210, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(255, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Pack xong thì vào app chiến thôi ^^!";
            // 
            // btnbuoc3
            // 
            this.btnbuoc3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnbuoc3.ForeColor = System.Drawing.Color.Red;
            this.btnbuoc3.Location = new System.Drawing.Point(45, 232);
            this.btnbuoc3.Name = "btnbuoc3";
            this.btnbuoc3.Size = new System.Drawing.Size(150, 51);
            this.btnbuoc3.TabIndex = 4;
            this.btnbuoc3.Text = "Bước 3 pack lại SDK";
            this.btnbuoc3.UseVisualStyleBackColor = true;
            this.btnbuoc3.Click += new System.EventHandler(this.btnbuoc3_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label3.Location = new System.Drawing.Point(210, 249);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(339, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Khi copy sang máy khác đã cài sdk cần pack lại";
            // 
            // FormCaiDatSDK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 351);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnbuoc3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnbuoc2);
            this.Controls.Add(this.btnbuoc1);
            this.Name = "FormCaiDatSDK";
            this.Text = "FormCaiDatSDK";
            this.Load += new System.EventHandler(this.FormCaiDatSDK_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnbuoc1;
        private System.Windows.Forms.Button btnbuoc2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnbuoc3;
        private System.Windows.Forms.Label label3;
    }
}