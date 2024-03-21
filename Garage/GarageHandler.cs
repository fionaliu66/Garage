using Garage.Interface;
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
