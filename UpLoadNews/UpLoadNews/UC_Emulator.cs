using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace UpLoadNews
{
    public partial class UC_Emulator : UserControl
    {
        public UC_Emulator(string idprosess,string name)
        {
            InitializeComponent();
            m_idprosess = idprosess;
            m_name = name;
        }
        private string m_idprosess;
        private string m_name;

        public string Idprosess
        {
            get
            {
                return m_idprosess;
            }

            set
            {
                m_idprosess = value;
            }
        }

        public string Name1
        {
            get
            {
                return m_name;
            }

            set
            {
                m_name = value;
            }
        }

        private void UC_Emulator_Load(object sender, EventArgs e)
        {
            lblname.Text = m_name;
        }
        public void KillProcess(int pid)
        {
            Process[] process = Process.GetProcesses();

            foreach (Process prs in process)
            {
                if (prs.Id == pid)
                {
                    prs.Kill();
                    break;
                }
            }
        }
        private void btnclose_Click(object sender, EventArgs e)
        {
            KillProcess(int.Parse(m_idprosess));
        }
    }
}
