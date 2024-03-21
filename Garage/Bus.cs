using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    public class Bus : Vehicle
    {
        public Bus(string regNr, string color, int numOfWheels, int numOfSeats) : base(regNr, color, numOfWheels)
        {
            NumOfSeats = numOfSeats;
        }

        public int NumOfSeats { get; set; }

        public override string ToString()
        {
            return base.ToString() + $", Number of seats: {NumOfSeats}";
        }
    }
}
