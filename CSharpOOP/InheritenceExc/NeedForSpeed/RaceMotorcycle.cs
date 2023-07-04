using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed
{
    public class RaceMotorcycle : Motorcycle
    {
        private double defaultFuelConsumption = 8;
        public RaceMotorcycle(int horsePower, double fuel) : base(horsePower, fuel)
        {
            HorsePower= horsePower;
            Fuel= fuel;
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
