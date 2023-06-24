using System;
using System.Collections.Generic;
using System.Linq;


Func<List<string>, string, string, List<string>> remove = (guests, criteriA, valuE) =>
    {
        switch(criteriA)
        {
            case "StartsWith":
                foreach (var guest in guests)
                {
                    if (guest.StartsWith(valuE))
                    {
                        guests.RemoveAll(g => g.StartsWith(valuE));
                        break;
                    }
                }
                break;
            case "EndsWith":
                foreach (var guest in guests)
                {
                    if (guest.EndsWith(valuE))
                    {
                        guests.RemoveAll(g => g.EndsWith(valuE));
                        break;
                    }
                }
                break;
            case "Length":
                foreach (var guest in guests)
                {
                        guests.RemoveAll(g => g.Length == int.Parse(valuE));   
                }
                break;
        }
        return guests;
    };
 Func<List<string>, string, string, List<string>> doubleIt = (guests, criteriA, valuE) =>
 {
     List<string> peopleToDouble = new();
     switch(criteriA)
     {
         case "StartsWith":
             peopleToDouble = guests.FindAll(g => g.StartsWith(valuE));
             foreach (var guest in peopleToDouble)
             {

                 int index = guests.IndexOf(guest);
                 guests.Insert(index, guest);

             }
             break;

         case "EndsWith":
             peopleToDouble = guests.FindAll(g => g.EndsWith(valuE));
             foreach (var guest in peopleToDouble)
             {
                 
                     int index = guests.IndexOf(guest);
                     guests.Insert(index, guest);
                     
                 
             }
             break;

         case "Length":
             peopleToDouble = guests.FindAll(g => g.Length == int.Parse(valuE));
             foreach (var guest in peopleToDouble)
             {
                 
                     int index = guests.IndexOf(guest);
                     guests.Insert(index, guest);
                    
                 
             }
             break;
     }
     return guests; 
 };
List<string> guests = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .ToList();
string command = string.Empty;
    
while((command = Console.ReadLine()) != "Party!")
{
    string[] commandIndex = command.Split(' ');
    string typeCommand = commandIndex[0];
    string criteria = commandIndex[1];
    string value = commandIndex[2];
    
    if(typeCommand == "Remove")
    {
        remove(guests, criteria, value);
    }
    else
    {
        doubleIt(guests, criteria, value);
    }

}
if (guests.Any())
{
    Console.WriteLine(string.Join(", ", guests) + " are going to the party!");
}
else
{
    Console.WriteLine("Nobody is going to the party!");
}


