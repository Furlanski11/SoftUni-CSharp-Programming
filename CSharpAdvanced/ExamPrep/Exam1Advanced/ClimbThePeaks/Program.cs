using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
//100/100 SUCCESS!!!
string food = Console.ReadLine();
string staminaInput = Console.ReadLine();

Stack<int> foodForSevenDays = new Stack<int>(food.Split(", ").Select(int.Parse));

Queue<int> stamina = new Queue<int>(staminaInput.Split(", ").Select(int.Parse));

Queue<Peak> peeks = new ();
peeks.Enqueue (new Peak("Vihren", 80));
peeks.Enqueue(new Peak("Kutelo", 90));
peeks.Enqueue(new Peak("Banski Suhodol", 100));
peeks.Enqueue(new Peak("Polezhan", 60));
peeks.Enqueue(new Peak("Kamenitza", 70));


List<Peak> conqueredPeeks = new List<Peak>();

while (foodForSevenDays.Any())
{
    if(peeks.Count== 0)
    {
        break;
    }
    int currentFood = foodForSevenDays.Peek();
    int currentStamina = stamina.Peek();
    int sum = currentFood + currentStamina;
    Peak currentPeek = peeks.Peek();

   if(sum >= currentPeek.Difficulty)
    {
        foodForSevenDays.Pop();
        stamina.Dequeue();
        conqueredPeeks.Add(currentPeek);
        peeks.Dequeue();
    }
    else
    {
        foodForSevenDays.Pop();
        stamina.Dequeue();
    }

}

 if(peeks.Count == 0)
{
    Console.WriteLine("Alex did it! He climbed all top five Pirin peaks in one week -> @FIVEinAWEEK");

    if (conqueredPeeks.Any())
    {
        Console.WriteLine("Conquered peaks:");
        foreach (var peek in conqueredPeeks)
        {
            Console.WriteLine(peek.Name);
        }
    }
}
else
{
    Console.WriteLine("Alex failed! He has to organize his journey better next time -> @PIRINWINS");

    if (conqueredPeeks.Any())
    {
        Console.WriteLine("Conquered peaks:");
        foreach (var peek in conqueredPeeks)
        {
            Console.WriteLine(peek.Name);
        }
    }
}

 public class Peak
{
    public Peak(string name, int difficulty)
    {
        Name = name;
        Difficulty = difficulty;
    }

    public string Name { get; set; }
    public int Difficulty { get; set; }
}