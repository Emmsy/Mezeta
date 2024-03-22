using Mezeta.Core.Contracts;
using Mezeta.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Mezeta.Areas.Admin.Controllers
{
    public class MainController : BaseController
    {
        private readonly IRecipeService recipeService;


        public MainController(IRecipeService _recipeService)
        {
            recipeService = _recipeService;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(RecipeViewModel model)
        {

            return View(model);
        }

        public IActionResult Edit()
        {
            return View();
        }
    }
}
