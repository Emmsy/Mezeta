using Mezeta.Core.Contracts;
using Mezeta.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Mezeta.Controllers
{
    [Authorize]
    public class CalculationController : Controller
    {
        private readonly IRecipeService recipeService;
        private static RecipePrepairViewModel recipePrepairings = new RecipePrepairViewModel();

        public CalculationController(IRecipeService _recipeService)
        {
            recipeService = _recipeService;
        }

        /// <summary>
        /// калкулира рецептата с нужните количества
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> CalculationsRecipe(int id)
        {
            var recipe = await recipeService.GetRecipe(id);
            if (recipePrepairings.RecipeId == 0 || recipePrepairings.RecipeId != id)
            {
                recipePrepairings = new RecipePrepairViewModel()
                {
                    RecipeId = id,
                    Recipe = recipe,
                    RawQuantity = 1,
                    StartDate = DateTime.Now,
                    ExpectedQuantity = 0.55
                };
            }
            return View(recipePrepairings);
        }

        /// <summary>
        /// калкулира рецептата с нужните количества
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CalculationsRecipe(int id, RecipePrepairViewModel model)
        {
            var recipe = await recipeService.GetRecipe(id);
            model.Recipe = recipe;
            model.RecipeId = recipe.Id;
            model.ExpectedQuantity = Math.Round((model.RawQuantity * 0.55), 2);
            recipePrepairings = model;
            return View(model);
        }

        /// <summary>
        /// показва списъка със рецепти които се приготвят
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Prepairings()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account", new { area = "Identity" });
            }
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var model = await recipeService.GetPrepairingsRecipes(userId);
            return View(model);
        }

        /// <summary>
        /// добавя рецепта в списъка които се приготвят
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddToPrepairings()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account", new { area = "Identity" });
            }
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (recipePrepairings.RecipeId != 0)
            {
                await recipeService.AddToPreparings(userId, recipePrepairings);
            }

            return RedirectToAction("Prepairings", "Calculation");
        }


        /// <summary>
        /// премахва рецепта в списъка които се приготвят
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> RemoveFromPreparings(int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account", new { area = "Identity" });
            }

            await recipeService.RemoveFromPreparings(id);

            return RedirectToAction("Prepairings", "Calculation");
        }

    }
}
