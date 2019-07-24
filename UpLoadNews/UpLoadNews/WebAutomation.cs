using Gecko;
using Gecko.DOM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UpLoadNews
{
    public partial class WebAutomation : Form
    {

        public WebAutomation(int flag)
        {           
            InitializeComponent();
            CallBackWinAppWebBrowser();
           // InitMouseKeyBoardEvent();
            var path = Application.StartupPath + "\\Firefox";
            Xpcom.Initialize(path);
            Flag = flag;

        }
        #region // cac xu ly
        private int m_Flag;
        private void Run_Upload()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(this.Run_Upload));
            }
            else
            {
                sleep(2, false);
                go("https://google.com");
                sleep(2, false);              
                go("https://www.youtube.com/upload?redirect_to_creator=true");
                //sleep(2, false);
                Application.DoEvents();
                click("appbar-guide-button");
                sleep(2, false);
                //bool statuslogin = false;
                //while (IsBreakSleep == true)
                //{
                //    string html = extract("upload-button-text", "text");
                //    if (html != "")
                //    {
                //        statuslogin = true;
                //    }
                //}

                click("/html/body/div[2]/div[4]/div/div[5]/div/div[4]/div[4]/div/div/div/button");
                sleep(5, false);
                sendText(@"C:\Users\Workstation Z400\Downloads\681.mp4");
                sleep(1, false);
                sendKeys("{ENTER}");
                Thread.Yield();
            }
        }
        private void ThaoTac()
        {
            if(m_Flag==0)
            {
                sleep(2, true);
                go("https://google.com");
            }
            else if(m_Flag==1)
            {
                nsICookieManager CookieMan;
                CookieMan = Xpcom.GetService<nsICookieManager>("@mozilla.org/cookiemanager;1");
                CookieMan = Xpcom.QueryInterface<nsICookieManager>(CookieMan);
                CookieMan.RemoveAll();
            }
            else if(m_Flag==3)
            {
                new Thread(new ThreadStart(this.Run_Upload)).Start();               
                
            }
        }
        #endregion

        private bool IsStop = false;
        private TabPage currentTab = null;
        private WebBrowser wbMain;
        public string MaxWait = string.Empty;
        private bool IsBreakSleep = false;

        #region WebBrowser

        public void CallBackWinAppWebBrowser()
        {
            wbMain = new WebBrowser();
            //wbMain.ObjectForScripting = this;
            wbMain.ScriptErrorsSuppressed = true;

            wbMain.DocumentText = @"<html>
                                        <head>
                                            <script type='text/javascript'>
                                                var isAborted = false;

                                                function UnAbort() {isAborted = false; window.external.UnAbort();}
                                                function Abort() {isAborted = true; release(); window.external.Abort();}
                                                function CheckAbort() {if(isAborted == true) { window.external.Abort(); throw new Error('Aborted');} }

                                                /*var isAborted = false;
                                                function UnAbort() {isAborted = false;}
                                                function Abort() {isAborted = true;}
                                                function CheckAbort() {if(isAborted == true) throw new Error('Aborted');}*/

                                                function stringtoXML(data){ if (window.ActiveXObject){ var doc = new ActiveXObject('Microsoft.XMLDOM'); doc.async='false'; doc.loadXML(data); } else { var parser = new DOMParser(); var doc = parser.parseFromString(data,'text/xml'); }	return doc; }

                                                /* Open new tab */

                                                function release() { CheckAbort(); window.external.ReleaseMR();  }

                                                function countNodes(xpath) { CheckAbort(); return window.external.countNodes(xpath); } 

                                                function tabnew() { CheckAbort(); window.external.tabnew();}
                                                /* Close current tab  */
                                                function tabclose() { CheckAbort(); window.external.tabclose();}
                                                /* Close all tab  */
                                                function tabcloseall() { CheckAbort(); window.external.tabcloseall();}
                                                /* Go to website by url or xpath  */
                                                function go(a) { CheckAbort(); window.external.go(a);}
                                                
                                                function goWithProxy(url, proxyUrl){ CheckAbort(); window.external.goWithProxy(url, proxyUrl); }

                                                function back() { CheckAbort(); window.external.Back(); }
                                                function next() { CheckAbort(); window.external.Next(); }
                                                function reload() { CheckAbort(); window.external.Reload(); }
                                                function stop() { CheckAbort(); window.external.Stop(); }

                                                /* Sleep with a = miliseconds to sleep, b = true if wait until browser loading finished, b = false wait until timeout miliseconds  */
                                                function sleep(a, b) { CheckAbort(); window.external.sleep(a,b);}
                                                /* Quit application  */
                                                function exit() { CheckAbort(); window.external.exit();}
                                                /* Click by xpath  */
                                                function click(a) { CheckAbort(); window.external.click(a);}
                                                /* write a log to preview, a = content of log  */
                                                function log(a) { CheckAbort(); window.external.log(a);}
                                                /* clear log on the preview  */
                                                function clearlog() { CheckAbort(); window.external.clearlog();}
                                                /* extract data from xpath  */
                                                //function extract(a) {CheckAbort(); return window.external.extract(a);}
                                                function extract(xpath, type) {CheckAbort(); return window.external.extract(xpath, type);}

                                                function extractUntil(xpath, type){ CheckAbort(); return window.external.extractUntil(xpath, type); }

                                                function filliframe(title, value) { CheckAbort(); window.external.filliframe(title, value); }                                                

                                                /* fill xpath by value, a = xpath, b = value  */
                                                function fill(a,b) { CheckAbort(); window.external.fill(a,b);}
                                                /* convert extract string to object  */

                                                /*function filldropdown(a, b) { CheckAbort(); window.external.filldropdown(a, b); }*/
                                                function filldropdown(xpath, value) { CheckAbort(); window.external.filldropdown(xpath, value); }
                                                function toObject(a) {CheckAbort(); var wrapper= document.createElement('div'); wrapper.innerHTML= a; return wrapper;}
                                                function blockFlash(isBlock) { CheckAbort(); window.external.BlockFlash(isBlock); }

                                                /* browser get all link in the area of xpath, it will stop until program go all of link , a = xpath */
                                                function browser(a) {CheckAbort(); window.external.browser(a);}
                                                /* reset list website to unread so program can go back and browser continue */
                                                function resetlistwebsite() {CheckAbort(); window.external.ResetListWebsite();}
                                                /* take a snapshot from current website on current tab, a = location to save a snapshot */

                                                function takesnapshot(a) {CheckAbort(); window.external.TakeSnapshot(a);}
                                                /* reconigze text of image from url, a = url of image  */
                                                function imageToText(xpath, language) { CheckAbort(); return window.external.imgToText(xpath, language);}
                                                /* set value to file upload (not work in ie)  */
                                                function fileupload(a,b){CheckAbort(); window.external.FileUpload(a,b);}

                                                /* create folder, a = location  */
                                                function createfolder(a) { CheckAbort(); window.external.createfolder(a);}
                                                /* download file from url, a = url to download, b = location where file located  */
                                                function download(a,b) {CheckAbort(); window.external.download(a,b);}

                                                function downloadWebsite(url) { CheckAbort(); return window.external.DownloadWebsite(url); } 

                                                function getfiles(a) { CheckAbort(); return window.external.getfiles(a); }
                                                function getfolders(a) { CheckAbort(); return window.external.getfolders(a); }

                                                /* read a file, a = location of file  */
                                                function read(a) { CheckAbort(); return window.external.read(a);}
                                                /* save file, a = content of file, b = location of file to save, c = is file override (true: fill will be override, false: not override)  */
                                                function save(a,b,c) { CheckAbort(); return window.external.save(a,b,c);}
                                                /* remove a file, a = location of file will be removed */
                                                function remove(a) { CheckAbort(); window.external.remove(a);}
                                                function removefolder(a) {CheckAbort(); window.external.removefolder(a);}
                                                
                                                function copyfolder(a,b,c) {CheckAbort(); window.external.copyFolder(a,b,c);}
                                                function copyfile(a,b,c) {CheckAbort(); window.external.copyFile(a,b,c);}

                                                function replacetextinfile(a, b, c) { CheckAbort(); window.external.replaceTextinFile(a,b,c); }

                                                function explorer(a) { CheckAbort(); window.external.explorer(a); }

                                                /* run code from string, a = code to run  */
                                                function excute(a) { CheckAbort(); window.external.excute(a);}

                                                function logoff() { CheckAbort(); window.external.logoff();} 
                                                function lockworkstation() {CheckAbort(); window.external.lockworkstation();} 
                                                function forcelogoff() { CheckAbort(); window.external.forcelogoff();} 
                                                function reboot() { CheckAbort(); window.external.reboot();} 
                                                function shutdown() { CheckAbort(); window.external.shutdown();} 
                                                function hibernate() { CheckAbort(); window.external.hibernate();} 
                                                function standby() { CheckAbort(); window.external.standby();} 


                                                /* run application, a = location of application */
                                                function runcommand(path, parameters) { CheckAbort(); window.external.runcommand(path, parameters); }

                                                function createtask(a,b,c,d,e,f) { CheckAbort(); window.external.createtask(a,b,c,d,e,f); }
                                                function removetask(a) { CheckAbort(); window.external.removetask(a);}

                                                function generatekeys() { CheckAbort(); window.external.generatekeys();}
                                                function encrypt(a, b) { CheckAbort(); return window.external.encrypt(a, b);}
                                                function decrypt(a, b) { CheckAbort(); return window.external.decrypt(a, b);}

                                                function showpicture(a,b) { CheckAbort(); window.external.showimage(a,b); }
                                                function savefilterimage(a) { CheckAbort(); window.external.savefilterimage(a); }

                                                function writetextimage(a, b) {CheckAbort(); window.external.writetextimage(a,b); } 

                                                function getcurrenturl() {CheckAbort(); return window.external.getCurrentUrl();}

                                                function scrollto(a) {CheckAbort(); window.external.scrollto(a); }

                                                function getheight() { CheckAbort(); return window.external.getheight(); }

                                                function gettitle() { CheckAbort(); return window.external.gettitle(); } 

                                                function getlinks(a) { CheckAbort(); return window.external.getlinks(a); } 

                                                function getCurrentContent() { CheckAbort(); return window.external.getCurrentContent(); } 

                                                function getCurrentPath() { CheckAbort(); return window.external.getCurrentPath(); } 

                                                function checkelement(a) { CheckAbort(); return window.external.checkelement(a);}

                                                function readCellExcel(a, b, c, d) { CheckAbort(); return window.external.readCellExcel(a,b,c,d);}

                                                function writeCellExcel(a, b, c, d) { CheckAbort(); window.external.writeCellExcel(a,b,c,d); }

                                                function replaceMsWord(a, b, c, d) { CheckAbort(); window.external.replaceMsWord(a,b,c,d); } 

                                                function loadHTML(a) { CheckAbort(); window.external.loadHTML(a); }" +

                                                "function textToJSON(a) { CheckAbort(); var b = eval(\"(\" + window.external.textToJSON(a) + \")\"); return b; }" +

                                                @"function getCurrentLogin() { return textToJSON(window.external.getCurrentUser());}

                                                function login(a, b) { return window.external.login(a,b); }

                                                function register(a, b, c, d) { return window.external.register(a, b, c, d);}

                                                function getAccount(a) { CheckAbort(); var b = window.external.GetAccount(a); if(b == '') return ''; else return textToJSON(b); }

                                                function captchaborder(a,b) { CheckAbort(); window.external.CaptchaBorder(a,b); } 

                                                function saveImageFromElement(a,b) { CheckAbort(); window.external.SaveImageFromElement(a,b);}

                                                function getControlText(a,b,c) { CheckAbort(); return window.external.GetControlText(a,b,c); }

                                                function setControlText(a,b,c,d) { CheckAbort(); window.external.SetControlText(a,b,c,d); }

                                                function clickControl(a,b,c) { CheckAbort(); window.external.ClickControl(a,b,c); } 

                                                function getCurrentMouseX() { CheckAbort(); return window.external.GetCurrentMouseX(); } 

                                                function getCurrentMouseY() { CheckAbort(); return window.external.GetCurrentMouseY(); } 

                                                function MouseDown(a,b) { CheckAbort(); window.external.Mouse_Down(a,b); }

                                                function MouseUp(a,b) { CheckAbort(); window.external.Mouse_Up(a,b); }

                                                function MouseClick(a,b) { CheckAbort(); window.external.Mouse_Click(a,b); }

                                                function MouseDoubleClick(a,b) { CheckAbort(); window.external.Mouse_Double_Click(a,b); }

                                                function MouseMove(a,b,c,d) {CheckAbort(); window.external.Mouse_Show(a,b,c,d); }

                                                function MouseWheel(a,b) { CheckAbort(); window.external.Mouse_Wheel(a,b); }

                                                function KeyDown(a,b) { CheckAbort(); window.external.Key_Down(a,b); }

                                                function KeyUp(a,b) { CheckAbort(); window.external.Key_Up(a,b); }

                                                function sendText(a) { CheckAbort(); window.external.sendText(a); }

                                                function Reload() { CheckAbort(); window.external.Reload(); }

                                                function sendEmail(name, email, subject, content) { CheckAbort(); return window.external.sendEmail(name, email, subject, content); }" +

                                                "function getAccountBy(name) { CheckAbort(); var a = window.external.GetAccountBy(name); if(a != '') { return eval(\"(\" + a + \")\"); } else { return ''; } }" +

                                                @"function getDatabases(name) { CheckAbort(); return window.external.GetDatabases(name); } 

                                                function getTables(name, dbName) { CheckAbort(); return window.external.GetTables(name, dbName); }

                                                function getColumns(name, dbName, table) { CheckAbort(); return window.external.GetColumns(name, dbName, table); }

                                                function getRows(name, dbName, sql) { CheckAbort(); return window.external.GetRows(name, dbName, sql); }

                                                function excuteQuery(name, dbName, sql) { CheckAbort(); return window.external.ExcuteQuery(name, dbName, sql); } 

                                                function removeStopWords(text) { CheckAbort(); return window.external.RemoveStopWords(text); }

                                                function addElement(path, node1, node2, text) { CheckAbort(); return window.external.AddElement(path, node1, node2, text); }

                                                function checkXmlElement(path, node, text) { CheckAbort(); return window.external.CheckXmlElement(path, node, text); }

                                                function getXmlElement(path, node) { CheckAbort(); return window.external.GetXmlElement(path, node); }

                                                function getParentElement(path, node, text) { CheckAbort(); return window.external.GetParentElement(path, node, text); }
                                                
                                                function extractbyRegularExpression(pattern, groupName) { CheckAbort(); return window.external.ExtractUsingRegularExpression(pattern, groupName); }

                                                function addToDownload(fileName, url, folder) { CheckAbort(); return window.external.AddToDownload(fileName, url, folder); }

                                                function startDownload() { CheckAbort(); return window.external.StartDownload(); }

                                                function hide() { CheckAbort(); return window.external.MinimizeWindow(); }

                                                function sendKeys(key) { CheckAbort(); window.external.sendKeys(key); }

                                            </script>
                                        </head>
                                        <body>
                                            
                                        </body>
                                    </html>";
            this.Controls.Add(wbMain);
        }

        void ExcuteJSCodeWebBrowser(string code)
        {
            wbMain.Document.InvokeScript("UnAbort");
            object obj = wbMain.Document.InvokeScript("eval", new object[] { code });
        }

        private object GetCurrentWB()
        {
            if (tabMain.SelectedTab != null)
            {
                if (tabMain.SelectedTab.Controls.Count > 0)
                {
                    Control ctr = tabMain.SelectedTab.Controls[0];
                    if (ctr != null)
                    {
                        return ctr as object;
                    }
                }
            }
            return null;
        }

        void GoWebBrowser(string url)
        {
            if (String.IsNullOrEmpty(url)) return;
            if (url.Equals("about:blank")) return;

            GeckoWebBrowser wbBrowser = new GeckoWebBrowser();

            wbBrowser.ProgressChanged += wbBrowser_ProgressChanged;
            wbBrowser.Navigated += wbBrowser_Navigated;
            wbBrowser.DocumentCompleted += new EventHandler<Gecko.Events.GeckoDocumentCompletedEventArgs>(wbBrowser_DocumentCompleted);
          //  wbBrowser.DocumentCompleted += wbBrowser_DocumentCompleted;
          //  wbBrowser.CanGoBackChanged += wbBrowser_CanGoBackChanged;
          //  wbBrowser.CanGoForwardChanged += wbBrowser_CanGoForwardChanged;
            wbBrowser.ShowContextMenu += new EventHandler<GeckoContextMenuEventArgs>(wbBrowser_ShowContextMenu);
          //  wbBrowser.DomContextMenu += wbBrowser_DomContextMenu;
            wbBrowser.NoDefaultContextMenu = true;

            currentTab.Controls.Add(wbBrowser);
            wbBrowser.Dock = DockStyle.Fill;
            wbBrowser.Navigate(url);
        }

        void wbBrowser_ProgressChanged(object sender, GeckoProgressEventArgs e)
        {
            progressbar.Maximum = (int)e.MaximumProgress;
            var currentProgress = (int)e.CurrentProgress;
            if (currentProgress <= progressbar.Maximum)
                progressbar.Value = (int)e.CurrentProgress;
        }
        
        void wbBrowser_Navigated(object sender, GeckoNavigatedEventArgs e)
        {
            string url = string.Empty;
            url = ((GeckoWebBrowser)sender).Url.ToString();
            if (url != "about:blank")
                tbxAddress.Text = url;
        }

        void wbBrowser_DocumentCompleted(object sender, Gecko.Events.GeckoDocumentCompletedEventArgs e)
        {
           // 


            if (e.Uri.AbsolutePath != (sender as GeckoWebBrowser).Url.AbsolutePath)
                return;

            GeckoWebBrowser wbBrowser = (GeckoWebBrowser)sender;          
           // wbBrowser.DocumentCompleted -= wbBrowser_DocumentCompleted;
            string title = wbBrowser.DocumentTitle;
            currentTab.Text = (title.Length > 10 ? title.Substring(0, 10) + "..." : title);
            tbxAddress.Text = wbBrowser.Url.ToString();

            IsBreakSleep = true;
        }

        void wbBrowser_ShowContextMenu(object sender, GeckoContextMenuEventArgs e)
        {
            //contextMenuBrowser.Show(Cursor.Position);

            //CurrentMouseX = Cursor.Position.X;
            //CurrentMouseY = Cursor.Position.Y;

            /*GeckoWebBrowser wb = (GeckoWebBrowser)GetCurrentWB();
            if (wb != null)
            {
                htmlElm = (GeckoHtmlElement)wb.Document.ElementFromPoint(Cursor.Position.X, Cursor.Position.Y);
                if (htmlElm != null)
                {
                    if (htmlElm.GetType().Name == "GeckoIFrameElement")
                    {
                        var iframe = (GeckoIFrameElement)wb.Document.GetElementById(htmlElm.Id);
                        if (iframe != null)
                        {
                            var contentDocument = iframe.ContentWindow.Document;
                            if (contentDocument != null)
                                htmlElm = (GeckoHtmlElement)contentDocument.ElementFromPoint(Cursor.Position.X, Cursor.Position.Y);
                        }
                    }
                }
            }*/
        }

        private int CurrentMouseX = 0;
        private int CurrentMouseY = 0;       

        void GoWebBrowserByXpath(string xpath)
        {
            GeckoWebBrowser wb = (GeckoWebBrowser)GetCurrentWB();
            if (wb != null)
            {
                GeckoHtmlElement elm = GetCompleteElementByXPath(wb, xpath);
                if (elm != null)
                {
                    UpdateUrlAbsolute(wb.Document, elm);
                    string url = extractData(elm, "href");
                    if (!string.IsNullOrEmpty(url))
                        wb.Navigate(url);
                }
            }
        }

        void NextWebBrowser()
        {
            GeckoWebBrowser wb = (GeckoWebBrowser)GetCurrentWB();
            if (wb != null)
            {
                wb.GoForward();
            }
        }

        void BackWebBrowser()
        {
            GeckoWebBrowser wb = (GeckoWebBrowser)GetCurrentWB();
            if (wb != null)
            {
                wb.GoBack();
            }
        }

        void ReloadWebBrowser()
        {
            GeckoWebBrowser wb = (GeckoWebBrowser)GetCurrentWB();
            if (wb != null)
            {
                wb.Refresh();
            }
        }

        void StopWebBrowser()
        {
            GeckoWebBrowser wb = (GeckoWebBrowser)GetCurrentWB();
            if (wb != null)
            {
                wb.Stop();
            }
        }

        void TabSelectedWebBrowser()
        {
            if (tabMain.TabCount > 0)
            {
                GeckoWebBrowser wb = (GeckoWebBrowser)GetCurrentWB();
                if (wb != null)
                {
                    tbxAddress.Text = wb.Url.ToString();
                    string title = wb.DocumentTitle;
                    currentTab.Text = (title.Length > 10 ? title.Substring(0, 10) + "..." : title);
                    this.Text = title;
                }
            }
        }

        private GeckoHtmlElement GetElementByXpath(GeckoDocument doc, string xpath)
        {
            if (doc == null) return null;

            xpath = xpath.Replace("/html/", "");
            GeckoElementCollection eleColec = doc.GetElementsByTagName("html"); if (eleColec.Length == 0) return null;
            GeckoHtmlElement ele = eleColec[0];
            string[] tagList = xpath.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string tag in tagList)
            {
                System.Text.RegularExpressions.Match mat = System.Text.RegularExpressions.Regex.Match(tag, "(?<tag>.+)\\[@id='(?<id>.+)'\\]");
                if (mat.Success == true)
                {
                    string id = mat.Groups["id"].Value;
                    GeckoHtmlElement tmpEle = doc.GetHtmlElementById(id);
                    if (tmpEle != null) ele = tmpEle;
                    else
                    {
                        ele = null;
                        break;
                    }
                }
                else
                {
                    mat = System.Text.RegularExpressions.Regex.Match(tag, "(?<tag>.+)\\[(?<ind>[0-9]+)\\]");
                    if (mat.Success == false)
                    {
                        GeckoHtmlElement tmpEle = null;
                        foreach (GeckoNode it in ele.ChildNodes)
                        {
                            if (it.NodeName.ToLower() == tag)
                            {
                                tmpEle = (GeckoHtmlElement)it;
                                break;
                            }
                        }
                        if (tmpEle != null) ele = tmpEle;
                        else
                        {
                            ele = null;
                            break;
                        }
                    }
                    else
                    {
                        string tagName = mat.Groups["tag"].Value;
                        int ind = int.Parse(mat.Groups["ind"].Value);
                        int count = 0;
                        GeckoHtmlElement tmpEle = null;
                        foreach (GeckoNode it in ele.ChildNodes)
                        {
                            if (it.NodeName.ToLower() == tagName)
                            {
                                count++;
                                if (ind == count)
                                {
                                    tmpEle = (GeckoHtmlElement)it;
                                    break;
                                }
                            }
                        }
                        if (tmpEle != null) ele = tmpEle;
                        else
                        {
                            ele = null;
                            break;
                        }
                    }
                }
            }

            return ele;
        }

        private string GetXpath(GeckoNode node)
        {
            if (node == null)
                return string.Empty;

            if (node.NodeType == NodeType.Attribute)
            {
                return String.Format("{0}/@{1}", GetXpath(((GeckoAttribute)node).OwnerDocument), node.LocalName);
            }
            if (node.ParentNode == null)
            {
                return "";
            }
            string elementId = ((GeckoHtmlElement)node).Id;
            if (!String.IsNullOrEmpty(elementId))
            {
                return String.Format("//*[@id='{0}']", elementId);
            }

            int indexInParent = 1;
            GeckoNode siblingNode = node.PreviousSibling;

            while (siblingNode != null)
            {

                if (siblingNode.LocalName == node.LocalName)
                {
                    indexInParent++;
                }
                siblingNode = siblingNode.PreviousSibling;
            }

            return String.Format("{0}/{1}[{2}]", GetXpath(node.ParentNode), node.LocalName, indexInParent);
        }

        private int GetXpathIndex(GeckoHtmlElement ele)
        {
            if (ele.Parent == null) return 0;
            int ind = 0, indEle = 0;
            string tagName = ele.TagName;
            GeckoNodeCollection elecol = ele.Parent.ChildNodes;
            foreach (GeckoNode it in elecol)
            {
                if (it.NodeName == tagName)
                {
                    ind++;
                    if (it.TextContent == ele.TextContent) indEle = ind;
                }
            }
            if (ind > 1) return indEle;
            return 0;
        }

        protected void UpdateUrlAbsolute(GeckoDocument doc, GeckoHtmlElement ele)
        {
            string link = doc.Url.GetLeftPart(UriPartial.Authority);

            var eleColec = ele.GetElementsByTagName("IMG");
            foreach (GeckoHtmlElement it in eleColec)
            {
                if (!it.GetAttribute("src").StartsWith("http://"))
                    it.SetAttribute("src", link + it.GetAttribute("src"));
            }
            eleColec = ele.GetElementsByTagName("A");
            foreach (GeckoHtmlElement it in eleColec)
            {
                if (!it.GetAttribute("href").StartsWith("http://"))
                    it.SetAttribute("href", link + it.GetAttribute("href"));
            }
        }

        private GeckoHtmlElement GetCompleteElementByXPath(GeckoWebBrowser wb, string xpath)
        {
            GeckoHtmlElement elm = GetElement(wb, xpath);

            int waitUntil = 0;
            int count = 0;

            int.TryParse(MaxWait, out waitUntil);

            while (elm == null)
            {
                //Stop when click Stop button
                if (IsStop) break;

                //It will stop when get the limit configuration
                if (count > waitUntil) break;

                elm = GetElement(wb, xpath);
                sleep(1, false);
                count++;
            }

            return elm;
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

        #endregion

        #region functions
        public void tabnew()
        {
            try
            {
                TabPage tab = new TabPage("new tab");
                tabMain.Controls.Add(tab);
                currentTab = tab;
                tabMain.SelectedTab = currentTab;
            }
            catch { }
        }
        nsIMemory _memoryService = null;
        public void go(string url)
        {
            if (currentTab == null)
            {
                tabnew();
            }

            //WebBrowser
            if (!url.StartsWith("/"))
            {
                if (currentTab.Controls.Count > 0)
                {
                    Control ctr = currentTab.Controls[0];
                    if (ctr != null)
                    {
                        var wb = (GeckoWebBrowser)ctr;
                        wb.Stop();
                        wb.ProgressChanged -= wbBrowser_ProgressChanged;
                        wb.Navigated -= wbBrowser_Navigated;
                        wb.DocumentCompleted -= wbBrowser_DocumentCompleted;
                        //wb.CanGoBackChanged -= wbBrowser_CanGoBackChanged;
                       // wb.CanGoForwardChanged -= wbBrowser_CanGoForwardChanged;
                        wb.ShowContextMenu -= new EventHandler<GeckoContextMenuEventArgs>(wbBrowser_ShowContextMenu);
                       // wb.DomContextMenu -= wbBrowser_DomContextMenu;
                        wb.Dispose();
                        wb = null;

                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                        if (_memoryService == null)
                        {
                            _memoryService = Xpcom.GetService<nsIMemory>("@mozilla.org/xpcom/memory-service;1");
                        }
                        _memoryService.HeapMinimize(false);
                    }
                    currentTab.Controls.Clear();
                }
                GoWebBrowser(url);
            }
            else
            {
                GoWebBrowserByXpath(url);
            }
        }

        public string extract(string xpath, string type)
        {
            string result = string.Empty;
            GeckoHtmlElement elm = null;

            GeckoWebBrowser wb = (GeckoWebBrowser)GetCurrentWB();
            if (wb != null)
            {
                elm = GetElement(wb, xpath);
                if (elm != null)
                    UpdateUrlAbsolute(wb.Document, elm);

                if (elm != null)
                {
                    switch (type)
                    {
                        case "html":
                            result = elm.OuterHtml;
                            break;
                        case "text":
                            if (elm.GetType().Name == "GeckoTextAreaElement")
                            {
                                result = ((GeckoTextAreaElement)elm).Value;
                            }
                            else
                            {
                                result = elm.TextContent.Trim();
                            }
                            break;
                        case "value":
                            result = ((GeckoInputElement)elm).Value;
                            break;
                        default:
                            result = extractData(elm, type);
                            break;
                    }
                }
            }

            return result;
        }

        public string extractUntil(string xpath, string type)
        {
            var result = string.Empty;

            GeckoHtmlElement elm = null;

            GeckoWebBrowser wb = (GeckoWebBrowser)GetCurrentWB();
            if (wb != null)
            {
                elm = GetCompleteElementByXPath(wb, xpath);
                if (elm != null)
                    UpdateUrlAbsolute(wb.Document, elm);

                if (elm != null)
                {
                    switch (type)
                    {
                        case "html":
                            result = elm.OuterHtml;
                            break;
                        case "text":
                            if (elm.GetType().Name == "GeckoTextAreaElement")
                            {
                                result = ((GeckoTextAreaElement)elm).Value;
                            }
                            else
                            {
                                result = elm.TextContent.Trim();
                            }
                            break;
                        default:
                            result = extractData(elm, type);
                            break;
                    }
                }
            }

            return result;
        }

        public void filliframe(string title, string value)
        {
            /*GeckoWebBrowser wb = (GeckoWebBrowser)GetCurrentWB();
            if (wb != null)
            {
                foreach (GeckoWindow ifr in wb.Window.Frames)
                {
                    if (ifr.Document.Title == title)
                    {
                        foreach (var item in ifr.Document.ChildNodes)
                        {
                            if (item.NodeName == "HTML")
                            {
                                foreach (var it in item.ChildNodes)
                                {
                                    if (it.NodeName == "BODY")
                                    {
                                        GeckoBodyElement elem = (GeckoBodyElement)it;
                                        elem.InnerHtml = value;
                                        elem.Focus();
                                    }
                                }                                
                                break;
                            }
                        }
                        break;
                    }
                }
            }*/
        }

        public void fill(string xpath, string value)
        {
            GeckoWebBrowser wb = (GeckoWebBrowser)GetCurrentWB();
            if (wb != null)
            {
                if (xpath.StartsWith("/"))
                {
                    GeckoHtmlElement elm = GetElement(wb, xpath);
                    if (elm != null)
                    {
                        switch (elm.TagName)
                        {
                            case "IFRAME":
                                /*foreach (GeckoWindow ifr in wb.Window.Frames)
                                {
                                    if (ifr.Document == elm.DOMElement)
                                    {
                                        ifr.Document.TextContent = value;
                                        break;
                                    }
                                }*/
                                break;
                            case "INPUT":
                                GeckoInputElement input = (GeckoInputElement)elm;
                                input.Value = value;
                                input.Focus();
                                break;
                            case "TEXTAREA":
                                GeckoTextAreaElement input1 = (GeckoTextAreaElement)elm;
                                input1.Value = value;
                                input1.Focus();
                                break;
                            default:
                                break;
                        }
                    }
                }
                else
                {
                    Byte[] bytes = Encoding.UTF32.GetBytes(value);
                    StringBuilder asAscii = new StringBuilder();
                    for (int idx = 0; idx < bytes.Length; idx += 4)
                    {
                        uint codepoint = BitConverter.ToUInt32(bytes, idx);
                        if (codepoint <= 127)
                            asAscii.Append(Convert.ToChar(codepoint));
                        else
                            asAscii.AppendFormat("\\u{0:x4}", codepoint);
                    }
                    /*var id = xpath;
                    using (AutoJSContext context = new AutoJSContext(wb.Window.JSContext))
                    {
                        context.EvaluateScript("document.getElementById('" + id + "').value = '" + asAscii.ToString() + "';");
                        context.EvaluateScript("document.getElementById('" + id + "').scrollIntoView();");
                    }*/
                }
            }

        }

        public void filldropdown(string xpath, string value)
        {
            GeckoWebBrowser wb = (GeckoWebBrowser)GetCurrentWB();
            if (wb != null)
            {
                if (xpath.StartsWith("/"))
                {
                    GeckoHtmlElement elm = GetElement(wb, xpath);
                    if (elm != null)
                    {
                        var dropdown = elm as GeckoSelectElement;
                        var length = dropdown.Options.Length;
                        var items = dropdown.Options;
                        for (var i = 0; i < length; i++)
                        {
                            var item = dropdown.Options.item((uint)i);
                            if (item.Text.ToUpper() == value.ToUpper())
                            {
                                item.SetAttribute("selected", "selected");
                            }
                            else
                            {
                                item.RemoveAttribute("selected");
                            }
                        }
                        elm.Focus();
                        //elm.SetAttribute("value", value);
                        //elm.SetAttribute("selectedIndex", value);
                        //elm.Focus();
                    }
                }
                else
                {
                    /*var id = xpath;
                    using (AutoJSContext context = new AutoJSContext(wb.Window.JSContext))
                    {
                        string javascript = string.Empty;
                        context.EvaluateScript("document.getElementById('" + id + "').selectedIndex = " + value + ";");
                        JQueryExecutor jquery = new JQueryExecutor(wb.Window);
                        jquery.ExecuteJQuery("$('#" + id + "').trigger('change');");
                        context.EvaluateScript("document.getElementById('" + id + "').scrollIntoView();");
                    }*/
                }
            }
        }

        public void click(string xpath)
        {
            GeckoWebBrowser wb = (GeckoWebBrowser)GetCurrentWB();
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
                    /*var id = xpath;
                    using (AutoJSContext context = new AutoJSContext(wb.Window.JSContext))
                    {
                        context.EvaluateScript("document.getElementById('" + id + "').click();");
                        context.EvaluateScript("document.getElementById('" + id + "').scrollIntoView();");
                    }*/
                }
            }
        }
        public void clickjs(string xpath)
        {
            GeckoWebBrowser wb = (GeckoWebBrowser)GetCurrentWB();
            GeckoHtmlElement link = (GeckoHtmlElement)wb.Document.GetElementsByClassName(xpath)[0].LastChild;
            link.Click();
        }
        public void sleep(int seconds, bool isBreakWhenWBCompleted)
        {
            IsBreakSleep = false;
            for (int i = 0; i < seconds * 10; i++)
            {
                if (IsStop == false)
                {
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(100);

                    toolStripStatus.Text = "Sleep: " + ((i + 1) * 100) + "/" + (seconds * 1000);
                    if (isBreakWhenWBCompleted && IsBreakSleep)
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
            toolStripStatus.Text = "";
        }
               

        public void createfolder(string path)
        {
            try
            {
                if (System.IO.Directory.Exists(path) == false)
                    System.IO.Directory.CreateDirectory(path);
            }
            catch { }
        }

        public string getfiles(string path)
        {
            string result = "";
            string r = "";

            string[] filePaths = Directory.GetFiles(path);

            try
            {
                foreach (string f in filePaths)
                {
                    r += f + ",";
                }
                if (!string.IsNullOrEmpty(r))
                {
                    result = r.Substring(0, r.Length - 1);
                }
                else
                {
                    result = r;
                }
            }
            catch { }

            return result;
        }

        public string getfolders(string path)
        {
            string result = "";
            string r = "";

            try
            {
                string[] directoryPaths = Directory.GetDirectories(path);

                foreach (string f in directoryPaths)
                {
                    r += f + ",";
                }
                if (!string.IsNullOrEmpty(r))
                {
                    result = r.Substring(0, r.Length - 1);
                }
                else
                {
                    result = r;
                }
            }
            catch { }

            return result;
        }

        public void download(string savePath, string url)
        {
            using (System.Net.WebClient wc = new System.Net.WebClient())
            {
                wc.Credentials = System.Net.CredentialCache.DefaultCredentials;
                wc.Proxy = null;
                wc.Headers.Add(System.Net.HttpRequestHeader.UserAgent, "anything");
                try
                {
                    Uri uri = new Uri(url);
                    wc.DownloadFileAsync(uri, savePath);
                }
                catch (Exception ex)
                {

                }
            }
        }

        public string read(string path)
        {
            string result = "";
            try
            {
                string[] list = System.IO.File.ReadAllLines(path);
                foreach (string l in list)
                {
                    result += l + "\n";
                }
            }
            catch { }
            return result;
        }

        public void save(string content, string path, bool isOverride)
        {
            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(path, isOverride))
                {
                    file.WriteLine(content);
                }
            }
            catch { }
        }

        public void remove(string path)
        {
            try
            {
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
            }
            catch { }
        }

        public void removefolder(string path)
        {
            try
            {
                if (System.IO.Directory.Exists(path))
                {
                    File.SetAttributes(path, FileAttributes.Normal);

                    string[] files = Directory.GetFiles(path);
                    string[] dirs = Directory.GetDirectories(path);

                    foreach (string file in files)
                    {
                        File.SetAttributes(file, FileAttributes.Normal);
                        File.Delete(file);
                    }

                    foreach (string dir in dirs)
                    {
                        removefolder(dir);
                    }

                    Directory.Delete(path, false);
                }
            }
            catch { }
        }

        public void copyFolder(string source, string target, bool copySubDirs)
        {
            DirectoryInfo dir = new DirectoryInfo(source);

            if (!dir.Exists)
            {
               // log("Source directory does not exist or could not be found: " + source);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            // If the destination directory doesn't exist, create it.
            if (!Directory.Exists(target))
            {
                Directory.CreateDirectory(target);
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(target, file.Name);
                if (File.Exists(temppath))
                    File.SetAttributes(temppath, FileAttributes.Normal);
                file.CopyTo(temppath, true);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(target, subdir.Name);
                    copyFolder(subdir.FullName, temppath, copySubDirs);
                }
            }
        }

        public void copyFile(string source, string target, bool isOverride)
        {
            if (File.Exists(target))
                File.SetAttributes(target, FileAttributes.Normal);

            FileInfo file = new FileInfo(source);
            file.CopyTo(target, isOverride);
        }

        public void replaceTextinFile(string path, string pattern, string value)
        {
            if (File.Exists(path))
                File.SetAttributes(path, FileAttributes.Normal);

            string text = File.ReadAllText(path);
            var regex = new Regex(pattern);
            if (regex.IsMatch(text))
            {
                text = text.Replace(regex.Match(text).Groups[0].Value, value);
                File.WriteAllText(path, text);
            }
        }

        public void excute(string script)
        {
            ExcuteJSCodeWebBrowser(script);
        }

        public void runcommand(string path, string parameters)
        {
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.WorkingDirectory = getCurrentPath();
                startInfo.FileName = path;
                startInfo.Arguments = parameters;
                //startInfo.RedirectStandardOutput = true;
                //startInfo.RedirectStandardError = true;
                //startInfo.UseShellExecute = false;
                //startInfo.CreateNoWindow = true;
                try
                {
                    Process p = Process.Start(startInfo);
                    p.WaitForExit();
                }
                catch { }
            }
            catch { }
        }

        public void reboot()
        {
            System.Diagnostics.Process.Start("shutdown.exe", "-r -t 0");
        }

        public void shutdown()
        {
            System.Diagnostics.Process.Start("shutdown", "/s /t 0");
        }

        public void hibernate()
        {
            Application.SetSuspendState(PowerState.Hibernate, true, true);
        }

        public void standby()
        {
            Application.SetSuspendState(PowerState.Suspend, true, true);
        }

    
        public string encrypt(string publicKey, string plainText)
        {
            System.Security.Cryptography.CspParameters cspParams = null;
            System.Security.Cryptography.RSACryptoServiceProvider rsaProvider = null;
            byte[] plainBytes = null;
            byte[] encryptedBytes = null;

            string result = "";
            try
            {
                cspParams = new System.Security.Cryptography.CspParameters();
                cspParams.ProviderType = 1;
                rsaProvider = new System.Security.Cryptography.RSACryptoServiceProvider(cspParams);

                rsaProvider.FromXmlString(publicKey);

                plainBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
                encryptedBytes = rsaProvider.Encrypt(plainBytes, false);
                result = Convert.ToBase64String(encryptedBytes);
            }
            catch (Exception ex) { }
            return result;
        }

        public string decrypt(string privateKey, string encrypted)
        {
            System.Security.Cryptography.CspParameters cspParams = null;
            System.Security.Cryptography.RSACryptoServiceProvider rsaProvider = null;
            byte[] encryptedBytes = null;
            byte[] plainBytes = null;

            string result = "";
            try
            {
                cspParams = new System.Security.Cryptography.CspParameters();
                cspParams.ProviderType = 1;
                rsaProvider = new System.Security.Cryptography.RSACryptoServiceProvider(cspParams);

                rsaProvider.FromXmlString(privateKey);

                encryptedBytes = Convert.FromBase64String(encrypted);
                plainBytes = rsaProvider.Decrypt(encryptedBytes, false);

                result = System.Text.Encoding.UTF8.GetString(plainBytes);
            }
            catch (Exception ex) { }
            return result;
        }

        public void TakeSnapshot(string location)
        {
            try
            {
                GeckoWebBrowser wbBrowser = (GeckoWebBrowser)GetCurrentWB();
                ImageCreator creator = new ImageCreator(wbBrowser);
                byte[] rs = creator.CanvasGetPngImage((uint)wbBrowser.Document.ActiveElement.ScrollWidth, (uint)wbBrowser.Document.ActiveElement.ScrollHeight);


                MemoryStream ms = new MemoryStream(rs);
                Image returnImage = Image.FromStream(ms);

                returnImage.Save(location);

            }
            catch { }
        }

        public string imgToText(string xpath, string language)
        {
            string data = string.Empty;
            string path = string.Empty;
            path = Application.StartupPath + "\\captcha\\image.png";
            bool isSaveSuccess = saveImage(xpath, path);

            if (isSaveSuccess)
            {
                string text = Application.StartupPath + "\\captcha\\output.txt";

                string param = "";
                if (language == "vie")
                {
                    param = "\"" + path + "\" \"" + Application.StartupPath + "\\captcha\\output" + "\" -l vie";
                }
                else
                {
                    param = "\"" + path + "\" \"" + Application.StartupPath + "\\captcha\\output" + "\" -l eng";
                }


                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo.FileName = Application.StartupPath + "\\tesseract.exe";
                process.StartInfo.Arguments = param;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                process.Start();
                process.WaitForExit();

                data = read(text).Replace("\n", "");

            }

            return data;
        }

        private bool saveImage(string xpath, string location)
        {
            bool result = false;
            try
            {
                GeckoWebBrowser wbBrowser = (GeckoWebBrowser)GetCurrentWB();
                if (wbBrowser != null)
                {
                    GeckoImageElement element = null;
                    if (xpath.StartsWith("/"))
                        element = (GeckoImageElement)wbBrowser.Document.EvaluateXPath(xpath).GetNodes().FirstOrDefault();
                    else
                        element = (GeckoImageElement)wbBrowser.Document.GetElementById(xpath);
                    GeckoSelection selection = wbBrowser.Window.Selection;
                    selection.SelectAllChildren(element);
                    wbBrowser.CopyImageContents();
                    if (Clipboard.ContainsImage())
                    {
                        Image img = Clipboard.GetImage();
                        img.Save(location, System.Drawing.Imaging.ImageFormat.Png);
                        result = true;
                    }
                }
            }
            catch { result = false; }

            return result;
        }
        // chi su dung task o che do .net 4.5 tro len
        //async Task PopulateInputFile(GeckoHtmlElement file, string location)
        //{
        //file.Focus();

        //// delay the execution of SendKey to let the Choose File dialog show up
        //var sendKeyTask = Task.Delay(500).ContinueWith((_) =>
        //{
        //    // this gets executed when the dialog is visible
        //    SendKeys.SendWait(location + "{ENTER}");
        //}, TaskScheduler.FromCurrentSynchronizationContext());

        //file.Click(); // this shows up the dialog

        //await sendKeyTask;

        //// delay continuation to let the Choose File dialog hide
        //await Task.Delay(500);
        // }

        //public async Task FileUpload(string xpath, string location)
        //{
        //GeckoWebBrowser wb = (GeckoWebBrowser)GetCurrentWB();
        //if (wb != null)
        //{
        //    var file = GetElement(wb, xpath);
        //    if (file != null)
        //    {
        //        file.Focus();
        //        await PopulateInputFile(file, location);
        //    }
        //}
        //}

        public void sendKeys(string key)
        {
            SendKeys.SendWait(key);
        }

        public string getCurrentUrl()
        {
            string url = string.Empty;
            GeckoWebBrowser wb = (GeckoWebBrowser)GetCurrentWB();
            if (wb != null)
            {
                url = wb.Url.ToString();
            }
            return url;
        }

        public void scrollto(int value)
        {

        }

        public int getheight()
        {
            int result = 0;



            return result;
        }

        public string gettitle()
        {
            string result = "";

            GeckoWebBrowser wb = (GeckoWebBrowser)GetCurrentWB();
            if (wb != null)
            {
                result = wb.DocumentTitle;
            }

            return result;
        }

        public bool checkelement(string xpath)
        {
            bool result = false;



            return result;
        }

        public string getCurrentContent()
        {
            string result = "";

            GeckoWebBrowser wb = (GeckoWebBrowser)GetCurrentWB();
            if (wb != null)
            {
                result = wb.Document.Body.InnerHtml;
            }

            return result;
        }

        public string getCurrentPath()
        {
            string result = "";
            try
            {
                result = Application.StartupPath;
            }
            catch { }
            return result;
        }

        public void explorer(string path)
        {
            string argument = "/select, \"" + path + "\"";
            System.Diagnostics.Process.Start("explorer.exe", argument);
        }
      

        public string textToJSON(string text)
        {
            return text;
        }
        public void SaveImageFromElement(string xpath, string path)
        {
            saveImage(xpath, path);
        }
        public string GetCurrentMouseX()
        {
            return Cursor.Position.X.ToString();
        }

        public string GetCurrentMouseY()
        {
            return Cursor.Position.Y.ToString();
        }

        public void Mouse_Down(string mouseButton, int LastTime)
        {
            WaitApp(LastTime);

            if (mouseButton == "Left")
            {
                MouseKeyboardLibrary.MouseSimulator.MouseDown(MouseKeyboardLibrary.MouseButton.Left);
            }
            else if (mouseButton == "Right")
            {
                MouseKeyboardLibrary.MouseSimulator.MouseDown(MouseKeyboardLibrary.MouseButton.Right);
            }
            else if (mouseButton == "Middle")
            {
                MouseKeyboardLibrary.MouseSimulator.MouseDown(MouseKeyboardLibrary.MouseButton.Middle);
            }
        }

        public void Mouse_Up(string mouseButton, int LastTime)
        {
            WaitApp(LastTime);

            if (mouseButton == "Left")
            {
                MouseKeyboardLibrary.MouseSimulator.MouseUp(MouseKeyboardLibrary.MouseButton.Left);
            }
            else if (mouseButton == "Right")
            {
                MouseKeyboardLibrary.MouseSimulator.MouseUp(MouseKeyboardLibrary.MouseButton.Right);
            }
            else if (mouseButton == "Middle")
            {
                MouseKeyboardLibrary.MouseSimulator.MouseUp(MouseKeyboardLibrary.MouseButton.Middle);
            }

        }

        public void Mouse_Click(string mouseButton, int LastTime)
        {
            WaitApp(LastTime);

            if (mouseButton == "Left")
            {
                MouseKeyboardLibrary.MouseSimulator.Click(MouseKeyboardLibrary.MouseButton.Left);
            }
            else if (mouseButton == "Right")
            {
                MouseKeyboardLibrary.MouseSimulator.Click(MouseKeyboardLibrary.MouseButton.Right);
            }
            else if (mouseButton == "Middle")
            {
                MouseKeyboardLibrary.MouseSimulator.Click(MouseKeyboardLibrary.MouseButton.Middle);
            }
        }

        public void Mouse_Double_Click(string mouseButton, int LastTime)
        {
            WaitApp(LastTime);

            if (mouseButton == "Left")
            {
                MouseKeyboardLibrary.MouseSimulator.DoubleClick(MouseKeyboardLibrary.MouseButton.Left);
            }
            else if (mouseButton == "Right")
            {
                MouseKeyboardLibrary.MouseSimulator.DoubleClick(MouseKeyboardLibrary.MouseButton.Right);
            }
            else if (mouseButton == "Middle")
            {
                MouseKeyboardLibrary.MouseSimulator.DoubleClick(MouseKeyboardLibrary.MouseButton.Middle);
            }

        }

        public void Mouse_Show(int x, int y, bool isShow, int LastTime)
        {
            WaitApp(LastTime);

            MouseKeyboardLibrary.MouseSimulator.X = x;
            MouseKeyboardLibrary.MouseSimulator.Y = y;

            if (isShow)
            {
                MouseKeyboardLibrary.MouseSimulator.Show();
            }
            else if (isShow == false)
            {
                MouseKeyboardLibrary.MouseSimulator.Hide();
            }
        }

        public void Mouse_Wheel(int delta, int LastTime)
        {
            WaitApp(LastTime);

            MouseKeyboardLibrary.MouseSimulator.MouseWheel(delta);
        }

        public void Key_Down(string key, int LastTime)
        {
            WaitApp(LastTime);

            KeysConverter k = new KeysConverter();
            Keys mykey = (Keys)k.ConvertFromString(key);
            MouseKeyboardLibrary.KeyboardSimulator.KeyDown(mykey);
        }

        public void Key_Up(string key, int LastTime)
        {
            WaitApp(LastTime);

            KeysConverter k = new KeysConverter();
            Keys mykey = (Keys)k.ConvertFromString(key);
            MouseKeyboardLibrary.KeyboardSimulator.KeyUp(mykey);
        }

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

        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern short VkKeyScan(char ch);

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
            /*var actualValue = string.Empty;
            var values = Enum.GetValues(typeof(Keys));
            KeysConverter converter = new KeysConverter();
            string data = converter.ConvertToString(text);

            foreach (var item in text.ToArray())
            {
                WaitApp(2);
                if (item.ToString() == "_")
                {
                    MouseKeyboardLibrary.KeyboardSimulator.KeyDown(Keys.Shift);
                    MouseKeyboardLibrary.KeyboardSimulator.KeyDown(Keys.OemMinus);
                    MouseKeyboardLibrary.KeyboardSimulator.KeyUp(Keys.Shift);
                }
                else if (item.ToString() == " ")
                {
                    MouseKeyboardLibrary.KeyboardSimulator.KeyDown(Keys.Space);
                }
                else if (item.ToString() == ":")
                {
                    MouseKeyboardLibrary.KeyboardSimulator.KeyDown(Keys.Shift);
                    MouseKeyboardLibrary.KeyboardSimulator.KeyDown(Keys.Oem1);
                    MouseKeyboardLibrary.KeyboardSimulator.KeyUp(Keys.Shift);
                }
                else if (item.ToString() == "\\")
                {
                    MouseKeyboardLibrary.KeyboardSimulator.KeyDown(Keys.Shift);
                    MouseKeyboardLibrary.KeyboardSimulator.KeyDown(Keys.Oem5);
                    MouseKeyboardLibrary.KeyboardSimulator.KeyUp(Keys.Shift);
                }
                else if (item.ToString() == "-")
                {
                    MouseKeyboardLibrary.KeyboardSimulator.KeyDown(Keys.Shift);
                    MouseKeyboardLibrary.KeyboardSimulator.KeyDown(Keys.OemMinus);
                    MouseKeyboardLibrary.KeyboardSimulator.KeyUp(Keys.Shift);
                }
                else if (item.ToString() == ".")
                {
                    MouseKeyboardLibrary.KeyboardSimulator.KeyDown(Keys.Shift);
                    MouseKeyboardLibrary.KeyboardSimulator.KeyDown(Keys.OemPeriod);
                    MouseKeyboardLibrary.KeyboardSimulator.KeyUp(Keys.Shift);
                }
                else if (item.ToString() == "/")
                {
                    MouseKeyboardLibrary.KeyboardSimulator.KeyDown(Keys.Shift);
                    MouseKeyboardLibrary.KeyboardSimulator.KeyDown(Keys.OemQuestion);
                    MouseKeyboardLibrary.KeyboardSimulator.KeyUp(Keys.Shift);
                }
                else if (item.ToString() == "/")
                {
                    MouseKeyboardLibrary.KeyboardSimulator.KeyDown(Keys.Shift);
                    MouseKeyboardLibrary.KeyboardSimulator.KeyDown(Keys.Oemcomma);
                    MouseKeyboardLibrary.KeyboardSimulator.KeyUp(Keys.Shift);
                }
                else
                {
                    MouseKeyboardLibrary.KeyboardSimulator.KeyDown((Keys)converter.ConvertFromString(item.ToString().ToUpper()));
                }
            }*/
        }

        private void WaitApp(int seconds)
        {
            Application.DoEvents();
            System.Threading.Thread.Sleep(seconds);
        }

        public void Abort()
        {
            IsStop = true;
            
        }

        public void UnAbort()
        {
            IsStop = false;
        }

    

        public string ExtractUsingRegularExpression(string pattern, string groupName)
        {
            string result = string.Empty;

            GeckoWebBrowser wb = (GeckoWebBrowser)GetCurrentWB();
            if (wb != null)
            {
                string doc = wb.Document.Body.TextContent;
                Match m = Regex.Match(doc, pattern);
                if (m.Success)
                {
                    if (m.Groups.Count > 0)
                    {
                        result = m.Groups[groupName].Value;
                    }
                }
            }

            return result;
        }
        
      
        int repeatCount = 0;
        string repeatItem = string.Empty;

        public int Flag
        {
            get
            {
                return Flag1;
            }

            set
            {
                Flag1 = value;
            }
        }

        public int Flag1
        {
            get
            {
                return m_Flag;
            }

            set
            {
                m_Flag = value;
            }
        }

        private string extractData(GeckoHtmlElement ele, string attribute)
        {
            var result = string.Empty;

            if (ele != null)
            {
                var tmp = ele.GetAttribute(attribute);
                /*if (tmp == null)
                {
                    tmp = extractData(ele.Parent, attribute);
                }*/
                if (tmp != null)
                    result = tmp.Trim();
            }

            return result;
        }

        #endregion

        private void WebAutomation_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
           
            ThaoTac();
        }
    }
}
