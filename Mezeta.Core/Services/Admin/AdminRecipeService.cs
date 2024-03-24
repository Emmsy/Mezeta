using Mezeta.Core.Contracts.Admin;
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

        public Task AddIngredient(IngredientSpiceAddModel ingredient)
        {
            throw new NotImplementedException();
        }

 
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

        public async Task<IEnumerable<MeasuresViewModel>> GetAllMeasures()
        {
            return await data.Measures
                .Select(m=> new MeasuresViewModel
                {
                    Id = m.Id,
                    Unit=m.Unit,
                }).ToListAsync();
        }
    }
}
