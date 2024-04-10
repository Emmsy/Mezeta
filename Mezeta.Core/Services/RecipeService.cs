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
        private static readonly List<RecipePrepairViewModel> prepairsList = new List<RecipePrepairViewModel>();

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

            var allRecipes = data.Recipes.Include(i => i.Ingredients).Include(s => s.Spices).Where(t => recipeIds.Contains(t.Id));

            var result = await allRecipes.Select(d => new RecipeViewModel()
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

        /// <summary>
        /// дърпа рецепта от базата и я мапва във вид за вюто
        /// </summary>
        /// <param name="recipeId"></param>
        /// <returns></returns>
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

        /// <summary>
        /// прибавя на потребителя рецепта в списъка със зреещи мезета
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task AddToPreparings(string userId, RecipePrepairViewModel model)
        {
            var user = await data.Users.Where(d => d.Id == userId).Include(d => d.Prepairing).FirstOrDefaultAsync();
            var crtPrepaioringsRecipes = await data.RecipesPrepairings
                .Where(d => d.UserId == userId)
                .ToListAsync();
            if (user != null)
            {

                var crtIngredients = model.Recipe.Ingredients.Select(d => new RecipeIngredient()
                {
                    IngredientId = d.IngredientId,
                    Ingredient = data.Ingredients.Where(s => s.Id == d.IngredientId).FirstOrDefault(),
                    Quantity = d.Quantity,
                    MeasureId = d.MeasureId,
                    UnitOfMeasure = data.Measures.Where(s => s.Id == d.MeasureId).FirstOrDefault(),
                }).ToList();

                var crtSpices = model.Recipe.Spices.Select(d => new RecipeSpice()
                {
                    SpiceId = d.SpiceId,
                    Spice = data.Spices.Where(s => s.Id == d.SpiceId).FirstOrDefault(),
                    Quantity = d.Quantity,
                    MeasureId = d.MeasureId,
                    UnitOfMeasure = data.Measures.Where(s => s.Id == d.MeasureId).FirstOrDefault(),
                }).ToList();

                var crtPrep = new RecipePrepairing()
                {
                    StartDate = model.StartDate,
                    RawQuantity = model.RawQuantity,
                    RecipeId = model.RecipeId,
                    //Recipe = data.Recipes.Where(s => s.Id == model.RecipeId).FirstOrDefault(),
                    ExpectedQuantity = model.ExpectedQuantity,
                };

                crtPrepaioringsRecipes.Add(crtPrep);
                user.Prepairing = crtPrepaioringsRecipes;
                await data.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<RecipePrepairViewModel>> GetPrepairingsRecipes(string userId)
        {
            var crtPrepaioringsRecipes = await data.RecipesPrepairings
               .Where(d => d.UserId == userId)
               .Select(s => new RecipePrepairViewModel()
               {
                   Id = s.Id,
                   RecipeId = s.RecipeId,
                   Recipe = new RecipeViewModel()
                   {
                       Name = s.Recipe.Name,
                       Description = s.Recipe.Description,
                       ImageUrl = s.Recipe.ImageUrl,
                       Ingredients = s.Recipe.Ingredients.Select(i => new RecipeIngredientViewModel()
                       {
                           IngredientId = i.IngredientId,
                           IngredientName = data.Ingredients.Where(f => f.Id == i.IngredientId).Select(s => s.Name).FirstOrDefault(),
                           MeasureId = i.MeasureId,
                           MeasureUnit = data.Measures.Where(f => f.Id == i.MeasureId).Select(s => s.Unit).FirstOrDefault(),
                           Quantity = i.Quantity,
                       }),

                       Spices = s.Recipe.Spices.Select(i => new RecipeSpiceViewModel()
                       {
                           SpiceId = i.SpiceId,
                           SpiceName = data.Spices.Where(f => f.Id == i.SpiceId).Select(s => s.Name).FirstOrDefault(),
                           MeasureId = i.MeasureId,
                           MeasureUnit = data.Measures.Where(f => f.Id == i.MeasureId).Select(s => s.Unit).FirstOrDefault(),
                           Quantity = i.Quantity,
                       }),

                   },
                   StartDate = s.StartDate,
                   RawQuantity = s.RawQuantity,
                   ExpectedQuantity = s.ExpectedQuantity,

               })
               .ToListAsync();


            return crtPrepaioringsRecipes;

        }

        public async Task RemoveFromPreparings(int id)
        {
            var crtRecipePreperings = await data.RecipesPrepairings.Where(f => f.Id == id).FirstOrDefaultAsync();
            data.RecipesPrepairings.Remove(crtRecipePreperings);
            await data.SaveChangesAsync();

        }


    }

}
