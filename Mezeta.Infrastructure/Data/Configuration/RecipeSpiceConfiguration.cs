using Mezeta.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mezeta.Infrastructure.Data.Configuration
{
    internal class RecipeSpiceConfiguration : IEntityTypeConfiguration<RecipeSpice>
    {
        public void Configure(EntityTypeBuilder<RecipeSpice> builder)
        {
            builder.HasData(CreateRecipeSpices());
        }


        private IEnumerable<RecipeSpice> CreateRecipeSpices()
        {
            List<RecipeSpice> recipeSpices = new List<RecipeSpice>()
            {
                new RecipeSpice()
                {
                  Id = 1,
                  SpiceId = 1,
                  Quantity = 22,
                  UnitOfMeasure="g/kg"
                },

                new RecipeSpice()
                {
                  Id = 2,
                  SpiceId = 2,
                  Quantity = 0.6,
                  UnitOfMeasure="g/kg"
                },
            };

            return recipeSpices;
        }
    }
}
