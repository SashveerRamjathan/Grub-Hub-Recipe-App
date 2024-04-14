using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ST10361554_PROG6221_POE_Part1
{
    internal class RecipeMethods
    {
        public List<Recipe> recipes = new List<Recipe>(); // list collection to store more than one recipe

        public void GetRecipeInformation() // method gets the information required to create a recipe
        {
            Recipe recipe = new Recipe(); // recipe object is created

            Console.WriteLine("\nPlease enter the name of your recipe: ");
            recipe.RecipeName = Console.ReadLine(); // gets and stores the recipe name

            Console.WriteLine("\nPlease enter the number of ingredients required to make your recipe: ");
            recipe.NumberOfIngredients = Convert.ToInt32(Console.ReadLine()); // gets and stores number of ingredients

            recipe.Ingredients = new RecipeIngredient[recipe.NumberOfIngredients]; // array to hold recipe ingredients is initialised in recipe object

            for (int i = 0; i < recipe.NumberOfIngredients; i++) // for-loop to get and store the information for each ingredient object
            {
                RecipeIngredient ingredient = new RecipeIngredient(); // recipe ingredient object created

                Console.WriteLine("\nPlease enter the name of ingredient " + (i+1) + ": ");
                ingredient.IngredientName = Console.ReadLine(); // gets and stores ingredient name

                Console.WriteLine("\nPlease enter the unit of measurement for ingredient " + (i+1) + ": ");
                ingredient.UnitOfMeasurement = Console.ReadLine(); // gets and stores ingredient unit of measurement

                bool isValid = ValidateUnitOfMeasurement(ingredient.UnitOfMeasurement); // checks if the ingredient unit of measurement is valid

                while (isValid == false) // while loop to iterate until a valid input is achieved
                {
                    Console.WriteLine("\nPlease enter the unit of measurement for ingredient " + (i+1) + ": ");
                    ingredient.UnitOfMeasurement = Console.ReadLine(); // gets and stores ingredient unit of measurement

                    isValid = ValidateUnitOfMeasurement(ingredient.UnitOfMeasurement); // checks if the ingredient unit of measurement is valid
                }

                Console.WriteLine("\nPlease enter the amount of " + ingredient.IngredientName + " you have to add: ");
                ingredient.IngredientQuantity = Convert.ToDouble(Console.ReadLine()); // gets and stores ingredient quantity

                recipe.Ingredients[i] = ingredient; // stores the ingredient object in the ingredients array in the recipe object

            }

            Console.WriteLine("\nPlease enter the number of steps required in your recipe: ");
            recipe.NumberOfSteps = Convert.ToInt32(Console.ReadLine()); // gets and stores the number of steps in the recipe

            recipe.Steps = new RecipeStep[recipe.NumberOfSteps]; // steps array in the recipe object is initialised

            for (int i = 0; i < recipe.NumberOfSteps; i++) // for-loop to get  and store the information for each step object
            {
                RecipeStep step = new RecipeStep(); // recipe step object created

                Console.WriteLine("\nPlease enter a description for step " + (i+1) + ": ");
                step.StepDescription = Console.ReadLine(); // gets and stores the step description

                recipe.Steps[i] = step; // stores the step object in the steps array in the recipe object
            }

            recipes.Add(recipe); // adds the recipe object to the recipes list collection

            DisplaySystemMessageGreen("Recipe saved successfully"); // message to confirm recipe was created successfully
        }

        public Recipe SelectRecipe() // method to return a specific recipe from the recipes list collection
        {
            Recipe SelectedRecipe = new Recipe(); // create a recipe object

            if (recipes.Count > 0) // if statement to check if there are any recipes in the list, if true
            {
                Console.WriteLine("\nPlease enter the number of the recipe you would like to select: ");
                int selectedRecipeNumber = Convert.ToInt32(Console.ReadLine()); // gets and stores the recipe number

                int selectedRecipeIndex = (selectedRecipeNumber - 1); // converts the recipe number to a valid list index

                SelectedRecipe = recipes[selectedRecipeIndex]; // stores the recipe object retrieved from the list in the recipe object created (SelectedRecipe)
            }
            else
            {
                DisplaySystemMessageRed("There are no saved recipes at the moment, \nTry adding one first"); // message displayed if the recipes list collection has no recipes stored
            }

            return SelectedRecipe; // returns the recipe object
        }

        public void ScaleRecipeQuantities(Recipe recipe) // method to scale the quantities of a recipe by the chosen factor, method has  a recipe object as a parameter
        {
            const double scaleHalf = 0.5; // half factor constant 
            const double scaleDouble = 2; // double factor constant
            const double scaleTriple = 3; // triple factor constant

            double factorToScale = 1; // stores the factor chosen by the user, initialised with a value of 1

            if (recipes.Count > 0) // if statement to check if there are any recipes in the list, if true
            {
                Console.WriteLine("\nPlease choose a factor by which to scale the recipe quantities: "
                            + "\n1. Halve (0,5)"
                            + "\n2. Double (2)"
                            + "\n3. Triple (3)"); // prompt for the user to choose a factor to scale the recipe quantities

                int userChoice = Convert.ToInt32(Console.ReadLine()); // gets and stores the users choice

                if (userChoice >= 1 && userChoice <= 3) // if statement to check that a user enters a valid option
                {
                    if (userChoice == 1) // if statement to check if the user has chosen option one 
                    {
                        factorToScale = scaleHalf; // sets factor to scale variable to the half factor constant
                    }
                    else if (userChoice == 2) // if statement to check if the user has chosen option two 
                    {
                        factorToScale = scaleDouble; // sets factor to scale variable to the double factor constant
                    }
                    else if (userChoice == 3) // if statement to check if the user has chosen option three 
                    {
                        factorToScale = scaleTriple; // sets factor to scale variable to the triple factor constant
                    }

                    recipe.FactorToScale = factorToScale; // stores the value in factor to scale to the corresponding property in the recipe object

                    recipe.scaledIngredients = new RecipeIngredient[recipe.NumberOfIngredients]; // initialises the scaled ingredients array in the recipe object

                    for (int i = 0; i < recipe.NumberOfIngredients; i++) // for-loop to scale each ingredient by the specified factor
                    {
                        var ingredient = recipe.Ingredients[i]; // stores the ingredient object in a variable

                        ingredient.IngredientQuantity *= factorToScale; // gets, multiplies the quantity by the factor and stores it in the corresponding property in the ingredient object 

                        recipe.scaledIngredients[i] = ingredient; // adds the ingredient object to the scaled ingredients array in the recipe object
                    }

                    recipe.IsQuantityReset = false; // sets the value to false

                    DisplaySystemMessageGreen("Quantities Have been Scaled Successfully \nTo view the scaled values select option (4)"); // displays message that the quantities was reverted back to the original values
                }
                else
                {
                    DisplaySystemMessageRed("You have chosen an option that doesn't exist, please try again"); // message displayed if the user chooses an option that does not exist
                }
            }
            else
            {
                DisplaySystemMessageRed("There are no saved recipes at the moment, \nTry adding one first"); // message displayed if the recipes list collection has no recipes stored
            }

        }

        public void RevertScaledQuantities(Recipe recipe) // // method to revert the scale of the quantities of a recipe by the chosen factor, method has  a recipe object as a parameter
        {
            if (recipes.Count > 0) // if statement to check if there are any recipes in the list, if true
            {
                if (recipe.IsQuantityReset == false)
                {
                    double scaleFactor = recipe.FactorToScale; // gets and stores the factor that the ingredient quantities was scaled by

                    recipe.IsQuantityReset = true; // sets the value to true

                    for (int i = 0; i < recipe.NumberOfIngredients; i++) // for-loop to revert the scale of each ingredient by the specified factor
                    {
                        var ingredient = recipe.scaledIngredients[i]; // stores the ingredient object in a variable

                        ingredient.IngredientQuantity /= scaleFactor; // gets, divides the quantity by the factor and stores it in the corresponding property in the ingredient object 

                        recipe.scaledIngredients[i] = ingredient; // adds the ingredient object to the scaled ingredients array in the recipe object

                    }

                    DisplaySystemMessageGreen("Quantities Have been Reset Successfully \nTo view the original values select option (4)"); // displays message that the quantities was reverted back to the original values
                }
                else
                {
                    DisplaySystemMessageRed("Quantities Have been Reset Already \nTo view the recipe select option (4)"); // displays message that the quantities was reverted back to the original values already
                }

            }
            else
            {
                DisplaySystemMessageRed("There are no saved recipes at the moment, \nTry adding one first"); // message displayed if the recipes list collection has no recipes stored
            }

        }

        public void ClearRecipe() // method to delete all recipes
        {
            if (recipes.Count > 0) // if statement to check if there are any recipes in the list, if true
            {
                DisplaySystemMessageRed("Are you sure you want to clear all recipes: "
                + "\n1. Yes"
                + "\n2. No"); // display message to confirm if user wants to delete all recipes

                int userChoice = Convert.ToInt32(Console.ReadLine()); // gets and stores the users choice

                if (userChoice == 1  || userChoice == 2) // if statement to check id the user has chosen a valid option
                {
                    if (userChoice == 1) // if statement to check if user confirmed delete
                    {
                        recipes.Clear(); // clears the recipes list collection
                        DisplaySystemMessageGreen("Recipe(s) has been cleared successfully"); // message to display that the list was cleared
                    }

                }
                else
                {
                    DisplaySystemMessageRed("You have chosen an option that doesn't exist, please try again"); // message displayed if the user chooses an option that does not exist 
                }
            }
            else
            {
                DisplaySystemMessageRed("There are no recipes to clear at the moment, \nTry adding one first"); // message displayed if the recipes list collection has no recipes stored
            }
        }

        public bool ValidateUnitOfMeasurement(string measurement) // method to validate the unit of measurement for an ingredient is valid, measurement is a parameter
        {
            // Code Attribution
            // Regular Expression written using code from: 
            // Carter, T.
            // Stack Overflow
            // Regex for numbers only
            // https://stackoverflow.com/questions/273141/regex-for-numbers-only

            // "^" asserts the start of the string.
            // "[^0-9]" matches any character that is not a digit (0-9).The "^" inside the square brackets negates the character class.
            // "+" ensures that there is at least one non-digit character.
            // "$" asserts the end of the string.

            bool isValid = true; // stores if the measurement value is valid

            if (Regex.IsMatch(measurement, "^-?\\d*\\.?\\d+$")) // if statement if to check if iit matches the regular expression
            {
                isValid = false; // changes the boolean value to false
                DisplaySystemMessageRed("This unit of measurement is invalid, \nEnter a valid one"); //message displayed if the measurement matches the regular description
            }

            return isValid; // returns the boolean value
        }

        public void DisplayRecipe() // "DisplayRecipe" overloaded method that takes no parameters, formats and displays a recipe
        {
            if (recipes.Count > 0) // if statement to check if there are any recipes in the list, if true
            {
                for (int i = 0; i < recipes.Count; i++) // for loop to display the recipe information for all the recipes stored in the recipes list collection
                {
                    Console.WriteLine("\n----------------------------------------------------------------------------");
                    Console.WriteLine("Recipe Number: " + (i+1));
                    Console.WriteLine("----------------------------------------------------------------------------");
                    Console.WriteLine("Recipe Name: " + recipes[i].RecipeName);
                    Console.WriteLine("\n\nRecipe Ingredients: " + "\n");

                    foreach (RecipeIngredient item in recipes[i].Ingredients) // for each loop to display the ingredient information for all the ingredients stored in the ingredient array in the recipe object
                    {
                        Console.WriteLine("-> " + item.IngredientQuantity + " " + item.UnitOfMeasurement + " of " + item.IngredientName);
                    }

                    Console.WriteLine("\n\nRecipe Steps: " + "\n");

                    for (int j = 0; j < recipes[i].Steps.Length; j++) // for loop to display the recipe step information for all the steps stored in the steps array in the recipe object
                    {
                        Console.WriteLine("Step Number: " + (j+1));
                        Console.WriteLine(recipes[i].Steps[j].StepDescription + "\n");
                    }
                }
            }
            else
            {
                DisplaySystemMessageRed("There are no recipes to display at the moment, \nTry adding one first"); // message displayed if the recipes list collection has no recipes stored
            }
        }

        public void DisplayRecipe(Recipe recipe) // "DisplayRecipe" overloaded method that takes a recipe object as a parameter, formats and displays a recipe
        {
            Console.WriteLine("\n----------------------------------------------------------------------------");
            Console.WriteLine("Recipe Name: " + recipe.RecipeName);
            Console.WriteLine("----------------------------------------------------------------------------");

            Console.WriteLine("\n\nRecipe Ingredients: " + "\n");

            foreach (RecipeIngredient item in recipe.Ingredients) // for each loop to display the ingredient information for all the ingredients stored in the ingredient array in the recipe object
            {
                Console.WriteLine("-> " + item.IngredientQuantity + " " + item.UnitOfMeasurement + " of " + item.IngredientName);
            }

            Console.WriteLine("\n\nRecipe Steps: " + "\n");

            for (int j = 0; j < recipe.Steps.Length; j++)  // for loop to display the recipe step information for all the steps stored in the steps array in the recipe object
            {
                Console.WriteLine("Step Number: " + (j+1));
                Console.WriteLine(recipe.Steps[j].StepDescription + "\n");
            }

        }

        public void CloseRecipeApp() // method to stop the app
        {
            System.Environment.Exit(0);
        }

        public void DisplaySystemMessage(string message) // method to format message, message string passed in as a parameter
        {
            int messageLength = message.Length; // gets length of the message
            string displayLine = new string('-', (messageLength + 2)); // creates a line the length of the message

            Console.WriteLine("\n" + displayLine); // displays line
            Console.WriteLine(message); // displays message text
            Console.WriteLine(displayLine + "\n"); // displays line

        }

        public void DisplaySystemMessageGreen(string message) // method to format text colour to green and format message, message string passed in as a parameter
        {
            Console.ForegroundColor = ConsoleColor.Green; // changes text colour to green

            DisplaySystemMessage(message); // calls the "DisplaySystemMessage" to format message

            Console.ResetColor(); // resets the text colour to default colour (white)

        }

        public void DisplaySystemMessageRed(string message) // method to format text colour to red and format message, message string passed in as a parameter
        {
            Console.ForegroundColor = ConsoleColor.Red; // changes text colour to red

            DisplaySystemMessage(message); // calls the "DisplaySystemMessage" to format message

            Console.ResetColor(); // resets the text colour to default colour (white)

        }

    }
}
