using System;
using System.Collections.Generic;
using System.Linq;

namespace StacksAndQueues
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> children = Console.ReadLine().Split(" ").ToList();
            Queue<string> ingameKids = new Queue<string>(children);
            int throws = int.Parse(Console.ReadLine());
            string currentKid = string.Empty;
            while (ingameKids.Count != 1)
            {
                for (int i = 1; i < throws; i++)
                {
                    currentKid = ingameKids.Dequeue();
                    ingameKids.Enqueue(currentKid);
                }
                Console.WriteLine($"Removed {ingameKids.Dequeue()}");
            }
            Console.WriteLine($"Last is {ingameKids.Dequeue()}");
        }
    }
}
