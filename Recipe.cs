using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10361554_PROG6221_POE_Part1
{
    internal class Recipe
    {
        public string? RecipeName { get; set; } // stores the recipe's name
        public int NumberOfIngredients { get; set; } // stores the number of ingredients in the recipe
        public int NumberOfSteps { get; set; } // stores the number of steps need to make the recipe
        public double FactorToScale { get; set; } // stores the factor the ingredient quantity is scaled by
        public bool IsQuantityReset { get; set; } // stores if the quantity was reset already

        public RecipeIngredient[]? Ingredients; // array to store all the recipe ingredient objects

        public RecipeStep[]? Steps; // array to store all the recipe step objects

        public RecipeIngredient[]? scaledIngredients; // array to store all the recipe ingredients, once it has been scaled by the factor chosen
    }
}
