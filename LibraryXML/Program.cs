using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;

namespace LibraryXML
{
    class Program       
    {
        static void WriteBooks(XmlDocument doc)
        {
            XmlNode root = doc.DocumentElement;

            if (root.HasChildNodes)
            {
                for (int i = 0; i < root.ChildNodes.Count; i++)
                {
                    Console.WriteLine("Инвентарный номер: " + root.ChildNodes[i].ChildNodes[0].InnerText);
                    Console.WriteLine("ISBN: " + root.ChildNodes[i].ChildNodes[1].InnerText);
                    Console.WriteLine("Название книги: '" + root.ChildNodes[i].ChildNodes[2].InnerText + "'");
                    if(root.ChildNodes[i].ChildNodes[3].HasChildNodes)
                    {
                        for (int j = 0; j < root.ChildNodes[i].ChildNodes[3].ChildNodes.Count; j++)
                        {
                            Console.WriteLine("Автор: " + root.ChildNodes[i].ChildNodes[3].ChildNodes[j].InnerText);
                        }
                    }
                    Console.WriteLine();
                    Console.WriteLine("Читальный зал: " + root.ChildNodes[i].ChildNodes[4].ChildNodes[0].InnerText);
                    Console.WriteLine("На руках: " + root.ChildNodes[i].ChildNodes[4].ChildNodes[1].InnerText);
                    Console.WriteLine("На складе: " + root.ChildNodes[i].ChildNodes[4].ChildNodes[2].InnerText);
                    Console.WriteLine("____________________________________________");
                }
            }
        }

        static void Main(string[] args)
        {
            string DocName = @"C:\Users\lihoi\source\repos\LibraryXML\LibraryXML\BookLibraryXML.xml";

            XmlDocument Doc = new XmlDocument();
            XmlReaderSettings Settings = new XmlReaderSettings();
            Settings.DtdProcessing = DtdProcessing.Parse;
            Settings.ValidationType = ValidationType.DTD;
            Settings.XmlResolver = new XmlUrlResolver();

            using (XmlReader reader = XmlTextReader.Create(DocName, Settings))
            {
                try
                {
                    Doc.Load(reader);

                    WriteBooks(Doc);
                }
                catch(XmlSchemaException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                    
            }
            Console.ReadKey();

        }
    }
}
