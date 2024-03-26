using Mezeta.Core.Contracts;
using Mezeta.Core.Models;
using Mezeta.Infrastrucute.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mezeta.Core.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly ApplicationDbContext data;

        public RecipeService(ApplicationDbContext _data)
        {
           data = _data;
        }

        public async Task <IEnumerable<RecipeViewModel>> GetAllRecipes()
        {

            //var result =  await data.Recipes.Select(d=> new RecipeViewModel()
            //{
            //    Id = d.Id,
            //    Name = d.Name,
            //    Description = d.Description,
            //    ImageUrl = d.ImageUrl,
            //    Ingredients = d.Ingredients.Select(i => new RecipeIngredientViewModel()
            //    {
            //        Name = i.Ingredient.Name,
            //        Quantity = i.Quantity,
            //        MeasureId = i.MeasureId,
            //    }).ToList(),
            //    Spices = d.Spices.Select(s => new RecipeSpiceViewModel()
            //    {
            //        Name = s.Spice.Name,
            //        Quantity = s.Quantity,
            //        MeasureId=s.MeasureId
            //    }).ToList()

            //}).ToListAsync();

            //return result;
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RecipeSpiceViewModel>> GetAllSpices()
        {
            throw new NotImplementedException();
        }


        public Task<IEnumerable<RecipeIngredientViewModel>> GetAllIngredients()
        {
            throw new NotImplementedException();
        }

   
    }
}
