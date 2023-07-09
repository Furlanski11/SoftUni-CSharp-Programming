using System;
using Vehicles;


string[] carInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
string[] truckInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
string[] busInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);


Car car = new(double.Parse(carInput[1]), double.Parse(carInput[2]), double.Parse(carInput[3]));

Truck truck = new(double.Parse(truckInput[1]), double.Parse(truckInput[2]), double.Parse(truckInput[3]));

Bus bus = new(double.Parse(busInput[1]), double.Parse(busInput[2]), double.Parse(busInput[3]));

int lines = int.Parse(Console.ReadLine());

for (int i = 0; i < lines; i++)
{
    string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

    switch (tokens[0])
    {
        case "Drive":
            if (tokens[1] == "Car")
            {
                car.Drive(double.Parse(tokens[2]));
            }
            else if(tokens[1] == "Truck")
            {
                truck.Drive(double.Parse(tokens[2]));
            }
            else if (tokens[1] == "Bus")
            {
                bus.Drive(double.Parse(tokens[2]));
            }
            break;

        case "DriveEmpty":
            bus.DriveEmpty(double.Parse(tokens[2]));
            break;

        case "Refuel":
            if (tokens[1] == "Car")
            {
                car.Refuel(double.Parse(tokens[2]));
            }
            else if (tokens[1] == "Truck")
            {
                truck.Refuel(double.Parse(tokens[2]));
            }
            else if (tokens[1] == "Bus")
            {
                bus.Refuel(double.Parse(tokens[2]));
            }
            break;
    }
}

Console.WriteLine($"Car: {car.FuelQuantity:F2}");
Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
Console.WriteLine($"Bus: {bus.FuelQuantity:F2}");