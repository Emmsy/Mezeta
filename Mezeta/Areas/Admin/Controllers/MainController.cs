using Mezeta.Core.Contracts;
using Mezeta.Core.Contracts.Admin;
using Mezeta.Core.Models;
using Mezeta.Core.Models.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Mezeta.Areas.Admin.Controllers
{
    [Authorize]
    public class MainController : BaseController
    {
        private readonly IRecipeService recipeService;
        private readonly IAdminRecipeService adminRecipeService;


        public MainController(IRecipeService _recipeService, IAdminRecipeService _adminRecipeService)
        {
            recipeService = _recipeService;
            adminRecipeService = _adminRecipeService;
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
            var model = new IngredientSpiceAddModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddSpice(IngredientSpiceAddModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await adminRecipeService.AddSpice(model);

            //return RedirectToAction("AllSpices", "Admin", new {area="Admin"});
            return RedirectToAction("Index","Home", new {area="Home"});
        }



        public IActionResult Edit()
        {
            return View();
        }
    }
}
