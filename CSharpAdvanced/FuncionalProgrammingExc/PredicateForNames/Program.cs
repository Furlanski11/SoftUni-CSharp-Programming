using System;
using System.Collections.Generic;
using System.Linq;

int nameLenght = int.Parse(Console.ReadLine());

Predicate<string> isTrue = name =>
{
        if(name.Length <= nameLenght)
        {
            return true;
        }
    
    return false;
};

List<string> names = Console.ReadLine()
    .Split(" ")
    .ToList();

foreach (var name in names)
{
    if (isTrue(name))
    {
        Console.WriteLine(name);
    }
}
