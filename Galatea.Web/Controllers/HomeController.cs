using Galatea.Web.ViewModels.Home;

using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

using static Galatea.Common.GeneralConstants;

namespace Galatea.Web.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        public IActionResult Index()
        {
            if (this.User.IsInRole(AdminRoleName))
            {
                return this.RedirectToAction("Index", "Home", new { Area = AdminAreaName });
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
            if (statusCode == 400 || statusCode == 404)
            {
                return View("Error404");
            }

            if (statusCode == 401)
            {
                return View("Error401");
            }

            return View();
        }
    }
}