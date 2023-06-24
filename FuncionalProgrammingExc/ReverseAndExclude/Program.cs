using System;
using System.Collections.Generic;
using System.Linq;

Func<List<int>, int, List<int>> exclude = (numbers, divider) =>
{
    List<int> list = new List<int>();
    foreach (var number in numbers)
    {
        if (number % divider != 0)
        {
            list.Add(number);
        }
    }
    return list;
};

Func<List<int>, List<int>> reverse = numbers =>
{
    List<int> reversed= new List<int>();
    for (int i = numbers.Count - 1; i >= 0; i--)
    {
        reversed.Add(numbers[i]);
    }
    return reversed;
};

List<int> numbers = Console.ReadLine()
    .Split(' ')
    .Select(int.Parse)
    .ToList();
int divider = int.Parse(Console.ReadLine());

Console.WriteLine(string.Join(" ", 
    reverse(exclude(numbers, divider))));

