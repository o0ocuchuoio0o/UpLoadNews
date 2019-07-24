using Gecko;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using System.Windows.Automation;

namespace UpLoadNews
{
    public partial class WebAutomationV2 : Form
    {
        public WebAutomationV2()
        {
            InitializeComponent();
            var path = Application.StartupPath + "\\Firefox";
            Xpcom.Initialize(path);
        }

        private void CheckUpload()
        {
            geckoupload.Navigate("https://www.youtube.com/upload?redirect_to_creator=true");
            geckoupload.DocumentCompleted += new EventHandler<Gecko.Events.GeckoDocumentCompletedEventArgs>(geckoupload_ClickUpload);
        }  
        void geckoupload_ClickUpload(object sender, Gecko.Events.GeckoDocumentCompletedEventArgs e)
        {
            geckoupload.DocumentCompleted -= geckoupload_ClickUpload;
            Application.DoEvents();
            click("//*[@id='start-upload-button-single']/button[1]");
            Application.DoEvents();
            Thread.Sleep(2000);
            sendText("C:\\Users\\Workstation Z400\\Downloads\\681.mp4");
            Application.DoEvents();
            Thread.Sleep(2000);
            sendKeys("{ENTER}");

        }
     
        private GeckoHtmlElement GetElement(GeckoWebBrowser wb, string xpath)
        {
            GeckoHtmlElement elm = null;
            if (xpath.StartsWith("/"))
            {
                if (xpath.Contains("@class") || xpath.Contains("@data-type"))
                {
                    var html = GetHtmlFromGeckoDocument(wb.Document);
                    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(html);

                    var node = doc.DocumentNode.SelectSingleNode(xpath);
                    if (node != null)
                    {
                        var currentXpath = "/" + node.XPath;
                        elm = (GeckoHtmlElement)wb.Document.EvaluateXPath(currentXpath).GetNodes().FirstOrDefault();
                    }
                }
                else
                {
                    elm = (GeckoHtmlElement)wb.Document.EvaluateXPath(xpath).GetNodes().FirstOrDefault();
                }
            }
            else
            {
                elm = (GeckoHtmlElement)wb.Document.GetElementById(xpath);
            }
            return elm;
        }
        private string GetHtmlFromGeckoDocument(GeckoDocument doc)
        {
            var result = string.Empty;

            GeckoHtmlElement element = null;
            var geckoDomElement = doc.DocumentElement;
            if (geckoDomElement is GeckoHtmlElement)
            {
                element = (GeckoHtmlElement)geckoDomElement;
                result = element.InnerHtml;
            }

            return result;
        }


        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern short VkKeyScan(char ch);
        private Keys ConvertCharToVirtualKey(char ch)
        {
            short vkey = VkKeyScan(ch);
            Keys retval = (Keys)(vkey & 0xff);
            int modifiers = vkey >> 8;
            if ((modifiers & 1) != 0) retval |= Keys.Shift;
            if ((modifiers & 2) != 0) retval |= Keys.Control;
            if ((modifiers & 4) != 0) retval |= Keys.Alt;
            return retval;
        }
        public void sendText(string text)
        {
            foreach (var item in text.ToArray())
            {
                if (item.ToString() == ":")
                {
                    MouseKeyboardLibrary.KeyboardSimulator.KeyDown(Keys.Shift);
                    MouseKeyboardLibrary.KeyboardSimulator.KeyDown(Keys.Oem1);
                    MouseKeyboardLibrary.KeyboardSimulator.KeyUp(Keys.Shift);
                }
                else
                {
                    var key = ConvertCharToVirtualKey(item);
                    MouseKeyboardLibrary.KeyboardSimulator.KeyDown(key);
                }
            }           
        }
        public void sendKeys(string key)
        {
            SendKeys.SendWait(key);
        }



        public void click(string xpath)
        {
            GeckoWebBrowser wb = (GeckoWebBrowser)geckoupload;
            if (wb != null)
            {
                if (xpath.StartsWith("/"))
                {
                    GeckoHtmlElement elm = GetElement(wb, xpath);
                    if (elm != null)
                    {
                        elm.Click();
                        elm.Focus();
                    }
                }
                else
                {
                  
                }
            }
        }

        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        private AutomationElement WaitForDialog(AutomationElement element, string dialogname, int timeout)
        {
            // note: this should be improved for error checking (timeouts, etc.)

            while (true)
            {
                if (timeout == 0)
                {
                    return null;
                }
                var openDialog = element.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Window));
                if (openDialog != null)
                    if (openDialog.Current.Name == dialogname)
                    {
                        return openDialog;
                    }
                Thread.Sleep(1000);
                timeout--;
            }
        }



        private void WebAutomationV2_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;

            CheckUpload();
        }
    }
}
