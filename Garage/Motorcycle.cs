using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    internal class Motorcycle : Vehicle
    {
        public Motorcycle(string regNr, string color, uint numOfWheels, uint cylinderVol) : base(regNr, color, numOfWheels)
        {
            CylinderVol = cylinderVol;
        }

        public uint CylinderVol { get; set; }

        public override string ToString()
        {
            return base.ToString() + $", Cylinder Volumn: {CylinderVol}dl";
        }
    }
}
