﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    public class Tesla : Seat, IElectricCar
    {
        public Tesla(string model, string color, int battery) 
            : base(model, color)
        {
            Battery = battery;

        }

        public int Battery { get; }


        public override string ToString()
        {
            return $"{Color} Tesla {Model} with {Battery} Batteries\n{Start()}\n{Stop()}";
        }
    }
}
