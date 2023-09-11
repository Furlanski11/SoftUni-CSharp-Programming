using System;
using System.Collections.Generic;
using System.Linq;

namespace StacksAndQueues
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split(" ").Select(int.Parse).ToArray();
            Queue<int> numbers = new Queue<int>(nums);
            List<int> evenNumbers = new List<int>();
            while (numbers.Count != 0)
            {
                int curNum = numbers.Dequeue();
                if (curNum % 2 == 0)
                {
                    evenNumbers.Add(curNum);
                }
            }
            Console.WriteLine(string.Join(", ", evenNumbers));
        }
    }
}
