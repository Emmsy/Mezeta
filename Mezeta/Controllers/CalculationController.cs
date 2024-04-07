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


        [HttpPost]
        public async Task<IActionResult> AddToPrepairings(int recipeId)
        {
            var recipe = await recipeService.GetRecipe(recipeId);
            var recipePrepairings = new RecipePrepairViewModel()
            {
                RecipeId = recipeId,
                Recipe = recipe,
                RawQuantity = 1,
                StartDate = DateTime.Now,
                ExpectedQuantity = 0.55
            };

            return View(recipePrepairings);
        }


        [HttpPost]
        public Task<IActionResult> CalculateRecipe(RecipePrepairViewModel model)
        {

            return null;
        }
    }
}
