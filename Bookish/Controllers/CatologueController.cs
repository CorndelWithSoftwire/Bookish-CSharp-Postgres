using System;
using System.Linq;
using System.Web.Mvc;
using Bookish.DataAccess;
using Bookish.Web.Models;

namespace Bookish.Web.Controllers
{
    [Authorize]
    public class CatalogueController : Controller
    {
        private readonly BookRepository bookRepository = new BookRepository();
        private const int PageSize = 20;

        public ActionResult Index(int page = 1)
        {
            var allBooks = bookRepository.GetAllBooks().OrderBy(book => book.Title);
            var pageOfBooks = allBooks.Skip((page - 1) * PageSize).Take(PageSize);
            var totalPages = (int)Math.Ceiling(allBooks.Count() / (double)PageSize);

            return View(new CatalogueViewModel(page, totalPages, pageOfBooks));
        }

        [HttpPost]
        public ActionResult Search(BookSearchModel search)
        {
            var matchingBooks = bookRepository.SearchBooks(search.SearchText).OrderBy(book => book.Title);

            return View(new CatalogueSearchViewModel(search, 1, 1, matchingBooks));
        }

        public ActionResult Details(int id)
        {
            return View(bookRepository.GetBook(id));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NewBookModel newBook)
        {
            if (ModelState.IsValid)
            {
                var newBookId = bookRepository.AddBook(newBook.AsBook(), newBook.Copies);
                return RedirectToAction("Details", new { id = newBookId });
            }

            return View(newBook);
        }
    }
}