using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.WindowsAPICodePack.Shell;
namespace UpLoadNews
{
   public  class TimesFile
    {
        public static double Convert100NanosecondsToMilliseconds(double nanoseconds)
        {
            return nanoseconds * 0.0001;
        }

        public double GetTime(string path)
        {
            double time = 0;
            string file = path;
            ShellFile so = ShellFile.FromFilePath(file);
            double.TryParse(so.Properties.System.Media.Duration.Value.ToString(), out time);
            if (time > 0)
            {
                time = Math.Round(Convert100NanosecondsToMilliseconds(time) / 1000, 0);
            }
            return time;

        }
    }
}
