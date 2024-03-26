
using Garage;

namespace GarageOne.Interface
{
    public interface IGarage<T> where T : Vehicle
    {
        void AddVehicle(T item);
        List<T> GetAll();
        T? GetByRegNr(string s);
        bool isFull();
        T? RemoveByRegNr(string s);
    }
}