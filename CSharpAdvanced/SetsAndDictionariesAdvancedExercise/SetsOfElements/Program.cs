using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] lenghts = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();
            HashSet<int> first = new HashSet<int>();
            HashSet<int> second = new HashSet<int>();
            HashSet<int> third = new HashSet<int>();
            for (int i = 0; i < lenghts[0]; i++)
            {
                int nums = int.Parse(Console.ReadLine());
                first.Add(nums);
            }
            for (int i = 0; i < lenghts[1]; i++)
            {
                int nums = int.Parse(Console.ReadLine());
                second.Add(nums);
            }
            foreach (var num in first)
            {
                if (second.Contains(num))
                {
                    third.Add(num);
                }
            }
            Console.WriteLine(string.Join(" ",third));
        }
    }
}
