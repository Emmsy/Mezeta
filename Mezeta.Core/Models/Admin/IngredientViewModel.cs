using System.ComponentModel.DataAnnotations;

namespace Mezeta.Core.Models.Admin
{
    public class IngredientViewModel
    {
        [Required]
        public int IngredientId { get; set; }
 
        public IEnumerable<IngredientsModel> Ingredients { get; set; } = new List<IngredientsModel>();

        [Required]
        [Range(0, int.MaxValue,ErrorMessage ="Стойността трябва да е положително число")]
        public double Quantity { get; set; } = 0;

        [Required]
        public int MeasureId { get; set; }

        public IEnumerable<MeasuresViewModel> Measures { get; set; } = new List<MeasuresViewModel>();

        public IEnumerable<RecipeIngredientViewModel> AddedIngredients { get; set; }= new List<RecipeIngredientViewModel>();

    }
}
