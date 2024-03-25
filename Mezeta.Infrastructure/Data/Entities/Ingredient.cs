using System.ComponentModel.DataAnnotations;

namespace Mezeta.Infrastructure.Data.Entities
{
    public class Ingredient
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(1000)]
        public string Description { get; set; } = null!;

        [StringLength(500)]
        public string? ImageUrl { get; set; } = null!;
    }
}
