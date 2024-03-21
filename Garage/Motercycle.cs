using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    internal class Motercycle : Vehicle
    {
        public Motercycle(string regNr, string color, int numOfWheels, int cylinderVol) : base(regNr, color, numOfWheels)
        {
            CylinderVol = cylinderVol;
        }

        public int CylinderVol { get; set; }

        public override string ToString()
        {
            return base.ToString() + $", Cylinder Volumn: {CylinderVol}dl";
        }
    }
}
