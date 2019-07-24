using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
namespace DaoUploadNews
{
    public class VessionBL
    {
        private XmlDocument doc;
        private XmlElement root;
        public VessionBE docdulieu(string strpath)
        {  //khoi tao bien va load tai lieu xml
            VessionBE vession = new VessionBE();
            doc = new XmlDocument();
            doc.Load(strpath);
            //duyet den cac nut cua xml
            root = doc.DocumentElement;
            string kiemtra = root.SelectSingleNode("vession").InnerText;

            if (kiemtra != "" && kiemtra != string.Empty)
            {
                vession.Vession = kiemtra;
            }
            return vession;
        }
    }
}
