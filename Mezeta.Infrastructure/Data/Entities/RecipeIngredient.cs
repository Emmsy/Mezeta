﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mezeta.Infrastructure.Data.Entities
{
    public class RecipeIngredient
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(Ingredient))]
        public int IngredientId { get; set; }

        [Required]
        public Ingredient Ingredient { get; set; } = null!;

        [Required]
        [Precision(18, 2)]
        public double Quantity { get; set; }

        [Required]
        [ForeignKey(nameof(Measure))]
        public int MeasureId { get; set; } 

        public Measure UnitOfMeasure { get; set; } = null!;
    }
}
