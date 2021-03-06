﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Windows.Forms;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using System.IO;

namespace UpLoadNews
{
    public class cl_ReadVoice
    {
        public cl_ReadVoice()
        {
            PageFactory.InitElements(PropretiesCollection.driver, this);
        }


        #region // get tag       
        [FindsBy(How = How.CssSelector, Using = "pre[style='word-wrap: break-word; white-space: pre-wrap;']")]
        public IWebElement listtag;
        public static String chuanHoa(String _string)
        {
            return System.Text.RegularExpressions.Regex.Replace(_string, "\\s+", " ");
        }
        private string m_Tag;
        public string Tag
        {
            get
            {
                return m_Tag;
            }

            set
            {
                m_Tag = value;
            }
        }

        public async Task _tag()
        {

            System.Threading.Thread.Sleep(3000);
            string _listtag = "";
            try
            {

                _listtag = chuanHoa(SeleniumGetMeThor.GetText2(listtag)).Replace("[ \"", "#").Replace("\" ]", "").Replace("\", \"", ",#");

            }
            catch { }
            m_Tag = _listtag;
        }
        #endregion
        #region // readspeak 1
        [FindsBy(How = How.Id, Using = "ttsLanguage")]
        public IWebElement m_chonngonngu;
        [FindsBy(How = How.Id, Using = "ttsVoices")]
        public IWebElement m_chongioitinh;
        [FindsBy(How = How.Id, Using = "effectId")]
        public IWebElement m_choneffect;
        [FindsBy(How = How.Id, Using = "effectLevel")]
        public IWebElement m_choneffectlevel;
        [FindsBy(How = How.Id, Using = "tts_input")]
        public IWebElement m_text;
        [FindsBy(How = How.Id, Using = "control_button")]
        public IWebElement btnplay;

        [FindsBy(How = How.XPath, Using = "//audio")]
        public IWebElement link;

        public string getURLMp3(string _urlvoicecu,string ngonngu, string voice, string effect, string effectlevel, string text)
        {
            string ex= _urlvoicecu;
            SeleniumSetMeThor.SelectDropDown(m_chonngonngu, ngonngu);
            SeleniumSetMeThor.SelectDropDown(m_chongioitinh, voice);
            SeleniumSetMeThor.SelectDropDown(m_choneffect, effect);
            SeleniumSetMeThor.SelectDropDown(m_choneffectlevel, effectlevel);
            m_text.Clear();
            m_text.SendKeys(text);
            Thread.Sleep(1000);
            btnplay.Click();
            int kiemtra = 0;
            switch (kiemtra)
            {
                case 0:             // label case 1
                    System.Threading.Thread.Sleep(2000);
                    goto case 1;
                    break;
                case 1:
                    try
                    {
                        ex = SeleniumGetMeThor.GetTextLink(link);
                        if (ex != _urlvoicecu)
                        {
                            System.Threading.Thread.Sleep(5000);
                            return ex;
                        }
                        else
                        {
                            goto case 0;
                        }
                    }
                    catch { goto case 0; }
                    break;

            }           
            return ex;
        }



        #endregion


        #region // readspeak 2
       
        [FindsBy(How = How.XPath, Using = "//*[@class='infoBox']/ul/li[1]")]
        public IWebElement m_demo;

        [FindsBy(How = How.XPath, Using = "//*[@id='ui_wrap']/div[1]/div[1]/a[1]/img[1]")]
        public IWebElement m_demo2;


        [FindsBy(How = How.XPath, Using = "//*[@id='nekr_pop_content1']/form[1]/div[1]/div[2]/div[1]/dl[1]/dd[1]/div[1]/div[1]/a[1]")]
        public IWebElement m_btnngonngu;

        #region // lua chon ngon ngu
        [FindsBy(How = How.XPath, Using = "//*[@id='nekr_pop_content1']/form[1]/div[1]/div[2]/div[1]/dl[1]/dd[1]/div[1]/ul[1]/li[1]/a[1]")]
        public IWebElement m_ngonnguenglish;

        [FindsBy(How = How.XPath, Using = "//*[@id='nekr_pop_content1']/form[1]/div[1]/div[2]/div[1]/dl[1]/dd[1]/div[1]/ul[1]/li[2]/a[1]")]
        public IWebElement m_ngonngukorean;       
        #region // mc voice korean
            [FindsBy(How = How.XPath, Using = "/html/body/div/div[2]/div/form/div/div[2]/div/dl[2]/dd/ul/li/span/a")]
            public IWebElement m_mcYumi;
            [FindsBy(How = How.XPath, Using = "/html/body/div/div[2]/div/form/div/div[2]/div/dl[2]/dd/ul/li[2]/span/a")]
            public IWebElement m_mcHyeryun;
            [FindsBy(How = How.XPath, Using = "/html/body/div/div[2]/div/form/div/div[2]/div/dl[2]/dd/ul/li[3]/span/a")]
            public IWebElement m_mcHyuna;
            [FindsBy(How = How.XPath, Using = "/html/body/div/div[2]/div/form/div/div[2]/div/dl[2]/dd/ul/li[4]/span/a")]
            public IWebElement m_mcJimin;
            [FindsBy(How = How.XPath, Using = "/html/body/div/div[2]/div/form/div/div[2]/div/dl[2]/dd/ul/li[5]/span/a")]
            public IWebElement m_mcDayoung;
            [FindsBy(How = How.XPath, Using = "/html/body/div/div[2]/div/form/div/div[2]/div/dl[2]/dd/ul/li[6]/span/a")]
            public IWebElement m_mcGyuri;
            [FindsBy(How = How.XPath, Using = "/html/body/div/div[2]/div/form/div/div[2]/div/dl[2]/dd/ul/li[7]/span/a")]
            public IWebElement m_mcChorong;
            [FindsBy(How = How.XPath, Using = "/html/body/div/div[2]/div/form/div/div[2]/div/dl[2]/dd/ul/li[8]/span/a")]
            public IWebElement m_mcSena;
            [FindsBy(How = How.XPath, Using = "/html/body/div/div[2]/div/form/div/div[2]/div/dl[2]/dd/ul/li[9]/span/a")]
            public IWebElement m_mcYura;
            [FindsBy(How = How.XPath, Using = "/html/body/div/div[2]/div/form/div/div[2]/div/dl[2]/dd/ul/li[10]/span/a")]
            public IWebElement m_mcJihun;
            [FindsBy(How = How.XPath, Using = "/html/body/div/div[2]/div/form/div/div[2]/div/dl[2]/dd/ul/li[11]/span/a")]
            public IWebElement m_mcJunwoo;        
            [FindsBy(How = How.XPath, Using = "/html/body/div/div[2]/div/form/div/div[2]/div/dl[2]/dd/ul/li[12]/span/a")]
            public IWebElement m_mcMaru;


        #endregion
        [FindsBy(How = How.XPath, Using = "//*[@id='nekr_pop_content1']/form[1]/div[1]/div[2]/div[1]/dl[1]/dd[1]/div[1]/ul[1]/li[3]/a[1]")]
        public IWebElement m_ngonnguchinese;      
        #region // mc voice chinese
        [FindsBy(How = How.XPath, Using = "/html/body/div/div[2]/div/form/div/div[2]/div/dl[2]/dd/ul/li/span/a")]
        public IWebElement m_mcHui;
        [FindsBy(How = How.XPath, Using = "/html/body/div/div[2]/div/form/div/div[2]/div/dl[2]/dd/ul/li[2]/span/a")]
        public IWebElement m_mcHong;
        [FindsBy(How = How.XPath, Using = "/html/body/div/div[2]/div/form/div/div[2]/div/dl[2]/dd/ul/li[3]/span/a")]
        public IWebElement m_mcLiang;
        [FindsBy(How = How.XPath, Using = "/html/body/div/div[2]/div/form/div/div[2]/div/dl[2]/dd/ul/li[4]/span/a")]
        public IWebElement m_mcQiang;


