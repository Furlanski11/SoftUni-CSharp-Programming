using SpecialCars;
using System;
using System.Collections.Generic;
using System.Linq;

string command = string.Empty;
Tire[] tires = new Tire[5];

Car[] cars= new Car[5];
List<Tire[]> listTires = new();
List<Engine> listEngines = new();
List<Car[]> listCars = new();
while((command = Console.ReadLine()) != "No more tires")
{
    string[] tokens = command.Split(' ');
    
    tires = new Tire[]
     {
       new Tire(int.Parse(tokens[0]), double.Parse(tokens[1])),
       new Tire(int.Parse(tokens[2]), double.Parse(tokens[3])),
       new Tire(int.Parse(tokens[4]), double.Parse(tokens[5])),
       new Tire(int.Parse(tokens[6]), double.Parse(tokens[7])),
     };
    listTires.Add(tires);
}

while ((command = Console.ReadLine()) != "Engines done")
{
    string[] tokens = command.Split(' ');

    Engine engine = new Engine(int.Parse(tokens[0]), double.Parse(tokens[1]));
    
    listEngines.Add(engine);
}

while ((command = Console.ReadLine()) != "Show special")
{
    string[] tokens = command.Split(' ');

    cars = new Car[]
    {
        new Car(tokens[0],tokens[1], int.Parse(tokens[2]),
        int.Parse(tokens[3]), int.Parse(tokens[4]),
        listEngines[int.Parse(tokens[5])],
        listTires[int.Parse(tokens[6])])
    };
    listCars.Add(cars);
}
double pressureSum = 0;
foreach (var car in listCars)
{
    foreach (var item in car)
    {
        foreach (var tire in item.Tire)
        {
            pressureSum += tire.Pressure;
        }
        if(pressureSum >= 9 && pressureSum <= 10 && item.Engine.HorsePower >= 330)
        {

        Console.WriteLine($"Make: {item.Make}");
        Console.WriteLine($"Model: {item.Model}");
        Console.WriteLine($"Year: {item.Year}");
        Console.WriteLine($"HorsePowers: {item.Engine.HorsePower}");
        Console.WriteLine($"FuelQuantity: {item.FuelQuatity-= item.FuelConsumption * 0.2}");

        }
        pressureSum = 0;
    }
    
    
}
