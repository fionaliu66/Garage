using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    public class Garage<T> where T:Vehicle
    {
        private  int capacity;
        private T[] list;
        private int currentPos;

        public Garage(int capacity)
        {
            this.capacity = capacity;
            this.list = new T[capacity];
        }

        public void AddVehicle(T item)
        {
            if (currentPos > capacity)
            {
                //expand? 
                _ = new T[capacity * 2];
                T[] nList = list.ToArray();
                list = nList;
            }
            list[currentPos+1] = item;
            currentPos++;
        }

        public void RemoveVehicle(T item)
        {

        }
    }
}