        #endregion
        [FindsBy(How = How.XPath, Using = "//*[@id='nekr_pop_content1']/form[1]/div[1]/div[2]/div[1]/dl[1]/dd[1]/div[1]/ul[1]/li[4]/a[1]")]
        public IWebElement m_ngonngujapan;      
        #region // mc voice japan
        [FindsBy(How = How.XPath, Using = "/html/body/div/div[2]/div/form/div/div[2]/div/dl[2]/dd/ul/li/span/a")]
        public IWebElement m_mcMisaki;
        [FindsBy(How = How.XPath, Using = "/html/body/div/div[2]/div/form/div/div[2]/div/dl[2]/dd/ul/li[2]/span/a")]
        public IWebElement m_mcHaruka;
        [FindsBy(How = How.XPath, Using = "/html/body/div/div[2]/div/form/div/div[2]/div/dl[2]/dd/ul/li[3]/span/a")]
        public IWebElement m_mcSayaka;
        [FindsBy(How = How.XPath, Using = "/html/body/div/div[2]/div/form/div/div[2]/div/dl[2]/dd/ul/li[4]/span/a")]
        public IWebElement m_mcHikari;
        [FindsBy(How = How.XPath, Using = "/html/body/div/div[2]/div/form/div/div[2]/div/dl[2]/dd/ul/li[5]/span/a")]
        public IWebElement m_mcRisa;
        [FindsBy(How = How.XPath, Using = "/html/body/div/div[2]/div/form/div/div[2]/div/dl[2]/dd/ul/li[6]/span/a")]
        public IWebElement m_mcShow;
        [FindsBy(How = How.XPath, Using = "/html/body/div/div[2]/div/form/div/div[2]/div/dl[2]/dd/ul/li[7]/span/a")]
        public IWebElement m_mcRyo;
        [FindsBy(How = How.XPath, Using = "/html/body/div/div[2]/div/form/div/div[2]/div/dl[2]/dd/ul/li[8]/span/a")]
        public IWebElement m_mcTakeru;
        [FindsBy(How = How.XPath, Using = "/html/body/div/div[2]/div/form/div/div[2]/div/dl[2]/dd/ul/li[9]/span/a")]
        public IWebElement m_mcAkira;


        #endregion
        [FindsBy(How = How.XPath, Using = "//*[@id='nekr_pop_content1']/form[1]/div[1]/div[2]/div[1]/dl[1]/dd[1]/div[1]/ul[1]/li[5]/a[1]")]
        public IWebElement m_ngonnguMexicanSpanish;
        [FindsBy(How = How.XPath, Using = "//*[@id='nekr_pop_content1']/form[1]/div[1]/div[2]/div[1]/dl[1]/dd[1]/div[1]/ul[1]/li[6]/a[1]")]
        public IWebElement m_ngonnguUKEnglish;
        [FindsBy(How = How.XPath, Using = "//*[@id='nekr_pop_content1']/form[1]/div[1]/div[2]/div[1]/dl[1]/dd[1]/div[1]/ul[1]/li[7]/a[1]")]
        public IWebElement m_ngonnguCanadianFrench;
        [FindsBy(How = How.XPath, Using = "//*[@id='nekr_pop_content1']/form[1]/div[1]/div[2]/div[1]/dl[1]/dd[1]/div[1]/ul[1]/li[8]/a[1]")]
        public IWebElement m_ngonnguChineseTaiwan;
        [FindsBy(How = How.XPath, Using = "//*[@id='nekr_pop_content1']/form[1]/div[1]/div[2]/div[1]/dl[1]/dd[1]/div[1]/ul[1]/li[9]/a[1]")]
        public IWebElement m_ngonnguCantoneseChinese;
        [FindsBy(How = How.XPath, Using = "//*[@id='nekr_pop_content1']/form[1]/div[1]/div[2]/div[1]/dl[1]/dd[1]/div[1]/ul[1]/li[10]/a[1]")]
        public IWebElement m_ngonnguThai;
        [FindsBy(How = How.XPath, Using = "//*[@id='nekr_pop_content1']/form[1]/div[1]/div[2]/div[1]/dl[1]/dd[1]/div[1]/ul[1]/li[11]/a[1]")]
        public IWebElement m_ngonnguBrazilian;
        [FindsBy(How = How.XPath, Using = "//*[@id='nekr_pop_content1']/form[1]/div[1]/div[2]/div[1]/dl[1]/dd[1]/div[1]/ul[1]/li[12]/a[1]")]
        public IWebElement m_ngonnguGerman;
        [FindsBy(How = How.XPath, Using = "//*[@id='nekr_pop_content1']/form[1]/div[1]/div[2]/div[1]/dl[1]/dd[1]/div[1]/ul[1]/li[13]/a[1]")]
        public IWebElement m_ngonnguEuropeanSpanish;
        [FindsBy(How = How.XPath, Using = "//*[@id='nekr_pop_content1']/form[1]/div[1]/div[2]/div[1]/dl[1]/dd[1]/div[1]/ul[1]/li[14]/a[1]")]
        #region // mc voice Spanish
        [FindsBy(How = How.XPath, Using = "/html/body/div/div[2]/div/form/div/div[2]/div/dl[2]/dd/ul/li/span/a")]
        public IWebElement m_mcLola;
        [FindsBy(How = How.XPath, Using = "/html/body/div/div[2]/div/form/div/div[2]/div/dl[2]/dd/ul/li[2]/span/a")]
        public IWebElement m_mcManuel;
              

        #endregion

        public IWebElement m_ngonnguItalian;
        [FindsBy(How = How.XPath, Using = "//*[@id='nekr_pop_content1']/form[1]/div[1]/div[2]/div[1]/dl[1]/dd[1]/div[1]/ul[1]/li[15]/a[1]")]
        public IWebElement m_ngonnguEuropeanFrench;
        #region // mc voice EuropeanFrench
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[2]/div[1]/form/div/div[2]/div[1]/dl[2]/dd/ul/li[1]/span/a")]
        public IWebElement m_mcJolie;
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[2]/div[1]/form/div/div[2]/div[1]/dl[2]/dd/ul/li[2]/span/a")]
        public IWebElement m_mcLouis;   
        
        #endregion
        [FindsBy(How = How.XPath, Using = "//*[@id='nekr_pop_content1']/form[1]/div[1]/div[2]/div[1]/dl[1]/dd[1]/div[1]/ul[1]/li[16]/a[1]")]
        public IWebElement m_ngonnguEuropeanPortuguese;
        [FindsBy(How = How.XPath, Using = "//*[@id='nekr_pop_content1']/form[1]/div[1]/div[2]/div[1]/dl[1]/dd[1]/div[1]/ul[1]/li[17]/a[1]")]
        public IWebElement m_ngonnguSwedish;
        [FindsBy(How = How.XPath, Using = "//*[@id='nekr_pop_content1']/form[1]/div[1]/div[2]/div[1]/dl[1]/dd[1]/div[1]/ul[1]/li[18]/a[1]")]
        public IWebElement m_ngonnguDutch;
        [FindsBy(How = How.XPath, Using = "//*[@id='nekr_pop_content1']/form[1]/div[1]/div[2]/div[1]/dl[1]/dd[1]/div[1]/ul[1]/li[19]/a[1]")]
        public IWebElement m_ngonnguAustralianEnglish;
        [FindsBy(How = How.XPath, Using = "//*[@id='nekr_pop_content1']/form[1]/div[1]/div[2]/div[1]/dl[1]/dd[1]/div[1]/ul[1]/li[20]/a[1]")]
        public IWebElement m_ngonnguRussian;

        #endregion

       
        [FindsBy(How = How.XPath, Using = "//*[@id='nekr_pop_content1']/form[1]/div[1]/div[2]/div[1]/dl[3]/dd[1]/div[1]/div[1]/a[1]")]
        public IWebElement m_btnsize;
        [FindsBy(How = How.XPath, Using = "//*[@id='nekr_pop_content1']/form[1]/div[1]/div[2]/div[1]/dl[3]/dd[1]/div[1]/ul[1]/li[2]/a[1]")]
        public IWebElement m_selectsize;
        [FindsBy(How = How.XPath, Using = "//*[@id='nekr_pop_content1']/form[1]/div[1]/div[2]/div[1]/dl[3]/dd[1]/div[1]/ul[1]/li[1]/a[1]")]
        public IWebElement m_selectsize0;


        [FindsBy(How = How.Id, Using = "content")]
        public IWebElement m_text2;      

