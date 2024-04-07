using Mezeta.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mezeta.Core.Models
{
    public class RecipePrepairViewModel
    {      
        public int Id { get; set; }

        public int RecipeId { get; set; }

        public RecipeViewModel Recipe { get; set; } = null!;

        [Precision(18, 2)]
        public double RawQuantity { get; set; } = 1.00;

        public DateTime StartDate { get; set; } = DateTime.Now;

        [Precision(18, 2)]
        public double ExpectedQuantity { get; set; }

    }
}
