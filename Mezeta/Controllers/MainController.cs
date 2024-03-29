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
        public async Task<IActionResult> AllRecipes()
        {
            var allRecipies =  await recipeService.GetAllRecipes();

            return View(allRecipies);
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

        public IActionResult Calculation()
        {
            return View();
        }
    }
}
