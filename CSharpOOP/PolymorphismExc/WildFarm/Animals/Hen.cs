using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Foods;

namespace WildFarm.Animals
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override IReadOnlyCollection<Type> PreferredFoods
            => new HashSet<Type>() {typeof(Meat), typeof(Seeds), typeof(Fruit), typeof(Vegetable) };

        protected override double WeightMultiplier => 0.35;

        public override string AskFood()
        {
            return "Cluck";
        }
    }
}
