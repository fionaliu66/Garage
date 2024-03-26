
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
        public string RegisterNr
        {
            get { return _registerNr; }
            set
            {
                if (IsValidRegisterNumber(value))
                {
                    _registerNr = value;
                }
                else
                {
                    //should have way to handle 
                    throw new ArgumentException("Invalid register number, it should contains 6 letter or numbers or combine letter and numbers");
                }
            }
        }
        public string Color { get; set; }
        public uint NumOfWheels { get; set; }
        public Vehicle(string regNr, string color, uint numOfWheels)
        {
            RegisterNr = regNr;
            Color = color;
            NumOfWheels = numOfWheels;
        }
        public override string ToString()
        {
            return $"{this.GetType().Name}, {RegisterNr}, {Color}, Number Of Wheels: {NumOfWheels}";
        }
        public bool IsValidRegisterNumber(string s)
        {
            return !string.IsNullOrEmpty(s) && s.Length == 6;
        }
        public override bool Equals(object? obj)
        {
            if(obj == null) 
                return false;
            if(!(obj is Vehicle))
                return false;

            return this.RegisterNr == ((Vehicle)obj).RegisterNr;
        }
        public override int GetHashCode()
        {
            return RegisterNr.GetHashCode();
        }
        //public virtual object Clone() {
        //    Vehicle newV = (Vehicle)this.MemberwiseClone();
        //    string newRegNr = new string(_registerNr.ToCharArray());
        //    string newColor = new string(Color.ToCharArray());
        //    newV.Color = newColor;
        //    newV.RegisterNr = newRegNr;
        //    return newV;
        //}

    }
}
