using System;
using System.Collections.Generic;
using System.Linq;

namespace StacksAndQueues
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine()
                .Split().Select(int.Parse).ToList();
            Stack<int> numbers = new Stack<int>(input);
            string command = string.Empty;
            while ((command = Console.ReadLine().ToLower()) != "end")
            {
                string[] commandIndex = command.Split(" ",
                    StringSplitOptions.RemoveEmptyEntries);
                if (commandIndex[0] == "add")
                {
                    int first = int.Parse(commandIndex[1]);
                    int second = int.Parse(commandIndex[2]);
                    numbers.Push(first);
                    numbers.Push(second);
                }
                else if (commandIndex[0] == "remove")
                {
                    if (int.Parse(commandIndex[1]) <= numbers.Count)
                    {
                        for (int i = 0; i < int.Parse(commandIndex[1]); i++)
                        {
                            numbers.Pop();
                        }
                    }
                }
            }
            int sum = 0;
            while (numbers.Count != 0)
            {
                sum += numbers.Pop();
            }
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