        [FindsBy(How = How.XPath, Using = "//*[@id='nekr_pop_content1']/form[1]/div[1]/div[2]/div[2]/dl[1]/dd[2]/a[1]/img[1]")]
        public IWebElement btnlisten;
        [FindsBy(How = How.XPath, Using = "//audio")]
        public IWebElement link2;
        public void selectV2(string ngonngu,string mcvoice)
        {
            m_demo.Click();
            Thread.Sleep(1000);
            m_btnngonngu.Click();
            Thread.Sleep(1000);
            if (ngonngu == "English")
            {
                m_ngonnguenglish.Click();
            }
            else if (ngonngu == "Korean")
            {
                m_ngonngukorean.Click();
                #region // click mc voice
                if(mcvoice=="Dayoung")
                {
                    m_mcDayoung.Click();
                }
                if (mcvoice == "Dayoung")
                {
                    m_mcDayoung.Click();
                }
                if (mcvoice == "Hyeryun")
                {
                    m_mcHyeryun.Click();
                }
                if (mcvoice == "Hyuna")
                {
                    m_mcHyuna.Click();
                }
                if (mcvoice == "Jihun")
                {
                    m_mcJihun.Click();
                }
                if (mcvoice == "Jimin")
                {
                    m_mcJimin.Click();
                }
                if (mcvoice == "Junwoo")
                {
                    m_mcJunwoo.Click();
                }
                if (mcvoice == "Sena")
                {
                    m_mcSena.Click();
                }
                if (mcvoice == "Yumi")
                {
                    m_mcYumi.Click();
                }
                if (mcvoice == "Yura")
                {
                    m_mcYura.Click();
                }
                #endregion 
            }
            else if (ngonngu == "Chinese")
            {
                m_ngonnguchinese.Click();
                #region // click mc voice
                if (mcvoice == "Hui (Mandarin)")
                {
                    m_mcHui.Click();
                }
                if (mcvoice == "Linlin (Mandarin)")
                {
                    m_mcHong.Click();
                }
                if (mcvoice == "Yafang (Taiwanese)")
                {
                    m_mcQiang.Click();
                }
                if (mcvoice == "Liang (Mandarin)")
                {
                    m_mcLiang.Click();
                }               
                #endregion 
            }
            else if (ngonngu == "Japanese")
            {
                m_ngonngujapan.Click();
                #region // click mc voice
                if(mcvoice== "Haruka")
                {
                    m_mcHaruka.Click();
                }
               
                if (mcvoice == "Hikari")
                {
                    m_mcHikari.Click();
                }
                if (mcvoice == "Misaki")
                {
                    m_mcMisaki.Click();
                }
                if (mcvoice == "Ryo")
                {
                    m_mcRyo.Click();
                }
                if (mcvoice == "Sayaka")
                {
                    m_mcSayaka.Click();
                }
                if (mcvoice == "Show")
                {
                    m_mcShow.Click();
                }
                if (mcvoice == "Takeru")
                {
                    m_mcTakeru.Click();
                }
                #endregion

            }
            else if (ngonngu == "German")
            {
                m_ngonnguGerman.Click();
            }
            else if (ngonngu == "Spanish")
            {
                m_ngonnguEuropeanSpanish.Click();
                #region // click mc voice
                if(mcvoice== "Soledad (American)")
                {
                    m_mcManuel.Click();
                }
                if (mcvoice == "Lola (Castilian)")
                {
                    m_mcLola.Click();
                }
                #endregion
            }
            else if (ngonngu == "Thai")
            {
                m_ngonnguThai.Click();
            }
            else if (ngonngu == "Russian")
            {
                m_ngonnguRussian.Click();
            }
            else if (ngonngu == "French")
            {
                m_ngonnguEuropeanFrench.Click();
                #region // click mc voice
                if (mcvoice == "Jolie")
                {
                    m_mcJolie.Click();
                }
                if (mcvoice == "Olivier")
                {
                    m_mcLouis.Click();
                }
                #endregion
            }
            else if (ngonngu == "Italian")
            {
                m_ngonnguItalian.Click();
            }
            try
            {
                Thread.Sleep(500);
                m_btnsize.Click();
                Thread.Sleep(1000);
                m_selectsize.Click();
            }
            catch { }
        }

        public void checklager()
        {
            try
            {
                Thread.Sleep(500);
                m_btnsize.Click();
                Thread.Sleep(1000);
                m_selectsize0.Click();
            }
            catch { }
        }
        public string getURLMp3_V2(string _urlvoicecu, string text)
        {
            string ex = _urlvoicecu;
            try
            {               

                m_text2.Clear();
                m_text2.SendKeys(text);
                btnlisten.Click();
                Thread.Sleep(2000);
                int kiemtra = 0;
                switch (kiemtra)
                {
                    case 0:             // label case 1
                        System.Threading.Thread.Sleep(2000);
                        goto case 1;
                        break;
                    case 1:
                        try
                        {
                            ex = SeleniumGetMeThor.GetTextLink(link2);
                            if (ex != _urlvoicecu)
                            {
                                return ex;
                            }
                            else
                            {
                                goto case 0;
                            }
                        }
                        catch { goto case 0; }
                        break;

                }

                return ex;
            }
            catch
            {
                    
            }
           return ex;
        }
        public void selectV2_TiengHan(string ngonngu, string mcvoice)
        {
            m_demo.Click();
            Thread.Sleep(1000);
            m_btnngonngu.Click();
            Thread.Sleep(1000);
            if (ngonngu == "English")
            {
                m_ngonngukorean.Click();
            }
            else if (ngonngu == "Korean")
            {
               
                m_ngonnguenglish.Click();
                #region // click mc voice
                if (mcvoice == "Dayoung")
                {
                    m_mcDayoung.Click();
                }
                if (mcvoice == "Dayoung")
                {
                    m_mcDayoung.Click();
                }
                if (mcvoice == "Hyeryun")
                {
                    m_mcHyeryun.Click();
                }
                if (mcvoice == "Hyuna")
                {
                    m_mcHyuna.Click();
                }
                if (mcvoice == "Jihun")
                {
                    m_mcJihun.Click();
                }
                if (mcvoice == "Jimin")
                {
                    m_mcJimin.Click();
                }
                if (mcvoice == "Junwoo")
                {
                    m_mcJunwoo.Click();
                }
                if (mcvoice == "Sena")
                {
                    m_mcSena.Click();
                }
                if (mcvoice == "Yumi")
                {
                    m_mcYumi.Click();
                }
                if (mcvoice == "Yura")
                {
                    m_mcYura.Click();
                }
                #endregion 
            }
            else if (ngonngu == "Chinese")
            {
                m_ngonnguchinese.Click();
                #region // click mc voice
                if (mcvoice == "Hui (Mandarin)")
                {
                    m_mcHui.Click();
                }
                if (mcvoice == "Linlin (Mandarin)")
                {
                    m_mcHong.Click();
                }
                if (mcvoice == "Yafang (Taiwanese)")
                {
                    m_mcQiang.Click();
                }
                if (mcvoice == "Liang (Mandarin)")
                {
                    m_mcLiang.Click();
                }
                #endregion
            }
            else if (ngonngu == "Japanese")
            {
                m_ngonngujapan.Click();
                #region // click mc voice
                if (mcvoice == "Haruka")
                {
                    m_mcHaruka.Click();
                }

                if (mcvoice == "Hikari")
                {
                    m_mcHikari.Click();
                }
                if (mcvoice == "Misaki")
                {
                    m_mcMisaki.Click();
                }
                if (mcvoice == "Ryo")
                {
                    m_mcRyo.Click();
                }
                if (mcvoice == "Sayaka")
                {
                    m_mcSayaka.Click();
                }
                if (mcvoice == "Show")
                {
                    m_mcShow.Click();
                }
                if (mcvoice == "Takeru")
                {
                    m_mcTakeru.Click();
                }
                #endregion

            }
            else if (ngonngu == "German")
            {
                m_ngonnguGerman.Click();
            }
            else if (ngonngu == "Spanish")
            {
                m_ngonnguEuropeanSpanish.Click();
                #region // click mc voice
                if (mcvoice == "Soledad (American)")
                {
                    m_mcManuel.Click();
                }
                if (mcvoice == "Lola (Castilian)")
                {
                    m_mcLola.Click();
                }
                #endregion
            }
            else if (ngonngu == "Thai")
            {
                m_ngonnguThai.Click();
            }
            else if (ngonngu == "Russian")
            {
                m_ngonnguRussian.Click();
            }
            else if (ngonngu == "French")
            {
                m_ngonnguEuropeanFrench.Click();
                #region // click mc voice
                if (mcvoice == "Jolie")
                {
                    m_mcJolie.Click();
                }
                if (mcvoice == "Olivier")
                {
                    m_mcLouis.Click();
                }
                #endregion
            }
            else if (ngonngu == "Italian")
            {
                m_ngonnguItalian.Click();
            }
            try
            {
                Thread.Sleep(500);
                m_btnsize.Click();
                Thread.Sleep(1000);
                m_selectsize.Click();
            }
            catch { }
        }
        #endregion

