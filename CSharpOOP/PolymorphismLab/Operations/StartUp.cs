﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operations
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            MathOperations mathOperations= new MathOperations();

            Console.WriteLine(mathOperations.Add(2, 3));
            Console.WriteLine(mathOperations.Add(2.2, 3.3, 5.5));
            Console.WriteLine(mathOperations.Add(2.2m, 3.3m, 4.4m));
        }
    }
}
