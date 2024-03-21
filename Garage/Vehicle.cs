using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    public class Vehicle
    {
        public string RegNr { get; set; }
        public string Color {  get; set; }

        public uint NumOfWheels {  get; set; }

        public Vehicle(string regNr, string color, uint numOfWheels) { 
            RegNr = regNr;
            Color = color;
            NumOfWheels = numOfWheels;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}, {RegNr}, {Color}, Number Of Wheels: {NumOfWheels}";
        }
    }
}
