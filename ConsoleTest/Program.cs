using _13.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book1 = new Book
            {
                Id = "bk105",
                Author = "Viktar Varanko",
                Description = "Desc book",
                Isbn = "0-596-00103-7",
                PublishDate = DateTime.Now,
                Publisher = "Radj",
                Title = "BOOK 1",
                RegistrationDate = DateTime.Now,
                Genre = new List<string>() { "comedy", "qwe" }
            };

            Book book2 = new Book
            {
                Id = "bk106",
                Author = "Viktar Varanko",
                Description = "Desc book 2",
                Isbn = "0-596-00103-0",
                PublishDate = DateTime.Now,
                Publisher = "Bridge",
                Title = "BOOK 2",
                RegistrationDate = DateTime.Now,
                Genre = new List<string>() { "comedy", "phantasy" }
            };

            Catalog catalog = new Catalog
            {
                Books = new List<Book>() { book1, book2 }
            };

            XmlSerializer formatterBooks = new XmlSerializer(typeof(Book));
            XmlSerializer formatterCatalog = new XmlSerializer(typeof(Catalog));

            using (FileStream fs = new FileStream("book.xml", FileMode.OpenOrCreate))
            {
                formatterBooks.Serialize(fs, book1);
            }

            using (FileStream fs = new FileStream("catalog.xml", FileMode.OpenOrCreate))
            {
                formatterCatalog.Serialize(fs, catalog);
            }

            using (FileStream fs = new FileStream("catalog.xml", FileMode.OpenOrCreate))
            {
                var values = (Catalog)formatterCatalog.Deserialize(fs);

                int counter = 1;
                foreach (var item in values.Books)
                {
                    Console.WriteLine($"{counter} -> {item.Title}");
                }
            }

            Console.ReadKey();
        }
    }
}
