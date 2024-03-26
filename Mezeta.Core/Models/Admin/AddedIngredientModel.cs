using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mezeta.Core.Models.Admin
{
    public class AddedIngredientModel
    {

        public string IngredientName{ get; set; } 

        public double Quantity { get; set; }

        public string MeasureName { get; set; } 
    }
}
