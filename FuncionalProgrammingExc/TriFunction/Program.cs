using System;
using System.Collections.Generic;
using System.Linq;

int length = int.Parse(Console.ReadLine());

List<string> list = Console.ReadLine()
	.Split(" ")
	.ToList();

Func<List<string>, int,string> func = (list, length) =>
{
	int newLength = 0;
	string person = string.Empty;
	foreach (var name in list)
	{
		foreach (char ch in name)
		{
			newLength += ch;
		}
		if(newLength >= length)
		{
			person = name;
			return person;
		}
         newLength = 0;
	}
	
	return null;
};
	Console.WriteLine(func(list, length));