        #region readspeak 3
        [FindsBy(How = How.XPath, Using = "/html/body/div/div/div[2]/div/div/ul/li")]       
        public IWebElement m_btnchonngonngu;
        [FindsBy(How = How.Id, Using = "tts-text")]
        public IWebElement m_text3;
        [FindsBy(How = How.Id, Using = "tts-play")]
        public IWebElement btnplay3;
        [FindsBy(How = How.XPath, Using = "//audio")]
        public IWebElement link3;

        #region  // cac ngon ngu trong web 3
        [FindsBy(How = How.XPath, Using = "/html/body/div/div/div[2]/div/div/ul/li")]       
        public IWebElement m_chonngonnguenglish;
        [FindsBy(How = How.XPath, Using = "/html/body/div/div/div[2]/div/div/ul[2]/li[2]")]
        public IWebElement m_chonngonngumxspanish;
        [FindsBy(How = How.XPath, Using = "/html/body/div/div/div[2]/div/div/ul[2]/li[3]")]
        public IWebElement m_chonngonngumadarin;
        [FindsBy(How = How.XPath, Using = "/html/body/div/div/div[2]/div/div/ul[2]/li[4]")]
        public IWebElement m_chonngonngukorean;    
        [FindsBy(How = How.XPath, Using = "/html/body/div/div/div[2]/div/div/ul[2]/li[5]")]
        public IWebElement m_chonngonngujapan;
        [FindsBy(How = How.XPath, Using = "/html/body/div/div/div[2]/div/div/ul[2]/li[6]")]
        public IWebElement m_chonngonngucafrech;
        [FindsBy(How = How.XPath, Using = "/html/body/div/div/div[2]/div/div/ul[2]/li[7]")]
        public IWebElement m_chonngonnguukenglish;
        [FindsBy(How = How.XPath, Using = "/html/body/div/div/div[2]/div/div/ul[2]/li[8]")]
        public IWebElement m_chonngonngutaiwanse;
        [FindsBy(How = How.XPath, Using = "/html/body/div/div/div[2]/div/div/ul[2]/li[9]")]
        public IWebElement m_chonngonngucantonsesn;
        [FindsBy(How = How.XPath, Using = "/html/body/div/div/div[2]/div/div/ul[2]/li[10]")]
        public IWebElement m_chonngonnguthai;
        [FindsBy(How = How.XPath, Using = "/html/body/div/div/div[2]/div/div/ul[2]/li[11]")]
        public IWebElement m_chonngonngubrazin;
        [FindsBy(How = How.XPath, Using = "/html/body/div/div/div[2]/div/div/ul[2]/li[12]")]
        public IWebElement m_chonngonngugerman;
        [FindsBy(How = How.XPath, Using = "/html/body/div/div/div[2]/div/div/ul[2]/li[13]")]
        public IWebElement m_chonngonngueuspanish;
        [FindsBy(How = How.XPath, Using = "/html/body/div/div/div[2]/div/div/ul[2]/li[14]")]
        public IWebElement m_chonngonnguitalian;
        [FindsBy(How = How.XPath, Using = "/html/body/div/div/div[2]/div/div/ul[2]/li[15]")]
        public IWebElement m_chonngonngueufrench;
        #endregion
        public void selectV3(string ngonngu)
        {          
            Thread.Sleep(1000);
            m_btnchonngonngu.Click();
            Thread.Sleep(1000);
            if (ngonngu == "English")
            {
                m_chonngonnguenglish.Click();
            }
            else if (ngonngu == "Korean")
            {
                m_chonngonngukorean.Click();
            }
            else if (ngonngu == "Chinese")
            {
                m_chonngonngutaiwanse.Click();
            }
            else if (ngonngu == "Japanese")
            {
                m_chonngonngujapan.Click();
            }
            else if (ngonngu == "German")
            {
                m_chonngonngugerman.Click();
            }
            else if (ngonngu == "Spanish")
            {
                m_chonngonngueuspanish.Click();
            }
            else if (ngonngu == "Thai")
            {
                m_chonngonnguthai.Click();
            }            
            else if (ngonngu == "French")
            {
                m_chonngonngueufrench.Click();
            }
            else if (ngonngu == "Italian")
            {
                m_chonngonnguitalian.Click();
            }
            Thread.Sleep(5000);
        }

     

        public string getURLMp3_V3(string _urlvoicecu,string text)
        {
            string ex= _urlvoicecu;

            m_text3.Clear();
            m_text3.SendKeys(text);
            btnplay3.Click();
            Thread.Sleep(1000);
            int kiemtra = 0;
            switch (kiemtra)
            {
                case 0:             // label case 1
                    System.Threading.Thread.Sleep(1000);
                    goto case 1;
                    break;
                case 1:
                    try
                    {

                        string textbutton = btnplay3.Text;
                        if (ex != _urlvoicecu)
                        {
                            System.Threading.Thread.Sleep(2000);
                        }
                        else
                        {
                            ex = SeleniumGetMeThor.GetTextLink(link3);
                        }

                        if (ex != _urlvoicecu && textbutton == "PLAY")
                        {
                           
                            return ex;
                        }
                        else
                        {
                            goto case 0;
                        }
                    }
                    catch { goto case 0; }
                    break;

            }
          
            return ex;
        }


        #endregion

        #region // READSPEAK VIET NAM 1
        [FindsBy(How = How.Id, Using = "voiceselect")]
        public IWebElement m_mcvietnam;
        [FindsBy(How = How.Id, Using = "inputtextarea")]
        public IWebElement m_textvietnam;
        [FindsBy(How = How.Id, Using = "buttonSpeak")]
        public IWebElement btnspeak;
        [FindsBy(How = How.XPath, Using = "//audio")]
        public IWebElement linkvietnam;
        [FindsBy(How = How.Id, Using = "buttonSave")]
        public IWebElement buttonSavevietnam;
        public string getURLMp3VietNam(string ngonngu,string text)
        {
           
            string ex="";
            SeleniumSetMeThor.SelectDropDown(m_mcvietnam, ngonngu);
            m_textvietnam.Clear();
            m_textvietnam.SendKeys(text);
            Thread.Sleep(1000);
            btnspeak.Click();
            ex = SeleniumGetMeThor.GetTextLink(linkvietnam);
            Thread.Sleep(1000);
            buttonSavevietnam.Click();
            Thread.Sleep(10000);
            return ex;
        }
        #endregion


        #region // lấy voice IBM https://text-to-speech-demo.ng.bluemix.net/
        [FindsBy(How = How.Name, Using = "voice")]
        public IWebElement m_chonngonnguIBM;
        [FindsBy(How = How.XPath, Using = "//textarea")]
        public IWebElement m_textIBM;
        [FindsBy(How = How.XPath, Using = "//button[@class='base--button speak-button']")]
        public IWebElement btnspeakIBM;
        [FindsBy(How = How.Id, Using = "audio")]
        public IWebElement linkIBM;
        public string getURLMp3IBM(string _urlvoicecu, string ngonngu,string text)
        {
            string ex = _urlvoicecu;
            SeleniumSetMeThor.SelectDropDown(m_chonngonnguIBM, ngonngu);
            m_textIBM.Clear();
            m_textIBM.SendKeys(text);
            Thread.Sleep(1000);
            btnspeakIBM.Click();
            int kiemtra = 0;
            switch (kiemtra)
            {
                case 0:             // label case 1
                    System.Threading.Thread.Sleep(2000);
                    goto case 1;
                    break;
                case 1:
                    try
                    {
                        ex = SeleniumGetMeThor.GetTextLink(linkIBM);
                        if (ex != _urlvoicecu)
                        {
                            System.Threading.Thread.Sleep(5000);
                            return ex;
                        }
                        else
                        {
                            goto case 0;
                        }
                    }
                    catch { goto case 0; }
                    break;

            }
            return ex;
        }



        #endregion

