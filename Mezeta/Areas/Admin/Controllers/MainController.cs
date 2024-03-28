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
        private readonly IAdminRecipeService adminRecipeService;
        private static List<RecipeIngredientViewModel> listofIngredients = new List<RecipeIngredientViewModel>();
        private static List<RecipeSpiceViewModel> listofSpices = new List<RecipeSpiceViewModel>();
       
        public MainController(IAdminRecipeService _adminRecipeService)
        {
            adminRecipeService = _adminRecipeService;
        }

        [HttpGet]
        public IActionResult All()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AllIngredients()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AllIngredients(List<IngredientSpiceGetModel> model)
        {

            return View(model);
        }

        public IActionResult Edit()
        {
            return View();
        }
    }
}
