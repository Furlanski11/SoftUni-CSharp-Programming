using System;
using System.Linq;
Func<double, double> pricesWithVAT = x => x + x * 0.20;

double[] prices = Console.ReadLine()
    .Split(", ",StringSplitOptions.RemoveEmptyEntries)
    .Select(double.Parse)
    .ToArray();
foreach (var price in prices)
{
    Console.WriteLine($"{pricesWithVAT(price):f2}");
}