        #region // lay voice notevibes https://notevibes.com/
        [FindsBy(How = How.Name, Using = "voice")]
        public IWebElement m_chonngonnguvibes;
        [FindsBy(How = How.Name, Using = "content")]
        public IWebElement m_textvibes;
        [FindsBy(How = How.XPath, Using = "//input[@type='submit']")]
        public IWebElement btnspeakvibes;
        [FindsBy(How = How.XPath, Using = "//source")]
        public IWebElement linkvibes;
        public string getURLMp3vibes(string _urlvoicecu, string ngonngu, string text)
        {
            string ex = _urlvoicecu;
            SeleniumSetMeThor.SelectDropDown(m_chonngonnguvibes, ngonngu);
            m_textvibes.Clear();
            m_textvibes.SendKeys(text);
            Thread.Sleep(1000);
            btnspeakvibes.Click();
            Thread.Sleep(1000);
            int kiemtra = 0;
            switch (kiemtra)
            {
                case 0:             // label case 1
                    System.Threading.Thread.Sleep(2000);
                    goto case 1;
                    break;
                case 1:
                    try
                    {
                        ex = SeleniumGetMeThor.GetTextLink(linkvibes);
                        if (ex != _urlvoicecu)
                        {
                            System.Threading.Thread.Sleep(5000);
                            return ex;
                        }
                        else
                        {
                            goto case 0;
                        }
                    }
                    catch { goto case 0; }
                    break;

            }
            return ex;
        }

        #endregion

        #region // lay voice ispeech.org https://www.ispeech.org/text.to.speech

            #region // lua chon ngon ngu
            [FindsBy(How = How.XPath, Using = "/html/body/div/div[2]/div/div/div/div/div/div[2]/div/div/ul/li/div/span")]
            public IWebElement m_USEnglish;
            [FindsBy(How = How.XPath, Using = "/html/body/div/div[2]/div/div/div/div/div/div[2]/div/div/ul/li[2]/div")]
            public IWebElement m_UKEnglish;
            [FindsBy(How = How.XPath, Using = "/html/body/div/div[2]/div/div/div/div/div/div[2]/div/div/ul/li[3]/div")]
            public IWebElement m_AustralianEnglish;
            [FindsBy(How = How.XPath, Using = "/html/body/div/div[2]/div/div/div/div/div/div[2]/div/div/ul/li[4]/div")]
            public IWebElement m_USSpanish;
            [FindsBy(How = How.XPath, Using = "/html/body/div/div[2]/div/div/div/div/div/div[2]/div/div/ul/li[5]/div")]
            public IWebElement m_Chinese;
            [FindsBy(How = How.XPath, Using = "/html/body/div/div[2]/div/div/div/div/div/div[2]/div/div/ul/li[6]/div")]
            public IWebElement m_HongKongChinese;
            [FindsBy(How = How.XPath, Using = "/html/body/div/div[2]/div/div/div/div/div/div[2]/div/div/ul/li[7]/div")]
            public IWebElement m_TaiwanChinese;
            [FindsBy(How = How.XPath, Using = "/html/body/div/div[2]/div/div/div/div/div/div[2]/div/div/ul/li[8]/div")]
            public IWebElement m_Japanese;
            [FindsBy(How = How.XPath, Using = "/html/body/div/div[2]/div/div/div/div/div/div[2]/div/div/ul/li[9]/div")]
            public IWebElement m_Korean;
            [FindsBy(How = How.XPath, Using = "/html/body/div/div[2]/div/div/div/div/div/div[2]/div/div/ul/li[10]/div")]
            public IWebElement m_CanadianEnglish;
            [FindsBy(How = How.XPath, Using = "/html/body/div/div[2]/div/div/div/div/div/div[2]/div/div/ul/li[11]/div")]
            public IWebElement m_Hungarian;
            [FindsBy(How = How.XPath, Using = "/html/body/div/div[2]/div/div/div/div/div/div[2]/div/div/ul/li[12]/div")]
            public IWebElement m_BrazilianPortuguese;
            [FindsBy(How = How.XPath, Using = "/html/body/div/div[2]/div/div/div/div/div/div[2]/div/div/ul/li[13]/div")]
            public IWebElement m_EuropeanPortuguese;
            [FindsBy(How = How.XPath, Using = "/html/body/div/div[2]/div/div/div/div/div/div[2]/div/div/ul/li[14]/div")]
            public IWebElement m_EuropeanSpanish;
            [FindsBy(How = How.XPath, Using = "/html/body/div/div[2]/div/div/div/div/div/div[2]/div/div/ul/li[15]/div")]
            public IWebElement m_EuropeanCzech;
            [FindsBy(How = How.XPath, Using = "/html/body/div/div[2]/div/div/div/div/div/div[2]/div/div/ul/li[16]/div")]
            public IWebElement m_EuropeanDanish;
            [FindsBy(How = How.XPath, Using = "/html/body/div/div[2]/div/div/div/div/div/div[2]/div/div/ul/li[17]/div")]
            public IWebElement m_EuropeanFinnish;
            [FindsBy(How = How.XPath, Using = "/html/body/div/div[2]/div/div/div/div/div/div[2]/div/div/ul/li[18]/div")]
            public IWebElement m_EuropeanFrench;
            [FindsBy(How = How.XPath, Using = "/html/body/div/div[2]/div/div/div/div/div/div[2]/div/div/ul/li[19]/div")]
            public IWebElement m_EuropeanNorwegian;
            [FindsBy(How = How.XPath, Using = "/html/body/div/div[2]/div/div/div/div/div/div[2]/div/div/ul/li[20]/div")]
            public IWebElement m_EuropeanDutch;
            [FindsBy(How = How.XPath, Using = "/html/body/div/div[2]/div/div/div/div/div/div[2]/div/div/ul/li[21]/div")]
            public IWebElement m_EuropeanPolish;
            [FindsBy(How = How.XPath, Using = "/html/body/div/div[2]/div/div/div/div/div/div[2]/div/div/ul/li[22]/div")]
            public IWebElement m_EuropeanItalian;
            [FindsBy(How = How.XPath, Using = "/html/body/div/div[2]/div/div/div/div/div/div[2]/div/div/ul/li[23]/div")]
            public IWebElement m_EuropeanTurkish;
            [FindsBy(How = How.XPath, Using = "/html/body/div/div[2]/div/div/div/div/div/div[2]/div/div/ul/li[24]/div")]
            public IWebElement m_EuropeanGreek;
            [FindsBy(How = How.XPath, Using = "/html/body/div/div[2]/div/div/div/div/div/div[2]/div/div/ul/li[25]/div")]
            public IWebElement m_EuropeanGerman;
            [FindsBy(How = How.XPath, Using = "/html/body/div/div[2]/div/div/div/div/div/div[2]/div/div/ul/li[26]/div")]
            public IWebElement m_Russian;
            [FindsBy(How = How.XPath, Using = "/html/body/div/div[2]/div/div/div/div/div/div[2]/div/div/ul/li[27]/div")]
            public IWebElement m_Swedish;
            [FindsBy(How = How.XPath, Using = "/html/body/div/div[2]/div/div/div/div/div/div[2]/div/div/ul/li[28]/div")]
            public IWebElement m_CanadianFrench;
            [FindsBy(How = How.XPath, Using = "/html/body/div/div[2]/div/div/div/div/div/div[2]/div/div/ul/li[29]/div")]
            public IWebElement m_Arabic;
        #endregion

