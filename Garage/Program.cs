namespace Garage
{
    internal class Program
    {
        private GarageHandler handler = new GarageHandler();
        static void Main(string[] args)
        {
            
            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4 ,5 ,6, 0) of your choice"
                    + "\n1. New Garage"
                    + "\n2. Park Car/Remove Car"
                    + "\n3. List all parked vehicles"
                    + "\n4. List vehicle types and how many of each are in the garage"
                    + "\n5. Search Car by Register Number"
                    + "\n6. Search Car by Property"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                       
                        break;
                    case '2':
                        
                        break;
                    case '3':
                       
                        break;
                    case '4':
                      
                        break;
                    case '5':
                        break;
                    case '6':
                        break;
                  
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }
    }
}
