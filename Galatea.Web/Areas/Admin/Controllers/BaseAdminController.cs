using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using static Galatea.Common.GeneralConstants;

namespace Galatea.Web.Areas.Admin.Controllers
{
    [Area(AdminAreaName)]
    [Authorize(Roles = AdminRoleName)]
    public class BaseAdminController : Controller
    {

    }
}
