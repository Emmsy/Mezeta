using Mezeta.Core.Contracts;
using Mezeta.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mezeta.Controllers
{
    [Authorize]
    public class CalculationController : Controller
    {
        private readonly IRecipeService recipeService;


        public CalculationController(IRecipeService _recipeService)
        {
            recipeService = _recipeService;
        }

        public IActionResult Prepairings()
        {

             return View();
        }


        [HttpGet]
        public Task<IActionResult> AddToPrepairings(int recipeId)
        {

            return null;
        }
        [HttpPost]
        public Task<IActionResult> AddToPrepairings(RecipeIngredientViewModel model)
        {

            return null;
        }
    }
}
