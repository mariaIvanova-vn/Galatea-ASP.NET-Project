using Microsoft.AspNetCore.Mvc;

namespace Galatea.Web.Areas.Admin.Controllers
{
    public class HomeController : BaseAdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
