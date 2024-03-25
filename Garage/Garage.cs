using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    public class Garage<T> where T : Vehicle
    {
        private uint capacity;
        private T[] vehicleArray;
        private int nextPos = 0;

        public Garage(uint capacity)
        {
            this.capacity = capacity;
            this.vehicleArray = new T[capacity];
        }

        public void AddVehicle(T item)
        {
            //the position index starts with 0 and ends with 9
            //if (nextPos > capacity - 1)
            //{
            //    //expand? 
            //    T[] nList = new T[capacity * 2];
            //    Array.Copy(list, nList, list.Length);
            //    list = nList;

            //    throw new InvalidOperationException("Garage is full.");

            //}
            vehicleArray[nextPos] = item;
            nextPos++;
        }

        private void RemoveVehicle(T item)
        {
           
        }
        public T? RemoveByRegNr(string s)
        {
            Console.WriteLine(GetAll().Count);
            var list = GetAll();
            if(list.Count == 0)
            {
                return null;
            }
            else
            {
                var t = vehicleArray.FirstOrDefault(v => v.RegNr.Equals(s));
                if(t == null)
                {
                    return null;
                }
                else
                {
                    //remove vehicle here manually, 
                    int i = Array.IndexOf(vehicleArray, t);
                    for(int j = i; j < list.Count -1 ; j++)
                    {
                        vehicleArray[j] = vehicleArray[j + 1];
                    }
                    vehicleArray[list.Count - 1] = null!;
                    nextPos--;
                    Console.WriteLine(GetAll().Count);
                    return t;
                }
            }
          

        }
        public T? GetByRegNr(string s)
        {
            //since element in Array can be null. should use null check here to 
            //avoid Null Reference Exception
            var item = Array.Find(vehicleArray, v => v != null && v.RegNr == s);
            //dufault value for T is null         
            return item;
        }
        public List<T> GetAll()
        {
            //null check for empty elements in array
            var copyL = new List<T>();
            for (int i = 0; i < vehicleArray.Length && vehicleArray[i] != null; i++)
            {
                copyL.Add(vehicleArray[i]);
            }
            return copyL;
        }
        public bool isFull()
        {
            if (GetAll().Count == capacity)
                return true;
            return false;
        }
    }
}
