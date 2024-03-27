using System.ComponentModel.DataAnnotations;

namespace Mezeta.Infrastructure.Data.Entities
{
    public class Recipe
    {
        //public Recipe()
        //{
        //    Ingredients = new List<RecipeIngredient>();
        //    Spices = new List<RecipeSpice>();
        //    Comments = new List<Comment>();
        //}

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(1000)]
        public string Description { get; set; } = null!;

        public IEnumerable<RecipeIngredient> Ingredients { get; set; } = new List<RecipeIngredient>();
        public IEnumerable<RecipeSpice> Spices { get; set; } = new List<RecipeSpice>();
        public IEnumerable<Comment> Comments { get; set; } = new List<Comment>();

        [StringLength(500)]
        public string? ImageUrl { get; set; } = null!;

    }
}
