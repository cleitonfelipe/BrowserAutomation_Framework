using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrowserAutomationTest.Framework_v1.Interfaces;
using System.Xml;

namespace BrowserAutomationTest.Framework_v1
{
    public class GetXML : IGetXML
    {
        private XmlDocument doc;
        private XmlNodeList item;

        public XmlDocument document
        {
            get { return doc; }

            set { doc = value; }
        }

        public XmlNodeList elementList
        {
            get { return item; }

            set { item = value; }
        }

        public IGetXML Load(string xmlFile)
        {
            doc = new XmlDocument();
            doc.Load(xmlFile);
            return this;
        }

        public string GetValue(string key)
        {
            Random ran = new Random();

            string dados = string.Empty;

            item = doc.GetElementsByTagName("User");

            switch (key)
            {
                case "usuario":
                    int qnum = ran.Next(0, item.Count - 1);
                    string ranQuestion = item[qnum].Attributes["usuario"].Value;
                    dados = ranQuestion;
                    break;
                case "senha":
                    int qnum2 = ran.Next(0, item.Count - 1);
                    string ranQuestion2 = item[qnum2].Attributes["senha"].Value;
                    dados = ranQuestion2;
                    break;
                default:
                    break;
            }
            return dados;
        }
    }
}
