using ST10361554_PROG6221_POE_Part1;
using System;

internal class Program
{
    private static void Main(string[] args)
    {
        RecipeMethods methods = new RecipeMethods(); // Creates an instance of the RecipeMethods class

        int userChoice = -1; // Initializes the userChoice variable to -1

        methods.DisplaySystemMessage("Welcome to My Recipe App!"); // Displays a welcome message


        while (true) // Enters an infinite loop
        {
            try
            {
                userChoice = MenuPrompt(); // Calls the MenuPrompt method to get user input
            }
            catch (Exception e)
            {
                methods.DisplaySystemMessageRed("Oops, an error occurred: " + e.Message); // Displays an error message if an exception occurs
            }

            switch (userChoice) // Switch statement based on userChoice
            {
                //create recipe
                case 1:
                    {
                        try
                        {
                            methods.GetRecipeInformation(); // Calls the GetRecipeInformation method to create a new recipe
                        }
                        catch (Exception e)
                        {
                            methods.DisplaySystemMessageRed("Oops, an error occurred: " + e.Message); // Displays an error message if an exception occurs
                        }

                        break;
                    }

                //Scale Recipe Quantities
                case 2:
                    {
                        try
                        {
                            Recipe recipeToScale = methods.SelectRecipe(); // Calls the SelectRecipe method to choose a recipe to scale
                            methods.ScaleRecipeQuantities(recipeToScale); // Calls the ScaleRecipeQuantities method to scale the selected recipe
                        }
                        catch (Exception e)
                        {
                            methods.DisplaySystemMessageRed("Oops, an error occurred: " + e.Message); // Displays an error message if an exception occurs
                        }

                        break;
                    }

                //Reset Quantities
                case 3:
                    {
                        try
                        {
                            Recipe recipeToReset = methods.SelectRecipe(); // Calls the SelectRecipe method to choose a recipe to reset
                            methods.RevertScaledQuantities(recipeToReset); // Calls the RevertScaledQuantities method to revert scaled quantities of the selected recipe
                        }
                        catch (Exception e)
                        {
                            methods.DisplaySystemMessageRed("Oops, an error occurred: " + e.Message); // Displays an error message if an exception occurs
                        }

                        break;
                    }

                //View Recipe
                case 4:
                    {
                        try
                        {
                            if (methods.recipes.Count > 0) // Checks if there are saved recipes
                            {
                                int displayUserChoice = DisplayRecipePrompt(); // Calls the DisplayRecipePrompt method to prompt the user for viewing options

                                if (displayUserChoice == 1) // If user chooses to display a specific recipe
                                {
                                    Recipe recipeToDisplay = methods.SelectRecipe(); // Calls the SelectRecipe method to choose a recipe to display
                                    methods.DisplayRecipe(recipeToDisplay); // Calls the DisplayRecipe method to display the selected recipe
                                }
                                else if (displayUserChoice == 2) // If user chooses to display all stored recipes
                                {
                                    methods.DisplayRecipe(); // Calls the DisplayRecipe method to display all stored recipes
                                }
                                else
                                {
                                    methods.DisplaySystemMessageRed("You have chosen an option that doesn't exist, please try again"); // Displays an error message for invalid user choice
                                }
                            }
                            else
                            {
                                methods.DisplaySystemMessageRed("There are no saved recipes at the moment, \nTry adding one first"); // Displays a message if there are no saved recipes
                            }
                        }
                        catch (Exception e)
                        {
                            methods.DisplaySystemMessageRed("Oops, an error occurred: " + e.Message); // Displays an error message if an exception occurs
                        }

                        break;
                    }

                //Clear Recipe
                case 5:
                    {
                        try
                        {
                            methods.ClearRecipe(); // Calls the ClearRecipe method to clear all recipes
                        }
                        catch (Exception e)
                        {
                            methods.DisplaySystemMessageRed("Oops, an error occurred: " + e.Message); // Displays an error message if an exception occurs
                        }

                        break;
                    }

                //Close App
                case 6:
                    {
                        methods.CloseRecipeApp(); // Calls the CloseRecipeApp method to close the application
                        break;
                    }
                default:
                    {
                        methods.DisplaySystemMessageRed("You have chosen an option that doesn't exist, please try again"); // Displays an error message for invalid user choice
                        break;
                    }
            }
        }
    }

    public static int MenuPrompt()
    {
        Console.WriteLine("\nPlease enter the number of the operation you would like to perform: "
                + "\n1. Create Recipe"
                + "\n2. Scale Recipe Quantities"
                + "\n3. Reset Quantities"
                + "\n4. View Recipe"
                + "\n5. Clear Recipe"
                + "\n6. Close App");  // Prompt the user to choose an operation

        int userChoice = Convert.ToInt32(Console.ReadLine()); // Read user input and convert it to an integer

        return userChoice; // Return the user's choice
    }

    public static int DisplayRecipePrompt()
    {
        int userChoice = -1; // Initialize userChoice to -1

        Console.WriteLine("\nPlease choose one of the options below, \nEnter the number of the operation you would like to perform: " +
        "\n1. Display specific recipe" +
        "\n2. Display all stored recipes"); // Prompt the user to choose an option for displaying recipes

        userChoice = Convert.ToInt32(Console.ReadLine()); // Read user input and convert it to an integer

        return userChoice; // Return the user's choice
    }

}