using System;

namespace Bookish.DataAccess
{
  public class Copy
  {
    public int Id { get; set; }
    public string Borrower { get; set; }
    public DateTime DueDate { get; set; }
    public Book Book { get; set; }

    public bool IsAvailable => Borrower == null;
  }
}
