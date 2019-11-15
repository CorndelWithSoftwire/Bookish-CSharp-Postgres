using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Bookish.Web.Helpers
{
    public static class UserDisplayHelpers
    {
        public static MvcHtmlString UserNameFromId(this HtmlHelper html, string userId)
        {
            var userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = userManager.FindById(userId);

            if (user == null) return MvcHtmlString.Empty;

            return MvcHtmlString.Create(user.UserName);
        }
    }
}