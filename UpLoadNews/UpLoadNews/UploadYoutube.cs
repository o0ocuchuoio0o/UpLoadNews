using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;

namespace UpLoadNews
{
    public class UploadYoutube
    {
        public UploadYoutube()
        {
            PageFactory.InitElements(PropretiesCollection.driver, this);
        }
        #region // bienlogin
        [FindsBy(How = How.Id, Using = "identifierId")]
        public IWebElement txtuser;
        [FindsBy(How = How.Id, Using = "identifierNext")]
        public IWebElement btnnextuser;
        [FindsBy(How = How.Name, Using = "password")]
        public IWebElement txtpass;
        [FindsBy(How = How.Id, Using = "passwordNext")]
        public IWebElement btnnextpass;     

        [FindsBy(How = How.Id, Using = "text")]
        public IWebElement m_statuslogin;
        #endregion

        #region // các biến xác nhận mail khôi phục lúc login
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/div[2]/div[2]/div/div/div[2]/div/div/div/form/span/section/div/div/div/ul/li[1]/div/div[2]")]
        public IWebElement m_xacnhanmailkhoiphuc;
        [FindsBy(How = How.Id, Using = "knowledge-preregistered-email-response")]
        public IWebElement m_txtxacnhanmail;
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/div[2]/div[2]/div/div/div[2]/div/div[2]/div/div[1]/div/span/span")]
        public IWebElement m_nexxacnhanmail;
        [FindsBy(How = How.XPath, Using = "/html/body/c-wiz[2]/c-wiz/div/div[1]/div/div/div/div[2]/div[3]/div/div[2]/div/span/span")]
        public IWebElement btndonexacnhanmail;
        #endregion

        [FindsBy(How = How.Id, Using = "button")]
        public IWebElement btnsub;
       //[FindsBy(How = How.XPath, Using = "/html/body/div[2]/div[4]/div/div[5]/div/div[4]/div[4]/div/div/div/button")]
        [FindsBy(How = How.CssSelector, Using = "input[type='file']")]        
        public IWebElement btnupload;

        [FindsBy(How = How.CssSelector, Using = "input[name='title']")]
        public IWebElement txttieude;
        [FindsBy(How = How.CssSelector, Using = "textarea[name='description']")]
        public IWebElement txtmota;
        [FindsBy(How = How.CssSelector, Using = "input[class='video-settings-add-tag']")]
        public IWebElement txttag;
        [FindsBy(How = How.CssSelector, Using = "input[type='file']")]
        public IWebElement btnthumnail;
        [FindsBy(How = How.CssSelector, Using = "li[data-tab-id='monetization']")]
        public IWebElement tabmonetization;
        [FindsBy(How = How.CssSelector, Using = "#monetize-with-noone")]
        public IWebElement objmonetization;
        [FindsBy(How = How.CssSelector, Using = "#monetize-with-ads")]
        public IWebElement radmonetization;

        [FindsBy(How = How.CssSelector, Using = "#upload-item-0 > div.upload-item-main > div.upload-state-bar > div.progress-bars > div.inner-progress-bars > div.progress-bar-processing > span.progress-bar-text > span")]
        public IWebElement prossesbar;

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div[4]/div/div[5]/div/div[5]/div[2]/div/div[3]/div/div[2]/div[2]/div[2]/span[2]")]
        public IWebElement prossesbar2;

        [FindsBy(How = How.CssSelector, Using = "button[class='yt-uix-button yt-uix-button-size-default save-changes-button yt-uix-tooltip yt-uix-button-primary']")]
        public IWebElement btnsavepublich;


        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div[4]/div/div[5]/div/div[4]/div[2]/div/div[1]/a")]
        public IWebElement errorupload;
        public void NextUser(string user)
        {
            txtuser.Clear();
            txtuser.SendKeys(user);
           // SendKeys.SendWait(@"{ENTER}");
             btnnextuser.Click();
        }
        public void NextPass(string pass)
        {           
            txtpass.SendKeys(pass);
            // SendKeys.Send("{ENTER}");
            btnnextpass.Click();
        }

