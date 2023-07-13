using System;

string[] input = Console.ReadLine().Split(' ');

int sum = 0;

foreach (var element in input)
{
    try
    {
        if (int.Parse(element) > int.MaxValue)
        {
            throw new OverflowException();
        }
        else if (!int.TryParse(element, out int result))
        {
            throw new FormatException();
        }
        sum += int.Parse(element);
        PrintMessage(element, sum);
    }
    catch (OverflowException)
    {
        Console.WriteLine($"The element '{element}' is out of range!");
        PrintMessage(element, sum);
    }
    catch (FormatException)
    {
        Console.WriteLine($"The element '{element}' is in wrong format!");
        PrintMessage(element, sum);
    }
}
Console.WriteLine($"The total sum of all integers is: {sum}");

void PrintMessage(string element, int sum)
{
    Console.WriteLine($"Element '{element}' processed - current sum: {sum}");
}
