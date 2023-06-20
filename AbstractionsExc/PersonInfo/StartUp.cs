﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonInfo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string name = Console.ReadLine(); 
            int age = int.Parse(Console.ReadLine());
            string id = Console.ReadLine();
            string birthdate = Console.ReadLine();
            IPerson person = new Citizen(name, age, id, birthdate);
            IBirthable birthable = new Citizen(name, age, id, birthdate);
            IIdentifiable identifiable = new Citizen(name, age, id, birthdate);
            Console.WriteLine(person.Name);
            Console.WriteLine(person.Age);
            Console.WriteLine(birthable.Birthdate);
            Console.WriteLine(identifiable.Id);
        }
    }
}
