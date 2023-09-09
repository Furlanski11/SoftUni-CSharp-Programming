using System;
using System.Collections.Generic;
using System.Linq;

namespace StacksAndQueues
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] splitedInput = input.Split(" ");
            Stack<string> stack = new Stack<string>(splitedInput.Reverse());
            int sum = int.Parse(stack.Pop());
            while (stack.Count != 0)
            {
                string currentPop = stack.Pop();
                if (currentPop == "+")
                {
                    sum += int.Parse(stack.Pop());
                }
                else if (currentPop == "-")
                {
                    sum -= int.Parse(stack.Pop());
                }
            }
            Console.WriteLine(sum);
        }
    }
}
