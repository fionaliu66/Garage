﻿using Garage;

namespace GarageOne.Interface
{
    public interface IGarageHandler<T> where T : Vehicle
    {
        void Add(T item);
        void AddVehicle();
        void GetVehicle(string s);
        void GetVehiclesByProp();
        void GetVehiclesByType();
        void PrintAllVehicle();
        void Remove(string regNr);
    }
}