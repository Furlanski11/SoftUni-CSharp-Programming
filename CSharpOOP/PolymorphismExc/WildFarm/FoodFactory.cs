using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Foods;
using WildFarm.Interfaces;

namespace WildFarm
{
    public class FoodFactory
    {
        public IFood FoodCreator(string[] input)
        {
            string foodType = input[0];
            int quantity = int.Parse(input[1]);

            switch (foodType)
            {
                case "Meat":
                    return new Meat(quantity);
                case "Fruit":
                    return new Fruit(quantity);
                case "Vegetable":
                    return new Vegetable(quantity);
                case "Seeds":
                    return new Seeds(quantity);
            }
            return null;
        }
    }
}
