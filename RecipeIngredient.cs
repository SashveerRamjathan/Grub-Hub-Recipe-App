using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10361554_PROG6221_POE_Part1
{
    internal class RecipeIngredient
    {
        public string? IngredientName { get; set; } // stores the ingredient name
        public double IngredientQuantity { get; set; } // stores the quantity of the ingredient added
        public string? UnitOfMeasurement { get; set; } // stores the unit of measurement of the ingredient e.g. cup
    }
}
