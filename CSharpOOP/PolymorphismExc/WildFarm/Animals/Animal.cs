using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Foods;
using WildFarm.Interfaces;

namespace WildFarm.Animals
{
    public abstract class Animal : IAnimal
    {
        protected Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;

        }

        public string Name {get; private set;}

        public double Weight { get; private set; }

        public int FoodEaten { get; private set; }

        public abstract IReadOnlyCollection<Type> PreferredFoods { get; }

        protected abstract double WeightMultiplier { get; }

        public abstract string AskFood();
        

        public void Feed(IFood food)
        {
          if(!PreferredFoods.Any(pf => food.GetType().Name == pf.Name))
            {
                Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");
                return;
            }

            Weight += food.Quantity * WeightMultiplier;

            FoodEaten += food.Quantity;
        }
    }
}
