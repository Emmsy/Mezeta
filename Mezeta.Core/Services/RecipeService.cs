using Mezeta.Core.Contracts;
using Mezeta.Core.Models;
using Mezeta.Infrastructure.Data.Entities;
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
        public async Task<IEnumerable<RecipeViewModel>> GetAllRecipes()
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
                    MeasureUnit = i.UnitOfMeasure.Unit,
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
                Id = d.Id,
                Name = d.Name,
                Description = d.Description,
                ImageUrl = d.ImageUrl,
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

        /// <summary>
        /// връща всички любими рецепти
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<RecipeViewModel>> GetFavoritesRecipes(string userId)
        {
            var user = await data.Users.Where(d => d.Id == userId).Include(d => d.Favorites).FirstOrDefaultAsync();
            var recipeIds = user.Favorites.Select(d => d.Id).ToList();

            var allRecipes =  data.Recipes.Include(i => i.Ingredients).Include(s => s.Spices).Where(t => recipeIds.Contains(t.Id));

            var result = await   allRecipes.Select(d => new RecipeViewModel()
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
                    MeasureUnit = i.UnitOfMeasure.Unit,
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
        /// Добавя рецепта в списъка с любими на текущия потребител
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="recipeId"></param>
        /// <returns></returns>
        public async Task AddToFavorites(string userId, int recipeId)
        {
            var user = await data.Users.Where(d => d.Id == userId).Include(d => d.Favorites).FirstOrDefaultAsync();

            var recipe = await data.Recipes.Where(d => d.Id == recipeId)
                .Include(d => d.Ingredients).Include(d => d.Spices)
                .FirstOrDefaultAsync();
            if (user != null)
            {
                var userFavs = user.Favorites.ToList();
                var containsThisRecipe = user.Favorites.Select(d => d.Id == recipeId).FirstOrDefault();
                if (!containsThisRecipe)
                {
                    userFavs.Add(recipe);
                    user.Favorites = userFavs;
                    await data.SaveChangesAsync();
                }
            }

        }

        /// <summary>
        /// Премахва на текущия юзър рецепта от любими
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="recipeId"></param>
        /// <returns></returns>
        public async Task RemoveFromFavorites(string userId, int recipeId)
        {
            var user = await data.Users.Where(d => d.Id == userId).Include(d => d.Favorites).FirstOrDefaultAsync();
            if (user != null)
            {
                var crtRecipe = await data.Recipes
                .Where(d => d.Id == recipeId)
                .Include(d => d.Ingredients)
                .Include(d => d.Spices)
                .FirstOrDefaultAsync();

                var userFavs = user.Favorites.ToList();
                userFavs.Remove(crtRecipe);
                user.Favorites = userFavs;
                await data.SaveChangesAsync();
            }

        }

        public async Task<RecipeViewModel> GetRecipe(int recipeId)
        {
            var result = new RecipeViewModel(); 

            var recipe = await data.Recipes
                .Where(d => d.Id == recipeId)
                .Include(d => d.Ingredients)
                .Include(d => d.Spices)
                .FirstOrDefaultAsync();

            var crtIngredients = new List<RecipeIngredientViewModel>();
            var crtSpices = new List<RecipeSpiceViewModel>();
            if (recipe != null)
            {

                foreach (var item in recipe.Ingredients)
                {
                    var crtIngr = new RecipeIngredientViewModel()
                    {
                        IngredientId = item.IngredientId,
                        IngredientName = await data.Ingredients.Where(d => d.Id == item.IngredientId).Select(d => d.Name).FirstOrDefaultAsync(),
                        Quantity = item.Quantity,
                        MeasureId = item.MeasureId,
                        MeasureUnit = await data.Measures.Where(d => d.Id == item.MeasureId).Select(d => d.Unit).FirstOrDefaultAsync(),
                    };
                    crtIngredients.Add(crtIngr);
                }

                foreach (var item in recipe.Spices)
                {
                    var crtSpice = new RecipeSpiceViewModel()
                    {
                        SpiceId = item.SpiceId,
                        SpiceName = await data.Spices.Where(d => d.Id == item.SpiceId).Select(d => d.Name).FirstOrDefaultAsync(),
                        Quantity = item.Quantity,
                        MeasureId = item.MeasureId,
                        MeasureUnit = await data.Measures.Where(d => d.Id == item.MeasureId).Select(d => d.Unit).FirstOrDefaultAsync(),
                    };
                    crtSpices.Add(crtSpice);
                }

                result = new RecipeViewModel()
                {
                    Id = recipe.Id,
                    Name = recipe.Name,
                    Description = recipe.Description,
                    ImageUrl = recipe.ImageUrl,
                    Ingredients = crtIngredients,
                    Spices = crtSpices

                };
            }

            return result;
        }
        public async Task<RecipePrepairViewModel> AddToPreparings(string userId, int recipeId)
        {
            var user = await data.Users.Where(d => d.Id == userId).Include(d => d.Prepairing).FirstOrDefaultAsync();
            var crtRecipe = await data.Recipes
                .Where(d => d.Id == recipeId)
                .Include(d => d.Ingredients)
                .Include(d => d.Spices)
                .FirstOrDefaultAsync();
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RecipeViewModel>> GetPrepairingsRecipes(string userId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveFromPreparings(string userId, int recipeId)
        {
            throw new NotImplementedException();
        }

      
    }

}
