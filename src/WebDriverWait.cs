using System;
using OpenQA.Selenium;

namespace BrowserAutomationTest.Framework_v1
{
    internal class WebDriverWait
    {
        private IWebDriver driver;
        private TimeSpan timeSpan;

        public WebDriverWait(IWebDriver driver, TimeSpan timeSpan)
        {
            this.driver = driver;
            this.timeSpan = timeSpan;
        }
    }
}