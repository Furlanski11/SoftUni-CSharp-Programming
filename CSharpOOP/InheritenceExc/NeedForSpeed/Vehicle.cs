using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed
{
	public class Vehicle
	{
		public double defaultFuelConsumption = 1.25;

		public Vehicle(int horsePower, double fuel)
		{
			HorsePower = horsePower;
			Fuel = fuel;
		}

		public double FuelConsumption { get; set; }

		public double Fuel { get; set; }

		public int HorsePower { get; set; }

		public virtual void Drive(double kilometers)
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
