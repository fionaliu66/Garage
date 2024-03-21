using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    public class Garage<T> where T : Vehicle
    {
        private int capacity;
        private T[] list;
        private int nextPos = 0;

        public Garage(int capacity)
        {
            this.capacity = capacity;
            this.list = new T[capacity];
        }

        public void AddVehicle(T item)
        {
            if (nextPos > capacity)
            {
                ////expand? 
                //T[] nList = new T[capacity * 2];
                //Array.Copy(list, nList, list.Length);
                //list = nList;
                throw new InvalidOperationException("Array is full.");
            }
            list[nextPos] = item;
            nextPos++;
        }

        public void RemoveVehicle(T item)
        {
            //TODO t may be defualt null?
            var t = Array.Find(list, v => v.RegNr == item.RegNr);

            Console.WriteLine(t.ToString());
        }

        public void GetAll()
        {
            for (int i = 0; i < list.Length && list[i] != null; i++)
            {
                Console.WriteLine(list[i]);
            }
        }
    }
}
