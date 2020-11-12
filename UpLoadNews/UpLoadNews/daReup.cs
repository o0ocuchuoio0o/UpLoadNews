using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.ComponentModel;
using Facebook;
using System.Dynamic;

namespace UpLoadNews
{
    public class daReup
    {
        public DataTable DerializeDataTable(string json)
        {
            DataTable dt = (DataTable)JsonConvert.DeserializeObject("[" + json.ToString() + "]", (typeof(DataTable)));
            return dt;
        }

        public DataTable LayThongTinCaNhan(string tokent)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(string));
            dt.Columns.Add("name", typeof(string));
            dt.Columns.Add("access_token", typeof(string));

            string linkAPI = "https://graph.facebook.com/me?access_token=" + tokent;
            var client = new RestClient(linkAPI);
            var request = new RestRequest(Method.GET);
            client.Timeout = -1;
            request.AddHeader("Content-Type", "application/json");
            try
            {
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    DataTable dulieu = new DataTable();
                    dulieu = DerializeDataTable(response.Content);
                    if (dulieu.Rows.Count > 0)
                    {
                        DataRow r = dulieu.Rows[0];
                        dt.Rows.Add(r["id"].ToString(), r["name"].ToString(), tokent);
                    }
                }

            }
            catch { }
            return dt;

        }
        public DataTable LayThongTinListPage(string tokent, string uid)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(string));
            dt.Columns.Add("name", typeof(string));
            dt.Columns.Add("access_token", typeof(string));


            string linkAPI = "https://graph.facebook.com/" + uid + "/accounts?access_token=" + tokent;
            var client = new RestClient(linkAPI);
            var request = new RestRequest(Method.GET);
            client.Timeout = -1;

            try
            {
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {

                    dynamic dynObj = JsonConvert.DeserializeObject(response.Content);
                    var _data = dynObj.data;
                    string m_data = Convert.ToString(_data);
                    var jArraydata = JArray.Parse(m_data);
                    foreach (JObject j in jArraydata)
                    {
                        dynamic dynObjdata = JsonConvert.DeserializeObject(j.ToString());
                        var _access_token = dynObjdata.access_token;
                        var _name = dynObjdata.name;
                        var _id = dynObjdata.id;
                        string m_access_token = Convert.ToString(_access_token);
                        string m_name = Convert.ToString(_name);
                        string m_id = Convert.ToString(_id);
                        dt.Rows.Add(m_id, m_name, m_access_token);
                    }


                }

            }
            catch { }
            return dt;

        }

        public DataTable LayThongTinInfoVideo(string tokent, string listlinkvideo)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Link", typeof(string));
            dt.Columns.Add("TieuDe", typeof(string));
            dt.Columns.Add("Thumnail", typeof(string));
            string[] manglink = listlinkvideo.ToString().Split('|');
            for (int i = 0; i < manglink.Length; i++)
            {
                string idvideo = manglink[i].ToString().Replace("https://www.youtube.com/watch?v=", "");
                string linkAPI = "https://www.googleapis.com/youtube/v3/videos?part=id%2C+snippet&id=" + idvideo + "&key=" + tokent;
                var client = new RestClient(linkAPI);
                var request = new RestRequest(Method.GET);
                client.Timeout = -1;

                try
                {
                    IRestResponse response = client.Execute(request);
                    if (response.StatusCode == HttpStatusCode.OK)
                    {

                        dynamic dynObj = JsonConvert.DeserializeObject(response.Content);
                        var _items = dynObj.items;
                        string m_items = Convert.ToString(_items);
                        var jArraydata = JArray.Parse(m_items);
                        foreach (JObject j in jArraydata)
                        {
                            dynamic dynObjdata = JsonConvert.DeserializeObject(j.ToString());
                            var _snippet = dynObjdata.snippet;
                            string m_snippet = Convert.ToString(_snippet);

                            dynamic dynObjdata1 = JsonConvert.DeserializeObject(m_snippet.ToString());
                            var _TieuDe = dynObjdata1.title;
                            string m_TieuDe = Convert.ToString(_TieuDe);
                            dt.Rows.Add(manglink[i].ToString(), m_TieuDe, "https://i.ytimg.com/vi/" + idvideo + "/default.jpg");


                        }


                    }

                }
                catch { }
            }
            return dt;

        }

        public void UpLoadVideo(string tokent, string filename, string path, string title, string description, string uidpage, string thumnail)
        {
            try
            {
                var fbp = new FacebookClient(tokent);
                dynamic parameters = new ExpandoObject();
                parameters.source = new FacebookMediaObject { ContentType = "multipart/form-data", FileName = filename }.SetValue(System.IO.File.ReadAllBytes(path));
                parameters.title = title;
                parameters.description = description;
                parameters.picture = thumnail;
                // parameters.locale = "es_LA";
                string url = "https://graph-video.facebook.com/" + uidpage + "/videos";
                dynamic result = fbp.Post(url, parameters);

            }
            catch
            {


            }
        }

        public void UpLoadVideoLocal(string tokent, string filename, string path, string title, string description, string uidpage, string thumnail, string paththumnail)
        {
            try
            {
                var fbp = new FacebookClient(tokent);
                dynamic parameters = new ExpandoObject();
                parameters.source = new FacebookMediaObject { ContentType = "multipart/form-data", FileName = filename }.SetValue(System.IO.File.ReadAllBytes(path));
                parameters.title = title;
                parameters.description = description;
                parameters.thumb = new FacebookMediaObject { ContentType = "image/jpeg", FileName = thumnail }.SetValue(System.IO.File.ReadAllBytes(paththumnail)); ;
                // parameters.locale = "es_LA";
                string url = "https://graph-video.facebook.com/" + uidpage + "/videos";
                dynamic result = fbp.Post(url, parameters);

            }
            catch
            {


            }
        }
    }
}