            public void selectIspeech(string ngonngu)
                {
                    Thread.Sleep(6000);
                    if (ngonngu == "US English")
                    {
                      m_USEnglish.Click();
                    }
                    if (ngonngu == "UK English")
                    {
                        m_USEnglish.Click();
                    }
                    if (ngonngu == "Australian English")
                    {
                        m_AustralianEnglish.Click();
                    }
                    if (ngonngu == "US Spanish")
                    {
                    m_USSpanish.Click();
                    }
                    if (ngonngu == "Chinese")
                    {
                    m_Chinese.Click();
                    }
                    if (ngonngu == "Hong Kong Chinese")
                    {
                    m_HongKongChinese.Click();
                    }
                    if (ngonngu == "Taiwan Chinese")
                    {
                    m_TaiwanChinese.Click();
                    }
                    if (ngonngu == "Japanese")
                    {
                    m_Japanese.Click();
                    }
                    if (ngonngu == "Korean")
                    {
                    m_Korean.Click();
                    }
                    if (ngonngu == "Canadian English")
                    {
                    m_CanadianEnglish.Click();
                    }
                    if (ngonngu == "Hungarian")
                    {
                    m_Hungarian.Click();
                    }
                    if (ngonngu == "Brazilian Portuguese")
                    {
                    m_BrazilianPortuguese.Click();
                    }
                    if (ngonngu == "European Portuguese")
                    {
                    m_EuropeanPortuguese.Click();
                    }
                    if (ngonngu == "European Spanish")
                    {
                    m_EuropeanSpanish.Click();
                    }
                    if (ngonngu == "European Czech")
                    {
                        m_EuropeanCzech.Click();
                    }
                    if (ngonngu == "European Danish")
                    {
                        m_EuropeanDanish.Click();
                    }
                    if (ngonngu == "European French")
                    {
                        m_EuropeanFrench.Click();
                    }
                    if (ngonngu == "European Norwegian")
                    {
                        m_EuropeanNorwegian.Click();
                    }
                    if (ngonngu == "EuropeanDutch")
                    {
                        m_EuropeanDutch.Click();
                    }
                    if (ngonngu == "European Polish")
                    {
                    m_EuropeanPolish.Click();
                    }
                    if (ngonngu == "European Italian")
                    {
                    m_EuropeanItalian.Click();
                    }
                    if (ngonngu == "European Turkish")
                    {
                    m_EuropeanTurkish.Click();
                    }
                    if (ngonngu == "European Greek")
                    {
                    m_EuropeanGreek.Click();
                    }
                    if (ngonngu == "European German")
                    {
                    m_EuropeanGerman.Click();
                    }
                    if (ngonngu == "Russian")
                    {
                    m_Russian.Click();
                    }
                    if (ngonngu == "Swedish")
                    {
                    m_Swedish.Click();
                    }
                    if (ngonngu == "Canadian French")
                    {
                    m_CanadianFrench.Click();
                    }
                    if (ngonngu == "Arabic")
                    {
                    m_Arabic.Click();
                    }
            
            }
        
            [FindsBy(How = How.XPath, Using = "//textarea")]
            public IWebElement m_textispeech;

            [FindsBy(How = How.XPath, Using = "/html/body/div/div[2]/div/div/div/div/div/div[2]/div[2]/div[2]/div/div/span")]
            public IWebElement btnspeakispeech;

            [FindsBy(How = How.XPath, Using = "//audio")]
            public IWebElement linkispeech;
            public string getURLMp3_ispeech(string _urlvoicecu, string text)
            {
                string ex = _urlvoicecu;
                m_textispeech.Clear();
                m_textispeech.SendKeys(text);
                btnspeakispeech.Click();
                Thread.Sleep(2000);
                int kiemtra = 0;
                switch (kiemtra)
                {
                    case 0:             // label case 1
                        System.Threading.Thread.Sleep(1000);
                        goto case 1;
                        break;
                    case 1:
                        try
                        {
                            ex = SeleniumGetMeThor.GetTextLink(linkispeech);
                            if (ex != _urlvoicecu)
                            {
                                System.Threading.Thread.Sleep(2000);
                                return ex;
                            }
                            else
                            {
                                goto case 0;
                            }
                        }
                        catch { goto case 0; }
                        break;


                }

                return ex;
            }



        #endregion

        #region // lấy voice https://ttsmp3.com/text-to-speech/Korean/

        [FindsBy(How = How.Id, Using = "voicetext")]
        public IWebElement m_textttsmp3;
        [FindsBy(How = How.Id, Using = "sprachwahl")]
        public IWebElement m_chonngonnguttsmp3;
        [FindsBy(How = How.Id, Using = "downloadenbutton")]
        public IWebElement m_downttsmp3;

        public void getvoicemp3_TTSmp3(string ngonngu,string text)
        {
            SeleniumSetMeThor.SelectDropDown(m_chonngonnguttsmp3, ngonngu);
            m_textttsmp3.Clear();
            m_textttsmp3.SendKeys(text);
            Thread.Sleep(1000);
            m_downttsmp3.Click();
            Thread.Sleep(5000);
        }


        #endregion

        #region // lấy voice ở trang https://ttstool.com/?fbclid=IwAR0cMXqLvFPhhkaeZhzok0PvB_befDCd4FBIZNfrEdlmZXsAzWZTGGkuX-Y

        [FindsBy(How = How.XPath, Using = "//textarea")]
        public IWebElement m_textttstool;
        [FindsBy(How = How.XPath, Using = "/html/body/div/table/tbody/tr/td[2]/select")]
        public IWebElement m_chonserverttstool;
        [FindsBy(How = How.XPath, Using = "/html/body/div/table/tbody/tr[2]/td[2]/select")]
        public IWebElement m_chonngonnguttstool;
        [FindsBy(How = How.XPath, Using = "/html/body/div/table[2]/tbody/tr/td/div[2]/div[2]/select")]
        public IWebElement m_chonvoicettstool;
        [FindsBy(How = How.XPath, Using = "/html/body/div/div/i[2]")]
        public IWebElement m_downttstool;
        public void getvoicemp3_TTSTOOL(string server,string ngonngu,string voice, string text)
        {
            SeleniumSetMeThor.SelectDropDown(m_chonserverttstool, server);
            Thread.Sleep(1000);
            SeleniumSetMeThor.SelectDropDown(m_chonngonnguttstool, ngonngu);
            Thread.Sleep(2000);
            SeleniumSetMeThor.SelectDropDown(m_chonvoicettstool, voice);
            Thread.Sleep(1000);
            m_textttstool.Clear();
            m_textttstool.SendKeys(text);
            Thread.Sleep(1000);
            m_downttstool.Click();
            Thread.Sleep(4000);
        }

        #endregion


        #region // lấy voice ở trang https://tts.reallusion.com/en/Home/TTS
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div[3]/div/div[2]/div/div/ul/li[8]")]
        public IWebElement m_reall_korean;
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div[3]/div/div[2]/div/div/ul/li[7]")]
        public IWebElement m_reall_japan;
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div[3]/div/div[2]/div/div/ul/li[11]")]
        public IWebElement m_reall_french;
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div[3]/div/div[2]/div/div/ul/li[3]")]
        public IWebElement m_reall_german;
        [FindsBy(How = How.Id, Using = "txtTTS")]
        public IWebElement m_reall_text;
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div[3]/div/div[2]/div/div[2]/div[2]/table/tbody/tr/td[3]/a")]
        public IWebElement btn_reall_listen;
        [FindsBy(How = How.XPath, Using = "//source")]
        public IWebElement link_reall;
        public void select_voice_reall(string ngonngu)
        {
           
            if (ngonngu == "Korean")
            {
                m_reall_korean.Click();
              
            }
            else if (ngonngu == "German")
            {
                m_reall_german.Click();
            }
            else if (ngonngu == "French")
            {
                m_reall_french.Click();
            }
            else if (ngonngu == "Japanese")     

            {
                m_reall_japan.Click();             

            }           
        }
        public string getURLMp3_Voice_Reall(string _urlvoicecu, string text)
        {
            string ex = _urlvoicecu;
            try
            {
                System.Threading.Thread.Sleep(2000);
                m_reall_text.Clear();
                m_reall_text.SendKeys(text);
                btn_reall_listen.Click();
                Thread.Sleep(2000);
                int kiemtra = 0;
                switch (kiemtra)
                {
                    case 0:             // label case 1
                        System.Threading.Thread.Sleep(2000);
                        goto case 1;
                        break;
                    case 1:
                        try
                        {
                            ex = SeleniumGetMeThor.GetTextLink(link_reall);
                            if (ex != _urlvoicecu)
                            {
                                return ex;
                            }
                            else
                            {
                                goto case 0;
                            }
                        }
                        catch { goto case 0; }
                        break;

                }

                return ex;
            }
            catch 
            {
              
            }
            return ex;
        }

        #endregion


        #region // lấy voice ở trang https://www.cereproc.com/en/products/cloud
        [FindsBy(How = How.XPath, Using = "/html/body/main/div[1]/div[1]/a")]
        public IWebElement m_cereproc;
        [FindsBy(How = How.XPath, Using = "/html/body/main/div[1]/div[1]/div/div/div/div/div/div[2]/form/div[2]/div[1]/a/span")]
        public IWebElement m_cereproc_ngonngu;
        [FindsBy(How = How.XPath, Using = "/html/body/main/div[1]/div[1]/div/div/div/div/div/div[2]/form/div[2]/div[2]/a/span")]
        public IWebElement m_cereproc_giong;   
        

        
        [FindsBy(How = How.XPath, Using = "/html/body/main/div[1]/div[1]/div/div/div/div/div/div[2]/form/div[2]/div[2]/ul/li[2]")]
        public IWebElement m_cereproc_englishnam;

