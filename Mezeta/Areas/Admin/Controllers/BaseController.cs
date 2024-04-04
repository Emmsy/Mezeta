using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mezeta.Areas.Admin.Controllers
{
    /// <summary>
    /// Базов контролер за админ area
    /// </summary>

    [Area("Admin")]
    [Route("/Admin/[controller]/[Action]/{id?}")]
    [Authorize(Roles = "Admin")]
    public class BaseController : Controller
    {
     
    }
}
