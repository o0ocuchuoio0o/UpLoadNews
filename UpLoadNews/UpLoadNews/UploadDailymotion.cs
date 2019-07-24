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
    public class UploadDailymotion
    {
        public UploadDailymotion()
        {
            PageFactory.InitElements(PropretiesCollection.driver, this);
        }
        [FindsBy(How = How.CssSelector, Using = "input[type='file']")]
        public IWebElement btnuploadvideo;
        [FindsBy(How = How.CssSelector, Using = "input[name='title']")]
        public IWebElement txttieude;
        [FindsBy(How = How.CssSelector, Using = "textarea[name='description']")]
        public IWebElement txtmota;
        [FindsBy(How = How.CssSelector, Using = "input[name='tags']")]
        public IWebElement txttag;

        [FindsBy(How = How.XPath, Using = "//*[@id='react-root']/div/section/main/div/div/div/div/div[2]/div[1]/div/span/span")]
        public IWebElement prosses;

        [FindsBy(How = How.XPath, Using = "//*[@id='react-root']/div/section/main/div/div/div/div/div[2]/div[2]/div/div[1]/div/div[3]/span[2]/div[2]")]
        public IWebElement btndang;
        #region // lựa chọn danh muc
        [FindsBy(How = How.Name, Using = "category")]
        public IWebElement btncategory;
        [FindsBy(How = How.XPath, Using = "/div[@class='column right']/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/ul[1]/li[1]/button")]
        public IWebElement cmb__;
        [FindsBy(How = How.XPath, Using = "/div[@class='column right']/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/ul[1]/li[2]/button")]
        public IWebElement cmbAnimals;        
        [FindsBy(How = How.XPath, Using = "/div[@class='column right']/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/ul[1]/li[3]/button")]
        public IWebElement cmbCars;
        [FindsBy(How = How.XPath, Using = "/div[@class='column right']/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/ul[1]/li[4]/button")]
        public IWebElement cmbCeleb;
        [FindsBy(How = How.XPath, Using = "/div[@class='column right']/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/ul[1]/li[5]/button")]
        public IWebElement cmbComedyEntertainment;
        [FindsBy(How = How.XPath, Using = "/div[@class='column right']/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/ul[1]/li[6]/button")]
        public IWebElement cmbCreative;
        [FindsBy(How = How.XPath, Using = "/div[@class='column right']/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/ul[1]/li[7]/button")]
        public IWebElement cmbEducation;
        [FindsBy(How = How.XPath, Using = "/div[@class='column right']/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/ul[1]/li[8]/button")]
        public IWebElement cmbGaming;
        [FindsBy(How = How.XPath, Using = "/div[@class='column right']/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/ul[1]/li[9]/button")]
        public IWebElement cmbKids;
        [FindsBy(How = How.XPath, Using = "/div[@class='column right']/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/ul[1]/li[10]/button")]
        public IWebElement cmbLifestyle;
        [FindsBy(How = How.XPath, Using = "/div[@class='column right']/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/ul[1]/li[11]/button")]
        public IWebElement cmbMovies;
        [FindsBy(How = How.XPath, Using = "/div[@class='column right']/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/ul[1]/li[12]/button")]
        public IWebElement cmbMusic;
        [FindsBy(How = How.XPath, Using = "/div[@class='column right']/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/ul[1]/li[13]/button")]
        public IWebElement cmbNews;
        [FindsBy(How = How.XPath, Using = "//div[@class='column right']//div[2]//div[1]//div[1]//div[1]//div[1]//div[1]//ul[1]//li[14]//button")]
        public IWebElement cmbSports;
        [FindsBy(How = How.XPath, Using = "/div[@class='column right']/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/ul[1]/li[15]/button")]
        public IWebElement cmbTech;
        [FindsBy(How = How.XPath, Using = "/div[@class='column right']/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/ul[1]/li[16]/button")]
        public IWebElement cmbTravel;
        [FindsBy(How = How.XPath, Using = "/div[@class='column right']/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/ul[1]/li[17]/button")]
        public IWebElement cmbTV;
        [FindsBy(How = How.XPath, Using = "/div[@class='column right']/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/ul[1]/li[18]/button")]
        public IWebElement cmbWebcam;
        public void selectcategory(string category)
        {
            btncategory.Click();
            Thread.Sleep(1000); 
            if (category == "--")
            {
                cmb__.Click();
            }
            else if (category == "Animals")
            {
                cmbAnimals.Click();
            }
            else if (category == "Cars")
            {
                cmbCars.Click();
            }
            else if (category == "Celeb")
            {
                cmbCeleb.Click();
            }
            else if (category == "Comedy & Entertainment")
            {
                cmbComedyEntertainment.Click();
            }
            else if (category == "Creative")
            {
                cmbCreative.Click();
            }
            else if (category == "Education")
            {
                cmbEducation.Click();
            }
            else if (category == "Gaming")
            {
                cmbGaming.Click();
            }
            else if (category == "Kids")
            {
                cmbKids.Click();
            }
            else if (category == "Lifestyle & How - to")
            {
                cmbLifestyle.Click();
            }
            else if (category == "Movies")
            {
                cmbMovies.Click();
            }
            else if (category == "Music")
            {
                cmbMusic.Click();
            }
            else if (category == "News")
            {
                cmbNews.Click();
            }
            else if (category == "Sports")
            {
                cmbSports.Click();
            }
            else if (category == "Tech")
            {
                cmbTech.Click();
            }
            else if (category == "Travel")
            {
                cmbTravel.Click();
            }
            else if (category == "TV")
            {
                cmbTV.Click();
            }
            else if (category == "Webcam")
            {
                cmbWebcam.Click();
            }
        }
        #endregion

        public async Task Upload(string path, string tieude, string mota, string tag,string category, string paththumnail)
        {
           
            Thread.Sleep(5000);
            try
            {
                btnuploadvideo.SendKeys(path);
            }
            catch{                
            }           
            Thread.Sleep(5000);
            try
            {
                txttieude.Clear();
                txttieude.SendKeys(tieude);
            }
            catch { }
            System.Threading.Thread.Sleep(1000);
            try
            {
                txtmota.Clear();
                txtmota.SendKeys(mota);
            }
            catch { }
            System.Threading.Thread.Sleep(1000);
            try
            {
                txttag.Clear();
                txttag.SendKeys(tag);
            }
            catch { }
            Thread.Sleep(1000);
            try
            {
                selectcategory(category);
            }
            catch { }
            int kiemtra = 0;
            switch (kiemtra)
            {
                case 0:             // label case 1
                    System.Threading.Thread.Sleep(10000);
                    goto case 1;
                    break;
                case 1:
                    try
                    {
                        string xuly = SeleniumGetMeThor.GetText2(prosses);
                        if (xuly.Contains("100"))
                        {
                            System.Threading.Thread.Sleep(8000);
                            btndang.Click();
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
