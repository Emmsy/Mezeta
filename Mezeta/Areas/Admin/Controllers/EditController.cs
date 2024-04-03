using Mezeta.Core.Contracts.Admin;
using Mezeta.Core.Models.Admin;
using Mezeta.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Mezeta.Areas.Admin.Controllers
{
    public class EditController : BaseController
    {
        private readonly IAdminRecipeService adminRecipeService;
        private static List<RecipeIngredientViewModel> listofIngredients = new List<RecipeIngredientViewModel>();
        private static List<RecipeSpiceViewModel> listofSpices = new List<RecipeSpiceViewModel>();
        private static RecipeViewModel tempRecipe = new RecipeViewModel();

        public EditController(IAdminRecipeService _adminRecipeService)
        {
            adminRecipeService = _adminRecipeService;
        }

        /// <summary>
        /// редактиране на рецепта
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> EditRecipe(int id)
        {
            var model = await adminRecipeService.GetRecipe(id);
            tempRecipe = model;

            return View(model);
        }

        /// <summary>
        /// редактиране на рецепта
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>

        [HttpPost]
        public async Task<IActionResult> EditRecipe(int id,RecipeViewModel model)
        {
            model.Spices = tempRecipe.Spices;
            model.Ingredients = tempRecipe.Ingredients;
            tempRecipe = model;

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await adminRecipeService.EditRecipe(id,model);

            listofIngredients = new List<RecipeIngredientViewModel>();
            listofSpices = new List<RecipeSpiceViewModel>();


            return RedirectToAction("AllRecipes", "Main", new { area = "Home" });
        }

        /// <summary>
        /// Редактира Продукт
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> EditIngredient(int id)
        {
            var model = await adminRecipeService.GetIngredient(id);

            return View(model);
        }
        /// <summary>
        /// Добавя Продукт
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> EditIngredient(int id,IngredientSpiceGetModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await adminRecipeService.EditIngredient(id,model);

            return RedirectToAction("AllIngredients", "Main", new { area = "Home" });
        }

        /// <summary>
        /// Добавя подправка
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> EditSpice(int id)
        {
            var model = await adminRecipeService.GetSpice(id);
            return View(model);
        }

        /// <summary>
        /// Добавя подправка
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> EditSpice(int id, IngredientSpiceGetModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await adminRecipeService.EditSpice(id,model);

            return RedirectToAction("AllSpices", "Main", new { area = "Home" });
        }

    }
}
