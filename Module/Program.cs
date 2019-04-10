using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module
{

    public class Section
    {
        public int Id { get; set; } //ідентифікатор розділу
        public string Name { get; set; } //назва розділу
    }
    public class Book
    {
        public int Id { get; set; }  //ідентифікатор книжки
        public int SId { get; set; }  //ідентифікатор розділу
        public string Title { get; set; } //назва книжки
    }
    public class BookName
    {
        public string Id { get; set; }
        public string Title { get; set; }
    }
    public class BookInfo
    {
        public string Id { get; set; }
        public string Info { get; set; }
    }


    class Program
    {

        static void Main(string[] args)
        {
            /*var books = new List<BookName>(){
                new BookName {Id = "111", Title = "Програмування"},
                new BookName {Id = "222", Title = "Логіка"},
                new BookName {Id = "333", Title = "Програмна інженерія"}
            };
            //побудувати та заповнити колекцію описів книжок
            var info = new List<BookInfo>()
            {
                new BookInfo{Id = "111", Info = "Опис книги Програмування"},
                new BookInfo{Id = "222", Info = "Опис книги Логіка"},
                new BookInfo{Id = "111", Info = "Опис книги Програмна інженерія"}
            };
            var query = from book in books
                        join b in info
                          on book.Id equals b.Id
                        orderby b.Info descending
                        select new
                        {
                            Id = book.Id,
                            Title = book.Title,
                            Info = b.Info
                        };
            foreach (var book in query)
            {
                Console.WriteLine("{0}, {1}, {2}", book.Id, book.Title, book.Info);
            }*/
                //побудувати та заповнити колекцію розділів бібліотеки
                var sections = new List<Section>(){
                    new Section {Id = 1, Name = "Програмування"},
                    new Section {Id = 2, Name = "Логіка"},
                    new Section {Id = 3, Name = "Історія"}
                };
                //побудувати та заповнити колекцію книжок
                var books = new List<Book>()
                {
                    new Book {Id = 10, Title = "Програмування", SId=1},
                    new Book {Id = 11, Title = "Логіка", SId=2},
                    new Book {Id = 12, Title = "Програмна інженерія", SId=1}
                };
                var innerGroupJoinQuery =
                from sect in sections
                join book in books
                on sect.Id equals book.SId into booksSect
                select new { SectionName = sect.Name, Books = booksSect };
                foreach (var section in innerGroupJoinQuery)
                {
                    Console.WriteLine("{0}:", section.SectionName);
                    foreach (var book in section.Books)
                    {
                        Console.WriteLine(" \t{0}", book.Title);
                        Console.WriteLine(" \t{0}", book.Id);
                        Console.WriteLine(" \t{0}", book.SId);

                    }
                }
                Console.Read();
            }
        }
    }
