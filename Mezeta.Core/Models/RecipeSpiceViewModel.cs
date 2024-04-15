using System.ComponentModel.DataAnnotations;

namespace Mezeta.Core.Models
{
    public class RecipeSpiceViewModel
    {
        [Required]
        public int SpiceId { get; set; }

        public string? SpiceName { get; set; }

        [Required]
        public double Quantity { get; set; }

        [Required]
        public int MeasureId { get; set; }

        public string? MeasureUnit { get; set; }


    }
}
