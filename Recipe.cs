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

        public ArrayList Ingredients = new ArrayList();

        public ArrayList Steps = new ArrayList();
    }
}
