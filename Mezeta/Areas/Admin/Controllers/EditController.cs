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
        private static bool isIngredientsRecipeAdded = false;
        private static bool isSpicesRecipeAdded = false;

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
            int crtId = id;
            if (id == 0)
            {
                crtId = tempRecipe.Id;
            }
        
            var model = await adminRecipeService.GetRecipe(crtId);
            if(listofIngredients.Count>0 )
            {
                model.Ingredients = listofIngredients;         
            }

            if (listofSpices.Count > 0)
            {
                model.Spices = listofSpices;
            }

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
        public async Task<IActionResult> EditRecipe(int id, RecipeViewModel model)
        {
            model.Spices = tempRecipe.Spices;
            model.Ingredients = tempRecipe.Ingredients;
            tempRecipe = model;

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await adminRecipeService.EditRecipe(id, model);

            listofIngredients = new List<RecipeIngredientViewModel>();
            listofSpices = new List<RecipeSpiceViewModel>();
            isIngredientsRecipeAdded=false;
            isSpicesRecipeAdded=false;


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
        public async Task<IActionResult> EditIngredient(int id, IngredientSpiceGetModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await adminRecipeService.EditIngredient(id, model);

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

            await adminRecipeService.EditSpice(id, model);

            return RedirectToAction("AllSpices", "Main", new { area = "Home" });
        }


        /// <summary>
        /// Редактиране на лист от продукти за текуща рецепта
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> EditListIngredient(int id)
        {
            if (isIngredientsRecipeAdded == false)
            {
                var recipe = await adminRecipeService.GetRecipe(id);
               listofIngredients=recipe.Ingredients.ToList();
                
            }

            var model = new IngredientViewModel()
            {
                Ingredients = await adminRecipeService.GetAllIngredientsName(),
                Measures = await adminRecipeService.GetAllMeasures(),
                AddedIngredients = listofIngredients,
            };

            return View(model);
        }

        /// <summary>
        /// Редактиране на лист от продукти за текуща рецепта
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> EditListIngredient(IngredientViewModel model)
        {

            isIngredientsRecipeAdded = true;

            var crt = new RecipeIngredientViewModel()
            {
                IngredientId = model.IngredientId,
                IngredientName = await adminRecipeService.GetIngredientName(model.IngredientId),
                MeasureId = model.MeasureId,
                MeasureUnit = await adminRecipeService.GetMeasureName(model.MeasureId),
                Quantity = model.Quantity,
            };
            listofIngredients.Add(crt);

            return RedirectToAction("EditListIngredient", "Edit", new { area = "Admin" });
        }


        /// <summary>
        /// изтрива продукт от листа преди редакция на рецептата
        /// </summary>
        /// <param name="id"></param>
        /// <param name="quantity"></param>
        /// <param name="measureId"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult DeleteIngredientFromList(int id, double quantity, int measureId)
        {
            var crt = listofIngredients
                .Where(x => x.IngredientId == id
                && x.Quantity == quantity
                && x.MeasureId == measureId)
                .FirstOrDefault();

            listofIngredients.Remove(crt);

            return RedirectToAction("EditListIngredient", "Edit", new { area = "Admin" });
        }


        /// <summary>
        /// Редактиране на лист от продукти за текуща рецепта
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> EditListSpice(int id)
        {
            if (isSpicesRecipeAdded == false)
            {
                var recipe = await adminRecipeService.GetRecipe(id);
                listofSpices = recipe.Spices.ToList();

            }

            var model = new SpiceViewModel()
            {
                Spices = await adminRecipeService.GetAllSpicesName(),
                Measures = await adminRecipeService.GetAllMeasures(),
                AddedSpices = listofSpices,
            };

            return View(model);
        }

        /// <summary>
        /// Редактиране на лист от продукти за текуща рецепта
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> EditListSpice(SpiceViewModel model)
        {

            isSpicesRecipeAdded = true;

            var crt = new RecipeSpiceViewModel()
            {
                SpiceId = model.SpiceId,
                SpiceName = await adminRecipeService.GetSpiceName(model.SpiceId),
                MeasureId = model.MeasureId,
                MeasureUnit = await adminRecipeService.GetMeasureName(model.MeasureId),
                Quantity = model.Quantity,
            };
            listofSpices.Add(crt);

            return RedirectToAction("EditListSpice", "Edit", new { area = "Admin" });
        }


        /// <summary>
        /// изтрива продукт от листа преди редакция на рецептата
        /// </summary>
        /// <param name="id"></param>
        /// <param name="quantity"></param>
        /// <param name="measureId"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult DeleteSpiceFromList(int id, double quantity, int measureId)
        {
            var crt = listofSpices
                .Where(x => x.SpiceId == id
                && x.Quantity == quantity
                && x.MeasureId == measureId)
                .FirstOrDefault();

            listofSpices.Remove(crt);

            return RedirectToAction("EditListSpice", "Edit", new { area = "Admin" });
        }
        /// <summary>
        /// Изчиства формата за попълване за добавяне на рецепта
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult ClearScreanForRecipe()
        {
            listofIngredients = new List<RecipeIngredientViewModel>();
            listofSpices = new List<RecipeSpiceViewModel>();
            tempRecipe = new RecipeViewModel();
            isIngredientsRecipeAdded = false;
            isSpicesRecipeAdded = false;
            return RedirectToAction("EditRecipe", "Edit", new { area = "Admin" });
        }


    }
}
