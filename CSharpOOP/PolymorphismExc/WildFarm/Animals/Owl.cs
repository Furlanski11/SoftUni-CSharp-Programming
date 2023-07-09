using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Foods;

namespace WildFarm.Animals
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override IReadOnlyCollection<Type> PreferredFoods => new HashSet<Type>() {typeof(Meat) };

        protected override double WeightMultiplier => 0.25;

        public override string AskFood()
        {
            return "Hoot Hoot";
        }

    }
}
