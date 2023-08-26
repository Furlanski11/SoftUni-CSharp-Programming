using System;
using Tuple;

string nameAdress = Console.ReadLine();

string[] names = nameAdress.Split(" ");

CustomTuple<string, string> tupleNames = new($"{names[0]} {names[1]}", names[2]);

string beers = Console.ReadLine();

string[] beersInput = beers.Split(" ");

CustomTuple<string, int> tupleBeers = new(beersInput[0], int.Parse(beersInput[1]));

string[] numbers = Console.ReadLine().Split(" ");

CustomTuple<int, double> nums = new(int.Parse(numbers[0]), double.Parse(numbers[1]));

Console.WriteLine(tupleNames);
Console.WriteLine(tupleBeers);
Console.WriteLine(nums);