using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    public class Boat : Vehicle
    {
        public Boat(string regNr, string color, uint numOfWheels, double length) : base(regNr, color, numOfWheels)
        {
            Length = length;
        }

        public double Length { get; set; }

        public override string ToString()
        {
            return base.ToString() + $", Length: {Length}";
        }
    }
}
