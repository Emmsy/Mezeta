using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Mezeta.Core.Models
{
    public class RecipePrepairViewModel
    {
        public int Id { get; set; }

        [Required]
        public int RecipeId { get; set; }

        public RecipeViewModel Recipe { get; set; } = null!;

        [Required]
        [Precision(18, 2)]
        [Range(0, double.MaxValue, ErrorMessage = "Стойността трябва да е положително число")]
        public double RawQuantity { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; } 

        [Precision(18, 2)]
        public double ExpectedQuantity { get; set; }

    }
}
