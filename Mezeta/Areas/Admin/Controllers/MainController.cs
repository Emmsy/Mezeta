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
        private static List<RecipeIngredientViewModel> listofIngredients = new List<RecipeIngredientViewModel>();
        private static List<RecipeSpiceViewModel> listofSpices = new List<RecipeSpiceViewModel>();
       




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
            var model = new RecipeViewModel()
            {
                Ingredients = new List<RecipeIngredientViewModel>(),
                Spices = new List<RecipeSpiceViewModel>(),

            };

            return View(model);
        }

        [HttpPost]
        public IActionResult AddRecipe(RecipeViewModel model)
        {
            

            return View(model);
        }

        /// <summary>
        /// Добавя Продукт
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult AddIngredient()
        {
            return View();
        }
        /// <summary>
        /// Добавя Продукт
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddIngredient(IngredientSpiceAddModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await adminRecipeService.AddIngredient(model);

            //return RedirectToAction("AllSpices", "Admin", new {area="Admin"});
            return RedirectToAction("Index", "Home", new { area = "Home" });
        }

        /// <summary>
        /// Добавя подправка
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult AddSpice()
        {
            var model = new IngredientSpiceAddModel();
            return View(model);
        }
        /// <summary>
        /// Добавя подправка
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
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

        [HttpGet]
        public async Task<IActionResult> AddListIngredient()
        {
            var addedIngredients = new List<AddedIngredientModel>();
            if (listofIngredients.Count >0)
            {
                foreach (var item in listofIngredients)
                {
                    var crt = new AddedIngredientModel()
                    {
                        IngredientName = await adminRecipeService.GetIngredientName(item.IngredientId),
                        MeasureName=await adminRecipeService.GetMeasureName(item.MeasureId),
                        Quantity = item.Quantity,
                    };

                    addedIngredients.Add(crt);
                }
            }
            var model = new IngredientSpiceViewModel()
            {
                Ingredients = await adminRecipeService.GetAllIngredientsName(),
                Measures = await adminRecipeService.GetAllMeasures(),
                AddedIngredients=addedIngredients
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddListIngredient(IngredientSpiceViewModel model)
        {
            
            var crt = new RecipeIngredientViewModel()
            {
                IngredientId = model.IngredientId,
                MeasureId = model.MeasureId,
                Quantity = model.Quantity,
            };
            listofIngredients.Add(crt);

            return RedirectToAction("AddListIngredient", "Main", new { area = "Admin" });
        }

        //[HttpGet]
        //public async Task<IActionResult> ListIngredientToShow()
        //{
        //    return View(listofIngredients);
        //}


      
        public IActionResult Edit()
        {
            return View();
        }
    }
}
