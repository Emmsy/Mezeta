using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mezeta.Areas.Admin.Controllers
{
    [Authorize]
    public class MainController : BaseController
    {
        /// <summary>
        /// Показва главната страница в административния панел
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult All()
        {
            return View();
        }

    }
}
