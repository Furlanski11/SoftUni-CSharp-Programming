using System;
using System.Collections.Generic;
using System.Linq;

int[] integers = Console.ReadLine()
    .Split(' ')
    .Select(int.Parse)
    .ToArray();


int exceptionCounter = 0;

while (exceptionCounter < 3)
{
    try
    {
        string[] input = Console.ReadLine().Split(' ');
        string command = input[0];
        switch (command)
        {
            case "Replace":
                int index = int.Parse(input[1]);
                int element = int.Parse(input[2]);
                integers[index] = element;
                
                break;

            case "Print":
                 int startIndex = int.Parse(input[1]);
                 int endIndex = int.Parse(input[2]);
                 List<int> elements = new();
                for (int i = startIndex; i <= endIndex; i++)
                {
                    if(endIndex >= integers.Length || startIndex < 0 || startIndex >= endIndex)
                    {
                        throw new IndexOutOfRangeException();
                    }

                    elements.Add(integers[i]);
                }
                Console.WriteLine(string.Join(", ", elements));
                break;

            case "Show":
                index = int.Parse(input[1]);
                Console.WriteLine(integers[index]);
                break;
        }
    }
    catch (IndexOutOfRangeException)
    {
        exceptionCounter++;
        Console.WriteLine("The index does not exist!");
    }
    catch(FormatException)
    {
        exceptionCounter++;
        Console.WriteLine("The variable is not in the correct format!");
    }
}
Console.WriteLine(string.Join(", ", integers));