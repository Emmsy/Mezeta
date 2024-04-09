using Mezeta.Core.Contracts;
using Mezeta.Core.Models;
using Mezeta.Core.Models.Admin;
using Mezeta.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Linq;
using System.Security.Claims;

namespace Mezeta.Controllers
{
    [Authorize]
    public class CalculationController : Controller
    {
        private readonly IRecipeService recipeService;
        private static RecipePrepairViewModel recipePrepairings = new RecipePrepairViewModel();
        private static double crtRaw = 1;
        private static DateTime startDate = DateTime.Now;


        public CalculationController(IRecipeService _recipeService)
        {
            recipeService = _recipeService;
        }

        [HttpGet]
        public async Task<IActionResult> CalculationsRecipe(int id)
        {
            var recipe = await recipeService.GetRecipe(id);
            if (recipePrepairings.RecipeId == 0)
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


        [HttpPost]
        public async Task<IActionResult> CalculationsRecipe(int id,RecipePrepairViewModel model)
        {
 
            var recipe = await recipeService.GetRecipe(id);

            var calculateIngredients = new List<RecipeIngredientViewModel>();
            foreach (var ing in recipe.Ingredients)
            {
                var crtIng = new RecipeIngredientViewModel()
                {
                    IngredientId = ing.IngredientId,
                    MeasureId = ing.MeasureId,
                    IngredientName = ing.IngredientName,
                    MeasureUnit = ing.MeasureUnit,
                    Quantity = (ing.Quantity * model.RawQuantity),
                };

                calculateIngredients.Add(crtIng);
            }

            var calculateSpices = new List<RecipeSpiceViewModel>();
            foreach (var sp in recipe.Spices)
            {
                var crtSp = new RecipeSpiceViewModel()
                {
                    SpiceId = sp.SpiceId,
                    SpiceName = sp.SpiceName,
                    MeasureId = sp.MeasureId,
                    MeasureUnit = sp.MeasureUnit,
                    Quantity = (sp.Quantity * model.RawQuantity),
                };
                calculateSpices.Add(crtSp);
            }

            var calculateRecipe = new RecipeViewModel()
            {
                Id = recipe.Id,
                Name = recipe.Name,
                Description = recipe.Description,
                ImageUrl = recipe.ImageUrl,
                Ingredients = calculateIngredients,
                Spices = calculateSpices,
            };
            model.RecipeId = recipe.Id;
            model.Recipe = calculateRecipe;
            model.ExpectedQuantity = Math.Round((model.RawQuantity * 0.55),2);

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


    }
}
