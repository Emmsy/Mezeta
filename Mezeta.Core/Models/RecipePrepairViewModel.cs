using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Mezeta.Core.Models
{
    public class RecipePrepairViewModel
    {
        //public int Id { get; set; }

        [Required]
        public int RecipeId { get; set; }

        public RecipeViewModel Recipe { get; set; } = null!;

        [Required]
        [Precision(18, 2)]
        public double RawQuantity { get; set; }

        [Required] 
        public DateTime StartDate { get; set; } 

        [Precision(18, 2)]
        public double ExpectedQuantity { get; set; }

    }
}
