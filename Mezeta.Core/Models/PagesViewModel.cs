using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Mezeta.Core.Models
{
    public class PagesViewModel
    {

        public IEnumerable<RecipeViewModel> Recipes { get; set; }
        public int RecipePerPage { get; set; }
        public int CurrentPage { get; set; }
        public string Sorting {  get; set; }

        public int PageCount()
        {
            return Convert.ToInt32(Math.Ceiling(Recipes.Count() / (double)RecipePerPage));
        }
        public IEnumerable<RecipeViewModel> PaginatedRecipes()
        {
            int start = (CurrentPage - 1) * RecipePerPage;
            if (Sorting == "Newest")
            {
                return Recipes.OrderByDescending(b => b.Id).Skip(start).Take(RecipePerPage);
            }
            
            return Recipes.OrderBy(b => b.Id).Skip(start).Take(RecipePerPage);

        }
    }
}

