using System.Collections;
using System.Collections.Generic;

namespace Bookish.DataAccess
{
  public class Book
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public IEnumerable<Copy> Copies { get; set; }
  }
}
