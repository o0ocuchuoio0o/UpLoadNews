﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
namespace DaoUploadNews
{
    public class CauHinhServerBL
    {
        private XmlDocument doc;
        private XmlElement root;
        public CauHinhServerBE docdulieu(string strpath)
        {  //khoi tao bien va load tai lieu xml
            CauHinhServerBE cauhinh = new CauHinhServerBE();

            doc = new XmlDocument();

            doc.Load(strpath);
            //duyet den cac nut cua xml
            root = doc.DocumentElement;           
            string User = root.SelectSingleNode("id").InnerText;
            string Pass = root.SelectSingleNode("pw").InnerText;
            //gan cac nut cua xml vao bien khoi tao trong bo luu tru
           
            cauhinh.User1 = User;
            cauhinh.Pass1 = Pass;
            return cauhinh;
        }
        //methor ghi du lieu len xml 
        public void ghidulieu(CauHinhServerBE cauhinh, string strpath)
        {
            doc = new XmlDocument();

            root = doc.CreateElement("CAUHINH");        
            XmlElement User = root.OwnerDocument.CreateElement("id");
            User.InnerText = cauhinh.User1;
            XmlElement Pass = root.OwnerDocument.CreateElement("pw");
            Pass.InnerText = cauhinh.Pass1;
            doc.AppendChild(root);        
            root.AppendChild(User);
            root.AppendChild(Pass);
            doc.Save(strpath);
        }
    }
}
