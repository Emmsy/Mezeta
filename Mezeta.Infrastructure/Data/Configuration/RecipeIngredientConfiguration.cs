using Mezeta.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mezeta.Infrastructure.Data.Configuration
{
    internal class RecipeIngredientConfiguration : IEntityTypeConfiguration<RecipeIngredient>
    {
        public void Configure(EntityTypeBuilder<RecipeIngredient> builder)
        {
            builder.HasData(CreateRecipeSpices());
        }


        private IEnumerable<RecipeIngredient> CreateRecipeSpices()
        {
            List<RecipeIngredient> recipeingredients = new List<RecipeIngredient>()
            {
                new RecipeIngredient()
                {
                  Id = 1,
                  IngredientId = 1,
                  Quantity = 600,
                  UnitOfMeasure="g/kg"
                },

                new RecipeIngredient()
                {
                  Id = 2,
                  IngredientId = 2,
                  Quantity = 400,
                  UnitOfMeasure="g/kg"

                },
            };

            return recipeingredients;
        }
    }
}
