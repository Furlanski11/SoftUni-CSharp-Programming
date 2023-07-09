using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public class Truck : IVehicle
    {
        private const double airConditioning = 1.6;

        private double emptyTank = 0;

        private double fuelCapacity;

        public Truck(double fuelQuantity, double fuelConsumptionPerKm, double fuelCapacity)
        {
            FuelQuantity = fuelQuantity;

            FuelConsumptionPerKm = fuelConsumptionPerKm;

            FuelCapacity = fuelCapacity;
        }

        public double FuelQuantity
        {
            get;
            private set;

        }

        public double FuelConsumptionPerKm { get; private set; }

        public double TraveledKilometers { get; private set; }

        public double FuelCapacity
        {
            get => fuelCapacity;
            private set
            {
                if(value < FuelQuantity)
                {
                    FuelQuantity = emptyTank;
                }
                fuelCapacity = value;
            }
        }

        public void Drive(double km)
        {
            double consumption = km * (FuelConsumptionPerKm + airConditioning);

            if (FuelQuantity < consumption)
            {
                Console.WriteLine("Truck needs refueling");
            }
            else
            {
                Console.WriteLine($"Truck travelled {km} km");
                FuelQuantity -= consumption;
                TraveledKilometers += km;
            }
        }

        public void Refuel(double fuel)
        {
            if (fuel <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
                return;
            }
            if (FuelQuantity + fuel > FuelCapacity)
            {
                Console.WriteLine($"Cannot fit {fuel} fuel in the tank");
                return;
            }
            FuelQuantity += fuel - (fuel * 0.05);
        }
    }
}
