using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace XMLPasring
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Xml Read
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load("Data.xml");

            var rootElement = xmlDocument.DocumentElement;
            City city = new City()
            {
                Name = rootElement.GetElementsByTagName("name")[0].InnerText,
                Population = int.Parse(rootElement.GetElementsByTagName("population")[0].InnerText),
                isCapital = bool.Parse(rootElement.GetElementsByTagName("isCapital")[0].InnerText),
                CountryName = rootElement.GetElementsByTagName("countryName")[0].InnerText
            };
            Console.ReadLine();
            */

            City city = new City
            {
                Name = "Almaty",
                Population = 2000000,
                isCapital = false,
                CountryName = "Kazakhstan"
            };

            XmlDocument xmlDocument = new XmlDocument();
            var rootElement = xmlDocument.CreateElement("city");

            var nameElement = xmlDocument.CreateElement("name");
            nameElement.InnerText = city.Name;

            rootElement.AppendChild(nameElement);

            var populationElement = xmlDocument.CreateElement("population");
            populationElement.InnerText = city.Population.ToString();

            rootElement.AppendChild(populationElement);

            xmlDocument.AppendChild(rootElement);

            xmlDocument.Save("data2.xml");

            Console.ReadLine();
        }
    }
}
