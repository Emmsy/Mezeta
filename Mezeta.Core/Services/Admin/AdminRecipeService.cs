﻿using Mezeta.Core.Contracts.Admin;
using Mezeta.Core.Models;
using Mezeta.Core.Models.Admin;
using Mezeta.Infrastructure.Data.Entities;
using Mezeta.Infrastrucute.Data;
using Microsoft.EntityFrameworkCore;

namespace Mezeta.Core.Services.Admin
{
    public class AdminRecipeService : IAdminRecipeService
    {
        private readonly ApplicationDbContext data;

        public AdminRecipeService(ApplicationDbContext _data)
        {
            data = _data;
        }

        /// <summary>
        /// Добавя рецепта в базата
        /// </summary>
        /// <param name="recipe">recipe</param>
        /// <returns></returns>
        public async Task AddRecipes(RecipeViewModel recipe)
        {

            var crtIngredients = new List<RecipeIngredient>();
            var crtSpices = new List<RecipeSpice>();

            foreach (var ing in recipe.Ingredients)
            {
                var crtIngredient = new RecipeIngredient()
                {
                    IngredientId = ing.IngredientId,
                    MeasureId = ing.MeasureId,
                    Quantity = ing.Quantity,
                };
                crtIngredients.Add(crtIngredient);
            }


            foreach (var sp in recipe.Spices)
            {
                var crtSpice = new RecipeSpice()
                {
                    SpiceId = sp.SpiceId,
                    MeasureId = sp.MeasureId,
                    Quantity = sp.Quantity,
                };
                crtSpices.Add(crtSpice);

            }

            var crtRecipe = new Recipe()
            {
                Name = recipe.Name,
                Description = recipe.Description,
                ImageUrl = recipe.ImageUrl,
                Ingredients = crtIngredients,
                Spices = crtSpices,
                Comments = new List<Comment>(),

            };

            await data.Recipes.AddAsync(crtRecipe);
            await data.SaveChangesAsync();
        }


        /// <summary>
        /// Добавя продукт в базата
        /// </summary>
        /// <param name="ingredient"></param>
        /// <returns></returns>
        public async Task AddIngredient(IngredientSpiceAddModel ingredient)
        {
            var crtingredient = new Ingredient()
            {
                Name = ingredient.Name,
                Description = ingredient.Description,
                ImageUrl = ingredient.ImageUrl,
            };

            await data.AddAsync(crtingredient);
            await data.SaveChangesAsync();
        }

        /// <summary>
        /// Добавя подправка в базата
        /// </summary>
        /// <param name="spice"></param>
        /// <returns></returns>
        public async Task AddSpice(IngredientSpiceAddModel spice)
        {
            var crtspice = new Spice()
            {
                Name = spice.Name,
                Description = spice.Description,
                ImageUrl = spice.ImageUrl,
            };

           await  data.AddAsync(crtspice);
           await data.SaveChangesAsync();
        }

        /// <summary>
        /// Взима всички мерни единици от базата
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<MeasuresViewModel>> GetAllMeasures()
        {
            return await data.Measures
                .Select(m=> new MeasuresViewModel
                {
                    Id = m.Id,
                    Unit=m.Unit,
                }).ToListAsync();
        }

        /// <summary>
        /// Взима всички имена на продуктите
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<IngredientsModel>> GetAllIngredientsName()
        {
            return await data.Ingredients
                .Select(m => new IngredientsModel
                {
                    Id = m.Id,
                    Name= m.Name,
                }).ToListAsync();
        }

        /// <summary>
        /// Взима всички имена на подправките
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<IngredientsModel>> GetAllSpicesName()
        {
            return await data.Spices
                 .Select(m => new IngredientsModel
                 {
                     Id = m.Id,
                     Name = m.Name,
                 }).ToListAsync();
        }

        /// <summary>
        /// Всичка мерните единици като стринг
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        public async Task<string> GetMeasureName(int id)
        {
            var name =await data.Measures.Where(d=>d.Id==id).Select(d=>d.Unit).FirstOrDefaultAsync() ?? string.Empty;
            return name;
        }

        /// <summary>
        /// Взима името на конкретен продукт
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        public async Task<string> GetIngredientName(int id)
        {
            var name = await data.Ingredients.Where(d => d.Id == id).Select(d => d.Name).FirstOrDefaultAsync() ?? string.Empty;
            return name;
        }

        /// <summary>
        /// Взима името на конкретна подправка
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        public async Task<string> GetSpiceName(int id)
        {
            var name = await data.Spices.Where(d => d.Id == id).Select(d => d.Name).FirstOrDefaultAsync() ?? string.Empty;
            return name;
        }
    }
}
