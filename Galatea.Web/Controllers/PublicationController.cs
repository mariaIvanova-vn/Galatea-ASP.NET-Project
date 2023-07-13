using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Galatea.Web.Controllers
{
    [Authorize]
    public class PublicationController : Controller
    {
       
        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            return View();
        }
    }
}
