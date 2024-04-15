using Mezeta.Core.Constants;
using System.ComponentModel.DataAnnotations;

namespace Mezeta.Core.Models
{
    public class RecipeViewModel
    {
    
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = RecipeMessage.LengthError,MinimumLength =4)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(1000, ErrorMessage = RecipeMessage.LengthError, MinimumLength = 4)]
        public string Description { get; set; } = null!;

        public IEnumerable<RecipeIngredientViewModel> Ingredients { get; set; } = new List<RecipeIngredientViewModel>();
        public IEnumerable<RecipeSpiceViewModel> Spices { get; set; } = new List<RecipeSpiceViewModel>();
        //public IEnumerable<Comment> Comments { get; set; }

        [StringLength(500, ErrorMessage = RecipeMessage.LengthError, MinimumLength = 4)]
        public string? ImageUrl { get; set; } 
    }
}
