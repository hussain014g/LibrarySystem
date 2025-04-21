using System;
using System.Collections.Generic;

namespace LibrarySystem
{
    class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public bool IsAvailable { get; set; }
        private static int nextId = 1;

        public Book(string title, string author)
        {
            Id = nextId++;
            Title = title;
            Author = author;
            IsAvailable = true;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"[{Id}] {Title} by {Author} - {(IsAvailable ? "Available" : "Checked Out")}");
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

        public void ReturnBook(string title)
        {
            foreach (Book book in books)
            {
                if (book.Title == title && !book.IsAvailable)
                {
                    book.IsAvailable = true;
                    Console.WriteLine($"You returned '{book.Title}'");
                    return;
                }
            }
            Console.WriteLine("Book was not checked out or does not exist.");
        }
    }

    class Program_changes
    {
        static void Main(string[] args)
        {
            Library lib = new Library();
            lib.AddBook(new Book("1984", "George Orwell"));
            lib.AddBook(new Book("To Kill a Mockingbird", "Harper Lee"));
            lib.AddBook(new Book("Brave New World", "Aldous Huxley"));

            Console.WriteLine("Initial Book List:");
            lib.ShowAvailableBooks();

            Console.Write("\nEnter the title of the book to checkout: ");
            string checkoutTitle = Console.ReadLine();
            lib.CheckoutBook(checkoutTitle);

            Console.WriteLine("\nAfter Checkout:");
            lib.ShowAvailableBooks();

            Console.Write("\nEnter the title of the book to return: ");
            string returnTitle = Console.ReadLine();
            lib.ReturnBook(returnTitle);

            Console.WriteLine("\nFinal Book List:");
            lib.ShowAvailableBooks();
        }
    }
}
