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
            Stack<int> firstbrackets = new Stack<int>();
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    firstbrackets.Push(i);
                }
                if (input[i] == ')')
                {
                    int firstBracket = firstbrackets.Pop();
                    for (int j = firstBracket; j <= i; j++)
                    {
                        Console.Write(input[j]);
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}
