using System;
using System.Collections.Generic;
using System.Linq;

namespace CitiesByContinetAndCountry
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, List<string>>> continents = 
                new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ");
                string continent = input[0];
                string country = input[1];
                string town = input[2];
                if (!continents.ContainsKey(continent))
                {
                    continents.Add(continent, new Dictionary<string, List<string>>());
                    continents[continent].Add(country, new List<string>());
                    continents[continent][country].Add(town);
                }
                else
                {
                    if (!continents[continent].ContainsKey(country))
                    {
                        continents[continent].Add(country, new List<string>());
                        continents[continent][country].Add(town);
                    }
                    else
                    {
                        continents[continent][country].Add(town);
                    }
                }
            }
            foreach (var continent in continents)
            {
                Console.WriteLine($"{continent.Key}:");
                foreach (var country in continent.Value)
                {
                    Console.Write($"  {country.Key} -> ");
                    Console.Write($"{string.Join(", ", country.Value)}");
                    Console.WriteLine();
                }
            }
        }
    }
}
