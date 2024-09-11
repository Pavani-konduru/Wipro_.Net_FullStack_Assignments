using System;
using System.Linq;
using System.Xml.Linq;

class Program
{
    static void Main()
    {
        string xmlFilePath = @"C:\Users\Administrator\source\repos\Day 23\XML_Document\books.xml";

        XDocument xdoc = XDocument.Load(xmlFilePath);

        var booksByJohnDoe = from book in xdoc.Descendants("book")
                             where (string)book.Element("author") == "John Doe"
                             select book.Element("title")?.Value;

        Console.WriteLine("Books authored by John Doe:");
        foreach (var title in booksByJohnDoe)
        {
            Console.WriteLine(title);
        }

        var averagePrice = xdoc.Descendants("book")
                               .Average(book => (decimal)book.Element("price"));

        Console.WriteLine($"The average price of all books is: {averagePrice}");

        XDocument bookStore1 = new XDocument(
            new XElement("bookstore",
            new XElement("book",
            new XElement("title", "Harry Potter"),
            new XElement("author", "John Doe"),
            new XElement("price", 290.95)
            ),
            new XElement("book",
            new XElement("title", "Believe in Yourself"),
            new XElement("author", "Joseph Murphy"),
            new XElement("price", 190.95)
            ),
            new XElement("book",
            new XElement("title", "Learning LINQ"),
            new XElement("author", "John Doe"),
            new XElement("price", 389.95)
            )
            )
            );

        bookStore1.Save(@"C:\Users\Administrator\source\repos\Day 23\XML_Document\books.xml");
        Console.WriteLine("\nXML file 'bookstore1.xml' has been created and saved in Pavani's PC using C#");

        string xmlFilePath1 = @"C:\Users\Administrator\source\repos\Day 23\XML_Document\books.xml";

        XDocument xdoc1 = XDocument.Load(xmlFilePath1);

        var JohnDoeBooks1 = from book in xdoc.Descendants("book")
                             where (string)book.Element("author") == "John Doe"
                             select book.Element("title")?.Value;

        Console.WriteLine("Books authored by John Doe:");
        foreach (var title in booksByJohnDoe)
        {
            Console.WriteLine(title);
        }

        var averagePrice1 = xdoc.Descendants("book")
                               .Average(book => (decimal)book.Element("price"));

        Console.WriteLine($"The average price of all books is: {averagePrice1}");
        Console.WriteLine("\n\nBook Details: ");

        foreach(XElement book in xdoc.Descendants("book" ))
                {
            string title = book.Element("title").Value;
            string author = book.Element("author").Value;
            string price = book.Element("price").Value;

            Console.WriteLine($"Title: {title}");
            Console.WriteLine($"Author: {author}");
            Console.WriteLine($"Price: {price}");


        }
        Console.WriteLine();



    }
}