using Mezeta.Core.Contracts;
using Mezeta.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mezeta.Areas.Admin.Controllers
{
    [Authorize]
    public class MainController : BaseController
    {
        private readonly IRecipeService recipeService;


        public MainController(IRecipeService _recipeService)
        {
            recipeService = _recipeService;
        }

        [HttpGet]
   
        public IActionResult All()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddRecipe()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddRecipe(RecipeViewModel model)
        {

            return View(model);
        }

        [HttpGet]
        public IActionResult AddIngredient()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddIngredient(RecipeIngredientViewModel model)
        {

            return View(model);
        }

        [HttpGet]
        public IActionResult AddSpice()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddSpice(RecipeSpiceViewModel model)
        {

            return View(model);
        }



        public IActionResult Edit()
        {
            return View();
        }
    }
}
