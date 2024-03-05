﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mezeta.Infrastructure.Data.Entities
{
    public class RecipeSpice
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(Spice))]
        public int SpiceId { get; set; }

        [Required]
        public Spice Spice { get; set; } = null!;

        [Required]
        [Precision(18,2)]
        public double Quantity { get; set; }

        [Required]
        [StringLength(8)]
        public string UnitOfMeasure { get; set; } = null!;
    }
}
