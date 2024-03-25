using Mezeta.Core.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mezeta.Core.Models.Admin
{
    public class IngredientSpiceAddModel
    {
        [Required]
        [StringLength(100, ErrorMessage = RecipeMessage.LengthError, MinimumLength = 4)]
        public string Name { get; set; } = null!;


        [Required]
        [StringLength(1000, ErrorMessage = RecipeMessage.LengthError, MinimumLength =30)]
        public string Description { get; set; } = null!;

        [StringLength(500)]
        public string? ImageUrl { get; set; } = null!;
    }
}
