using GarageOne;

namespace Garage
{
    internal class Program
    {
        private static GarageHandler<Vehicle> handler = new GarageHandler<Vehicle>(new Garage<Vehicle>(10));

        //populate some vehicles

        static void Populate()
        {
            Airplane airplane = new Airplane("ABC123", "White", 4, 4);
            Airplane airplane1 = new Airplane("ACD911", "Black", 8, 8);
            Car car = new Car("CBA123", "White", 4, FuelType.Gasoline);
            Boat boat = new Boat("CCC123", "White", 0, 5.0);
            Motorcycle motercycle = new Motorcycle("BBB333", "Black", 2, 50);
            Bus bus = new Bus("DDD333", "Yellow", 6, 120);
            handler.Add(airplane);
            handler.Add(car);
            handler.Add(boat);
            handler.Add(motercycle);
            handler.Add(bus);
            handler.Add(airplane1);
        }
        static void Main(string[] args)
        {

            Populate();
            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4 ,5 ,6 ,7 ,0) of your choice"
                    + "\n1. New Garage"
                    + "\n2. Park Car"
                    + "\n3. Remove Car"
                    + "\n4. List all parked vehicles"
                    + "\n5. List vehicle types and how many of each are in the garage"
                    + "\n6. Search Car by Register Number"
                    + "\n7. Search Car by Property"
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
                        uint cap = UserInputHelper.AskForUInt("How many places would you like to have in you garage?");
                        handler = new GarageHandler<Vehicle>(new Garage<Vehicle>(cap));
                        Console.WriteLine($"Garage with {cap} place has been created");
                        break;
                    case '2':
                        handler.AddVehicle();
                        break;
                    case '3':
                        Vehicle vehicle = new Vehicle("ABC123", "White", 8);
                        handler.Remove(vehicle);
                        break;
                    case '4':
                        handler.PrintAllVehicle();
                        break;
                    case '5':
                        handler.GetVehiclesByType();
                        break;
                    case '6':
                        string s = UserInputHelper.AskForString("Enter the Register Number");
                        handler.GetVehicle(s);
                        break;
                    case '7':
                        handler.GetVehiclesByProp();
                        break;
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4, 5, 6, 7)");
                        break;
                }
            }
        }




    }
}
