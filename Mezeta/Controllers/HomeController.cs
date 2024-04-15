using Microsoft.AspNetCore.Mvc;

namespace Mezeta.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
     
    }
}