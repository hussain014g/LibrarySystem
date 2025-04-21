using System;
using System.Collections.Generic;

namespace LibrarySystem
{
    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public bool IsAvailable { get; set; }

        public Book(string title, string author)
        {
            Title = title;
            Author = author;
            IsAvailable = true;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"{Title} by {Author} - {(IsAvailable ? "Available" : "Checked Out")}");
        }
    }

    class Library
    {
        private List<Book> books = new List<Book>();

        public void AddBook(Book book)
        {
            books.Add(book);
        }

        public void ShowAvailableBooks()
        {
            Console.WriteLine("Available books:");
            foreach (Book book in books)
            {
                if (book.IsAvailable)
                    book.DisplayInfo();
            }
        }

        public void CheckoutBook(string title)
        {
            foreach (Book book in books)
            {
                if (book.Title == title && book.IsAvailable)
                {
                    book.IsAvailable = false;
                    Console.WriteLine($"You checked out '{book.Title}'");
                    return;
                }
            }
            Console.WriteLine("Book not available.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Library lib = new Library();
            lib.AddBook(new Book("1984", "George Orwell"));
            lib.AddBook(new Book("To Kill a Mockingbird", "Harper Lee"));

            lib.ShowAvailableBooks();

            Console.Write("Enter the book to checkout: ");
            string title = Console.ReadLine();
            lib.CheckoutBook(title);

            Console.WriteLine("\nAfter checkout:");
            lib.ShowAvailableBooks();
        }
    }
}
