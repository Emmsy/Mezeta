using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mezeta.Core.Models
{
    public class RecipeSpiceViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public double Quantity { get; set; }

        [Required]
        [StringLength(8)]
        public string UnitOfMeasure { get; set; } = null!;
    }
}
