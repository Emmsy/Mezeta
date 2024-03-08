using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mezeta.Controllers
{
    [Authorize]
    public class MezetaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult All()
        {
            return View();
        }

        public IActionResult View()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Calculation()
        {
            return View();
        }
    }
}
