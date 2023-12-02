using System;
using System.Collections.Generic;
using System.Linq;

Dictionary<string, int> locations = new();
//100/100 => SUCCESS!!!

locations.Add("Sink", 0);

locations.Add("Oven", 0);

locations.Add("Countertop", 0);

locations.Add("Wall", 0);

locations.Add("Floor", 0);

Stack<int> whiteTiles = new Stack<int>(Console.ReadLine().Split(" ").Select(int.Parse));
Queue<int> greyTiles = new Queue<int>(Console.ReadLine().Split(" ").Select(int.Parse));

while(whiteTiles.Count > 0 || greyTiles.Count > 0 || whiteTiles.Count > 0 && greyTiles.Count > 0)
{
    if(whiteTiles.Count == 0)
    {
        break;
    }
    if(greyTiles.Count == 0)
    {
        break;
    }
  int currentWhiteTile = whiteTiles.Peek();
  int currentGreyTile = greyTiles.Peek();
  int sumOfTiles = currentGreyTile + currentWhiteTile;
    if (currentWhiteTile == currentGreyTile)
    {
        if (sumOfTiles == 40)
        {
            locations["Sink"]++;
        }
        else if (sumOfTiles == 50)
        {
            locations["Oven"]++;
        }
        else if (sumOfTiles == 60)
        {
            locations["Countertop"]++;
        }
        else if (sumOfTiles == 70)
        {
            locations["Wall"]++;
        }
        else
        {
            locations["Floor"]++;
        }
        whiteTiles.Pop();
        greyTiles.Dequeue();
    }
    else
    {
        greyTiles.Dequeue();
        greyTiles.Enqueue(currentGreyTile);
        whiteTiles.Pop();
        whiteTiles.Push(currentWhiteTile / 2);
    }
}
if(whiteTiles.Count > 0)
{
    Console.WriteLine($"White tiles left: {string.Join(", ", whiteTiles)}");
}
else
{
    Console.WriteLine($"White tiles left: none");
}

if (greyTiles.Count > 0)
{
    Console.WriteLine($"Grey tiles left: {string.Join(", ", greyTiles)}");
}
else
{
    Console.WriteLine($"Grey tiles left: none");
}

foreach (var location in locations.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
{
    if(location.Value > 0)
    {
        Console.WriteLine($"{location.Key}: {location.Value}");
    }
}