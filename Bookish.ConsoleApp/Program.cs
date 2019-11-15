using System;
using Bookish.DataAccess;

namespace Bookish.ConsoleApp
{
  class Program
  {
    static void Main(string[] args)
    {
      var repo = new BookRepository();
      var books = repo.GetAllBooks();

      foreach (var book in books)
      {
        Console.WriteLine($"{book.Title} by {book.Author}");
      }

      Console.ReadLine();
    }
  }
}
