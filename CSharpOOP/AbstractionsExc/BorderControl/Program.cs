using BorderControl;
using System;
using System.Collections.Generic;
using System.Linq;

List<Rebel> rebels = new List<Rebel>();
List<Citizen> citizens = new List<Citizen>();
int people = int.Parse(Console.ReadLine());

for (int i = 0; i < people; i++)
{
    string[] input = Console.ReadLine().Split(" ",
        StringSplitOptions.RemoveEmptyEntries);

    if (input.Length == 4)
    {
        citizens.Add(new Citizen(input[0], int.Parse(input[1]), input[2], input[3]));
    }
    else
    {
        rebels.Add(new Rebel(input[0], int.Parse(input[1]), input[2]));
    }
}

string command = string.Empty;

int soldFood = 0;

while ((command = Console.ReadLine()) != "End")
{
    Citizen foundCitizen = citizens.FirstOrDefault(c => c.Name == command);
    if (foundCitizen != null)
    {
        foundCitizen.BuyFood();
    }

    Rebel foundRebel = rebels.FirstOrDefault(r => r.Name == command);
    
    if (foundRebel != null)
    {
        foundRebel.BuyFood();
    }
}

foreach (var citizen in citizens)
{
    soldFood += citizen.Food;
}

foreach (var rebel in rebels)
{
    soldFood += rebel.Food;
}

Console.WriteLine(soldFood);

