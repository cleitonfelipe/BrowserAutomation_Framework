using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserAutomationTest.Framework_v1.Interfaces
{
    public interface IAutomationBrowser
    {
        IAutomationBrowser SetupTest(string browser, string url);
               
        IAutomationBrowser ExecutionTest();      
        
        IAutomationBrowser SendKeys(string valueData);
        
        IAutomationBrowser Submit();
        
        IAutomationBrowser Clear();

        IAutomationBrowser Click();
        
        IAutomationBrowser CloseBrowser();


        IAutomationBrowser GetElementByClassName(string className);
        IAutomationBrowser GetSeveralElementsByClassName(string className);


        IAutomationBrowser GetElementByPartialLinkText(string partiallinktext);
        IAutomationBrowser GetSeveralElementsByPartialLinkText(string partiallinktext);


        IAutomationBrowser GetElementById(string id);
        IAutomationBrowser GetSeveralElementsById(string id);


        IAutomationBrowser GetElementByCssSelector(string css);
        IAutomationBrowser GetSeveralElementsByCssSelector(string cssselector);


        IAutomationBrowser GetElementByLinkText(string link);
        IAutomationBrowser GetSeveralElementsByLinkText(string linktext);


        IAutomationBrowser GetElementByXPath(string xpath);
        IAutomationBrowser GetSeveralElementsByXPath(string xpath);


        IAutomationBrowser GetElementByName(string name);
        IAutomationBrowser GetSeveralElementsByName(string name);


        IAutomationBrowser GetElementByTagName(string tag);
        IAutomationBrowser GetSeveralElementsByTagName(string tag);

        bool GetPageSource(string source);

        IAutomationBrowser SwitchToIFrame(int frame);

        IAutomationBrowser SwitchToOutOfIFrame();

        bool IsAlertPresent();

        string CloseAlertAndGetItsText();

        string GetCurrentUrl();

        IAutomationBrowser ExecuteJS(string script);

        IAutomationBrowser GetAttribute(string attribute);

        string GetText();

    }
}