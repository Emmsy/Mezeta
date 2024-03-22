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
                  MeasureId = 1,
                },

                new RecipeSpice()
                {
                  Id = 2,
                  SpiceId = 2,
                  Quantity = 0.6,
                  MeasureId= 1,
                },
            };

            return recipeSpices;
        }
    }
}
