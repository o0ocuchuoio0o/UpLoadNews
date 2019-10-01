using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UpLoadNews
{
    class ManagerChannel
    {
        public ManagerChannel()
        {
            PageFactory.InitElements(PropretiesCollection.driver, this);
        }

        #region // các biến login
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/header/div[2]/div[3]/div/a")]
        public IWebElement btndangnhap;
        [FindsBy(How = How.Id, Using = "identifierId")]
        public IWebElement txtuser;
        [FindsBy(How = How.Id, Using = "identifierNext")]
        public IWebElement btnnextuser;
        [FindsBy(How = How.Name, Using = "password")]
        public IWebElement txtpass;
        [FindsBy(How = How.Id, Using = "passwordNext")]
        public IWebElement btnnextpass;
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

        #region // các biến đổi pass

        [FindsBy(How = How.XPath, Using = "/html/body/c-wiz/div/div[2]/c-wiz/c-wiz/div/div[4]/div/div/c-wiz/section/article/div/div/div[6]/div[2]/a/div/div/div/div[2]/div[2]/div")]
        public IWebElement btnthaypassmail;
        //xác nhận pass cũ
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/div[2]/div[2]/div/div/div[2]/div/div[1]/div/form/span/section/div/div/div[2]/div[1]/div/div/div/div/div[1]/div/div[1]/input")]
        public IWebElement txtpasscu;
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/div[2]/div[2]/div/div/div[2]/div/div[2]/div/div[1]/div/span/span")]
        public IWebElement btnnextpasscu;

        [FindsBy(How = How.XPath, Using = "/html/body/c-wiz/div/div[3]/c-wiz/div/div[3]/div[1]/c-wiz/form/div[1]/div/div[1]/div/div[1]/input")]
        public IWebElement txtpassmoilan1;
        [FindsBy(How = How.XPath, Using = "/html/body/c-wiz/div/div[3]/c-wiz/div/div[3]/div[1]/c-wiz/form/div[3]/div/div[1]/div/div[1]/input")]
        public IWebElement txtpassmoilan2;


        [FindsBy(How = How.XPath, Using = "/html/body/c-wiz/div/div[3]/c-wiz/div/div[3]/div[2]/div/span/span")]
        public IWebElement btnxacnhanpassmoi;

        #endregion

        #region  //các biến thay mail khôi phục
        [FindsBy(How = How.XPath, Using = "/html/body/c-wiz/div/div[2]/c-wiz/c-wiz/div/div[4]/div/div/c-wiz/section/article[2]/div/div/div[2]/div/a/div/div/div/div")]
        public IWebElement btnthaymailkhoiphuc;
        [FindsBy(How = How.XPath, Using = "/html/body/c-wiz[2]/div/div[3]/c-wiz/div/div[3]/div[1]/a/div[2]/span")]
        public IWebElement btnchonthaymailkhoiphuc;
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/div[2]/div[2]/div/div/div[2]/div/div[1]/div/form/span/section/div/div/div[2]/div[1]/div/div/div/div/div[1]/div/div[1]/input")]
        public IWebElement txtpassthaymailkhoiphuc;
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/div[2]/div[2]/div/div/div[2]/div/div[2]/div/div[1]/div/span/span")]
        public IWebElement btnnextmailkhoiphuc;
        [FindsBy(How = How.XPath, Using = "/html/body/c-wiz/div/div[3]/c-wiz/div/div[3]/div[1]/div/div[2]/span/span/span")]
        public IWebElement btnchonsuamailkhoiphuc;
        [FindsBy(How = How.XPath, Using = "/html/body/div[11]/div/div[2]/span/div/div[1]/div[1]/div/div[1]/input")]
        public IWebElement txtnhapmailkhoiphuc;
        [FindsBy(How = How.XPath, Using = "/html/body/div[11]/div/div[2]/div[3]/div[2]/span/span")]
        public IWebElement btndonesuamailkhoiphuc;
        #endregion



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

        public void ThayMailKhoiPhuc(string user, string pass, string mailkhoiphuccu, string mailkhoiphuc)
        {
            btndangnhap.Click();
            System.Threading.Thread.Sleep(2000);

            try
            {
                NextUser(user);
            }
            catch { }
            System.Threading.Thread.Sleep(2000);
            try
            {
                NextPass(pass);
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
                    m_txtxacnhanmail.SendKeys(mailkhoiphuccu);
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

            #region // thay mail khôi phục
            try
            {
                try
                {
                    btnthaymailkhoiphuc.Click();
                }
                catch { }
                System.Threading.Thread.Sleep(2000);
                try
                {
                    btnchonthaymailkhoiphuc.Click();
                }
                catch { }
                System.Threading.Thread.Sleep(2000);
                try
                {
                    txtpassthaymailkhoiphuc.SendKeys(pass);
                }
                catch { }
                System.Threading.Thread.Sleep(2000);
                try
                {
                    btnnextmailkhoiphuc.Click();
                }
                catch { }
                System.Threading.Thread.Sleep(2000);
                try
                {
                    btnchonsuamailkhoiphuc.Click();
                }
                catch { }
                System.Threading.Thread.Sleep(2000);
                try
                {
                    txtnhapmailkhoiphuc.Clear();
                    txtnhapmailkhoiphuc.SendKeys(mailkhoiphuc);
                }
                catch { }
                System.Threading.Thread.Sleep(2000);
                try
                {
                    btndonesuamailkhoiphuc.Click();
                }
                catch { }
            }
            catch { }
            #endregion




        }
        
        public void ThayPassMoi(string user, string pass, string mailkhoiphuc, string passmoi)
        {
            btndangnhap.Click();
            System.Threading.Thread.Sleep(2000);

            try
            {
                NextUser(user);
            }
            catch { }
            System.Threading.Thread.Sleep(2000);
            try
            {
                NextPass(pass);
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
                btnthaypassmail.Click();
            }
            catch { }
            System.Threading.Thread.Sleep(1000);
            try
            {
                txtpasscu.Clear();
                txtpasscu.SendKeys(pass);
            }
            catch { }
            System.Threading.Thread.Sleep(1000);
            try
            {
                btnnextpasscu.Click();
            }
            catch { }
            System.Threading.Thread.Sleep(2000);
            try
            {

                txtpassmoilan1.SendKeys(passmoi);
            }
            catch { }
            System.Threading.Thread.Sleep(2000);
            try
            {
                txtpassmoilan2.SendKeys(passmoi);
            }
            catch { }
            System.Threading.Thread.Sleep(1000);
            try
            {
                btnxacnhanpassmoi.Click();

            }
            catch { }

        }

        #region //load video youtube
        public DataTable LoadListVideo(string linkvideocu)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("LinkAnh", typeof(string));
            dt.Columns.Add("Ten", typeof(string));
            while (true)
            {
                List<IWebElement> listVideoBefore = PropretiesCollection.driver.FindElements(By.XPath("//*[@class='style-scope ytd-grid-renderer']")).ToList();
                try
                {
                    int dem = 0;
                    IWebElement lastvideo = null;
                    foreach (IWebElement field in listVideoBefore)
                    {
                        try
                        {
                            IWebElement video = field.FindElement(By.TagName("ytd-grid-video-renderer"));

                            string[] thongtinvideo = video.Text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                            string tenvideo = thongtinvideo[1].ToString();
                            IWebElement Ivideo = PropretiesCollection.driver.FindElement(By.XPath("//*[@title='" + tenvideo + "']"));
                            string linkvideo = Ivideo.GetAttribute("href");
                            if (tenvideo != null && linkvideo != null)
                            {
                                dt.Rows.Add(linkvideo, tenvideo);
                            }
                            // trường hợp tìm kiếm link tới video đã lưu thì thoát vòng lặp
                            if(linkvideo==linkvideocu)
                            {
                                break;
                            }
                        }
                        catch { }
                        if (dem == listVideoBefore.Count - 1)
                        {
                            lastvideo = field;
                        }
                        else
                        {
                            dem++;
                        }
                    }
                    int Y = lastvideo.Location.Y;
                    IJavaScriptExecutor jse = (IJavaScriptExecutor)PropretiesCollection.driver;
                    jse.ExecuteScript("window.scrollTo(0," + Y + ")", "");
                    Thread.Sleep(3000);
                    List<IWebElement> listVideoAffter = PropretiesCollection.driver.FindElements(By.XPath("//*[@class='style-scope ytd-grid-renderer']")).ToList();
                    if (listVideoBefore.Count == listVideoAffter.Count)
                    {
                        break;
                    }
                }
                catch { }
            }

            return dt;


        }
        #endregion



        #region // các thay đổi trong csdl





        #endregion



    }
}
