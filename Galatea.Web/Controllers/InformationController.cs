using Galatea.Web.ViewModels.Home;

using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Galatea.Web.Controllers
{
    public class InformationController : Controller
    {
        public InformationController()
        {
        }

        public IActionResult Information()
        {
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