﻿using Mezeta.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mezeta.Core.Contracts
{
    public interface IRecipeService
    {
        Task<IEnumerable<RecipeViewModel>> GetAllRecipes();
        Task<IEnumerable<IngredientSpiceGetModel>> GetAllIngredients();
        Task<IEnumerable<IngredientSpiceGetModel>> GetAllSpices();

        Task<RecipeViewModel> GetRecipe(int recipeId);

        Task<IEnumerable<RecipeViewModel>> GetFavoritesRecipes(string userId);
        Task AddToFavorites(string userId, int recipeId);
        Task RemoveFromFavorites(string userId, int recipeId);

        Task<IEnumerable<RecipePrepairViewModel>> GetPrepairingsRecipes(string userId);
        Task AddToPreparings(string userId, RecipePrepairViewModel model);
        Task RemoveFromPreparings(int recipeId);

    }
}
