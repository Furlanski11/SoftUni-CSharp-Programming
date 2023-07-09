using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks.Dataflow;

namespace LargestThreeNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();
            List<int> nums= new List<int>(numbers);
            int[] sorted = nums.OrderByDescending(x => x).ToArray();
            if (sorted.Length >= 3)
            {

                for (int i = 0; i < 3; i++)
                {
                    Console.Write($"{sorted[i]} ");
                }
            }
            else
            {
                Console.WriteLine(string.Join(" ", sorted));
            }
        }
    }
}
