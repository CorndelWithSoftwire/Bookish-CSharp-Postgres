using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using Dapper;
using Npgsql;

namespace Bookish.DataAccess
{
  public class BookRepository
  {
    public IEnumerable<Book> GetAllBooks()
    {
      using (var db = CreateSqlConnection())
      {
        return db.Query<Book>("SELECT * FROM Books");
      }
    }

    private static IDbConnection CreateSqlConnection()
    {
      return new NpgsqlConnection(ConfigurationManager.ConnectionStrings["MyPostgres"].ConnectionString);
    }

    public IEnumerable<Book> SearchBooks(string searchText)
    {
      using (var db = CreateSqlConnection())
      {
        return db.Query<Book>(
          "SELECT * FROM Books WHERE Title LIKE '%' + @searchText + '%' OR Author LIKE '%' + @searchText + '%'", 
          new {searchText});
      }
    }

    public Book GetBook(int id)
    {
      using (var db = CreateSqlConnection())
      {
        var book = db.QuerySingle<Book>("SELECT * FROM Books WHERE Id = @id", new {id});
        book.Copies = db.Query<Copy>("SELECT * FROM Copies WHERE BookId = @bookId", new {bookId = book.Id});
        return book;
      }
    }

    public IEnumerable<Copy> GetCopiesBorrowedByUser(string user)
    {
      using (var db = CreateSqlConnection())
      {
        return db.Query<Copy, Book, Copy>(
          "SELECT * FROM Copies JOIN Books ON Books.Id = Copies.BookId WHERE Borrower = @user",
          (copy, book) => 
          {
            copy.Book = book;
            return copy;
          },
          new {user});
      }
    }

    public int AddBook(Book newBook, int copies)
    {
      using (var db = CreateSqlConnection())
      {
        int bookId = db.QuerySingle<int>(
          "INSERT INTO Books(Title, Author, ISBN) VALUES(@Title, @Author, @ISBN); SELECT SCOPE_IDENTITY()", newBook);

        db.Execute("INSERT INTO Copies(BookId) VALUES(@BookId)", 
          Enumerable.Range(1, copies).Select(_ => new {bookId}));

        return bookId;
      }
    }
  }
}