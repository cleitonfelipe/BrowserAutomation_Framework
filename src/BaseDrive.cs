using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserAutomationTest.Framework_v1
{
    public class BaseDrive
    {
        private IWebDriver _driver;
        private static BaseDrive _uniqueInstance;

        /// <summary>
        /// Construtor receberá qualquer classe que implemente IWebDriver conforme fala a assinatura da classe  
        /// </summary>
        /// <param name="type">Qual quer classe que implemente a interface IWebDriver</param>
        public BaseDrive()
        {
            _driver = GetWebDriver();
        }

        /// <summary>
        /// Retorna uma nova instancia de WebDriver de acordo com o tipo
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private IWebDriver GetWebDriver()
        {
            //Not Implemented
            return null;
        }

        /// <summary>
        /// Retorna o WebDriver 
        /// </summary>
        /// <returns></returns>
        public IWebDriver GetDriver()
        {
            return _driver;
        }

        public static BaseDrive GetInstance()
        {
            if (_uniqueInstance == null)
            {
                _uniqueInstance = new BaseDrive();
            }

            return _uniqueInstance;
        }
    }
}
