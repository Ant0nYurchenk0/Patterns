using System;
namespace AdapterExample
{
    /** змінилася бібліотека для парсину XML файлів, а в новій бібліотеці інші методи**/
    class OldXMLParser : IOldXMLParser
    {
        public string Parse()
        {
            return "old parser";
        }
    }

    interface IOldXMLParser
    {
        string Parse();
    }


    class NewXMLParser
    {
        public string ParseXML()
        {
            return "new parser";
        }
    }

    class Adapter : IOldXMLParser
    {

        private readonly NewXMLParser _adaptee;
        public Adapter(NewXMLParser adaptee)
        {
            _adaptee = adaptee;
        }


        public string Parse()
        {

            return _adaptee.ParseXML();
        }
    }

    class Parser
    {
        public static void ParseFile(IOldXMLParser xmlParser)
        {
            Console.WriteLine(xmlParser.Parse());
        }
    }

    public class ParsingProgram
    {
        static void Main()
        {
            var oldParser = new OldXMLParser();
            Parser.ParseFile(oldParser);
            var newParser = new NewXMLParser();
            var adapter = new Adapter(newParser);
            Parser.ParseFile(adapter);
            Console.ReadKey();
        }
    }
}