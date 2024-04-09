using ST10361554_PROG6221_POE_Part1;

internal class Program
{
    private static void Main(string[] args)
    {
        RecipeMethods methods = new RecipeMethods();

        Console.WriteLine("Welcome to My Recipe App!" + "\n");

        while (true) 
        {
            Console.WriteLine("Please enter the number of the operation you would like to perform: "
                + "\n1. Create Recipe"
                + "\n2. Scale Recipe Quantities"
                + "\n3. View Original Recipe"
                + "\n4. Clear Recipe"
                + "\n5. Close App");

            int userChoice = Convert.ToInt32(Console.ReadLine());

            switch (userChoice)
            {
                case 1:
                {
                    methods.GetRecipeInformation();
                    break;
                }
                case 2: 
                { 
                   methods.ScaleRecipeQuantities(); 
                   break;
                }
                case 3:
                {
                   methods.DisplayRecipe();
                   break;
                }
                case 4:
                {
                   methods.ClearRecipe();
                   break;
                }
                case 5:
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