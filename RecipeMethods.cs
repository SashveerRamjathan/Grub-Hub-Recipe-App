using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10361554_PROG6221_POE_Part1
{
    internal class RecipeMethods
    {
        Recipe recipe = new Recipe();

         List<Recipe> recipes = new List<Recipe>();

        public void GetRecipeInformation()
        {
            Console.WriteLine("\nPlease enter the name of your recipe: ");
            recipe.RecipeName = Console.ReadLine();

            Console.WriteLine("\nPlease enter the number of ingredients required to make your recipe: ");
            recipe.NumberOfIngredients = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < recipe.NumberOfIngredients; i++)
            {
                RecipeIngredient ingredient = new RecipeIngredient();

                Console.WriteLine("\nPlease enter the name of ingredient " + (i+1) + ": ");
                ingredient.IngredientName = Console.ReadLine();

                Console.WriteLine("\nPlease enter the unit of measurement for ingredient " + (i+1) + ": ");
                ingredient.UnitOfMeasurement = Console.ReadLine();

                Console.WriteLine("\nPlease enter the amount of " + ingredient.IngredientName + " you have to add: ");
                ingredient.IngredientQuantity = Convert.ToDouble(Console.ReadLine());

                recipe.Ingredients.Add(ingredient);

            }

            Console.WriteLine("\nPlease enter the number of steps required in your recipe: ");
            recipe.NumberOfSteps = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < recipe.NumberOfSteps; i++)
            {
                RecipeStep step = new RecipeStep();

                Console.WriteLine("\nPlease enter a description for step " + (i+1) + ": ");
                step.StepDescription = Console.ReadLine();

                recipe.Steps.Add(step);
            }

            recipes.Add(recipe);

            Console.WriteLine("\nRecipe saved successfully");
        }

        public void ScaleRecipeQuantities()
        {
            const double scaleHalf = 0.5;
            const double scaleDouble = 2;
            const double scaleTriple = 3;

            double factorToScale = 1;

            Console.WriteLine("\nPlease choose a factor by which to scale the recipe quantities: "
                            + "\n1. Halve"
                            + "\n2. Double"
                            + "\n3. Triple");

            int userChoice = Convert.ToInt32(Console.ReadLine());

            if(userChoice == 1)
            {
                factorToScale = scaleHalf;
            }
            else if(userChoice == 2) 
            {
                factorToScale = scaleDouble;
            }
            else if( userChoice == 3)
            {
                factorToScale = scaleTriple;
            }

            recipe.FactorToScale = factorToScale;

            recipe.scaledIngredients.Clear();

            for (int i = 0; i < recipe.NumberOfIngredients; i++)
            {
                var ingredient = recipe.Ingredients[i];

                ingredient.IngredientQuantity *= factorToScale;

                recipe.scaledIngredients.Add(ingredient);
            }

            DisplayScaledRecipe(recipe.scaledIngredients);

        }

        public void RevertScaledQuantities()
        {
            double scaleFactor = recipe.FactorToScale;

            for (int i = 0; i < recipe.NumberOfIngredients; i++)
            {
                var ingredient = recipe.scaledIngredients[i];

                ingredient.IngredientQuantity /= scaleFactor;

                recipe.scaledIngredients.Add(ingredient);
            }

            Console.WriteLine("\nQuantities Have been Reset Successfully" +
                "\nTo view the original values select option (4)");
        }

        public void ClearRecipe()
        {
            Console.WriteLine("\nAre you sure you want to clear all recipes: "
                + "\n1. Yes"
                + "\n2. No");
            int userChoice = Convert.ToInt32(Console.ReadLine());

            if(userChoice == 1) 
            {
                recipes.Clear();
            }

            Console.WriteLine("\nRecipe has been cleared successfuly");

        }

        public void DisplayRecipe()
        {
            for (int i = 0; i < recipes.Count; i++)
            {
                Console.WriteLine("\n----------------------------------------------------------------------------");
                Console.WriteLine("Recipe Number: " + (i+1));
                Console.WriteLine("----------------------------------------------------------------------------");
                Console.WriteLine("Recipe Name: " + recipes[i].RecipeName);
                Console.WriteLine("\n\nRecipe Ingredients: " + "\n");

                foreach (RecipeIngredient item in recipes[i].Ingredients)
                {
                    Console.WriteLine("-> " + item.IngredientQuantity + " " + item.UnitOfMeasurement + " of " + item.IngredientName);
                }

                Console.WriteLine("\n\nRecipe Steps: " + "\n");

                for (int j = 0; j < recipes[i].Steps.Count; j++)
                {
                    Console.WriteLine("Step Number: " + (j+1));
                    Console.WriteLine(recipes[i].Steps[j].StepDescription + "\n");
                }
            }
        }

        public void DisplayScaledRecipe(List<RecipeIngredient> ingredients)
        {
            for (int i = 0; i < recipes.Count; i++)
            {
                Console.WriteLine("\n----------------------------------------------------------------------------");
                Console.WriteLine("Recipe Number: " + (i+1));
                Console.WriteLine("----------------------------------------------------------------------------");
                Console.WriteLine("Recipe Name: " + recipes[i].RecipeName);
                Console.WriteLine("\n\nRecipe Ingredients: " + "\n");

                foreach (RecipeIngredient item in ingredients)
                {
                    Console.WriteLine("-> " + item.IngredientQuantity + " " + item.UnitOfMeasurement + " of " + item.IngredientName);
                }

                Console.WriteLine("\n\nRecipe Steps: " + "\n");

                for (int j = 0; j < recipes[i].Steps.Count; j++)
                {
                    Console.WriteLine("Step Number: " + (j+1));
                    Console.WriteLine(recipes[i].Steps[j].StepDescription + "\n");
                }
            }
        }

        public void CloseRecipeApp() 
        {
            System.Environment.Exit(0);
        }

    }
}
