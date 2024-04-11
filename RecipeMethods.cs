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
        public List<Recipe> recipes = new List<Recipe>();

        public void GetRecipeInformation()
        {
            Recipe recipe = new Recipe();

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

            DisplayRecipeMessage("Recipe saved successfully");
        }

        public Recipe SelectRecipe()
        {
            Recipe SelectedRecipe = new Recipe();

            if (recipes.Count > 0)
            {
                Console.WriteLine("\nPlease enter the number of the recipe you would like to select: ");
                int selectedRecipeNumber = Convert.ToInt32(Console.ReadLine());

                int selectedRecipeIndex = (selectedRecipeNumber - 1);

                SelectedRecipe = recipes[selectedRecipeIndex];
            }
            else
            {
                DisplayRecipeMessage("There are no saved recipes at the moment, \nTry adding one first");
            }

            return SelectedRecipe;
        }

        public void ScaleRecipeQuantities(Recipe recipe)
        {
            const double scaleHalf = 0.5;
            const double scaleDouble = 2;
            const double scaleTriple = 3;

            double factorToScale = 1;

            if (recipes.Count > 0)
            {
                Console.WriteLine("\nPlease choose a factor by which to scale the recipe quantities: "
                            + "\n1. Halve"
                            + "\n2. Double"
                            + "\n3. Triple");

                int userChoice = Convert.ToInt32(Console.ReadLine());

                if (userChoice >= 1 && userChoice <= 3)
                {
                    if (userChoice == 1)
                    {
                        factorToScale = scaleHalf;
                    }
                    else if (userChoice == 2)
                    {
                        factorToScale = scaleDouble;
                    }
                    else if (userChoice == 3)
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

                    DisplayRecipe(recipe.scaledIngredients);
                }
                else
                {
                    DisplayRecipeMessage("You have chosen an option that doesn't exist, please try again");
                }
            }

        }

        public void RevertScaledQuantities(Recipe recipe)
        {
            if (recipes.Count > 0)
            {
                double scaleFactor = recipe.FactorToScale;

                for (int i = 0; i < recipe.NumberOfIngredients; i++)
                {
                    var ingredient = recipe.scaledIngredients[i];

                    ingredient.IngredientQuantity /= scaleFactor;

                    recipe.scaledIngredients.Add(ingredient);
                }

                DisplayRecipeMessage("Quantities Have been Reset Successfully \nTo view the original values select option (4)");
            }

        }

        public void ClearRecipe()
        {
            if (recipes.Count > 0)
            {
                Console.WriteLine("\nAre you sure you want to clear all recipes: "
                + "\n1. Yes"
                + "\n2. No");

                int userChoice = Convert.ToInt32(Console.ReadLine());

                if (userChoice == 1  || userChoice == 2)
                {
                    if (userChoice == 1)
                    {
                        recipes.Clear();
                    }

                    DisplayRecipeMessage("Recipe(s) has been cleared successfully");
                }
                else
                {
                    DisplayRecipeMessage("You have chosen an option that doesn't exist, please try again");
                }
            }
            else
            {
                DisplayRecipeMessage("There are no recipes to clear at the moment, \nTry adding one first");
            }
        }

        public void DisplayRecipe()
        {
            if (recipes.Count > 0)
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
            else
            {
                DisplayRecipeMessage("There are no recipes to display at the moment, \nTry adding one first");
            }
        }

        public void DisplayRecipe(Recipe recipe)
        {
            Console.WriteLine("\n----------------------------------------------------------------------------");
            Console.WriteLine("Recipe Name: " + recipe.RecipeName);
            Console.WriteLine("----------------------------------------------------------------------------");
            
            Console.WriteLine("\n\nRecipe Ingredients: " + "\n");

            foreach (RecipeIngredient item in recipe.Ingredients)
            {
                Console.WriteLine("-> " + item.IngredientQuantity + " " + item.UnitOfMeasurement + " of " + item.IngredientName);
            }

            Console.WriteLine("\n\nRecipe Steps: " + "\n");

            for (int j = 0; j < recipe.Steps.Count; j++)
            {
                Console.WriteLine("Step Number: " + (j+1));
                Console.WriteLine(recipe.Steps[j].StepDescription + "\n");
            }

        }

        public void DisplayRecipe(List<RecipeIngredient> ingredients)
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

        protected void DisplayRecipeMessage(string message)
        {
            int messageLength = message.Length;
            string displayLine = new string('-', (messageLength + 2));

            Console.WriteLine("\n" + displayLine);
            Console.WriteLine(message);
            Console.WriteLine(displayLine + "\n");
        }

    }
}
