using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net;
using System.IO;
using System.Data;
namespace UpLoadNews
{
    public class Picturegoogle
    {
        public string GetHtmlCode(string chuoitimkiem)
        {
            var rnd = new Random();
            string url = "https://www.google.com/search?q=" + chuoitimkiem + "&tbm=isch";
            string data = "";

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Accept = "text/html, application/xhtml+xml, */*";
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; Trident/7.0; rv:11.0) like Gecko";

            var response = (HttpWebResponse)request.GetResponse();

            using (Stream dataStream = response.GetResponseStream())
            {
                if (dataStream == null)
                    return "";
                using (var sr = new StreamReader(dataStream))
                {
                    data = sr.ReadToEnd();
                }
            }
            return data;
        }

        public DataTable GetUrls(string html)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("LinkAnh", typeof(string));
            try
            {
                int ndx = html.IndexOf("\"ou\"", StringComparison.Ordinal);
                while (ndx >= 0)
                {
                    ndx = html.IndexOf("\"", ndx + 4, StringComparison.Ordinal);
                    ndx++;
                    int ndx2 = html.IndexOf("\"", ndx, StringComparison.Ordinal);
                    string url = html.Substring(ndx, ndx2 - ndx);
                    dt.Rows.Add(url);
                    ndx = html.IndexOf("\"ou\"", ndx2, StringComparison.Ordinal);
                }
            }
            catch { }
            return dt;
        }
        public byte[] GetImage(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            var response = (HttpWebResponse)request.GetResponse();

            using (Stream dataStream = response.GetResponseStream())
            {
                if (dataStream == null)
                    return null;
                using (var sr = new BinaryReader(dataStream))
                {
                    byte[] bytes = sr.ReadBytes(100000000);

                    return bytes;
                }
            }

            return null;
        }
    }
}
