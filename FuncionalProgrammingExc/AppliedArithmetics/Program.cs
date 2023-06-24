using System;
using System.Linq;

Action<int[]> printNums = numbers => 
Console.WriteLine(string.Join(" ", numbers));
Func<int[], int[]> addNums = numbers =>
{
    for (int i = 0; i < numbers.Count(); i++)
    {
        numbers[i]++;
    }
    return numbers;
};
Func<int[], int[]> multiplyNums = numbers =>
{
    for (int i = 0; i < numbers.Count(); i++)
    {
        numbers[i] *= 2;
    }
    return numbers;
};
Func<int[], int[]> subtractNums = numbers =>  
{
    for (int i = 0; i < numbers.Count(); i++)
    {
        numbers[i]--;
    }
    return numbers;
};
int[] numbers = Console.ReadLine()
    .Split(' ')
    .Select(int.Parse)
    .ToArray();
string command = string.Empty;
while((command = Console.ReadLine()) != "end")
{
    switch (command)
    {
        case "add":
            addNums(numbers);
            break;
        case "multiply":
            multiplyNums(numbers);
            break;
        case "subtract":
            subtractNums(numbers);
            break;
        case "print":
            printNums(numbers);
            break;
    }
}