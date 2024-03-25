using Mezeta.Core.Models;
using Mezeta.Core.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mezeta.Core.Contracts.Admin
{
    public interface IAdminRecipeService
    {
        //Task<IEnumerable<RecipeViewModel>> GetAllRecipes();
        //Task<IEnumerable<RecipeSpiceViewModel>> GetAllSpices();
        //Task<IEnumerable<RecipeIngredientViewModel>> GetAllIngredients();

        Task AddRecipes(RecipeViewModel recipe);
        Task AddSpice(IngredientSpiceAddModel spice);
        Task AddIngredient(IngredientSpiceAddModel ingredient);
        Task<IEnumerable<MeasuresViewModel>> GetAllMeasures();
    }
}
