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

        public Garage(int capacity)
        {
            this.capacity = capacity;
            this.list = new T[capacity];
        }

    }
}
