using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    public enum FuelType
    {
        Gasoline,
        Diesel,
        Electric
    }
    public class Car : Vehicle
    {
        public Car(string regNr, string color, int numOfWheels, FuelType fuelType) : base(regNr, color, numOfWheels)
        {
            Fuel = fuelType;
        }

        public FuelType Fuel { get; set; }

        public override string ToString()
        {
            return base.ToString() + $", Fuel type: {Fuel}";
        }
    }
}
