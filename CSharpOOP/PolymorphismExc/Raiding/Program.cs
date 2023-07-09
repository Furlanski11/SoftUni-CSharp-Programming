using Raiding;
using System;
using System.Collections.Generic;

List<BaseHero> heroes= new List<BaseHero>();

int numberOfHeroes = int.Parse(Console.ReadLine());

while(heroes.Count < numberOfHeroes)
{
    string name = Console.ReadLine();
    string type = Console.ReadLine();

    switch (type)
    {
        case "Druid":
            heroes.Add(new Druid(name, 80));
            break;
        case "Paladin":
            heroes.Add(new Paladin(name, 100));
            break;
        case "Rogue":
            heroes.Add(new Rogue(name, 80));
            break;
        case "Warrior":
            heroes.Add(new Warrior(name, 100));
            break;
        default:
            Console.WriteLine("Invalid hero!");
            break;
    }
}

int bossHealth = int.Parse(Console.ReadLine());

int powersSum = 0;

foreach (var hero in heroes)
{
    Console.WriteLine(hero.CastAbility());
    powersSum += hero.Power;
}

if(powersSum >= bossHealth)
{
    Console.WriteLine("Victory!");
}
else
{
    Console.WriteLine("Defeat...");
}