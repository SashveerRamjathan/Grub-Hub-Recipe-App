﻿using ST10361554_PROG6221_POE_Part1;

internal class Program
{
    private static void Main(string[] args)
    {
        RecipeMethods methods = new RecipeMethods();

        double scaleFactor = 1;

        Console.WriteLine("Welcome to My Recipe App!" + "\n");

        while (true) 
        {
            Console.WriteLine("Please enter the number of the operation you would like to perform: "
                + "\n1. Create Recipe"
                + "\n2. Scale Recipe Quantities"
                + "\n3. Reset Quantities"
                + "\n4. View Recipe"
                + "\n5. Clear Recipe"
                + "\n6. Close App");

            int userChoice = Convert.ToInt32(Console.ReadLine());

            switch (userChoice)
            {
                //create recipe
                case 1:
                {
                    methods.GetRecipeInformation();
                    break;
                }

                //Scale Recipe Quantities
                case 2: 
                { 
                   scaleFactor = methods.ScaleRecipeQuantities(); 
                   break;
                }

                //Reset Quantities
                case 3:
                {
                   methods.RevertScaledQuantities(scaleFactor);
                   break;
                }

                //View Recipe
                case 4:
                {
                   methods.DisplayRecipe();
                   break;
                }

                //Clear Recipe
                case 5:
                {
                   methods.ClearRecipe();
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
                    Console.WriteLine("You have choosen an option that doesn't exsist, please try again");
                    break;
                }
            }

            continue;
        }
    }

   
}