using System.Collections.Generic;
using Bookish.DataAccess;

namespace Bookish.Web.Models
{
    public class CatalogueSearchViewModel : CatalogueViewModel
    {
        public CatalogueSearchViewModel(BookSearchModel searchCriteria, int page, int totalPages, IEnumerable<Book> books)
            : base(page, totalPages, books)
        {
            SearchCriteria = searchCriteria;
        }

        public BookSearchModel SearchCriteria { get; private set; }
    }
}