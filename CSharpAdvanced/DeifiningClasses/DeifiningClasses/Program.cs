using CarManuFacturer;
using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main()
        {
            Car car = new Car()
            {
                Make = "VW",
                Model = "Golf 4",
                Year = 2000,
                FuelQuantity = 50,
                FuelConsumption = 5
            };
            Console.WriteLine(car.WhoAmI());
            car.Drive(5); 
        }
    }
}
