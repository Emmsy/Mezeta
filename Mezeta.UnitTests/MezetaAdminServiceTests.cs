using Mezeta.Core.Contracts.Admin;
using Mezeta.Core.Models;
using Mezeta.Core.Models.Admin;
using Mezeta.Core.Services.Admin;
using Mezeta.Infrastructure.Data.Entities;
using Mezeta.Infrastrucute.Data;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Mezeta.UnitTests
{
    [TestFixture]
    public class MezetaAdminServiceTests
    {
        private IAdminRecipeService admineRecipeService;
        private ApplicationDbContext applicationDbContext;


        [SetUp]
        public void Setup()
        {
            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase("MezetaInMemoryDB")
               .Options;

            applicationDbContext = new ApplicationDbContext(contextOptions);

            applicationDbContext.Database.EnsureDeleted();
            applicationDbContext.Database.EnsureCreated();
            admineRecipeService = new AdminRecipeService(applicationDbContext);
        }

        [Test]
        public async Task AddIngredientTest()
        {

            var ingredient = new IngredientSpiceAddModel()
            {
                Name = "Ingredient Test",
                Description = "Test ingredient decpription",
                ImageUrl = "",
            };

            await admineRecipeService.AddIngredient(ingredient);
            await applicationDbContext.SaveChangesAsync();
            var result = await applicationDbContext.Ingredients.Where(x => x.Id == 3).FirstOrDefaultAsync();
            Assert.That(result.Name, Is.EqualTo("Ingredient Test"));
            Assert.That(result.Description, Is.EqualTo("Test ingredient decpription"));
            Assert.That(result.ImageUrl, Is.EqualTo(""));
        }

        [Test]
        public async Task AddSpiceTest()
        {

            var spice = new IngredientSpiceAddModel()
            {
                Name = "Ingredient Test",
                Description = "Test ingredient decpription",
                ImageUrl = "",
            };

            await admineRecipeService.AddSpice(spice);
            await applicationDbContext.SaveChangesAsync();
            var result = await applicationDbContext.Spices.Where(x => x.Id == 6).FirstOrDefaultAsync();
            Assert.That(result.Name, Is.EqualTo(spice.Name));
            Assert.That(result.Description, Is.EqualTo(spice.Description));
            Assert.That(result.ImageUrl, Is.EqualTo(spice.ImageUrl));
        }

        [Test]
        public async Task GetMeasureFromDbTest()
        {
            var result = await applicationDbContext.Measures.ToListAsync();

            Assert.That(result[0].Id, Is.EqualTo(1));
            Assert.That(result[0].Unit, Is.EqualTo("g"));
        }

        [Test]
        public async Task GetAllMeasuresTest()
        {
            var result = await admineRecipeService.GetAllMeasures();
            var list = result.ToList();
            Assert.That(list[1].Id, Is.EqualTo(2));
            Assert.That(list[1].Unit, Is.EqualTo("kg"));
        }


        [Test]
        public async Task GetMeasureNameTest()
        {
            var resultEl1 = await admineRecipeService.GetMeasureName(1);
            var resultEl3 = await admineRecipeService.GetMeasureName(3);
            Assert.That(resultEl1, Is.EqualTo("g"));
            Assert.That(resultEl3, Is.EqualTo("ml"));
        }


        [Test]
        public async Task GetAllIngredientsNameTest()
        {
            var result = await admineRecipeService.GetAllIngredientsName();
            var list = result.ToList();
            Assert.That(list[1].Id, Is.EqualTo(2));
            Assert.That(list[1].Name, Is.EqualTo("Свинска плешка"));
        }

        [Test]
        public async Task GetIngredientNameTest()
        {
            var resultEl1 = await admineRecipeService.GetIngredientName(1);
            var resultEl2 = await admineRecipeService.GetIngredientName(2);
            Assert.That(resultEl1, Is.EqualTo("Телешки шол"));
            Assert.That(resultEl2, Is.EqualTo("Свинска плешка"));
        }

        [Test]
        public async Task GetIngredientTest()
        {
            var result = await admineRecipeService.GetIngredient(1);
            Assert.That(result.Name, Is.EqualTo("Телешки шол"));
            Assert.That(result.Id, Is.EqualTo(1));
        }


        [Test]
        public async Task EditIngredientTest()
        {
            var result = applicationDbContext.Ingredients.Where(d => d.Id == 1).FirstOrDefault();
            IngredientSpiceGetModel model = new IngredientSpiceGetModel()
            {
                Name = "Edit Name",
                Description = "Edit Description",
                ImageUrl = ""
            };

            Assert.That(result.Name, Is.EqualTo("Телешки шол"));

            await admineRecipeService.EditIngredient(1, model);

            Assert.That(result.Id, Is.EqualTo(1));
            Assert.That(result.Name, Is.EqualTo("Edit Name"));
            Assert.That(result.Description, Is.EqualTo("Edit Description"));
        }


        [Test]
        public async Task DeleteIngredientTest()
        {
            var result = applicationDbContext.Ingredients.Where(d => d.Id == 1).FirstOrDefault();

            Assert.That(result.Name, Is.EqualTo("Телешки шол"));

            await admineRecipeService.DeleteIngredient(1);

            result = applicationDbContext.Ingredients.Where(d => d.Id == 1).FirstOrDefault();
            Assert.That(result, Is.Null);

        }

        [Test]
        public async Task GetAllSpicesNameTest()
        {
            var result = await admineRecipeService.GetAllSpicesName();
            var list = result.ToList();
            Assert.That(list[1].Id, Is.EqualTo(2));
            Assert.That(list[1].Name, Is.EqualTo("Витамин Ц на прах"));
        }

        [Test]
        public async Task GetSpiceNameTest()
        {
            var resultEl1 = await admineRecipeService.GetSpiceName(1);
            var resultEl2 = await admineRecipeService.GetSpiceName(4);
            Assert.That(resultEl1, Is.EqualTo("Нитритна сол"));
            Assert.That(resultEl2, Is.EqualTo("Кимион"));
        }

        [Test]
        public async Task GetSpiceTest()
        {
            var result = await admineRecipeService.GetSpice(1);
            Assert.That(result.Id, Is.EqualTo(1));
            Assert.That(result.Name, Is.EqualTo("Нитритна сол"));
        }

        [Test]
        public async Task EditSpiceTest()
        {
            var result = applicationDbContext.Spices.Where(d => d.Id == 1).FirstOrDefault();
            IngredientSpiceGetModel model = new IngredientSpiceGetModel()
            {
                Name = "Edit Name",
                Description = "Edit Description",
                ImageUrl = ""
            };

            Assert.That(result.Name, Is.EqualTo("Нитритна сол"));

            await admineRecipeService.EditSpice(1, model);

            Assert.That(result.Id, Is.EqualTo(1));
            Assert.That(result.Name, Is.EqualTo("Edit Name"));
            Assert.That(result.Description, Is.EqualTo("Edit Description"));
        }

        [Test]
        public async Task DeleteSpiceTest()
        {
            var result = applicationDbContext.Spices.Where(d => d.Id == 1).FirstOrDefault();

            Assert.That(result.Name, Is.EqualTo("Нитритна сол"));

            await admineRecipeService.DeleteSpice(1);

            result = applicationDbContext.Spices.Where(d => d.Id == 1).FirstOrDefault();
            Assert.That(result, Is.Null);

        }

        [Test]
        public async Task AddRecipesTest()
        {
            var recipeIngredientsTableCount = applicationDbContext.RecipesIngredients.Count();
            var recipeSpicesTableCount = applicationDbContext.RecipesSpices.Count();
            var crtIngredients = new List<RecipeIngredientViewModel>()
            {
                new RecipeIngredientViewModel()
                {
                    IngredientId = 1,
                    Quantity = 100,
                    MeasureId = 1,
                }
            };
            var crtSpices = new List<RecipeSpiceViewModel>()
            {

                new RecipeSpiceViewModel()
                {
                    SpiceId = 1,
                    Quantity = 0.6,
                    MeasureId = 1,
                }
            };

            RecipeViewModel model = new RecipeViewModel()
            {
                Name = "Test",
                Description = "Test Description",
                ImageUrl = "",
                Ingredients = crtIngredients,
                Spices = crtSpices,
            };

            await admineRecipeService.AddRecipes(model);

            Assert.That(applicationDbContext.Recipes.Count(), Is.EqualTo(1));

            var addedRecipe = await applicationDbContext.Recipes.Where(d => d.Id == 1).FirstOrDefaultAsync();

            Assert.That(addedRecipe.Name, Is.EqualTo("Test"));
            Assert.That(addedRecipe.Description, Is.EqualTo("Test Description"));
            Assert.That(applicationDbContext.RecipesIngredients.Count(), Is.Not.EqualTo(recipeIngredientsTableCount));
            Assert.That(applicationDbContext.RecipesSpices.Count(), Is.Not.EqualTo(recipeSpicesTableCount));

        }

        [Test]
        public async Task GetRecipesTest()
        {
            await AddRecipesTest();
            var result = await admineRecipeService.GetRecipe(1);

            Assert.That(result.Name, Is.EqualTo("Test"));
            Assert.That(result.Description, Is.EqualTo("Test Description"));

        }

        [Test]
        public async Task EditRecipesTest()
        {
            await AddRecipesTest();
            RecipeViewModel model = new RecipeViewModel()
            {
                Name = "Edited Name",
                Description = "Test Description-Edit",
                ImageUrl = "Add Img",

            };

            await admineRecipeService.EditRecipe(1, model);
            var result = await applicationDbContext.Recipes.Where(d => d.Id == 1).FirstOrDefaultAsync();

            Assert.That(result.Name, Is.EqualTo("Edited Name"));
            Assert.That(result.Description, Is.EqualTo("Test Description-Edit"));
            Assert.That(result.ImageUrl, Is.EqualTo("Add Img"));

        }

        [Test]
        public async Task DeleteRecipeTest()
        {
            await AddRecipesTest();

            Assert.That(applicationDbContext.Recipes.Count(), Is.EqualTo(1));

            await admineRecipeService.DeleteRecipe(1);

            Assert.That(applicationDbContext.Recipes.Count(), Is.EqualTo(0));

            var result = await applicationDbContext.Recipes.Where(d => d.Id == 1).FirstOrDefaultAsync();

            Assert.That(result, Is.Null);

        }


        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Dispose();
        }
    }
}