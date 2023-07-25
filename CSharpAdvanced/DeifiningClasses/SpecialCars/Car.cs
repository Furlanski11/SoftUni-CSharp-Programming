using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SpecialCars
{
    public class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelQuatity;
        private int fuelConsumption;
        private Engine engine;
        private Tire[] tire;

        public Car(string make, string model, int year, int fuelQuantity, int fuelConsumption, Engine engine, Tire[] tire)
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
            this.FuelQuatity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.Engine = engine;
            this.Tire = tire;
        }
        public string Make { get { return make; } set { make = value; } }
        public string Model { get { return model; } set { model = value; } }
        public int Year { get { return year;} set { year = value; } }
        public double FuelQuatity { get { return fuelQuatity; } set { fuelQuatity = value; } }
        public int FuelConsumption { get { return fuelConsumption; } set { fuelConsumption = value; } }
        public Engine Engine { get { return engine; } set { engine = value; } }
        public Tire[] Tire { get { return tire; } set { tire = value; } }
    }   
}
