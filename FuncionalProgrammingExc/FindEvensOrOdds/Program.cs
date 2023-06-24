using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

Predicate<int> isEven = number =>
{
    if(number % 2 == 0)
    {
        return true;
    }
    return false;
};

int[] borders = Console.ReadLine()
    .Split(' ')
    .Select(int.Parse)
    .ToArray();
 List<int> nums= new List<int>();
string command = Console.ReadLine();
for(int i = borders[0]; i <= borders[1]; i++)
{
    if(command == "even")
    {
        if (isEven(i))
        {
            Console.Write(i + " ");
        }
    }
    else
    {
        if (!isEven(i))
        {
            Console.Write(i + " ");
        }
    }
}

