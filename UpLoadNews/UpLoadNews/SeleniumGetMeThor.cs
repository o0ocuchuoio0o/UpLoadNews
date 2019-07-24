using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
namespace UpLoadNews
{
    public class SeleniumGetMeThor
    {
        public static string GetText(IWebElement element)
        {
            return element.GetAttribute("value");
        }
        public static string GetTextdone(IWebElement element)
        {
            return element.GetAttribute("aria-valuemax");
        }
        public static string GetText2(IWebElement element)
        {
            return element.GetAttribute("innerHTML");
        }
        public static string GetTextLink(IWebElement element)
        {
            return element.GetAttribute("src");
        }
        public static string GetTextFromDOL(IWebElement element)
        {

            return new SelectElement(element).AllSelectedOptions.SingleOrDefault().Text;

        }
      

    }
}
