using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UpLoadNews
{
    public partial class FormCaiDatSDK : Form
    {
        public FormCaiDatSDK()
        {
            InitializeComponent();
        }

        private void btnbuoc1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.ProcessStartInfo oInfo = new System.Diagnostics.ProcessStartInfo();
            string runvideo = System.IO.Directory.GetCurrentDirectory() + @"\SDK\SDK.exe";
            oInfo.FileName = runvideo;           
            System.Diagnostics.Process procvideo = new System.Diagnostics.Process();
            procvideo.StartInfo = oInfo;
            procvideo.StartInfo.Verb = "runas";
            procvideo.Start();
            procvideo.WaitForExit();
            procvideo.Close();
        }

        private void btnbuoc2_Click(object sender, EventArgs e)
        {
            #region // pack file
            System.Diagnostics.ProcessStartInfo oInfo = new System.Diagnostics.ProcessStartInfo();
            string runvideo = System.IO.Directory.GetCurrentDirectory() + @"\SDK\InstallAsActiveX.bat";
            oInfo.FileName = runvideo;
            System.Diagnostics.Process procvideo = new System.Diagnostics.Process();
            procvideo.StartInfo = oInfo;
            procvideo.StartInfo.Verb = "runas";
            procvideo.Start();
            procvideo.WaitForExit();
            procvideo.Close();
            #endregion

            #region // copy dll đã pack vô chương trình
            String path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filedll = path + @"\ByteScout Samples\Image To Video SDK\Visual C#\Full Featured Demo\__precompiled\Release\Interop.BytescoutImageToVideo.dll";
            System.IO.File.Copy(filedll, System.IO.Directory.GetCurrentDirectory()+ @"\Interop.BytescoutImageToVideo.dll", true);
            System.IO.File.Copy(filedll, System.IO.Directory.GetCurrentDirectory() + @"\Effect\Interop.BytescoutImageToVideo.dll", true);
            #endregion
        }

        private void FormCaiDatSDK_Load(object sender, EventArgs e)
        {

        }

        private void btnbuoc3_Click(object sender, EventArgs e)
        {
            #region // pack file
            System.Diagnostics.ProcessStartInfo oInfo = new System.Diagnostics.ProcessStartInfo();
            string runvideo = System.IO.Directory.GetCurrentDirectory() + @"\SDK\InstallAsActiveX.bat";
            oInfo.FileName = runvideo;
            System.Diagnostics.Process procvideo = new System.Diagnostics.Process();
            procvideo.StartInfo = oInfo;
            procvideo.StartInfo.Verb = "runas";
            procvideo.Start();
            procvideo.WaitForExit();
            procvideo.Close();
            #endregion

            #region // copy dll đã pack vô chương trình
            String path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filedll = path + @"\ByteScout Samples\Image To Video SDK\Visual C#\Full Featured Demo\__precompiled\Release\Interop.BytescoutImageToVideo.dll";
            System.IO.File.Copy(filedll, System.IO.Directory.GetCurrentDirectory() + @"\Interop.BytescoutImageToVideo.dll", true);
            System.IO.File.Copy(filedll, System.IO.Directory.GetCurrentDirectory() + @"\Effect\Interop.BytescoutImageToVideo.dll", true);
            #endregion
        }
    }
}
