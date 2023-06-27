using System;
using System.Linq;

Func<int[], int> customMIN = nums =>
{
    int minValue = int.MaxValue;
    foreach (var number in nums)
    {
        if(number < minValue)
        {
            minValue = number;
        }
    }
    return minValue;
};
int[] nums = Console.ReadLine()
    .Split(" ")
    .Select(int.Parse)
    .ToArray();
Console.WriteLine(customMIN(nums));

