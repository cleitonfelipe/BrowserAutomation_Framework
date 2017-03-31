using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Chrome;
using BrowserAutomationTest.Framework_v1.Interfaces;
using System.IO;
using System.Reflection;
using BrowserAutomationTest.Framework_v1;
using OpenQA.Selenium.Support.UI;
//using OpenQA.Selenium.Support.UI;

namespace BrowserAutomationTest.Framework_v1
{
    public class Navigation : IAutomationBrowser
    {

        #region Propriedades

        private IWebDriver driver;
        private IWebElement element;
        private IReadOnlyCollection<IWebElement> elements;
        //private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert;
        private string driverPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Driver\\";
        private IWebElement text;

        


        #endregion
        public bool AcceptNextAlert
        {
            get { return acceptNextAlert; }
            set { acceptNextAlert = value; }
        }
        public IWebDriver Driver
        {
            get { return driver; }

            set { driver = value; }
        }

        public IWebElement Element
        {
            get { return element; }

            set { element = value; }
        }

        public IWebElement Text
        {
            get { return text; }
            set { text = value; }
        }

        public IReadOnlyCollection<IWebElement> Elements
        {
            get { return elements; }

            set { elements = value; }
        }

        public IAutomationBrowser SetupTest(string browser, string url)
        {
            switch (browser)
            {
                case "IE":
                    Driver = new InternetExplorerDriver(driverPath);
                    break;
                case "Chrome":
                    Driver = new ChromeDriver(driverPath);
                    break;
                default:
                    Driver = new FirefoxDriver();
                    break;
            }

            baseURL = url + "/";
            return this;
        }

        public IAutomationBrowser ExecutionTest()
        {
            Driver.Navigate().GoToUrl(baseURL);
            return this;
        }

        public IAutomationBrowser SendKeys(string valueData)
        {
            Element.SendKeys(valueData);
            return this;
        }

        public IAutomationBrowser Click()
        {
            Element.Click();
            return this;
        }

        public IAutomationBrowser Submit()
        {
            Element.Submit();
            return this;
        }

        public IAutomationBrowser Clear()
        {
            Element.Clear();
            return this;
        }

        public IAutomationBrowser CloseBrowser()
        {
            Driver.Close();
            Driver.Dispose();
            Driver.Quit();
            return this;
        }

        #region Name
        public IAutomationBrowser GetElementByName(string name)
        {
            Element = Driver.FindElement(By.Name(name));
            return this;
        }

        public IAutomationBrowser GetSeveralElementsByName(string name)
        {
            Elements = Driver.FindElements(By.Name(name));
            return this;
        }

        #endregion

        #region Id
        public IAutomationBrowser GetElementById(string id)
        {
            Element = Driver.FindElement(By.Id(id));
            return this;
        }

        public IAutomationBrowser GetSeveralElementsById(string id)
        {
            Elements = Driver.FindElements(By.Id(id));
            return this;
        }

        #endregion

        #region TagName

        /// <summary>
        /// Retorna apenas um elemento 
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public IAutomationBrowser GetElementByTagName(string tag)
        {
            Element = Driver.FindElement(By.TagName(tag));
            return this;
        }

        /// <summary>
        /// Retorna varios elementos 
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public IAutomationBrowser GetSeveralElementsByTagName(string tag)
        {
            Elements = Driver.FindElements(By.TagName(tag));
            return this;
        }

        #endregion

        #region Classname
        public IAutomationBrowser GetElementByClassName(string className)
        {
            Element = Driver.FindElement(By.ClassName(className));
            return this;
        }

        public IAutomationBrowser GetSeveralElementsByClassName(string className)
        {
            Elements = Driver.FindElements(By.ClassName(className));
            return this;
        }

        #endregion

        #region CssSelector

        public IAutomationBrowser GetElementByCssSelector(string css)
        {
            Element = Driver.FindElement(By.CssSelector(css));
            return this;
        }

        public IAutomationBrowser GetSeveralElementsByCssSelector(string cssSelector)
        {
            Elements = Driver.FindElements(By.CssSelector(cssSelector));
            return this;
        }

        #endregion

        #region PartialLinkText
        public IAutomationBrowser GetElementByPartialLinkText(string partialLinkText)
        {
            Elements = Driver.FindElements(By.LinkText(partialLinkText));
            return this;
        }

        public IAutomationBrowser GetSeveralElementsByPartialLinkText(string partialLinkText)
        {
            Elements = Driver.FindElements(By.PartialLinkText(partialLinkText));
            return this;
        }

        #endregion

        #region xpath
        public IAutomationBrowser GetElementByXPath(string xpath)
        {
            Element = Driver.FindElement(By.XPath(xpath));
            return this;
        }
        public IAutomationBrowser GetSeveralElementsByXPath(string xpath)
        {
            Elements = Driver.FindElements(By.XPath(xpath));
            return this;
        }

        #endregion

        #region LinkText
        public IAutomationBrowser GetElementByLinkText(string link)
        {
            Element = Driver.FindElement(By.LinkText(link));
            return this;
        }

        public IAutomationBrowser GetSeveralElementsByLinkText(string link)
        {
            Elements = Driver.FindElements(By.LinkText(link));
            return this;
        }

        #endregion

        #region SwitchTo 

        public IAutomationBrowser SwitchToOutOfIFrame()
        {
            Driver.SwitchTo().DefaultContent();
            return this;
        }

        public IAutomationBrowser SwitchToIFrame(int frame)
        {
            Driver.SwitchTo().Frame(frame);
            return this;
        }

        #endregion

        public bool GetPageSource(string source)
        {
            var resultado = Driver.PageSource.Contains(source);
            return resultado;
        }

        public bool IsAlertPresent()
        {
            try
            {
                Driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        public string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = Driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }

        public string GetCurrentUrl()
        {
            var url = Driver.Url;
            return url;
        }

        public IAutomationBrowser ExecuteJS(string script)
        {
            IJavaScriptExecutor js = Driver as IJavaScriptExecutor;
            string scr = (string)js.ExecuteScript(script);
            return this;
        }

        public IAutomationBrowser GetAttribute(string attribute)
        {
            Element.GetAttribute(attribute);
            return this;
        }

        public string GetText()
        {
            var resultado = Element.Text;
            return resultado;
        }
    }
}
