using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Net;
using System.Web;
using xNet;
using RestSharp;
using System.Data;
using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;

namespace UpLoadNews
{
    public class Cl_Tag
    {
        public static string GetTag(string title)
        {
            string kq = "";
            string[] mangtag = title.ToString().Split(new string[] { " " }, StringSplitOptions.None);
            Random rand = new Random();
            for (int i = 0; i < mangtag.Length; i++)
            {

                int temp = rand.Next(mangtag.Length);
                kq = kq + "," + mangtag[temp];
            }
            return kq;

        }

        public string getTagFromrApidtags(string title, int numberTag)
        {
            string str = $"https://rapidtags.io/api/index.php?tool=tag-generator&input={HttpUtility.UrlEncode(title)}";
            xNet.HttpRequest request = new xNet.HttpRequest();
            request.UserAgent="Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/67.0.3396.87 Safari/537.36";
            request.AddHeader("accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8");
            request.AddHeader("authority", "rapidtags.io");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("accept-language", "vi");
            request.AddHeader("pragma", "no-cache");
            request.AddHeader("upgrade-insecure-requests", "1");
            request.AddHeader(":scheme", "https");
            request.Authorization="Basic YWhdZWQer5WhtZWRAMjAxNw==";
           
            request.Cookies=new CookieDictionary(false);
            var m_params = new RequestParams();
            m_params["tool"] = "tag-generator";
            m_params["input"] = title;
            //RequestParams @params = new RequestParams();
            //@params.set_Item("tool", "tag-generator");
            //@params.set_Item("input", title);           
            xNet.HttpResponse response = request.Post("https://rapidtags.io/api/index.php", m_params);
            System.Threading.Thread.Sleep(3000);
            char[] separator = new char[] { ',' };
            string[] source = response.ToString().Replace("[", "").Replace("]", "").Replace("\"", "").Split(separator);
            string str2 = "";
            foreach (string str3 in source.Take<string>(numberTag))
            {
                str2 = str2 + str3 + ",";
            }
           
            return WebUtility.HtmlDecode(str2);
        }


        public DataTable DerializeDataTable(string json)
        {
            DataTable dt = (DataTable)JsonConvert.DeserializeObject( json , (typeof(DataTable)));
            return dt;
        }
        public string _Tag(string title)
        {
            string tag = "";
            DataTable dt = new DataTable();
            //string link = @"https://rapidtags.io/api/index.php?tool=tag-generator&input=" + title;
            string link =@"https://rapidtags.io/api/index.php?tool=tag-generator&input=%EB%85%84%EA%B9%8C%EC%A7%80%20%EB%8B%A4%20%EC%A0%84%EA%B8%B0%EC%B0%A8%EB%A1%9C%20%EB%B0%B0%EB%8B%AC%ED%95%B4%20%EC%A3%BC%EC%85%94%EC%95%BC%20%ED%95%A9%EB%8B%88%EB%8B%A4.";
            var client = new RestClient(link);
            var request = new RestRequest(Method.POST);
            //request.AddParameter("tool", "tag-generator");
            //request.AddParameter("input", title);
            request.AddHeader("postman-token", "2550f11c-12f3-24a3-451c-2cec57a08068");
            request.AddHeader("cache-control", "no-cache");
            IRestResponse response = client.Execute(request);
            if (response != null && response.Content != null && response.Content.Length > 0)
            {
                try
                {
                    dt = DerializeDataTable(response.Content);
                }
                catch { }

            }
            return tag;
        }

     
    }
}
