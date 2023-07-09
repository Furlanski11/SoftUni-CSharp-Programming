using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            HashSet<string> guests = new HashSet<string>();
            HashSet<string> vipGuests = new HashSet<string>();
            while ((input = Console.ReadLine()) != "PARTY")
            {
                if (char.IsDigit(input[0]))
                {
                    vipGuests.Add(input);
                }
                else
                {
                    guests.Add(input);
                }
                
            }
            while((input = Console.ReadLine()) != "END")
            {
                guests.Remove(input);
                vipGuests.Remove(input);
            }
            Console.WriteLine(guests.Count + vipGuests.Count);
            foreach (var guest in vipGuests)
            {
                Console.WriteLine(guest);
            }
            foreach (var guest in guests)
            {
                Console.WriteLine(guest);
            }
        }
    }
}
