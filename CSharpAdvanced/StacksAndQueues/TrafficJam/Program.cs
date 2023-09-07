using System;
using System.Collections.Generic;
using System.Linq;

namespace StacksAndQueues
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            Queue<string> cars = new Queue<string>();
            int n = int.Parse(Console.ReadLine());
            int counter = 0;
            while ((input = Console.ReadLine()) != "end")
            {

                if (input == "green")
                {
                    for (int i = 0; i < n; i++)
                    {
                        if (cars.Count == 0)
                        {
                            break;
                        }
                        Console.WriteLine($"{cars.Dequeue()} passed!");
                        counter++;
                    }
                }

                else
                {
                    cars.Enqueue(input);
                }
            }
            Console.WriteLine($"{counter} cars passed the crossroads.");
        }
    }
}