        public async Task Login(string user,string pass,string path)
        {
            
            try
            {
                NextUser(user);
            }
            catch { }
            System.Threading.Thread.Sleep(4000);
            try
            {
                NextPass(pass);
            }
            catch { }
            System.Threading.Thread.Sleep(10000);
            try
            {
                btnupload.SendKeys(path);
            }
            catch { }
            
        }
        public async Task LoginAnDanh(string user, string pass,string mailkhoiphuc, string path)
        {

            try
            {
                NextUser(user);
            }
            catch { }
            System.Threading.Thread.Sleep(4000);
            try
            {
                NextPass(pass);
            }
            catch { }
            System.Threading.Thread.Sleep(10000);
            try
            {
                btnupload.SendKeys(path);
            }
            catch { }
            System.Threading.Thread.Sleep(2000);
            #region // trường hợp bắt xác nhận mail khôi phục
            try
            {
                try
                {
                    m_xacnhanmailkhoiphuc.Click();
                }
                catch { }
                System.Threading.Thread.Sleep(4000);
                try
                {
                    m_txtxacnhanmail.SendKeys(mailkhoiphuc);
                }
                catch { }
                System.Threading.Thread.Sleep(1000);
                try
                {
                    m_nexxacnhanmail.Click();
                }
                catch { }
                System.Threading.Thread.Sleep(6000);
                try
                {
                    btndonexacnhanmail.Click();
                }
                catch { }
            }
            catch { }
            #endregion
            System.Threading.Thread.Sleep(1000);
            try
            {
                btnupload.SendKeys(path);
            }
            catch { }


        }
        public async Task UploadFroFile(string path,string tieude, string mota, string tag, string paththumnail,int batkiemtien)
        {           
            System.Threading.Thread.Sleep(10000);
            btnupload.SendKeys(path);
            System.Threading.Thread.Sleep(5000);
            txttieude.Clear();
            txttieude.SendKeys(tieude);
            System.Threading.Thread.Sleep(5000);
            txtmota.Clear();
            txtmota.SendKeys(mota);
            System.Threading.Thread.Sleep(5000);
            txttag.Clear();
            txttag.SendKeys(tag);
            System.Threading.Thread.Sleep(8000);
            try
            {
                if (System.IO.File.Exists(paththumnail))
                {
                    try
                    {
                        btnthumnail.SendKeys(paththumnail);
                    }
                    catch { }
                }
            }
            catch { }
            // set thuoc tinh bat kiem tien
            try
            {
                if (batkiemtien == 1)
                {
                    System.Threading.Thread.Sleep(8000);
                    tabmonetization.Click();
                    if (objmonetization != null)
                    {
                        radmonetization.Click();
                    }
                }
            }
            catch { }
            int kiemtra = 0;
            switch (kiemtra)
            {
                case 0:             // label case 1
                    System.Threading.Thread.Sleep(15000);
                    goto case 1;
                    break;
                case 1:
                    try
                    {
                        string xuly = SeleniumGetMeThor.GetText2(prossesbar);
                        if (xuly == "100%")
                        {
                            System.Threading.Thread.Sleep(8000);
                            btnsavepublich.Click();
                            System.Threading.Thread.Sleep(5000);
                        }
                        else
                        {
                            goto case 0;
                        }
                    }
                    catch { goto case 0; }
                    break;

            }            
        }
        public async Task Upload(string tieude, string mota, string tag, string paththumnail,int batkiemtien)
        {
            
            System.Threading.Thread.Sleep(2000);
            try
            {
                txttieude.Clear();
                txttieude.SendKeys(tieude);
            }
            catch { }
            System.Threading.Thread.Sleep(2000);
            try
            {
                txtmota.Clear();
                txtmota.SendKeys(mota);
            }
            catch { }
            System.Threading.Thread.Sleep(2000);
            try
            {
                txttag.Clear();
                txttag.SendKeys(tag);
            }
            catch { }
            System.Threading.Thread.Sleep(2000);
            try
            {
                if (System.IO.File.Exists(paththumnail))
                {
                    try
                    {
                        btnthumnail.SendKeys(paththumnail);
                    }
                    catch { }
                }
            }
            catch { }
            // set thuoc tinh bat kiem tien
            try {
                if (batkiemtien == 1)
                {
                    System.Threading.Thread.Sleep(8000);
                    tabmonetization.Click();
                    if (objmonetization != null)
                    {
                        radmonetization.Click();
                    }
                }
            }
            catch { }
            int kiemtra =0;
            switch (kiemtra)
            {
                  case 0:             // label case 1
                    System.Threading.Thread.Sleep(15000);
                    goto case 1;
                    break;
                   case 1:
                        try
                        {
                            try { string error= SeleniumGetMeThor.GetText2(errorupload);
                                if(error== "supported file type")
                                {
                                    break;
                                }
                            }
                            catch { }
                            string xuly = SeleniumGetMeThor.GetText2(prossesbar);
                            if (xuly =="100%")
                            {
                            System.Threading.Thread.Sleep(8000);
                            btnsavepublich.Click();
                            System.Threading.Thread.Sleep(5000);
                        }
                            else
                            {
                                goto case 0;
                            }
                        }
                        catch { goto case 0; }
                    break;         
               
            }
          
        }


    }
}
