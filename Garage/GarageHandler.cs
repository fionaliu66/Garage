using Garage.Interface;
using GarageOne;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    public class GarageHandler<T> where T : Vehicle
    {
        private Garage<T> garage;
        public GarageHandler(Garage<T> garage)
        {
            this.garage = garage;
        }



        //Add Vehicle to Garage
        public void AddVehicle()
        {
            if (garage.isFull())
            {
                Console.WriteLine("Sorry, Garage is full");
            }
            else
            {
                //why there should be a boxing here
                Add(GenerateVehicle());
            }
        }
        private T GenerateVehicle()
        {
            //Generated from user input
            string regNr = UserInputHelper.AskForString("Type in Register Number").ToUpper();
            string color = UserInputHelper.AskForString("Type in Vehicle's color");
            uint numOfV = UserInputHelper.AskForUInt("Type in total number of wheels");
            //Ask for vehicle type and special propety
            string vType = UserInputHelper.AskForString("Which kind of vehicle is it? inputting the name \n(Airplane, Boat, Car ,Motorcycle ,Bus) of your choice");
            //form input string to match class names
            vType = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(vType);
            color = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(color);
            Vehicle v;
            switch (vType)
            {
                case "Airplane":
                    uint numOfE = UserInputHelper.AskForUInt("How many Engines does you airplane has?");
                    v = new Airplane(regNr, color, numOfV, numOfE);
                    break;
                case "Boat":
                    double length = UserInputHelper.AskForDouble("How long is your boat?");
                    v = new Boat(regNr, color, numOfV, length);
                    break;
                case "Car":
                    string fuelT = UserInputHelper.AskForString("What is your fuel Type(Gasoline, Diesel or Electric)");
                    FuelType fuelType = FuelType.Gasoline;
                    fuelT = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(fuelT);
                    switch (fuelT)
                    {
                        case "Gasoline":
                            fuelType = FuelType.Gasoline;
                            break;
                        case "Diesel":
                            fuelType = FuelType.Diesel;
                            break;
                        case "Electric":
                            fuelType = FuelType.Electric;
                            break;
                        default:
                            Console.WriteLine("Please write the right fuel type");
                            break;
                    }
                    v = new Car(regNr, color, numOfV, fuelType);
                    break;
                case "Motercyler":
                    uint cylinder = UserInputHelper.AskForUInt("Enter you Cyliner Volume");
                    v = new Motorcycle(regNr, color, numOfV, cylinder);
                    break;
                case "Bus":
                    uint seats = UserInputHelper.AskForUInt("How many seats does it has?");
                    v = new Bus(regNr, color, numOfV, seats);
                    break;
                default:
                    v = new(regNr, color, numOfV);
                    break;
            }
            return (T)v;
        }
        public void Add(T item)
        {
            garage.AddVehicle(item);
        }
        public void Remove(string regNr)
        {
            //since Regnr should be primary key, it should allowed user to remove car
            //by just giving the Regnr 
            //And primary key should be unique
            regNr = regNr.ToUpper();
            var t = garage.RemoveByRegNr(regNr);
            if(t == null)
            {
                Console.WriteLine("There is no such vehicle in garage");
            }
            else
            {
                Console.WriteLine($"Vehicle with register number {regNr} has been removed.");
            }
           
        }
        public void GetVehiclesByType()
        {
            var t = garage.GetAll();
            var groupByType = t.GroupBy(v => v.GetType().Name)
                              .Select(group => new
                              {
                                  GType = group.Key,
                                  GCount = group.Count()
                              });
            foreach (var group in groupByType)
            {
                Console.WriteLine($"Vehicle Type: {group.GType}, Count: {group.GCount}");
            }

        }
        public void GetVehiclesByProp()
        {
            //Show current color group 
            var t = garage.GetAll();
            if (t.Count == 0)
            {
                Console.WriteLine("There is no vehicle in the garage");
            }
            else
            {
                //Guide users to filter vehicles
                Console.WriteLine("Which property would you like to search \n(1, 2, 0) of your choice"
                   + "\n1. Search through all vehicles"
                   + "\n2. Search by Vehicle type"
                   + "\n0. Finish filtering and show result");
                uint nav = UserInputHelper.AskForUInt("");
                switch (nav)
                {
                    case 0:
                        PrintAllVehicle();
                        break;
                    case 1:
                        AskForColorAndWheels(t);
                        break;
                    case 2:
                        //ask for type and the ask for color and wheels
                        var elements = AskForType(t);
                        if (elements.Count > 0)
                        {
                            Console.WriteLine($"There are {elements.Count} {elements.First().GetType().Name} in the garage," +
                                $"\n1. Countine with further filter, color and wheels." +
                                "\n2. Stop filtering and show result");
                            uint navi = UserInputHelper.AskForUInt("");
                            switch (navi)
                            {
                                case 1:
                                    AskForColorAndWheels(elements);
                                    break;
                                case 2:
                                    foreach (var e in elements)
                                    {
                                        Console.WriteLine(e.ToString());
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("No such vehicle in Garage");
                        }
                        break;
                    default:
                        Console.WriteLine("Invaid input");
                        break;
                }
            }

        }
        private void AskForColorAndWheels(List<T> t)
        {
            //group vehicle by color 
            //show user current color collection
            var groupByColor = t.GroupBy(v => v.Color);
            string allColors = string.Join(", ", groupByColor.Select(g => g.Key));
            string color = UserInputHelper.AskForString($"Which color are you searching? There are {allColors}");
            //try select color by using user input
            try
            {
                var selectColor = groupByColor.Where(g => g.Key.Equals(color)).SelectMany(g => g.ToList()).ToList();
                //alternativ 1: return vehicle collection with choosen color 
                //alternativ 2: filtrate wheels here 
                uint wheelsNr = UserInputHelper.AskForUInt("How many wheels?");
                var selectWheels = selectColor.Where(w => w.NumOfWheels == wheelsNr);
                //loop list or return list
                foreach (var v in selectWheels)
                {
                    Console.WriteLine(v.ToString());
                }

            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("There is no such color", ex.Message);
            }

        }
        private List<T> AskForType(List<T> t)
        {
            var groupByType = t.GroupBy(v => v.GetType().Name);
            string allTypes = string.Join(", ", groupByType.Select(v => v.Key));
            string vType = UserInputHelper.AskForString($"Which type of vehicle would you like to see, there are {allTypes}");
            //form input
            vType = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(vType);
            List<T> selectedList = null!;
            switch (vType)
            {
                case "Airplane":
                    selectedList = groupByType.Where(g => g.Key.Equals("Airplane")).SelectMany(g => g.ToList()).ToList();
                    break;
                case "Boat":
                    selectedList = groupByType.Where(g => g.Key.Equals("Boat")).SelectMany(g => g.ToList()).ToList();
                    break;
                case "Bus":
                    selectedList = groupByType.Where(g => g.Key.Equals("Bus")).SelectMany(g => g.ToList()).ToList();
                    break;
                case "Car":
                    selectedList = groupByType.Where(g => g.Key.Equals("Car")).SelectMany(g => g.ToList()).ToList();
                    break;
                case "Motorcycle":
                    selectedList = groupByType.Where(g => g.Key.Equals("Motorcycle")).SelectMany(g => g.ToList()).ToList();
                    break;
                default:
                    Console.WriteLine("Invaid input");
                    break;
            }
            return selectedList!;
        }
        public void PrintAllVehicle()
        {
            var t = garage.GetAll();
            if (t.Count == 0)
            {
                Console.WriteLine("There is no vehicle in the garage");
            }
            else
            {
                foreach (var v in t)
                {
                    Console.WriteLine(v.ToString());
                }
            }

        }
        public void GetVehicle(string s)
        {
            s = s.ToUpper();
            var item = garage.GetByRegNr(s);
            //use all cw here in handler, not in garage
            if (item == null)
                Console.WriteLine("Cannot find this Vehicle");
            else
                Console.WriteLine(item.ToString());
        }
    }
}
