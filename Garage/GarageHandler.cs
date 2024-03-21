using Garage.Interface;
using GarageOne;
using System;
using System.Collections.Generic;
using System.Linq;
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
            string regNr = UserInputHelper.AskForString("Type in Register Number");
            string color = UserInputHelper.AskForString("Type in Vehicle's color");
            uint numOfV = UserInputHelper.AskForUInt("Type in total number of wheels");
            //Ask for vehicle type and special propety
            string vType = UserInputHelper.AskForString("Which kind of vehicle is it? inputting the name \n(Airplane, Boat, Car ,Motorcycle ,Bus) of your choice");
            Vehicle v;
            switch (vType)
            {
                case "Airplane":
                    uint numOfE = UserInputHelper.AskForUInt("How many Engines does you airplane has?");
                    v = new Airplane(regNr, color, numOfV,numOfE);
                    break;
                case "Boat":
                    double length = UserInputHelper.AskForDouble("How long is your boat?");
                    v = new Boat(regNr,color,numOfV,length);
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
                            fuelType= FuelType.Diesel;
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
        public void GetAllVehicle()
        {
           var t =  garage.GetAll();       
           foreach (var v in t)
            {
                Console.WriteLine(v.ToString());
            }
        }
        public void GetVehicle(string s)
        {
            //use all cw here in handler, not in garage
            if(garage.GetByRegNr(s) == null)
                Console.WriteLine("Cannot find this Vehicle");
        }
    }
}
