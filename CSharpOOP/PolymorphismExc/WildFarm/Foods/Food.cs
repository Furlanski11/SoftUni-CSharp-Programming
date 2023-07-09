using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Interfaces;

namespace WildFarm.Foods
{
    public class Food : IFood
    {
        public Food(int quantity)
        {
            Quantity = quantity;
        }

        public int Quantity { get; private set; }
    }
}
