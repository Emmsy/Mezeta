using System.ComponentModel.DataAnnotations;

namespace Mezeta.Core.Models
{
    public class RecipeIngredientViewModel
    {

        [Required]
        public int IngredientId { get; set; }

        public string? IngredientName { get; set; }

        [Required]
        public double Quantity { get; set; }

        [Required]
        public int MeasureId { get; set; }

        public string? MeasureUnit { get; set; }
    }
}
