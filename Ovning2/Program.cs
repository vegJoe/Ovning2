namespace Ovning2
{
    internal class Program
    {
        static bool running = true;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            while (running)
            {
                Console.Clear();
                MainMenu();
            }
        }

        static void MainMenu()
        {
            /*
             * Operation choises listed on the screen
             */
            Console.WriteLine("These are the Main Options.");
            Console.WriteLine("0: Close Program");
            Console.WriteLine("1: Enter age to determin price");
            Console.WriteLine("2: Enter number of participants");
            Console.WriteLine("3: Calibrate Program!");
            Console.WriteLine("4: Split text (for some reason)");
            Console.Write("Enter option: ");

            /*
             * Reads choise of user and tries to parse it to int. If not possible choise is set to 100 to choose
             * default in switch case
             */
            bool res = int.TryParse(Console.ReadLine()!, out int option);

            if (!res)
                option = 100;

            /*
             * Case 0 will terminate program by setting bool in main while loop to false
             * 
             * Case 1 will let user input age. Age method is called and returns price of ticket
             * 
             * Case 2 same as Case 1 but it let user input multiple tickets to get a total cost
             * 
             * Case 3 loops text that user typed 10 times
             * 
             * Case 4 asks for text of 3 words minimum, and then chooses the third word to type out on screen
             * 
             * Default case is activated if input does not match choises in menu
             */

            switch (option)
            {
                case 0:
                    running = false;
                    break;
                case 1:
                    {
                        Console.WriteLine("Enter your age with a number.");
                        Console.Write("Age: ");
                        int cost = Age(Convert.ToInt32(Console.ReadLine()));
                        Console.WriteLine($"Your price for the ticket will be {cost} kr");
                    }
                    break;
                case 2:
                    {
                        Console.Write("How many tickets: ");
                        int participants = Convert.ToInt32(Console.ReadLine());
                        int totalCost = 0;
                        for(int i = 1; i <= participants; i++)
                        {
                            Console.Write($"Input age of participant {i}: ");
                            totalCost += Age(Convert.ToInt32(Console.ReadLine()));
                        }
                        Console.WriteLine();
                        Console.WriteLine($"Total cost of the tickets is {totalCost} kr.");
                    }
                    break;
                case 3:
                    {
                        Console.WriteLine("Enter random text to start calibration.");
                        Console.Write("Input text: ");
                        string randomText = Console.ReadLine()!;
                        for(int i = 0; i < 10; i++)
                            Console.Write(randomText);
                    }
                    break;
                case 4:
                    {
                        Console.WriteLine("Enter text with a minimum of 3 different words");
                        var randomText = Console.ReadLine()!;
                        List<string> splitText = randomText.Split().ToList();
                        if (splitText.Count > 2)
                            Console.WriteLine(splitText[2]);
                    }
                    break;
                default:
                    {
                        Console.WriteLine("Did you enter a number representing one of the options?");
                        Console.WriteLine("Please push a key to start over...");
                        Console.ReadLine();
                    }
                    break;
            }
            Console.WriteLine("Press key to continue...");
            Console.ReadLine();
        }

        /*
         * Calculate price for ticket(s), determined on age.
         */
        static int Age(int age)
        {
            int cost;

            if (age < 20 && age >= 5)
                cost = 80;
            else if (age > 64 && age <= 100)
                cost = 90;
            else if (age < 5 || age > 100)
                cost = 0;
            else
                cost = 120;
                
            return cost; 
        }
    }
}
