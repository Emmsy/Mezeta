using Mezeta.Core.Contracts;
using Mezeta.Core.Models;
using Mezeta.Infrastrucute.Data;
using Microsoft.EntityFrameworkCore;

namespace Mezeta.Core.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly ApplicationDbContext data;

        public RecipeService(ApplicationDbContext _data)
        {
           data = _data;
        }
        /// <summary>
        /// Взима всички рецепти от базата
        /// </summary>
        /// <returns></returns>
        public async Task <IEnumerable<RecipeViewModel>> GetAllRecipes()
        {

            var result = await data.Recipes.Select(d => new RecipeViewModel()
            {
                Id = d.Id,
                Name = d.Name,
                Description = d.Description,
                ImageUrl = d.ImageUrl,

                Ingredients = d.Ingredients.Select(i => new RecipeIngredientViewModel()
                {
                    IngredientId = i.Id,
                    IngredientName = i.Ingredient.Name,
                    Quantity = i.Quantity,
                    MeasureId = i.MeasureId,
                    MeasureUnit=i.UnitOfMeasure.Unit,
                }).ToList(),

                Spices = d.Spices.Select(s => new RecipeSpiceViewModel()
                {
                    SpiceId = s.Id,
                    SpiceName = s.Spice.Name,
                    Quantity = s.Quantity,
                    MeasureId = s.MeasureId,
                    MeasureUnit = s.UnitOfMeasure.Unit,
                }).ToList()

            }).ToListAsync();

            return result;

        }
        /// <summary>
        /// Взима всички подправки от базата
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<IngredientSpiceGetModel>> GetAllSpices()
        {

            var result = await data.Spices.Select(d => new IngredientSpiceGetModel()
            {
                Id= d.Id,
                Name = d.Name,
                Description = d.Description,
                ImageUrl= d.ImageUrl,
            }).ToListAsync();

            return result;
        }

        /// <summary>
        /// Взима всички продукти от базата
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<IngredientSpiceGetModel>> GetAllIngredients()
        {

            var result = await data.Ingredients.Select(d => new IngredientSpiceGetModel()
            {
                Id = d.Id,
                Name = d.Name,
                Description = d.Description,
                ImageUrl = d.ImageUrl,
            }).ToListAsync();

            return result;
        }

   
    }
}
