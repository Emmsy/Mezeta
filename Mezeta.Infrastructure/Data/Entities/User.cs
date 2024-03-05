using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mezeta.Infrastructure.Data.Entities
{
    public class User : IdentityUser<string>
    {
        public User()
        {
            Favorites = new List<Recipe>();
            Prepairing = new List<RecipePrepairing>();
        }
        public IEnumerable<Recipe> Favorites { get; set; }
        public IEnumerable<RecipePrepairing> Prepairing { get; set; }
    }
}
