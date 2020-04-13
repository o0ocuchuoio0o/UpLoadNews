using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpLoadNews
{
    public class UploadYoutubeLogin
    {
        public UploadYoutubeLogin()
        {
            PageFactory.InitElements(PropretiesCollection.driver, this);
        }

        [FindsBy(How = How.XPath, Using = "/html/body/div[3]/div/div[1]/div/div/section/div/div/div/div[1]/a")]
        public IWebElement btnlogin;

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


        public UploadYoutube Login(string user, string pass, string mailkhoiphuc)
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
            System.Threading.Thread.Sleep(6000);
           
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
            System.Threading.Thread.Sleep(6000);

            return new UploadYoutube();
        }
    }
}
