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
            //set up regNr to standard form
            string regNr = UserInputHelper.AskForString("Type in Register Number").ToUpper();
            string color = UserInputHelper.AskForString("Type in Vehicle's color");
            uint numOfV = UserInputHelper.AskForUInt("Type in total number of wheels");
            //Ask for vehicle type and special propety
            string vType = UserInputHelper.AskForString("Which kind of vehicle is it? inputting the name \n(Airplane, Boat, Car ,Motorcycle ,Bus) of your choice");
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
            //why there should be a boxing here
            Add((T)v);
        }
        public void Add(T item)
        {
            garage.AddVehicle(item);
        }
        public void Remove(T item)
        {
            garage.RemoveVehicle(item);
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
                //which property are you looking for 

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
                        if(elements.Count > 0)
                        {
                            foreach(var e in elements)
                            {
                                Console.WriteLine(e.ToString());
                            }
                        }
                        break;
                    default:
                        Console.WriteLine("Invaid input");
                        break;
                }


                //var num =t.Count(v => v.Color == "White");
               

               
            }

        }
        private void AskForColorAndWheels(List<T> t)
        {
            var groupByColor = t.GroupBy(v => v.Color);                                        
            string allColors = string.Join(", ", groupByColor.Select(g => g.Key));
            string color = UserInputHelper.AskForString($"Which color are you searching? There are {allColors}");
            try
            {
                var selectColor = groupByColor.Where(g => g.Key.Equals(color)).SelectMany(g => g.ToList()).ToList();
                foreach (var e in selectColor)
                {
                    Console.WriteLine(e);
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
                    selectedList = groupByType.Where( g=> g.Key.Equals("Airplane")).SelectMany(g=> g.ToList()).ToList();
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
