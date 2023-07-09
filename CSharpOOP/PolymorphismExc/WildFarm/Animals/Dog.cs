using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Foods;

namespace WildFarm.Animals
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override IReadOnlyCollection<Type> PreferredFoods
            => new HashSet<Type>() {typeof(Meat) }; 

        protected override double WeightMultiplier => 0.40;

        public override string AskFood()
        {
            return "Woof!";
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
