using System;
using System.Collections.Generic;

int n = int.Parse(Console.ReadLine());
Dictionary<string, int> people = new Dictionary<string, int>();
for(int i = 0;i < n; i++)
{
    string[] input= Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries);
    people.Add(input[0], int.Parse(input[1]));   
}
string condition = Console.ReadLine();
int age = int.Parse(Console.ReadLine());
string format = Console.ReadLine();
if(condition == "older")
{
    switch (format)
    {
        case "name age":
            foreach (var person in people)
            {
                if (person.Value >= age)
                {
                    Console.WriteLine($"{person.Key} - {person.Value}");
                }
                }
            break;
        case "name":
            foreach (var person in people)
            {
                if (person.Value >= age)
                {
                    Console.WriteLine($"{person.Key}");
                }
            }
            break;
        case "age":
            foreach (var person in people)
            {
                if (person.Value >= age)
                {
                    Console.WriteLine($"{person.Value}");
                }
            }
            break;
    }
}
else
{
    switch (format)
    {
        case "name age":
            foreach (var person in people)
            {
                if (person.Value < age)
                {
                    Console.WriteLine($"{person.Key} - {person.Value}");
                }
            }
            break;
        case "name":
            foreach (var person in people)
            {
                if (person.Value < age)
                {
                    Console.WriteLine($"{person.Key}");
                }
            }
            break;
        case "age":
            foreach (var person in people)
            {
                if (person.Value < age)
                {
                    Console.WriteLine($"{person.Value}");
                }
            }
            break;
    }
}