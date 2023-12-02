using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//100/100 SUCCESS
int[] mgCaffeine = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int[] energyDrinks = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

Stack<int> mgOfCaffeine= new Stack<int>();
Queue<int> energyDrinkss= new Queue<int>();
for (int i = 0; i < mgCaffeine.Length; i++)
{
    mgOfCaffeine.Push(mgCaffeine[i]);
}

for (int i = 0; i < energyDrinks.Length; i++)
{
    energyDrinkss.Enqueue(energyDrinks[i]);
}

int maxCafeine = 300;
int stamatCaffeine = 0;

while(true)
{
    int curentCaffeine = mgOfCaffeine.Peek();
    int currentEnergyDrink = energyDrinkss.Peek();
    if(curentCaffeine * currentEnergyDrink + stamatCaffeine <= maxCafeine)
    {
        stamatCaffeine += mgOfCaffeine.Pop() * energyDrinkss.Dequeue();
    }
    else
    {
        mgOfCaffeine.Pop();
        int currentDrink = energyDrinkss.Dequeue();
        energyDrinkss.Enqueue(currentDrink);
        if (stamatCaffeine - 30 >= 0)
        {
            stamatCaffeine -= 30;
        }
    }
    if(energyDrinkss.Count == 0)
    {
        Console.WriteLine($"At least Stamat wasn't exceeding the maximum caffeine.");
        Console.WriteLine($"Stamat is going to sleep with {stamatCaffeine} mg caffeine.");
        break;
    }
    else if(mgOfCaffeine.Count == 0)
    {
        Console.WriteLine($"Drinks left: {string.Join(", ", energyDrinkss)}");
        Console.WriteLine($"Stamat is going to sleep with {stamatCaffeine} mg caffeine.");
        break;
    }
}