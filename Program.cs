﻿using ST10361554_PROG6221_POE_Part1;

internal class Program
{
    private static void Main(string[] args)
    {
        RecipeMethods methods = new RecipeMethods();

        int userChoice = -1;

        Console.WriteLine("Welcome to My Recipe App!" + "\n");

        while (true)
        {
            try
            {
                userChoice = MenuPrompt();
            }
            catch (Exception e)
            {
                Console.WriteLine("Oops, an error occurred: " + e.Message);
            }

            switch (userChoice)
            {
                //create recipe
                case 1:
                    {
                        try
                        {
                            methods.GetRecipeInformation();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Oops, an error occurred: " + e.Message);
                        }

                        break;
                    }

                //Scale Recipe Quantities
                case 2:
                    {
                        try
                        {
                            Recipe recipeToScale = methods.SelectRecipe();
                            methods.ScaleRecipeQuantities(recipeToScale);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Oops, an error occurred: " + e.Message);
                        }

                        break;
                    }

                //Reset Quantities
                case 3:
                    {
                        try
                        {
                            Recipe recipeToReset = methods.SelectRecipe();
                            methods.RevertScaledQuantities(recipeToReset);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Oops, an error occurred: " + e.Message);
                        }

                        break;
                    }

                //View Recipe
                case 4:
                    {
                        try
                        {
                            if (methods.recipes.Count > 0)
                            {
                                int displayUserChoice = DisplayRecipePrompt();

                                if (displayUserChoice == 1)
                                {
                                    Recipe recipeToDisplay = methods.SelectRecipe();
                                    methods.DisplayRecipe(recipeToDisplay);
                                }
                                else if (displayUserChoice == 2)
                                {
                                    methods.DisplayRecipe();
                                }
                            }
                            else
                            {
                                Console.WriteLine("\nThere are no saved recipes at the moment, \nTry adding one first");
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Oops, an error occurred: " + e.Message);
                        }

                        break;
                    }

                //Clear Recipe
                case 5:
                    {
                        try
                        {
                            methods.ClearRecipe();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Oops, an error occurred: " + e.Message);
                        }

                        break;
                    }

                //Close App
                case 6:
                    {
                        methods.CloseRecipeApp();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("You have chosen an option that doesn't exist, please try again");
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
                + "\n6. Close App");

        int userChoice = Convert.ToInt32(Console.ReadLine());

        return userChoice;
    }

    public static int DisplayRecipePrompt()
    {
        int userChoice = -1;

        try
        {
            Console.WriteLine("\nPlease choose one of the options below, \nEnter the number of the operation you would like to perform: " +
            "\n1. Display specific recipe" +
            "\n2. Display all stored recipes");

            userChoice = Convert.ToInt32(Console.ReadLine());
        }
        catch (Exception e)
        {
            Console.WriteLine("Oops, an error occurred: " + e.Message);
        }

        return userChoice;
    }

}