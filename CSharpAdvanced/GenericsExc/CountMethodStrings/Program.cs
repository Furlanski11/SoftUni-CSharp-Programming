using CountMethodStrings;
using System;
using System.Collections.Generic;
using System.Linq;

int n = int.Parse(Console.ReadLine());
Box<string> box = new Box<string>();

for (int i = 0; i < n; i++)
{
    box.Add(Console.ReadLine());
}

string comparer = Console.ReadLine();

Console.WriteLine(box.Bigger(comparer));
