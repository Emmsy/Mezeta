using Mezeta.Core.Contracts;
using Mezeta.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mezeta.Controllers
{
    //[Authorize]
    public class MainController : Controller
    {
        private readonly IRecipeService recipeService;

        
        public MainController(IRecipeService _recipeService)
        {
            recipeService = _recipeService;
        }

        [HttpGet]
        //[AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            var allRecipies =  await recipeService.GetAllRecipes();

            return View(allRecipies);
        }

        //public IActionResult View()
        //{
        //    return View();
        //}


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

        public IActionResult Calculation()
        {
            return View();
        }
    }
}
