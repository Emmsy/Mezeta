using Mezeta.Core.Contracts;
using Mezeta.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;

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

        /// <summary>
        /// дава основна информация за уменията за домашно поризводство на мезета
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// показва всичките рецепти
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> AllRecipes(int page=1, string sorting = "Newest")
        {
            var allRecipies =  await recipeService.GetAllRecipes();
            var recipePageView = new PagesViewModel()
            {
                RecipePerPage = 2,
                Recipes = allRecipies,
                CurrentPage = page,
                Sorting = sorting
            };

            return View(recipePageView);
        }

        /// <summary>
        /// показва всичките продукти
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> AllIngredients()
        {
            var model = await recipeService.GetAllIngredients();
            return View(model);
        }

        /// <summary>
        /// показва всичките подправки
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> AllSpices()
        {
            var model = await recipeService.GetAllSpices();
            return View(model);
        }


        /// <summary>
        /// показва списъка с любими рецепти
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Favorites() 
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account", new { area = "Identity" });
            }
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var model = await recipeService.GetFavoritesRecipes(userId);
            return View(model);
        }

        /// <summary>
        /// добавя рецепта в списъка с любими
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddToFavorites(int recipeId)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account", new { area = "Identity" });
            }
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await recipeService.AddToFavorites(userId, recipeId);

            return RedirectToAction("Favorites", "Main");
        }

        /// <summary>
        /// Премахва рецепта от списъка с любими
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> RemoveFromFavorites(int recipeId)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account", new { area = "Identity" });
            }
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await recipeService.RemoveFromFavorites(userId, recipeId);

            return RedirectToAction("Favorites", "Main");
        }


        /// <summary>
        /// показва пълно описание и съдържание на конкретна рецепта
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
          
            var model = await recipeService.GetRecipe(id);
            return View(model);
        }
    }
}
