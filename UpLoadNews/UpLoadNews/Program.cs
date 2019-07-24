using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace UpLoadNews
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // test thử phát coi
            Application.Run(new Login());
        }
    }
}