        [FindsBy(How = How.XPath, Using = "/html/body/main/div[1]/div[1]/div/div/div/div/div/div[2]/form/div[2]/div[1]/ul/li[16]")]
        public IWebElement m_cereproc_japan;
        [FindsBy(How = How.XPath, Using = "/html/body/main/div[1]/div[1]/div/div/div/div/div/div[2]/form/div[2]/div[1]/ul/li[8]")]
        public IWebElement m_cereproc_french;
        [FindsBy(How = How.XPath, Using = "/html/body/main/div[1]/div[1]/div/div/div/div/div/div[2]/form/div[2]/div[2]/ul/li[4]")]
        public IWebElement m_cereproc_frenchnam;
        

        [FindsBy(How = How.XPath, Using = "/html/body/main/div[1]/div[1]/div/div/div/div/div/div[2]/form/div[2]/div[1]/ul/li[3]")]
        public IWebElement m_cereproc_german;
        [FindsBy(How = How.XPath, Using = "/html/body/main/div[1]/div[1]/div/div/div/div/div/div[2]/form/div[1]/textarea")]
        public IWebElement m_cereproc_text;
       
        [FindsBy(How = How.XPath, Using = "/html/body/main/div[1]/div[1]/div/div/div/div/div/div[2]/form")]
        public IWebElement m_cereproc_from;
        [FindsBy(How = How.XPath, Using = "/html/body/main/div[1]/div[1]/div/div/div/div/div/div[2]/form/div[2]/div[3]/input")]
        public IWebElement btn_cereproc_listen;
        [FindsBy(How = How.XPath, Using = "//audio")]
        public IWebElement link_cereproc;
        public void select_voice_cereproc(string ngonngu,bool giongnam)
        {
            m_cereproc.Click();
            Thread.Sleep(2000);
            m_cereproc_ngonngu.Click();
            Thread.Sleep(1000);
            if (ngonngu == "English")
            {
                if (giongnam == true)
                {
                    m_cereproc_giong.Click();
                    Thread.Sleep(1000);
                    m_cereproc_englishnam.Click();
                }
            }
            if (ngonngu == "German")
            {
                m_cereproc_german.Click();
            }
            else if (ngonngu == "French")
            {
                m_cereproc_french.Click();
                if (giongnam == true)
                {
                    m_cereproc_giong.Click();
                    Thread.Sleep(1000);
                    m_cereproc_frenchnam.Click();
                }
               
            }
            else if (ngonngu == "Japanese")

            {
                m_cereproc_japan.Click();

            }
        }
        public string getURLMp3_Voice_cereproc(string _urlvoicecu, string text)
        {
            string ex = _urlvoicecu;
            try
            {
                Thread.Sleep(2000);
                m_cereproc_text.Clear();
                m_cereproc_text.SendKeys(text);
                Thread.Sleep(3000);

               

                int kiemtraclick = 0;
                switch (kiemtraclick)
                {
                    case 0:             // label case 1
                        System.Threading.Thread.Sleep(2000);
                        goto case 1;
                        break;
                    case 1:
                        try
                        {
                            if (SeleniumGetMeThor.GetTextClass(m_cereproc_from) == "voice-demo-form flex mfs mfs-enabled")
                            {
                                btn_cereproc_listen.Click();
                            }
                            else
                            {
                                goto case 0;
                            }
                        }
                        catch { goto case 0; }
                        break;

                }


                Thread.Sleep(1000);
                int kiemtra = 0;
                switch (kiemtra)
                {
                    case 0:             // label case 1
                        System.Threading.Thread.Sleep(2000);
                        goto case 1;
                        break;
                    case 1:
                        try
                        {
                            ex = SeleniumGetMeThor.GetTextLink(link_cereproc);
                            if (ex != _urlvoicecu)
                            {
                                return ex;
                            }
                            else
                            {
                                goto case 0;
                            }
                        }
                        catch { goto case 0; }
                        break;

                }

                return ex;
            }
            catch
            {

            }
            return ex;
        }

        #endregion



        #region // lay voice o trang : https://wideo.co/text-to-speech/

        [FindsBy(How = How.XPath, Using = "//textarea")]
        public IWebElement m_textwideo;      
        [FindsBy(How = How.CssSelector, Using = "MuiSelect-root MuiSelect-select MuiInputBase-input MuiInput-input MuiInputBase-inputSelect")]
        public IWebElement m_chonngonnguwideo;  
        [FindsBy(How = How.XPath, Using = "/html/body/div/div/div[3]/div[1]/button/span[1]")]
        public IWebElement m_listenwideo;
        [FindsBy(How = How.Id, Using = "audio-src")]
        public IWebElement m_linkwideo;
        

        public string getURLMp3_Wideo(string _urlvoicecu,  string voice,string text)
        {
            string ex = _urlvoicecu;
            SeleniumSetMeThor.SelectDropDownVaules(m_chonngonnguwideo, voice);
            m_textwideo.Clear();
            m_textwideo.SendKeys(text);
            Thread.Sleep(1000);
            m_listenwideo.Click();
            int kiemtra = 0;
            switch (kiemtra)
            {
                case 0:             // label case 1
                    System.Threading.Thread.Sleep(2000);
                    goto case 1;
                    break;
                case 1:
                    try
                    {
                        ex = SeleniumGetMeThor.GetTextLink(m_linkwideo);
                        if (ex != _urlvoicecu)
                        {
                            System.Threading.Thread.Sleep(5000);
                            return ex;
                        }
                        else
                        {
                            goto case 0;
                        }
                    }
                    catch { goto case 0; }
                    break;

            }
            return ex;
        }
        #endregion


        #region // lấy voice ở trang : https://www.linguatec.de/en/voice-reader-studio-15-test/
        [FindsBy(How = How.Id, Using = "vr_LanguageSelector")]
        public IWebElement m_ling_ngonngu;
        [FindsBy(How = How.Id, Using = "vr_VoiceSelector")]
        public IWebElement m_ling_voice;
        [FindsBy(How = How.Id, Using = "vr_SampleText")]
        public IWebElement m_ling_text;
        [FindsBy(How = How.Id, Using = "vr_ReadButton")]
        public IWebElement btn_ling_listen;
        [FindsBy(How = How.Id, Using = "vr_PlayButton")]
        public IWebElement btn_ling_listen2;
        [FindsBy(How = How.Id, Using = "vr_PauseButton")]
        public IWebElement btn_ling_Pause;
        
        [FindsBy(How = How.XPath, Using = "//audio")]
        public IWebElement ling_link;
        public string getURLMp3_Ling(string _urlvoicecu, string ngonngu, string voice,string text)
        {
            string ex = _urlvoicecu;
            SeleniumSetMeThor.SelectDropDown(m_ling_ngonngu, ngonngu);
            SeleniumSetMeThor.SelectDropDown(m_ling_voice, voice);

            m_ling_text.Clear();
            m_ling_text.SendKeys(text);
            Thread.Sleep(1000);
            try {
                btn_ling_Pause.Click();
            }
            catch { }
            try
            {
                if (_urlvoicecu == "")
                { btn_ling_listen.Click(); }
                else
                {
                    btn_ling_listen2.Click();
                }
            }
            catch { btn_ling_listen.Click(); }
            int kiemtra = 0;
            switch (kiemtra)
            {
                case 0:             // label case 1
                    System.Threading.Thread.Sleep(5000);
                    goto case 1;
                    break;
                case 1:
                    try
                    {
                        ex = SeleniumGetMeThor.GetTextLink(ling_link);
                        if (ex != _urlvoicecu)
                        {
                            System.Threading.Thread.Sleep(1000);
                            return ex;
                        }
                        else
                        {
                            goto case 0;
                        }
                    }
                    catch { goto case 0; }
                    break;

            }
            return ex;
        }

        #endregion


