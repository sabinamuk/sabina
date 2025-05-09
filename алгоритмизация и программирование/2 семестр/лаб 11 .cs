/******************************************************************************
Лаб 11 - 18.04.25 - библиотека
*******************************************************************************/
using System;
using System.Collections.Generic;
namespace Library
{
    struct Book
    {
        public string Author;
        public string Title;
        public int Year;
        public string Publisher;
        public Book(string author, string title, int year, string publisher)
        {
            Author = author;
            Title = title;
            Year = year;
            Publisher = publisher;
        }
    }
    struct Record
    {
        public string IssueDate;
        public string ReturnDate;

        public Record(string issueDate, string returnDate)
        {
            IssueDate = issueDate;
            ReturnDate = returnDate;
        }
    }
    class BookEntry
    {
        public Book BookInfo { get; set; }
        public List<Record> Records { get; set; }
        public BookEntry(Book bookInfo, List<Record> records)
        {
            BookInfo = bookInfo;
            Records = records;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int choice = 0;
            List<BookEntry> library = new List<BookEntry>();
            while (choice != 4)
            {
                Console.WriteLine("1. Добавить книги\n" +
                                  "2. Книги, которые ни разу не выдавались\n" +
                                  "3. Книги, которые не были возвращены\n" +
                                  "4. Выход");
                Console.Write("Выберите опцию: ");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        while (true)
                        {
                            Console.WriteLine("\nДля остановки введите 0 в поле автора");
                            Console.Write("Автор: ");
                            string author = Console.ReadLine();
                            if (author == "0") break;

                            Console.Write("Название книги: ");
                            string title = Console.ReadLine();
                            Console.Write("Год издания: ");
                            int year = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Издательство: ");
                            string publisher = Console.ReadLine();

                            Book book = new Book(author, title, year, publisher);
                            List<Record> records = new List<Record>();
                            Console.WriteLine("Введите даты выдачи и возврата книги (если не была выдана или сдана — нажмите Enter).");
                            while (true)
                            {
                                Console.Write("Дата выдачи: ");
                                string issue = Console.ReadLine();
                                string ret = "";
                                if (!string.IsNullOrEmpty(issue))
                                {
                                    Console.Write("Дата возврата: ");
                                    ret = Console.ReadLine();
                                }
                                records.Add(new Record(issue, ret));
                                if (string.IsNullOrEmpty(ret)) break;
                            }
                            library.Add(new BookEntry(book, records));
                        }
                        break;
                    case 2:
                        if (library.Count > 0)
                        {
                            Console.WriteLine("\nКниги, которые ни разу не выдавались:");
                            bool found = false;

                            foreach (var entry in library)
                            {
                                if (string.IsNullOrEmpty(entry.Records[0].IssueDate))
                                {
                                    found = true;
                                    var b = entry.BookInfo;
                                    Console.WriteLine($"Автор: {b.Author}, Название: {b.Title}, Год: {b.Year}, Издательство: {b.Publisher}");
                                }
                            }
                            if (!found)
                                Console.WriteLine("Все книги были выданы хотя бы один раз.");
                        }
                        else Console.WriteLine("\nБаза пуста.\n");
                        break;
                    case 3:
                        if (library.Count > 0)
                        {
                            Console.WriteLine("\nКниги, которые не были возвращены:");
                            bool found = false;
                            foreach (var entry in library)
                            {
                                var last = entry.Records[entry.Records.Count - 1];
                                if (!string.IsNullOrEmpty(last.IssueDate) && string.IsNullOrEmpty(last.ReturnDate))
                                {
                                    found = true;
                                    var b = entry.BookInfo;
                                    Console.WriteLine($"Автор: {b.Author}, Название: {b.Title}, Год: {b.Year}, Издательство: {b.Publisher}, Дата выдачи: {last.IssueDate}");
                                }
                            }
                            if (!found)
                                Console.WriteLine("Нет несданных книг.");
                        }
                        else Console.WriteLine("\nБаза пуста.\n");
                        break;
                }
            }
        }
    }
}
