using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mezeta.Core.Models
{
    public class RecipeIngredientViewModel
    {

        [Required]
        public string Name { get; set; }

        [Required]
        public double Quantity { get; set; }

        [Required]
        public int MeasureId { get; set; } 
    }
}
