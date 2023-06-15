using System;
using System.Linq;
int[] nums = Console.ReadLine()
    .Split(", ",StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();
int count = nums.Length;
int sum = nums.Sum();
Console.WriteLine(count);
Console.WriteLine(sum);