using Garage;
using GarageOne.Interface;

namespace GarageOneTest
{
    public class UnitTest1
    {
        private IGarage<Vehicle> garage = new Garage<Vehicle>(10);
        [Fact]
        public void Add_AddVehicleToGarage_SuccessParked()
        {
            //Arrange
            Vehicle v = new("ABC123", "White", 4);
            //Act
            garage.AddVehicle(v);
            //Assert
            Assert.Contains(v, garage.GetAll());
        }
        [Fact]
        public void Remove_RemoveVehicleByRegNr_SuccessRemoved()
        {
            //Arrange
            Vehicle vehicle = new("CCC222", "Black", 8);
            garage.AddVehicle(vehicle);
            //Act
            var respect = garage.RemoveByRegNr("CCC222");
            //Assert
            Assert.Equal(respect, vehicle);
        }
        [Fact]
        public void GetByRegNr_GetVehicleByRegNr_SuccessGet()
        {
            //Arrange
            Vehicle v = new("FFF123", "Pink", 2);
            garage.AddVehicle(v);
            //Act
            var respect = garage.GetByRegNr("FFF123");
            //Assert
            Assert.Equal(respect, v);
        }
        [Fact]
        public void GetAllVehicle_GetVehicleSum_SuccessCount()
        {
            //Arrange
            Vehicle[] vehicles = [
                new Vehicle("ABC123","White",8),
                new Vehicle("ACC123","White",8),
                new Vehicle("ADC123","White",8),
                new Vehicle("AEC123","White",8),
                new Vehicle("AFC123","White",8),
              ];
            int exceptSum = vehicles.Length;
            //Act
            foreach(var v in vehicles)
            {
                garage.AddVehicle(v);
            }
            int result = garage.GetAll().Count;
            //Assert
            Assert.Equal(exceptSum, result);
        }

    }
}