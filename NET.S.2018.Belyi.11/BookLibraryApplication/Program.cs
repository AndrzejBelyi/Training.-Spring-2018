using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLibrary;

namespace BookLibraryApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            BookListService bookService = new BookListService();
            bookService.AddBook(new Book("1234567891011", "Идиот", "Достоевский Ф.М", "Азбука", "2012", 700, 9.01m));
            bookService.AddBook(new Book("555534", "Доктор Живаго", "Борис Пастернак", "Азбука", "2013", 7700, 12));
            bookService.AddBook(new Book("ASDA21", "Малое собрание сочинений", "Антон Чехов", "Неизвестное", "2010", 90, 15));
            bookService.AddBook(new Book("2423DAA", "Евгений Онегин", "Александр Пушкин", "Известное", "1995", 88, 13));
            BookListBinaryFileStorage binaryFile=new BookListBinaryFileStorage(@"e:\GitHub\Training.-Spring-2018\NET.S.2018.Belyi.11\BookLibraryApplication\BinaryBookStorage");
            bookService.SaveToStorage(binaryFile);
            bookService.AddBook(new Book("2423Ddsa", "CCC2", "AFTOR2", "QWERTY", "1995", 88, 90));
            bookService.LoadFromStorage(binaryFile);
            foreach (Book b in bookService.bookList)
            {
                Console.WriteLine(b.ToString());
            }

            Console.WriteLine("\nCортировка по цене:\n");
            bookService.SortBooksListByTag(new Comparators.PriceComparer());
            foreach (Book b in bookService.bookList)
            {
                Console.WriteLine(b.ToString("ISBN", CultureInfo.InvariantCulture));
                Console.WriteLine(b.ToString("FULL",CultureInfo.InvariantCulture));
            }

            Console.WriteLine("\nCортировка по названию:\n");
            bookService.SortBooksListByTag(new Comparators.NameComparer());
            foreach (Book b in bookService.bookList)
            {
                Console.WriteLine(b.ToString());
            }
            Console.WriteLine("\nПоиск по имени Антон Чехов:\n");            
            Console.WriteLine(bookService.FindBookByTag(new Tags.TitlePredicate("Антон Чехов")).ToString());


        }
    }
}
