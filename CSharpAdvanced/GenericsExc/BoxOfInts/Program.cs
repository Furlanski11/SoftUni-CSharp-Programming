using BoxOfInts;
using System;

int n = int.Parse(Console.ReadLine());

Box<int> box = new();
for (int i = 0; i < n; i++)
{
    box.Add(int.Parse(Console.ReadLine()));
}

Console.WriteLine(box.ToString());
