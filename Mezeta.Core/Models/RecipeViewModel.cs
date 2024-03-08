using Mezeta.Core.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        //public IEnumerable<RecipeIngredient> Ingredients { get; set; }
        //public IEnumerable<RecipeSpice> Spices { get; set; }
        //public IEnumerable<Comment> Comments { get; set; }

        [StringLength(500, ErrorMessage = RecipeMessage.LengthError, MinimumLength = 4)]
        public string ImageUrl { get; set; } = null!;
    }
}
