using System;

Predicate<string> function = n => n[0] == n.ToUpper()[0];

string[] text = Console.ReadLine()
    .Split(' ',StringSplitOptions.RemoveEmptyEntries)
    .Where(n => function(n))
    .ToArray();
foreach (var word in text)
{
    Console.WriteLine(word);
}

