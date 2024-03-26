﻿using Mezeta.Core.Contracts.Admin;
using Mezeta.Core.Models;
using Mezeta.Core.Models.Admin;
using Mezeta.Infrastructure.Data.Entities;
using Mezeta.Infrastrucute.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mezeta.Core.Services.Admin
{
    public class AdminRecipeService : IAdminRecipeService
    {
        private readonly ApplicationDbContext data;

        public AdminRecipeService(ApplicationDbContext _data)
        {
            data = _data;
        }

        public Task AddRecipes(RecipeViewModel recipe)
        {
            throw new NotImplementedException();
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

        public async Task<IEnumerable<IngredientsModel>> GetAllIngredientsName()
        {
            return await data.Ingredients
                .Select(m => new IngredientsModel
                {
                    Id = m.Id,
                    Name= m.Name,
                }).ToListAsync();
        }

        public async Task<IEnumerable<IngredientsModel>> GetAllSpicesName()
        {
            return await data.Spices
                 .Select(m => new IngredientsModel
                 {
                     Id = m.Id,
                     Name = m.Name,
                 }).ToListAsync();
        }

        public async Task<string> GetMeasureName(int id)
        {
            var name =await data.Measures.Where(d=>d.Id==id).Select(d=>d.Unit).FirstOrDefaultAsync() ?? string.Empty;
            return name;
        }

        public async Task<string> GetIngredientName(int id)
        {
            var name = await data.Ingredients.Where(d => d.Id == id).Select(d => d.Name).FirstOrDefaultAsync() ?? string.Empty;
            return name;
        }
    }
}
