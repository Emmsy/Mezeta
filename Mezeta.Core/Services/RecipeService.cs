using Mezeta.Core.Contracts;
using Mezeta.Core.Models;
using Mezeta.Infrastrucute.Data;
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

        public Task<RecipeViewModel> GetAllRecipes()
        {
            throw new NotImplementedException();
        }
    }
}
