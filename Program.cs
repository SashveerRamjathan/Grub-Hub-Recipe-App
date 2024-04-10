using ST10361554_PROG6221_POE_Part1;

internal class Program
{
    private static void Main(string[] args)
    {
        RecipeMethods methods = new RecipeMethods();

        Console.WriteLine("Welcome to My Recipe App!" + "\n");

        while (true)
        {
            int userChoice = MenuPrompt();

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
                        Recipe recipeToScale = methods.SelectRecipe();
                        methods.ScaleRecipeQuantities(recipeToScale);
                        break;
                    }

                //Reset Quantities
                case 3:
                    {
                        Recipe recipeToReset = methods.SelectRecipe();
                        methods.RevertScaledQuantities(recipeToReset);
                        break;
                    }

                //View Recipe
                case 4:
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
        Console.WriteLine("\nPlease choose one of the options below, \nEnter the number of the operation you would like to perform: " +
            "\n1. Display specific recipe" +
            "\n2. Display all stored recipes");

        int userChoice = Convert.ToInt32(Console.ReadLine());

        return userChoice;
    }

}