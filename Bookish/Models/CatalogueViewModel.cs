using System.Collections.Generic;
using Bookish.DataAccess;

namespace Bookish.Web.Models
{
    public class CatalogueViewModel
    {
        public CatalogueViewModel(int page, int totalPages, IEnumerable<Book> books)
        {
            Page = page;
            TotalPages = totalPages;
            Books = books;
        }

        public int Page { get; private set; }
        public int TotalPages { get; private set; }
        public IEnumerable<Book> Books { get; private set; }
    }
}