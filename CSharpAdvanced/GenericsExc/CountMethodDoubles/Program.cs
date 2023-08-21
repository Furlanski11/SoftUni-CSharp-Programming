using CountMethodDoubles;
using System;

int n = int.Parse(Console.ReadLine());
Box<double> box = new Box<double>();

for (int i = 0; i < n; i++)
{
    box.Add(double.Parse(Console.ReadLine()));
}

double comparer = double.Parse(Console.ReadLine());

Console.WriteLine(box.Bigger(comparer));