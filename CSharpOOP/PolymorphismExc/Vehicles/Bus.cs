using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public class Bus : IVehicle
    {
        private const double airConditioning = 1.4;

        private const double emptyTank = 0;

        private double fuelCapacity;

        public Bus(double fuelQuantity, double fuelConsumptionPerKm, double fuelCapacity)
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

        public double FuelCapacity
        {
            get => fuelCapacity;
            private set
            {
                if (value < FuelQuantity)
                {
                    FuelQuantity = emptyTank;
                }
                fuelCapacity = value;
            }
        }

        public double TraveledKilometers { get; private set; }

        public void Drive(double km)
        {
            double consumption = km * (FuelConsumptionPerKm + airConditioning);

            if (FuelQuantity < consumption)
            {
                Console.WriteLine("Bus needs refueling");
            }
            else
            {
                Console.WriteLine($"Bus travelled {km} km");
                FuelQuantity -= consumption;
                TraveledKilometers += km;
            }
        }

        public void DriveEmpty(double km)
        {
            double consumption = km * FuelConsumptionPerKm;

            if (FuelQuantity < consumption)
            {
                Console.WriteLine("Bus needs refueling");
            }
            else
            {
                Console.WriteLine($"Bus travelled {km} km");
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
            FuelQuantity += fuel;
        }
    }
}
