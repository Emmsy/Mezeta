﻿using Mezeta.Core.Contracts;
using Mezeta.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mezeta.Controllers
{
    [Authorize]
    public class MainController : Controller
    {
        private readonly IRecipeService recipeService;

        
        public MainController(IRecipeService _recipeService)
        {
            recipeService = _recipeService;
        }

        [HttpGet]
        [AllowAnonymous]
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


       

        public IActionResult Calculation()
        {
            return View();
        }
    }
}
