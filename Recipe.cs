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
        public string? RecipeName { get; set; }
        public int NumberOfIngredients { get; set; }
        public int NumberOfSteps { get; set; }
        public double FactorToScale { get; set; }

        //change to arrays
        public List<RecipeIngredient> Ingredients = new List<RecipeIngredient>();

        public List<RecipeStep> Steps = new List<RecipeStep>();

        public List<RecipeIngredient> scaledIngredients = new List<RecipeIngredient>();
    }
}
