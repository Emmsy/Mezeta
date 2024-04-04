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

        /// <summary>
        /// връща всички любими рецепти
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<RecipeViewModel>> GetFavoritesRecipes(string userId)
        {
            var user = await data.Users.Where(d => d.Id == userId).Include(d=>d.Favorites).FirstOrDefaultAsync();
            var recipe =  user.Favorites.ToList();
            var result = new List<RecipeViewModel>();
           
            foreach (var item in recipe)
            {
                var crt = new RecipeViewModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    ImageUrl = item.ImageUrl,
                };
                result.Add(crt);
            }

            return result;
        }

        /// <summary>
        /// Добавя рецепта в списъка с любими на текущия потребител
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="recipeId"></param>
        /// <returns></returns>
        public async Task AddToFavorites(string userId,int recipeId)
        {
            var user = await data.Users.Where(d => d.Id == userId).Include(d=>d.Favorites).FirstOrDefaultAsync();

            var recipe = await data.Recipes.Where(d => d.Id == recipeId).FirstOrDefaultAsync();
            if (user != null)
            {
                var userFavs = user.Favorites.ToList();
                var containsThisRecipe =  user.Favorites.Select(d=>d.Id == recipeId).FirstOrDefault();
                if (!containsThisRecipe)
                {
                    userFavs.Add(recipe);
                    user.Favorites = userFavs;
                    await data.SaveChangesAsync(); 
                }          
            }
           
        }

    
        public Task AddToPreparings(string userId, int recipeId)
        {
            throw new NotImplementedException();
        }
    }    
    
}
