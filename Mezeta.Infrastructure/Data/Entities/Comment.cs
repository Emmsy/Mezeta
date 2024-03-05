using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mezeta.Infrastructure.Data.Entities
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; } = null!;

        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;

        public IdentityUser User { get; set; } = null!;
    }
}
