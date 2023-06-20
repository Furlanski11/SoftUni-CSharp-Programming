using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorderControl
{
    public class Rebel : IBuyer
    {
        public Rebel(string name, int age, string crew)
        {
            Name = name;
            Age = age;
            Crew = crew;
        }

        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Crew { get; private set; }
        public int Food { get; private set; }

        public void BuyFood()
        {
            Food += 5;
        }
    }
}
