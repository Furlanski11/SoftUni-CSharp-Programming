using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed
{
    public class Car : Vehicle
    {
        private double defaultFuelConsumption = 3;

        public Car(int horsePower, double fuel) :base (horsePower, fuel)  
        {
            HorsePower = horsePower;
            Fuel = fuel;
        }

        public override void Drive(double kilometers)
        {
            if (FuelConsumption != 0)
            {
                Fuel -= kilometers * FuelConsumption;
            }
            else
            {
                Fuel -= kilometers * defaultFuelConsumption;
            }
        }
    }
}
