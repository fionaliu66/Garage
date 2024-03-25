using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    public class Vehicle
    {
        private string _registerNr;
        public string RegNr
        {
            get { return _registerNr; }
            set
            {
                if (IsValidRegNr(value))
                    _registerNr = value;
                else
                    throw new ArgumentException("Invalid register number");
            }
        }
        public string Color { get; set; }

        public uint NumOfWheels { get; set; }

        public Vehicle(string regNr, string color, uint numOfWheels)
        {
            RegNr = regNr;
            Color = color;
            NumOfWheels = numOfWheels;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}, {RegNr}, {Color}, Number Of Wheels: {NumOfWheels}";
        }
        private bool IsValidRegNr(string regN)
        {
            return !string.IsNullOrEmpty(regN) && regN.Length == 6;
        }
    }
}
