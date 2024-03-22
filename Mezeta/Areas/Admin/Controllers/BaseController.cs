using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mezeta.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("/Admin/[controller]/[Action]/{id?}")]
    [Authorize(Roles = "Admin")]
    public class BaseController : Controller
    {
     
    }
}
