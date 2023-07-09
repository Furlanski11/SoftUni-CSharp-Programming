using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Foods;

namespace WildFarm.Animals
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override IReadOnlyCollection<Type> PreferredFoods 
            => new HashSet<Type>() {typeof(Vegetable), typeof(Meat) };

        protected override double WeightMultiplier => 0.30;
        
        public override string AskFood()
        {
            return "Meow";
        }
    }
}
