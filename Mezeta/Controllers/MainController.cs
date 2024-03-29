using Mezeta.Core.Contracts;
using Mezeta.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mezeta.Controllers
{
    [Authorize]
    public class MainController : Controller
    {
        private readonly IRecipeService recipeService;

        
        public MainController(IRecipeService _recipeService)
        {
            recipeService = _recipeService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> AllRecipes()
        {
            var allRecipies =  await recipeService.GetAllRecipes();

            return View(allRecipies);
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> AllIngredients()
        {
            var model = await recipeService.GetAllIngredients();
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> AllSpices()
        {
            var model = await recipeService.GetAllSpices();
            return View(model);
        }

        public IActionResult Calculation()
        {
            return View();
        }
    }
}
