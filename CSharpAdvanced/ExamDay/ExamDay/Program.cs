using System;
using System.Collections.Generic;
using System.Linq;

Queue<int> textile = new(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
Stack<int> meds = new(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

Dictionary<string, int> doneMeds = new();

doneMeds.Add("Patch", 0);
doneMeds.Add("Bandage", 0);
doneMeds.Add("MedKit", 0);

while (true)
{
     if (textile.Count == 0 && meds.Count == 0)
    {
        Console.WriteLine("Textiles and medicaments are both empty.");
        foreach (var item in doneMeds.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
        {
            if (item.Value > 0)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }

        };
        break;
    }
    else if (textile.Count == 0)
    {
        Console.WriteLine("Textiles are empty.");

        foreach (var item in doneMeds.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
        {
            if (item.Value > 0)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
         
        }
        if (meds.Any())
        {
            Console.Write("Medicaments left: ");
            Console.WriteLine(string.Join(", ", meds));
        }
        break;
    }
    else if (meds.Count == 0)
    {
        Console.WriteLine("Medicaments are empty.");

        foreach (var item in doneMeds.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
        {
            if (item.Value > 0)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
        }
        if (textile.Any())
        {
            Console.Write("Textiles left: ");
            Console.WriteLine(string.Join(", ", textile));
        }
        break;
    }
    int currentTextile = textile.Peek();
    int currentMed = meds.Peek();
    int sum = currentTextile + currentMed;
    int leftover = 0;
    if (sum == 30)
    {
        doneMeds["Patch"]++;
        textile.Dequeue();
        meds.Pop();
    }
    else if (sum == 40)
    {
        doneMeds["Bandage"]++;
        textile.Dequeue();
        meds.Pop();
    }
    else if (sum == 100)
    {
        doneMeds["MedKit"]++;
        textile.Dequeue();
        meds.Pop();
    }
    else if(sum >= 100)
    {
        doneMeds["MedKit"]++;
        leftover = sum -= 100;
        textile.Dequeue();
        if(meds.Count > 1)
        {
            meds.Pop();
            meds.Push(meds.Pop() + leftover);
        }
        else
        {
            meds.Pop();
        }
        
    }
    else
    {
        meds.Pop();
        meds.Push(currentMed + 10);
        textile.Dequeue();
    }

}

