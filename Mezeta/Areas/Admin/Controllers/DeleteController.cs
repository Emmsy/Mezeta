using Mezeta.Core.Contracts.Admin;
using Mezeta.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Mezeta.Areas.Admin.Controllers
{
    public class DeleteController : BaseController
    {
        private readonly IAdminRecipeService adminRecipeService;
     

        public DeleteController(IAdminRecipeService _adminRecipeService)
        {
            adminRecipeService = _adminRecipeService;
        }

        /// <summary>
        /// Изтрива рецепта от базата
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> DeleteRecipe(int id)
        {
            await adminRecipeService.DeleteRecipe(id);

            return RedirectToAction("AllRecipes", "Main", new { area = "Home" });
        }

        /// <summary>
        /// Изтрива продукт от базата
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> DeleteIngredient(int id)
        {

            await adminRecipeService.DeleteIngredient(id);

            return RedirectToAction("AllIngredients", "Main", new { area = "Home" });
        }

        /// <summary>
        /// изтрива подправка от базата
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> DeleteSpice(int id)
        {

            await adminRecipeService.DeleteSpice(id);

            return RedirectToAction("AllSpices", "Main", new { area = "Home" });
        }


    }
}
