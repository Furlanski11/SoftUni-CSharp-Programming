using System;
using System.Collections.Generic;
using System.Threading.Tasks.Dataflow;


int lastNumber = 1;
List<int> ReadNumber(int start, int end)
{
    List<int> numbers = new List<int>();
    
    while (numbers.Count < 10)
    {
        
        try
        {
          int number = int.Parse(Console.ReadLine());
          
            if(number <= lastNumber || number >= end)
            {
                throw new ArgumentException($"Your number is not in range {lastNumber} - {100}!");
            }
            else
            {
                numbers.Add(number);
            }
            lastNumber= number;
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid Number!");
        }

    }
    return numbers;
}

Console.WriteLine(string.Join(", ", ReadNumber(1, 100)));