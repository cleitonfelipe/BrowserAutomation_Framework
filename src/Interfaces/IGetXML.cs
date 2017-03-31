using System.Xml;

namespace BrowserAutomationTest.Framework_v1.Interfaces
{
    public interface IGetXML
    {
        XmlDocument document { get; set; }

        XmlNodeList elementList { get; set; }

        IGetXML Load(string xmlFile);

        string GetValue(string key);
    }
}
