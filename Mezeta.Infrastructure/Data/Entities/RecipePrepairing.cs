using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mezeta.Infrastructure.Data.Entities
{
    public class RecipePrepairing
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(Recipe))]
        public int RecipeId { get; set; }

        [Required]
        public Recipe Recipe { get; set; } = null!;


        [Precision(18, 2)]
        public double RawQuantity { get; set; }

        [Required]
        public DateTime StartDate { get; set; }


        [Precision(18, 2)]
        public double ExpectedQuantity { get; set; }


    }
}
