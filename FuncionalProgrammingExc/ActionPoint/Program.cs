using System;

Action<string> output = name => Console.WriteLine(name);
string[] names = Console.ReadLine().Split(" ");

foreach (string name in names)
{
    output(name);
}