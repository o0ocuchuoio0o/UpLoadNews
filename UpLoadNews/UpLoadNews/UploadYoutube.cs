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
using System.Runtime.InteropServices;

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

        [FindsBy(How = How.XPath, Using = "/html/body/ytcp-uploads-dialog/paper-dialog/div/div[1]/div/div[2]/ytcp-button/div")]
        public IWebElement btnuploadcu;
        [FindsBy(How = How.XPath, Using = "/html/body/ytcp-survey-dialog/ytcp-dialog/paper-dialog/div[3]/div/ytcp-button[2]/div")]
        public IWebElement btnboqua;
        
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
            System.Threading.Thread.Sleep(6000);
            try
            {
                btnuploadcu.Click();
                System.Threading.Thread.Sleep(3000);
                btnboqua.Click();
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
            System.Threading.Thread.Sleep(10000);
            try
            {
                btnupload.SendKeys(path);
            }
            catch { }


        }
        public async Task UploadFroFile(string path,string tieude, string mota, string tag, string paththumnail,int batkiemtien)
        {
            try { btnuploadcu.Click();
                System.Threading.Thread.Sleep(3000);
                btnboqua.Click();
            }
            catch { }   

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



        #region Upload Vession beta   
        [FindsBy(How = How.XPath, Using = "/html/body/ytcp-uploads-dialog/paper-dialog/div/ytcp-uploads-file-picker/div/ytcp-button/div")]
        public IWebElement clickupload;
        [FindsBy(How = How.XPath, Using = "/html/body/ytcp-uploads-dialog/paper-dialog/div/ytcp-animatable[1]/ytcp-uploads-details/div/ytcp-uploads-basics/ytcp-mention-textbox[1]/ytcp-form-input-container/div[1]/div[2]/ytcp-mention-input/div")]
        public IWebElement txttieudebeta;
        [FindsBy(How = How.XPath, Using = "/html/body/ytcp-uploads-dialog/paper-dialog/div/ytcp-animatable[1]/ytcp-uploads-details/div/ytcp-uploads-basics/ytcp-mention-textbox[2]/ytcp-form-input-container/div[1]/div[2]/ytcp-mention-input/div")]
        public IWebElement txtmotabeta;
        [FindsBy(How = How.XPath, Using = "/html/body/ytcp-uploads-dialog/paper-dialog/div/ytcp-animatable[1]/ytcp-uploads-details/div/ytcp-uploads-basics/ytcp-thumbnails-compact-editor/div[3]/ytcp-thumbnails-compact-editor-uploader/div/button")]
        public IWebElement btnthumnailbeta;

        
        [FindsBy(How = How.XPath, Using = "/html/body/ytcp-uploads-dialog/paper-dialog/div/ytcp-animatable[1]/ytcp-uploads-details/div/div/ytcp-button/div")]
        public IWebElement btnluachonkhac;
        [FindsBy(How = How.XPath, Using = "/html/body/ytcp-uploads-dialog/paper-dialog/div/ytcp-animatable[1]/ytcp-uploads-details/div/ytcp-uploads-advanced/ytcp-form-input-container/div[1]/div[2]/ytcp-free-text-chip-bar/ytcp-chip-bar/div/input")]
        public IWebElement txttagbeta;
        


        [FindsBy(How = How.XPath, Using = "/html/body/ytcp-uploads-dialog/paper-dialog/div/div[1]/ytcp-animatable/ytcp-stepper/div/button[2]/div[1]/span")]
        public IWebElement clickmanhinhketthuc;   // dung cai nay de quay lai voi truong hop chua bat kiem tien  
        [FindsBy(How = How.XPath, Using = "/html/body/ytcp-uploads-dialog/paper-dialog/div/div[1]/ytcp-animatable/ytcp-stepper-v2/div/div[2]/button/div[2]/iron-icon[1]")]
        public IWebElement clickmanhinhketthuc2;

        [FindsBy(How = How.XPath, Using = "/html/body/ytcp-uploads-dialog/paper-dialog/div/ytcp-animatable[1]/ytcp-uploads-video-elements/div[3]/ytcp-button[2]/div")]
        public IWebElement themmanhinhketthuc;  
        [FindsBy(How = How.XPath, Using = "/html/body/ytve-endscreen-modal/ytve-modal-host/ytcp-dialog/paper-dialog/div[2]/div/ytve-editor/div[1]/div/ytve-endscreen-editor-options-panel/div[2]/div/ytve-endscreen-template-picker/div/div/div/div[1]/div[1]")]
        public IWebElement addmanhinhketthuc;
        [FindsBy(How = How.XPath, Using = "/html/body/ytve-endscreen-modal/ytve-modal-host/ytcp-dialog/paper-dialog/div[1]/div/div[2]/div[2]/ytcp-button/div")]
        public IWebElement luumanhinhketthuc;
        [FindsBy(How = How.XPath, Using = " /html/body/ytve-endscreen-modal/ytve-modal-host/ytcp-dialog/paper-dialog/div[1]/div/div[2]/ytcp-button/div")]
        public IWebElement thoatmanhinhketthuc;
       

        [FindsBy(How = How.XPath, Using = "/html/body/ytcp-uploads-dialog/paper-dialog/div/ytcp-animatable[1]/ytcp-uploads-video-elements/div[4]/ytcp-button/div")]
        public IWebElement themmanhinhcard;
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div[2]/div/div/div[2]/a/span")]
        public IWebElement quaylaiupload;
      
        



        [FindsBy(How = How.XPath, Using = "/html/body/ytcp-uploads-dialog/paper-dialog/div/div[1]/ytcp-animatable/ytcp-stepper/div/button[3]/div[1]/span")]
        public IWebElement buoc3;
        [FindsBy(How = How.XPath, Using = "/html/body/ytcp-uploads-dialog/paper-dialog/div/div[1]/ytcp-animatable/ytcp-stepper-v2/div/div[3]/button/div[2]/iron-icon[1]")]
        public IWebElement buoc3_v2;

        [FindsBy(How = How.XPath, Using = "/html/body/ytcp-uploads-dialog/paper-dialog/div/div[1]/ytcp-animatable/ytcp-stepper/div/button[4]/div[1]/span")]
        public IWebElement buoc4;

        [FindsBy(How = How.XPath, Using = "/html/body/ytcp-uploads-dialog/paper-dialog/div/ytcp-animatable[1]/ytcp-uploads-review/div[2]/div[1]/ytcp-video-visibility-select-v2/div[1]/paper-radio-group/paper-radio-button[1]/div[1]/div[1]")]
        public IWebElement clickpublich;

        [FindsBy(How = How.XPath, Using = " /html/body/ytcp-uploads-prechecks-warning-dialog/ytcp-confirmation-dialog/ytcp-dialog/paper-dialog/div[3]/div/ytcp-button[1]/div")]
        public IWebElement clickchonpub;

        [FindsBy(How = How.XPath, Using = "/html/body/ytcp-uploads-dialog/paper-dialog/div/ytcp-animatable[1]/ytcp-uploads-review/div[2]/div[1]/ytcp-video-visibility-select/div[1]/paper-radio-group/paper-radio-button[3]/div[1]/div[1]")]
        public IWebElement clickpublichv2;
        

        [FindsBy(How = How.XPath, Using = "/html/body/ytcp-uploads-dialog/paper-dialog/div/ytcp-animatable[2]/div/div[2]/ytcp-button[3]/div")]
        public IWebElement xuatban; 
        

        [FindsBy(How = How.XPath, Using = "/html/body/ytcp-uploads-dialog/paper-dialog/div/ytcp-animatable[2]/div/div[2]/ytcp-button[2]/div")]
        public IWebElement btnnext;

        [FindsBy(How = How.XPath, Using = "/html/body/ytcp-uploads-dialog/paper-dialog/div/ytcp-animatable/ytcp-uploads-extras/div[1]/div[1]/ytcp-expansion-panel[2]/div/ytcp-ve/button/div[2]/div/iron-icon")]
        public IWebElement clicktag;
      


        [FindsBy(How = How.XPath, Using = "/html/body/ytcp-uploads-dialog/paper-dialog/div/ytcp-animatable/ytcp-uploads-review/div[2]/div[1]/ytcp-video-visibility-select-v2/div[1]/ytcp-expansion-panel/div/div/paper-radio-group/paper-radio-button[1]/div[1]/div[1]")]
        public IWebElement checkpublich;

        [FindsBy(How = How.XPath, Using = "/html/body/ytcp-uploads-dialog/paper-dialog/div/div[3]/div/div[2]/ytcp-animatable/ytcp-button[3]")]
        public IWebElement btndone;
        [FindsBy(How = How.XPath, Using = "/html/body/ytcp-uploads-dialog/paper-dialog/div/ytcp-animatable[2]/div/div[1]/ytcp-video-upload-progress/span")]
        public IWebElement prossesbarbeta;

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        #region // cac tab cho kenh bi check bkt
        [FindsBy(How = How.XPath, Using = "/html/body/ytcp-uploads-dialog/paper-dialog/div/div[1]/ytcp-animatable/ytcp-stepper/div/button[2]/div[1]/span")]
        public IWebElement btntabbkt;

        [FindsBy(How = How.XPath, Using = "/html/body/ytcp-uploads-dialog/paper-dialog/div/ytcp-animatable[1]/ytcp-uploads-monetization/ytpp-video-monetization-basics/div/div[1]/div/div/ytcp-video-metadata-monetization/ytcp-form-input-container/div[1]/div[2]/ytcp-video-monetization/div/div/div/ytcp-icon-button/iron-icon")]
        public IWebElement btnclickbkt;
        [FindsBy(How = How.XPath, Using = "/html/body/ytcp-video-monetization-edit-dialog/paper-dialog/div/paper-radio-group/paper-radio-button[1]/div[1]/div[1]")]
        public IWebElement clickbkt;
        [FindsBy(How = How.XPath, Using = "/html/body/ytcp-video-monetization-edit-dialog/paper-dialog/div/div/ytcp-button[2]/div")]
        public IWebElement doneclickbkt;

        [FindsBy(How = How.XPath, Using = "/html/body/ytcp-uploads-dialog/paper-dialog/div/div[1]/ytcp-animatable/ytcp-stepper/div/button[3]/div[1]/span")]
        public IWebElement btntabcheckbkt;
        [FindsBy(How = How.XPath, Using = "/html/body/ytcp-uploads-dialog/paper-dialog/div/ytcp-animatable[1]/ytcp-uploads-content-ratings/ytpp-self-certification-questionnaire/ytcp-checkbox-lit/div[2]")]
        public IWebElement checkbkt;
        [FindsBy(How = How.XPath, Using = "/html/body/ytcp-uploads-dialog/paper-dialog/div/div[1]/ytcp-animatable/ytcp-stepper/div/button[4]/div[1]/span")]
        public IWebElement buoc3bkt;
        [FindsBy(How = How.XPath, Using = "/html/body/ytcp-uploads-dialog/paper-dialog/div/div[1]/ytcp-animatable/ytcp-stepper/div/button[5]/div[1]/span")]
        public IWebElement buoc4bkt;

        #endregion


        public async Task UploadFroFileBeta(string path, string tieude, string mota, string tag, string paththumnail, int batkiemtien,bool m_private,bool m_checkmotizeion,int timechoupload)
        {

            clickupload.Click();
            Thread.Sleep(TimeSpan.FromSeconds(2));
            var dialogHWnd = FindWindow(null, "Open"); // Here goes the title of the dialog window
            var setFocus = SetForegroundWindow(dialogHWnd);
            if (setFocus)
            {

                Thread.Sleep(TimeSpan.FromSeconds(2));
                System.Windows.Forms.SendKeys.SendWait(path);
                System.Windows.Forms.SendKeys.SendWait("{DOWN}");
                System.Windows.Forms.SendKeys.SendWait("{TAB}");
                System.Windows.Forms.SendKeys.SendWait("{TAB}");
                System.Windows.Forms.SendKeys.SendWait("{ENTER}");
            }
           // clickupload.SendKeys(path);
            System.Threading.Thread.Sleep(30000);
            txttieudebeta.Clear();
            txttieudebeta.SendKeys(tieude);
            //IJavaScriptExecutor js = (IJavaScriptExecutor)PropretiesCollection.driver;
            //js.ExecuteScript("arguments[0].value='" + tieude + "';", txttieudebeta);
            System.Threading.Thread.Sleep(2000);
            txtmotabeta.Clear();
            txtmotabeta.SendKeys(mota);
            System.Threading.Thread.Sleep(5000);
           
          
            try
            {
                if (System.IO.File.Exists(paththumnail))
                {
                    try
                    {
                        btnthumnailbeta.Click();
                        Thread.Sleep(TimeSpan.FromSeconds(2));
                        var dialogThumnail = FindWindow(null, "Open"); // Here goes the title of the dialog window
                        var setFocusthumnail = SetForegroundWindow(dialogThumnail);
                        if (setFocusthumnail)
                        {

                            Thread.Sleep(TimeSpan.FromSeconds(2));
                            System.Windows.Forms.SendKeys.SendWait(paththumnail);
                            System.Windows.Forms.SendKeys.SendWait("{DOWN}");
                            System.Windows.Forms.SendKeys.SendWait("{TAB}");
                            System.Windows.Forms.SendKeys.SendWait("{TAB}");
                            System.Windows.Forms.SendKeys.SendWait("{ENTER}");
                        }
                    }
                    catch { }
                }
            }
            catch { }
            try {
                IJavaScriptExecutor jse = (IJavaScriptExecutor)PropretiesCollection.driver;
                jse.ExecuteScript("window.scrollTo(0," + 300 + ")", "");
                btnluachonkhac.Click();
                System.Threading.Thread.Sleep(2000);
                IJavaScriptExecutor jse2 = (IJavaScriptExecutor)PropretiesCollection.driver;
                jse2.ExecuteScript("window.scrollTo(0," + 200 + ")", "");
                txttagbeta.SendKeys(tag);
                System.Threading.Thread.Sleep(2000);
            }
            catch { }

            System.Threading.Thread.Sleep(timechoupload);
            if (m_checkmotizeion == false)
            {
                int kiemtrabkt = 0;
                try
                {
                    buoc4.Click();
                    kiemtrabkt = 1;
                }
                catch { }
                if (kiemtrabkt == 1)
                {
                    #region // trường hợp kênh đã bật kiếm tiền
                    buoc3.Click();
                    System.Threading.Thread.Sleep(2000);
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
                                int xuly = 0;
                                try
                                {
                                    themmanhinhketthuc.Click();
                                    System.Threading.Thread.Sleep(10000);
                                    xuly = 1;
                                }
                                catch
                                {
                                    //try
                                    //{
                                    //    themmanhinhcard.Click();
                                    //    xuly = 2;
                                    //}
                                    //catch
                                    //{
                                    goto case 0;
                                    //}
                                }

                                if (xuly == 1)
                                {
                                  
                                    try
                                    {
                                        addmanhinhketthuc.Click();
                                    }
                                    catch { }
                                    System.Threading.Thread.Sleep(5000);
                                    try
                                    {
                                        luumanhinhketthuc.Click();
                                    }
                                    catch
                                    {
                                        //try { thoatmanhinhketthuc.Click(); }
                                        //catch { }

                                    }
                                    System.Threading.Thread.Sleep(3000);
                                    buoc4.Click();
                                    System.Threading.Thread.Sleep(7000);
                                    if (m_private == true)
                                    {

                                    }
                                    else
                                    {
                                        try
                                        {
                                            clickpublichv2.Click();
                                        }
                                        catch { }
                                    }
                                    System.Threading.Thread.Sleep(2000);
                                    xuatban.Click();
                                    System.Threading.Thread.Sleep(2000);
                                    try
                                    {
                                        clickchonpub.Click();
                                    }
                                    catch { }
                                    System.Threading.Thread.Sleep(2000);
                                }
                                //else if(xuly==2)
                                //{
                                //    quaylaiupload.Click();
                                //    System.Threading.Thread.Sleep(3000);
                                //    buoc4.Click();
                                //    System.Threading.Thread.Sleep(2000);
                                //    if (m_private == true)
                                //    {

                                //    }
                                //    else
                                //    {
                                //        clickpublich.Click();
                                //    }
                                //    System.Threading.Thread.Sleep(2000);
                                //    xuatban.Click();
                                //    System.Threading.Thread.Sleep(2000);
                                //}
                                else
                                {
                                    goto case 0;
                                }
                            }
                            catch { goto case 0; }
                            break;

                    }
                    #endregion

                }
                else
                {
                    #region // trường hợp không có bước bật kiếm tiền
                    try
                    {
                        clickmanhinhketthuc.Click();
                    }
                    catch { }
                    try { clickmanhinhketthuc2.Click(); }
                    catch { }
                    System.Threading.Thread.Sleep(2000);
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
                                int xuly = 0;
                                try
                                {
                                    themmanhinhketthuc.Click();
                                    xuly = 1;
                                }
                                catch
                                {

                                    xuly = 0;

                                }

                                if (xuly == 1)
                                {
                                    System.Threading.Thread.Sleep(10000);
                                    try
                                    {
                                        addmanhinhketthuc.Click();
                                    }
                                    catch { }
                                    System.Threading.Thread.Sleep(5000);
                                    try
                                    {
                                            luumanhinhketthuc.Click();
                                      
                                    }
                                    catch
                                    {

                                    }
                                    System.Threading.Thread.Sleep(3000);
                                    try
                                    {
                                        buoc3.Click();
                                    }
                                    catch { }
                                    try { buoc3_v2.Click(); }
                                    catch { }
                                    System.Threading.Thread.Sleep(3000);
                                    xuatban.Click();
                                    System.Threading.Thread.Sleep(2000);
                                }

                                else 
                                {
                                    goto case 0;
                                }
                            }
                            catch { goto case 0; }
                            break;

                    }
                    #endregion

                }
            }
            else
            {
                btntabbkt.Click();
                System.Threading.Thread.Sleep(2000);
                btnclickbkt.Click();
                System.Threading.Thread.Sleep(2000);
                clickbkt.Click();
                System.Threading.Thread.Sleep(2000);
                doneclickbkt.Click();
                System.Threading.Thread.Sleep(2000);
                btntabcheckbkt.Click();
                IJavaScriptExecutor jse = (IJavaScriptExecutor)PropretiesCollection.driver;
                jse.ExecuteScript("window.scrollTo(0," + 450 + ")", "");
                System.Threading.Thread.Sleep(1000);
                checkbkt.Click();
                System.Threading.Thread.Sleep(2000);
                buoc3bkt.Click();
                int kiemtradulieu = 0;
                switch (kiemtradulieu)
                {
                    case 0:             // label case 1
                        System.Threading.Thread.Sleep(15000);
                        goto case 1;
                        break;
                    case 1:
                        try
                        {
                            int xuly = 0;
                            try
                            {
                                themmanhinhketthuc.Click();
                                System.Threading.Thread.Sleep(10000);
                                try
                                {
                                    addmanhinhketthuc.Click();
                                }
                                catch { }
                                System.Threading.Thread.Sleep(5000);
                                try
                                {
                                    luumanhinhketthuc.Click();
                                }
                                catch
                                {
                                }
                                System.Threading.Thread.Sleep(3000);
                                xuly = 1;
                                if (xuly == 1)
                                {
                                   
                                    buoc4bkt.Click();
                                    System.Threading.Thread.Sleep(7000);
                                    if (m_private == true)
                                    {

                                    }
                                    else
                                    {
                                        //try
                                        //{

                                        clickpublichv2.Click();
                                        //}
                                        //catch { }
                                    }
                                    System.Threading.Thread.Sleep(5000);
                                    xuatban.Click();
                                   
                                    System.Threading.Thread.Sleep(2000);
                                    try
                                    {
                                        clickchonpub.Click();
                                    }
                                    catch { }
                                    System.Threading.Thread.Sleep(2000);
                                }
                                else
                                {
                                    goto case 0;
                                }
                            }
                            catch
                            {
                                goto case 0;
                            }

                            
                           
                          
                        }
                        catch { goto case 0; }
                        break;

                }
            }
        }
        #endregion

    }
}
