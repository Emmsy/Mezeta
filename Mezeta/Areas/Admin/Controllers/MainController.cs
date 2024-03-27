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

        /// <summary>
        /// Създава нова рецепта
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult AddRecipe()
        {
            var model = new RecipeViewModel()
            {
                Ingredients = listofIngredients,
                Spices = listofSpices
            };

            

            return View(model);
        }

        /// <summary>
        /// Създава нова рецепта
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddRecipe(RecipeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            model.Spices=listofSpices;
            model.Ingredients=listofIngredients;

            await adminRecipeService.AddRecipes(model);

            listofIngredients = new List<RecipeIngredientViewModel>();
            listofSpices = new List<RecipeSpiceViewModel>();

            return RedirectToAction("Index", "Home", new { area = "Home" });
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

        /// <summary>
        /// Добавяне на лист от продукти за текуща рецепта
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> AddListIngredient()
        {

            var model = new IngredientViewModel()
            {
                Ingredients = await adminRecipeService.GetAllIngredientsName(),
                Measures = await adminRecipeService.GetAllMeasures(),
                AddedIngredients= listofIngredients
            };
            return View(model);
        }

        /// <summary>
        /// Добавяне на лист от продукти за текуща рецепта
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddListIngredient(IngredientViewModel model)
        {
            
            var crt = new RecipeIngredientViewModel()
            {
                IngredientId =  model.IngredientId,
                IngredientName= await adminRecipeService.GetIngredientName(model.IngredientId),
                MeasureId = model.MeasureId,
                MeasureUnit= await adminRecipeService.GetMeasureName(model.MeasureId),
                Quantity = model.Quantity,
            };
             listofIngredients.Add(crt);

            return RedirectToAction("AddListIngredient", "Main", new { area = "Admin" });
        }

        /// <summary>
        ///  Добавяне на лист от подправки за текуща рецепта
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> AddListSpice()
        {

            var model = new SpiceViewModel()
            {
                Spices = await adminRecipeService.GetAllSpicesName(),
                Measures = await adminRecipeService.GetAllMeasures(),
                AddedSpices = listofSpices
            };
            return View(model);
        }

        /// <summary>
        /// Добавяне на лист от подправки за текуща рецепта
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddListSpice(SpiceViewModel model)
        {

            var crt = new RecipeSpiceViewModel()
            {
                SpiceId = model.SpiceId,
                SpiceName = await adminRecipeService.GetSpiceName(model.SpiceId),
                MeasureId = model.MeasureId,
                MeasureUnit = await adminRecipeService.GetMeasureName(model.MeasureId),
                Quantity = model.Quantity,
            };
            listofSpices.Add(crt);

            return RedirectToAction("AddListSpice", "Main", new { area = "Admin" });
        }

        [HttpPost]
        public IActionResult ClearScreanForRecipe()
        {
            listofIngredients = new List<RecipeIngredientViewModel>();
            listofSpices = new List<RecipeSpiceViewModel>();
            return RedirectToAction("AddRecipe", "Main", new { area = "Admin" });
        }



        public IActionResult Edit()
        {
            return View();
        }
    }
}
