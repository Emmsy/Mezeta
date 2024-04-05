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
        Task AddRecipes(RecipeViewModel recipe);
        Task<RecipeViewModel> GetRecipe(int id);
        Task EditRecipe(int id,RecipeViewModel recipe);
        Task DeleteRecipe(int id);

        Task AddSpice(IngredientSpiceAddModel spice);
        Task<IngredientSpiceGetModel> GetSpice(int id);
        Task EditSpice(int id, IngredientSpiceGetModel ingredient);
        Task DeleteSpice(int id);

        Task AddIngredient(IngredientSpiceAddModel ingredient);
        Task<IngredientSpiceGetModel> GetIngredient(int id);
        Task EditIngredient(int id, IngredientSpiceGetModel ingredient);
        Task DeleteIngredient(int id);

        Task<IEnumerable<MeasuresViewModel>> GetAllMeasures();
        Task<IEnumerable<IngredientsModel>> GetAllIngredientsName();
        Task<IEnumerable<IngredientsModel>> GetAllSpicesName();

        Task<string> GetMeasureName(int id);
        Task<string> GetIngredientName(int id);
        Task<string> GetSpiceName(int id);
    }
}
