﻿using Mezeta.Core.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mezeta.Core.Models.Admin
{
    public class IngredientSpiceViewModel
    {
        public int IngredientId { get; set; }
 
        public IEnumerable<IngredientsModel> Ingredients { get; set; } = new List<IngredientsModel>();

        public int Quantity { get; set; } = 0;

        public int MeasureId { get; set; }

        public IEnumerable<MeasuresViewModel> Measures { get; set; } = new List<MeasuresViewModel>();

        public IEnumerable<AddedIngredientModel> AddedIngredients { get; set; }

    }
}
