﻿using Mezeta.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mezeta.Core.Contracts
{
    public interface IRecipeService
    {
       List<RecipeViewModel> GetAllRecipes();
    }
}