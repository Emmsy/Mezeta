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
        Task<RecipeViewModel> GetRecipe(int id);
        Task EditRecipe(int id,RecipeViewModel recipe);

        Task AddSpice(IngredientSpiceAddModel spice);
        Task<IngredientSpiceGetModel> GetSpice(int id);
        Task EditSpice(int id, IngredientSpiceGetModel ingredient);

        Task AddIngredient(IngredientSpiceAddModel ingredient);
        Task<IngredientSpiceGetModel> GetIngredient(int id);
        Task EditIngredient(int id, IngredientSpiceGetModel ingredient);

        Task<IEnumerable<MeasuresViewModel>> GetAllMeasures();
        Task<IEnumerable<IngredientsModel>> GetAllIngredientsName();
        Task<IEnumerable<IngredientsModel>> GetAllSpicesName();

        Task<string> GetMeasureName(int id);
        Task<string> GetIngredientName(int id);
        Task<string> GetSpiceName(int id);
    }
}
