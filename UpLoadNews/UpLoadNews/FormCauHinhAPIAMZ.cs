using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Amazon;
using NAudio;
using System.Threading;
using System.IO;
using Amazon.Runtime;
using DaoUploadNews;
namespace UpLoadNews
{
    public partial class FormCauHinhAPIAMZ : Form
    {
        public FormCauHinhAPIAMZ()
        {
            InitializeComponent();
        }
        private void laythongtinhethong()
        {
            CauHinhServerBE hethong = new CauHinhServerBE();
            CauHinhServerBL tkxuly = new CauHinhServerBL();
            //dog nay de load xml trong debug ne
            hethong = tkxuly.docdulieu(Environment.CurrentDirectory + "/CauHinhAPIAMZ.xml");           
            txtAccessKey.Text = hethong.User1;
            txtSecretKey.Text = hethong.Pass1;
          

        }
        private void FormCauHinhAPIAMZ_Load(object sender, EventArgs e)
        {
            laythongtinhethong();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            CauHinhServerBE hethong = new CauHinhServerBE();
            CauHinhServerBL tkxuly = new CauHinhServerBL();         
            hethong.User1 = txtAccessKey.Text.Trim();
            hethong.Pass1 = txtSecretKey.Text.Trim();
            tkxuly.ghidulieu(hethong, Environment.CurrentDirectory + "/CauHinhAPIAMZ.xml");
            MessageBox.Show("ok");
        }

        private void btntest_Click(object sender, EventArgs e)
        {
            try
            {
                BasicAWSCredentials connect = new BasicAWSCredentials(txtAccessKey.Text, txtSecretKey.Text);
                Amazon.Polly.AmazonPollyClient cl = new Amazon.Polly.AmazonPollyClient(connect, RegionEndpoint.USWest1);
                Amazon.Polly.Model.SynthesizeSpeechRequest req = new Amazon.Polly.Model.SynthesizeSpeechRequest();
                req.Text = "Hello word!";
                req.VoiceId = Amazon.Polly.VoiceId.Salli;
                req.OutputFormat = Amazon.Polly.OutputFormat.Mp3;
                req.SampleRate = "8000";
                req.TextType = Amazon.Polly.TextType.Text;
                Console.WriteLine("Sending Amazon Polly request: " + req.Text);
                Amazon.Polly.Model.SynthesizeSpeechResponse resp = cl.SynthesizeSpeech(req);               
                MessageBox.Show("ok amazon");
            }
            catch (Exception ex) {
                MessageBox.Show("Loi"+ex.ToString());
                return;
            }
        }
    }
}
