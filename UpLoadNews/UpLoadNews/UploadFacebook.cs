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
            int indexframe = 0;
            Thread.Sleep(2000);
            for (int i = 8; i < 13; i++)
            {
                if (IsElementPresent(By.XPath("//*[@id='facebook']/body/div[" + i + "]/div[2]/div/div/div/div/div/div/div/div[1]/div[2]/div[1]/div/div")) != 0)
                {
                    string tex = PropretiesCollection.driver.FindElement(By.XPath("//*[@id='facebook']/body/div[" + i + "]/div[2]/div/div/div/div/div/div/div/div[1]/div[2]/div[1]/div/div")).Text;
                    if (tex.Contains("video"))
                    {
                        indexframe = i;
                        break;
                    }
                }
            }
            Thread.Sleep(3000);
            if (IsElementPresent(By.XPath("//*[@id='facebook']/body/div[" + indexframe + "]/div[2]/div/div/div/div/div/div/div/div[1]/div[1]/div[1]/div[1]/div/label/input")) != 0)
            {
                PropretiesCollection.driver.FindElement(By.XPath("//*[@id='facebook']/body/div[" + indexframe + "]/div[2]/div/div/div/div/div/div/div/div[1]/div[1]/div[1]/div[1]/div/label/input")).SendKeys(tieude);
                if (IsElementPresent(By.XPath("//*[@id='facebook']/body/div[" + indexframe + "]/ div[2]/div/div/div/div/div/div/div/div[1]/div[1]/div[2]/div/div/div[1]/div[1]/div/div[1]/div[2]/div/div/div[2]/div")) != 0)
                {
                    PropretiesCollection.driver.FindElement(By.XPath("//*[@id='facebook']/body/div[" + indexframe + "]/ div[2]/div/div/div/div/div/div/div/div[1]/div[1]/div[2]/div/div/div[1]/div[1]/div/div[1]/div[2]/div/div/div[2]/div")).SendKeys(mota);
                    //if (IsElementPresent(By.XPath("//*[@id='entire-tag-area']/div/div/div[2]/div/span/label/input")) != 0)
                    //{
                    //    driver.FindElementByXPath("//*[@id='entire-tag-area']/div/div/div[2]/div/span/label/input").SendKeys("tukhoa,");
                    //}
                }
            }
            Thread.Sleep(2000);
            if (paththumnail != "")
            {
                if (IsElementPresent(By.XPath("//*[@id='facebook']/body/div[" + indexframe + "]/div[2]/div/div/div/div/div/div/div/div[1]/div[2]/div[2]/div[2]/div[2]/div/div[1]")) != 0)
                {
                    PropretiesCollection.driver.FindElement(By.XPath("//*[@id='facebook']/body/div[" + indexframe + "]/div[2]/div/div/div/div/div/div/div/div[1]/div[2]/div[2]/div[2]/div[2]/div/div[1]")).Click();
                    if (IsElementPresent(By.XPath("//*[@id='facebook']/body/div[" + indexframe + "]/div[2]/div/div/div/div/div/div/div/div[1]/div[1]/div[2]/div/div/div[4]/div[1]/div/div/div[2]/div/a/div")) != 0)
                    {
                        PropretiesCollection.driver.FindElement(By.XPath("//*[@id='facebook']/body/div[" + indexframe + "]/div[2]/div/div/div/div/div/div/div/div[1]/div[1]/div[2]/div/div/div[4]/div[1]/div/div/div[2]/div/a/div")).Click();
                    }
                    Thread.Sleep(1000);
                    SendKeys.SendWait(paththumnail);
                    SendKeys.SendWait("{Enter}");
                }
            }
            while (true)
            {
                string stt = PropretiesCollection.driver.FindElement(By.XPath("//*[@id='facebook']/body/div[" + indexframe + "]/div[2]/div/div/div/div/div/div/div/div[1]/div[1]/div[1]/div[1]/div[2]/div/div[3]/div/div")).Text;
                if (stt.Contains("100"))
                {
                    break;
                }
                Thread.Sleep(3000);
            }
            if (IsElementPresent(By.XPath("//*[@id='facebook']/body/div[" + indexframe + "]/div[2]/div/div/div/div/div/div/div/div[2]/div[2]/div/a/div/div")) != 0)
            {
                PropretiesCollection.driver.FindElement(By.XPath("//*[@id='facebook']/body/div[" + indexframe + "]/div[2]/div/div/div/div/div/div/div/div[2]/div[2]/div/a/div/div")).Click();
                Thread.Sleep(5000);
                if (IsElementPresent(By.XPath("//*[@id='facebook']/body/div[" + indexframe + "]/div[2]/div/div/div/div/div/div/div/div[2]/div[2]/div[2]/div/div/div[2]/div[2]/a[2]/div")) != 0)
                {
                    PropretiesCollection.driver.FindElement(By.XPath("//*[@id='facebook']/body/div[" + indexframe + "]/div[2]/div/div/div/div/div/div/div/div[2]/div[2]/div[2]/div/div/div[2]/div[2]/a[2]/div")).Click();
                }
            }
            while (true)
            {
                if (IsElementPresent(By.XPath("//*[@id='facebook']/body/div[" + indexframe + "]/div[2]/div/div/div/div/div/div/div/div[1]/div[2]/div[1]/div/div")) != 0)
                {
                }
                else
                {
                    break;
                }
                Thread.Sleep(2000);

            }
        }
    }
}
