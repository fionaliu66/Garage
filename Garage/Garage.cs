﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GarageOne.Interface;

namespace Garage
{
    public class Garage<T> : IGarage<T> where T : Vehicle
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
        public T? RemoveByRegNr(string s)
        {
            var list = GetAll();
            if (list.Count == 0)
            {
                return null;
            }
            else
            {
                //var t = vehicleArray.FirstOrDefault(v => v.RegNr.Equals(s)); wrong linq search
                var t = vehicleArray.FirstOrDefault(x => x.RegisterNr == s);
                if (t == null)
                {
                    return null;
                }
                else
                {
                    //remove vehicle here manually, 
                    int i = Array.IndexOf(vehicleArray, t);
                    for (int j = i; j < list.Count - 1; j++)
                    {
                        vehicleArray[j] = vehicleArray[j + 1];
                    }
                    vehicleArray[list.Count - 1] = null!;
                    nextPos--;
                    return t;
                }
            }
        }
        public T? GetByRegNr(string s)
        {
            //since element in Array can be null. should use null check here to 
            //avoid Null Reference Exception
            var item = Array.Find(vehicleArray, v => v != null && v.RegisterNr == s);
            //dufault value for T is null
            //safe return a copy if item        
            return item; ;
        }
        public List<T> GetAll()
        {
            //null check for empty elements in array
            var copyL = new List<T>();
            for (int i = 0; i < vehicleArray.Length && vehicleArray[i] != null; i++)
            {
                copyL.Add(vehicleArray[i]);
            }
            //why am i not getting a compile wrong here
            //the garages does not implement IEnumerable and Ienumerator
            //foreach (var v in vehicleArray)
            //{
            //    Console.WriteLine(v.ToString());
            //}
            return copyL;
        }
        public bool isFull()
        {
            return GetAll().Count == capacity;
        }
        //public IEnumerator GetEnumerator() =>vehicleArray.GetEnumerator();
    }
}
