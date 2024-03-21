using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    public class Airplane : Vehicle
    {
        public Airplane(string regNr, string color, uint numOfWheels, uint numOfEngines) : base(regNr, color, numOfWheels)
        {
            NumOfEngines = numOfEngines;
        }

        public uint NumOfEngines { get; set; }

        public override string ToString()
        {
            return base.ToString() + $", Number of Engines: {NumOfEngines}";
        }
    }
}
