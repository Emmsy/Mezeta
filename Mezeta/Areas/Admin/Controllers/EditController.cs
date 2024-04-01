﻿using Mezeta.Core.Contracts.Admin;
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


        [HttpGet]
        public async Task<IActionResult> EditRecipe(int id)
        {
            var model = await adminRecipeService.GetRecipe(id);
            tempRecipe = model;

            return View(model);
        }


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
            
            //if (listofIngredients.Count == 0)
            //{
            //    TempData["ErrorMessage"] = "Трябва да добавите продукти";
            //    return View(tempRecipe);
            //}
            //if (listofSpices.Count == 0)
            //{
            //    TempData["ErrorMessage"] = "Трябва да добавите подправки";
            //    return View(tempRecipe);
            //}

            await adminRecipeService.EditRecipe(id,model);

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
            return RedirectToAction("Index", "Home", new { area = "Home" });
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
                AddedIngredients = listofIngredients
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
                IngredientId = model.IngredientId,
                IngredientName = await adminRecipeService.GetIngredientName(model.IngredientId),
                MeasureId = model.MeasureId,
                MeasureUnit = await adminRecipeService.GetMeasureName(model.MeasureId),
                Quantity = model.Quantity,
            };
            listofIngredients.Add(crt);

            return RedirectToAction("AddListIngredient", "Add", new { area = "Admin" });
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

            return RedirectToAction("AddListSpice", "Add", new { area = "Admin" });
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
            tempRecipe=new RecipeViewModel();
            return RedirectToAction("AddRecipe", "Add", new { area = "Admin" });
        }

    }
}
