using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using System.Windows.Forms;
using System.Threading;

namespace UpLoadNews
{
    public class UploadFacebook
    {

        public UploadFacebook()
        {
            PageFactory.InitElements(PropretiesCollection.driver, this);
        }      

        [FindsBy(How = How.CssSelector, Using = "input[type='file']")]
        public IWebElement btnuploadvideo;

        [FindsBy(How = How.CssSelector, Using = "input[data-testid='VIDEO_TITLE_BAR_TEXT_INPUT']")]
        public IWebElement txttieude;
        [FindsBy(How = How.CssSelector, Using = "div[id='placeholder-1o8bm']")]
        public IWebElement txtmota;
        [FindsBy(How = How.CssSelector, Using = "input[class='_58al']")]
        public IWebElement txttag;

        [FindsBy(How = How.CssSelector, Using = "#video_upload_complete_bar > div._6equ _6eqv _3qn7 _61-3 _2fyi _3qng > div._3qn7 _61-0 _2fyi _3qng > div")]
        public IWebElement prossesbar;

        
        [FindsBy(How = How.XPath, Using = "/html/body/div[11]/div[2]/div/div/div/div/div/div/div/div[3]/div[1]/div/div/div/div[1]/div[1]/div/div/label")]
        public IWebElement clicktieude;
        [FindsBy(How = How.XPath, Using = "/html/body/div[25]/div[2]/div/div/div/div/div/div/div/div[3]/div[1]/div/div/div/div[1]/div[1]/div/div/label/input")]
        public IWebElement txttieude2;

        
             [FindsBy(How = How.XPath, Using = "/html/body/div[11]/div[2]/div/div/div/div/div/div/div/div[3]/div[1]/div/div/div/div[1]/div[2]/div/div[1]/div[1]/div/img")]
        public IWebElement clickmota;
        [FindsBy(How = How.XPath, Using = "/html/body/div[25]/div[2]/div/div/div/div/div/div/div/div[3]/div[1]/div/div/div/div[1]/div[2]/div/div[1]/div[2]/div/div/div[2]/div/div/div/div/span")]
        public IWebElement txtmota2;
        [FindsBy(How = How.XPath, Using = "/html/body/div[12]/div[2]/div/div/div/div/div/div/div/div[4]/div[1]/div[1]/div/div[3]/div/div")]
        public IWebElement prossesbarbeta;
        [FindsBy(How = How.XPath, Using = "/html/body/div[12]/div[2]/div/div/div/div/div/div/div/div[4]/div[2]/div/div/span/button/div/div")]
        public IWebElement btndone;
        private int IsElementPresent(By elementcheck)
        {
            int kq = 0;
            try {
                var element = PropretiesCollection.driver.FindElement(elementcheck);
                kq = 1;
            }
            catch { }

            return kq;
        }

        public async Task Upload(string path,string tieude,string mota,string tag,string paththumnail)
        {   
            btnuploadvideo.SendKeys(path);
            Thread.Sleep(1000);
            clicktieude.Click();
            Thread.Sleep(2000);           
            try {
                txttieude2.Clear();
                txttieude2.SendKeys(tieude);
            }
            catch { }
            Thread.Sleep(1000);
            clickmota.Click();
            Thread.Sleep(1000);
           
            try
            {
                txtmota2.Clear();
                txtmota2.SendKeys(mota);
            }
            catch { }
            Thread.Sleep(2000);
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
                        string xuly = SeleniumGetMeThor.GetText2(prossesbarbeta);
                        if (xuly == "100%")
                        {
                            System.Threading.Thread.Sleep(8000);
                            btndone.Click();
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