        #region // lấy voice ở trang : https://www.sestek.com/text-to-speech/tts-demo/
        [FindsBy(How = How.Id, Using = "ddlVoices")]
        public IWebElement m_sestek_ngonngu;     
        [FindsBy(How = How.Id, Using = "TextBox1")]
        public IWebElement m_sestek_text;
        [FindsBy(How = How.Id, Using = "vr_PlayButton")]
        public IWebElement btn_sestek_listen;
        [FindsBy(How = How.XPath, Using = "/html/body/form/div[4]/div/audio/source")]
        public IWebElement sestek_link;
        public string getURLMp3_sestek(string _urlvoicecu, string ngonngu,string text)
        {
            string ex = _urlvoicecu;
            SeleniumSetMeThor.SelectDropDown(m_sestek_ngonngu, ngonngu);

            m_sestek_text.Clear();
            m_sestek_text.SendKeys(text);
            Thread.Sleep(1000);
            btn_sestek_listen.Click();
            int kiemtra = 0;
            switch (kiemtra)
            {
                case 0:             // label case 1
                    System.Threading.Thread.Sleep(2000);
                    goto case 1;
                    break;
                case 1:
                    try
                    {
                        ex = SeleniumGetMeThor.GetTextLink(sestek_link);
                        if (ex != _urlvoicecu)
                        {
                            System.Threading.Thread.Sleep(5000);
                            return "https://ttsdemo.sestek.com" + ex;
                        }
                        else
                        {
                            goto case 0;
                        }
                    }
                    catch { goto case 0; }
                    break;

            }
            return ex;
        }



        #endregion


        #region // lấy voice ở trang https://tts.cool/

        #region // lựa chọn service lấy
        
        [FindsBy(How = How.XPath, Using = "/html/body/section/div/div[2]/div[1]/ul/li[3]/a")]
        public IWebElement m_Polly;
        [FindsBy(How = How.XPath, Using = "/html/body/section/div/div[2]/div[1]/ul/li[4]/a")]
        public IWebElement m_CereProc;
        [FindsBy(How = How.XPath, Using = "/html/body/section/div/div[2]/div[1]/ul/li[5]/a")]
        public IWebElement m_IBMWatson;
        [FindsBy(How = How.XPath, Using = "/html/body/section/div/div[2]/div[1]/ul/li[6]/a")]
        public IWebElement m_Acapela;
        [FindsBy(How = How.XPath, Using = "/html/body/section/div/div[2]/div[1]/ul/li[7]/a")]
        public IWebElement m_Oddcast;
        [FindsBy(How = How.XPath, Using = "/html/body/section/div/div[2]/div[1]/ul/li[8]/a")]
        public IWebElement m_ReadSpeaker;
        [FindsBy(How = How.XPath, Using = "/html/body/section/div/div[2]/div[1]/ul/li[9]/a")]
        public IWebElement m_GoogleTranslate;
        [FindsBy(How = How.XPath, Using = "/html/body/section/div/div[2]/div[1]/ul/li[6]/a")]
        public IWebElement m_iSpeech;
        public void select_Service(string ten)
        {
            
            if (ten == "Polly")
            {
                m_Polly.Click();
            }
            else if (ten == "CereProc")
            {
                m_CereProc.Click();
            }
            if (ten == "IBMWatson")
            {
                m_IBMWatson.Click();
            }
            if (ten == "Acapela")
            {
                m_Acapela.Click();
            }
            if (ten == "Oddcast")
            {
                m_Oddcast.Click();
            }
            if (ten == "ReadSpeaker")
            {
                m_ReadSpeaker.Click();
            }
            if (ten == "GoogleTranslate")
            {
                m_GoogleTranslate.Click();
            }
            if (ten == "iSpeech")
            {
                m_iSpeech.Click();
            }
            Thread.Sleep(2000);
        }

        #endregion
        #region // lựa chọn giới tính
        [FindsBy(How = How.XPath, Using = "/html/body/section/div/div[2]/div[2]/ul/li[3]/a")]
        public IWebElement m_Male;
        [FindsBy(How = How.XPath, Using = "/html/body/section/div/div[2]/div[2]/ul/li[4]/a")]
        public IWebElement m_Female;
        public void select_Sex(string sex)
        {
            

            if (sex == "Male")
            {
                m_Male.Click();
            }
            else if (sex == "Female")
            {
                m_Female.Click();
            }           
            Thread.Sleep(2000);
        }

        #endregion
        #region // lựa chọn ngôn ngữ
        [FindsBy(How = How.Id, Using = "toggleLangs")]
        public IWebElement m_showngonngu;

        [FindsBy(How = How.XPath, Using = "/html/body/section/div/div[2]/div[3]/button[12]")]
        public IWebElement m_englist_tts;
        [FindsBy(How = How.XPath, Using = "/html/body/section/div/div[2]/div[3]/button[35]")]
        public IWebElement m_Korean_tts;
        [FindsBy(How = How.XPath, Using = "/html/body/section/div/div[2]/div[3]/button[7]")]
        public IWebElement m_Chinese_tts;
        [FindsBy(How = How.XPath, Using = "/html/body/section/div/div[2]/div[3]/button[32]")]
        public IWebElement m_Japanese_tts;
        [FindsBy(How = How.XPath, Using = "/html/body/section/div/div[2]/div[3]/button[24]")]
        public IWebElement m_German_tts;
        [FindsBy(How = How.XPath, Using = "/html/body/section/div/div[2]/div[3]/button[48]")]
        public IWebElement m_Spanish_tts;
        [FindsBy(How = How.XPath, Using = "/html/body/section/div/div[2]/div[3]/button[53]")]
        public IWebElement m_Thai_tts;
        [FindsBy(How = How.XPath, Using = "/html/body/section/div/div[2]/div[3]/button[45]")]
        public IWebElement m_Russian_tts;
        [FindsBy(How = How.XPath, Using = "/html/body/section/div/div[2]/div[3]/button[20]")]
        public IWebElement m_French_tts;
        [FindsBy(How = How.XPath, Using = "/html/body/section/div/div[2]/div[3]/button[31]")]
        public IWebElement m_Italian_tts;
        #region // chọn voice
        [FindsBy(How = How.XPath, Using = "//button[@class='button button-voice is-light is-rounded']")]
        public IWebElement btnvoice;
        #endregion
        public void selectV2_TTSCool(string ngonngu)
        {
            m_showngonngu.Click();
            Thread.Sleep(2000);          
            if (ngonngu == "English")
            {
                m_englist_tts.Click();
            }
            else if (ngonngu == "Korean")
            {
                m_Korean_tts.Click();               
            }
            else if (ngonngu == "Chinese")
            {
                m_Chinese_tts.Click();              
            }
            else if (ngonngu == "Japanese")
            {
                m_Japanese_tts.Click();           
            }
            else if (ngonngu == "German")
            {
                m_German_tts.Click();
            }
            else if (ngonngu == "Spanish")
            {
                m_Spanish_tts.Click();               
            }
            else if (ngonngu == "Thai")
            {
                m_Thai_tts.Click();
            }
            else if (ngonngu == "Russian")
            {
                m_Russian_tts.Click();
            }
            else if (ngonngu == "French")
            {
                m_French_tts.Click();
            }
            else if (ngonngu == "Italian")
            {
                m_Italian_tts.Click();
            }
            Thread.Sleep(1000);
            btnvoice.Click();
        }

        #endregion

      
        [FindsBy(How = How.Id, Using = "text")]
        public IWebElement txt_ttscool;
        [FindsBy(How = How.Id, Using = "playbutton")]
        public IWebElement btnSayIt;
        [FindsBy(How = How.XPath, Using = "//audio")]
        public IWebElement link_ttscool;

        public string getURL_TTSCool(string _urlvoicecu, string text)
        {
            string ex = _urlvoicecu;
            try
            {

                txt_ttscool.Clear();
                txt_ttscool.SendKeys(text);
                btnSayIt.Click();
                Thread.Sleep(3000);
                int kiemtra = 0;
                switch (kiemtra)
                {
                    case 0:             // label case 1
                        System.Threading.Thread.Sleep(3000);
                        goto case 1;
                        break;
                    case 1:
                        try
                        {
                            ex = SeleniumGetMeThor.GetTextLink(link_ttscool);
                            Thread.Sleep(4000);
                            if (ex != _urlvoicecu)
                            {
                                return ex;
                            }
                            else
                            {
                                goto case 0;
                            }
                        }
                        catch { goto case 0; }
                        break;

                }

                return ex;
            }
            catch
            {

            }
            return ex;
        }

        #endregion




    }

}
