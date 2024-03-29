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
        private readonly IRecipeService recipeService;
        private static List<RecipeIngredientViewModel> listofIngredients = new List<RecipeIngredientViewModel>();
        private static List<RecipeSpiceViewModel> listofSpices = new List<RecipeSpiceViewModel>();
       
        public MainController(IAdminRecipeService _adminRecipeService, 
            IRecipeService _recipeService)
        {
            adminRecipeService = _adminRecipeService;
            recipeService = _recipeService;
        }

        [HttpGet]
        public IActionResult All()
        {
            return View();
        }


        //public IActionResult Edit()
        //{
        //    return View();
        //}
    }
}
