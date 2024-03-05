using Mezeta.Infrastructure.Data.Configuration;
using Mezeta.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Mezeta.Infrastrucute.Data
{
    public class ApplicationDbContext : IdentityDbContext<User,IdentityRole,string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new IngredientConfiguration());
            builder.ApplyConfiguration(new SpiceConfiguration());
            builder.ApplyConfiguration(new RecipeIngredientConfiguration());
            builder.ApplyConfiguration(new RecipeSpiceConfiguration());

            base.OnModelCreating(builder);
        }

        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Spice> Spices { get; set; }
        public DbSet<RecipeSpice> RecipesSpices { get; set; }
        public DbSet<RecipeIngredient> RecipesIngredients { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<RecipePrepairing> RecipesPrepairings { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
    }
}