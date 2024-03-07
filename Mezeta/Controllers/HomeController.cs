using Mezeta.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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