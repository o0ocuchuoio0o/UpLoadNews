namespace UpLoadNews
{
    partial class WebAutomationV2
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
            this.geckoupload = new Gecko.GeckoWebBrowser();
            this.SuspendLayout();
            // 
            // geckoupload
            // 
            this.geckoupload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.geckoupload.FrameEventsPropagateToMainWindow = false;
            this.geckoupload.Location = new System.Drawing.Point(0, 0);
            this.geckoupload.Name = "geckoupload";
            this.geckoupload.Size = new System.Drawing.Size(787, 534);
            this.geckoupload.TabIndex = 3;
            this.geckoupload.UseHttpActivityObserver = false;
            // 
            // WebAutomationV2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 534);
            this.Controls.Add(this.geckoupload);
            this.Name = "WebAutomationV2";
            this.Text = "WebAutomationV2";
            this.Load += new System.EventHandler(this.WebAutomationV2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Gecko.GeckoWebBrowser geckoupload;
    }
}