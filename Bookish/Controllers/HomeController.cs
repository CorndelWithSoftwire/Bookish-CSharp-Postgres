using System.Web.Mvc;
using Bookish.DataAccess;
using Microsoft.AspNet.Identity;

namespace Bookish.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly BookRepository bookRepository = new BookRepository();

        public ActionResult Index()
        {
            var currentUser = User.Identity.GetUserId();
            var copiesBorrowed = bookRepository.GetCopiesBorrowedByUser(currentUser);

            return View(copiesBorrowed);
        }

        public ActionResult About()
        {
            ViewBag.Message = "A digital library for the 21st century";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact the Book(ish) team!";

            return View();
        }
    }
}