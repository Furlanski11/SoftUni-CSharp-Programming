using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public interface IVehicle
    {
        double FuelQuantity { get; }
        double FuelConsumptionPerKm { get; }
        double FuelCapacity { get; }
        public void Drive(double km);
        public void Refuel(double fuel);
    }
}
