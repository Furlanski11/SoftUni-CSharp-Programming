using BoxOfString;
using System;
using System.Collections.Generic;

int n = int.Parse(Console.ReadLine());

Box<string> box = new();
for(int i = 0;i < n; i++)
{
    box.Add(Console.ReadLine());
}

Console.WriteLine(box.ToString());