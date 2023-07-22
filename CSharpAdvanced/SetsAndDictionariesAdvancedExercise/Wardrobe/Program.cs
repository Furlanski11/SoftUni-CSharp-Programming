 using System;
using System.Collections.Generic;
using System.Linq;

namespace Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> wardrobe = 
                new Dictionary<string, Dictionary<string, int>>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(new string[] { " -> ", "," }, StringSplitOptions.RemoveEmptyEntries);
                string color = input[0];
                    if (!wardrobe.ContainsKey(color))
                    {
                        wardrobe.Add(color, new Dictionary<string, int>());
                    }
                for (int j = 1; j < input.Length; j++)
                {
                        if (!wardrobe[color].ContainsKey(input[j]))
                        {
                            wardrobe[color].Add(input[j], 1);
                        }
                        else
                        {
                            wardrobe[color][input[j]]++;
                        }
                }
            }
            
                string[] lookedForCloth = Console.ReadLine().Split(" ");
                foreach (var colors in wardrobe)
                {
                    Console.WriteLine($"{colors.Key} clothes:");
                    foreach (var item in wardrobe[colors.Key])
                    {
                        if (lookedForCloth[0] == colors.Key && lookedForCloth[1] == item.Key)
                        {
                            Console.WriteLine($"* {item.Key} - {item.Value} (found!)");
                        }
                        else
                        {
                            Console.WriteLine($"* {item.Key} - {item.Value}");
                        }
                    }
                }
        }
    }
}
