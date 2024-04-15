using System.ComponentModel.DataAnnotations;

namespace Mezeta.Core.Models.Admin
{
    public class SpiceViewModel
    {
        [Required]
        public int SpiceId { get; set; }
 
        public IEnumerable<IngredientsModel> Spices { get; set; } = new List<IngredientsModel>();

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Стойността трябва да е положително число")]
        public double Quantity { get; set; }

        [Required]
        public int MeasureId { get; set; }

        public IEnumerable<MeasuresViewModel> Measures { get; set; } = new List<MeasuresViewModel>();

        public IEnumerable<RecipeSpiceViewModel> AddedSpices { get; set; } = new List<RecipeSpiceViewModel>();

    }
}
