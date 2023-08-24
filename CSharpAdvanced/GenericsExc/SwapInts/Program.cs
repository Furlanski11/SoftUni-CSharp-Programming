using SwapInts;
using System;

using System.Collections.Generic;
using System.Linq;

int n = int.Parse(Console.ReadLine());
Box<int> box = new Box<int>();

for (int i = 0; i < n; i++)
{
    box.Add(int.Parse(Console.ReadLine()));
}

int[] array = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
int first = array[0];
int second = array[1];

box.Swap(first, second);

Console.WriteLine(box.ToString());
