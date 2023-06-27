﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            try
            {
                string[] pizzaTokens = Console.ReadLine().Split();
                string[] doughTokens = Console.ReadLine().Split();

                string pizzaName = pizzaTokens[1];

                Dough dough = new(doughTokens[1], doughTokens[2], double.Parse(doughTokens[3]));

                Pizza pizza = new(pizzaName, dough);

                while (true)
                {
                    string toppingsInput = Console.ReadLine();

                    if (toppingsInput == "END")
                    {
                        break;
                    }

                    string[] toppingsTokens = toppingsInput.Split();

                    Topping topping = new(toppingsTokens[1], double.Parse(toppingsTokens[2]));

                    pizza.AddTopping(topping);
                }

                Console.WriteLine(pizza);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
