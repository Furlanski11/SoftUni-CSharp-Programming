using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Animals;
using WildFarm.Interfaces;

namespace WildFarm
{
    public class AnimalFactory
    {
        public IAnimal AnimalCreator(string[] animalInput)
        {
            string type = animalInput[0];
            string name = animalInput[1];
            double weight = double.Parse(animalInput[2]);

            switch (type)
            {
                case "Owl":
                    return new Owl(name, weight, double.Parse(animalInput[3]));
                case "Hen":
                    return new Hen(name, weight, double.Parse(animalInput[3]));
                case "Mouse":
                    return new Mouse(name, weight, animalInput[3]);
                case "Dog":
                    return new Dog(name, weight, animalInput[3]);
                case "Cat":
                    return new Cat(name, weight, animalInput[3], animalInput[4]);
                case "Tiger":
                    return new Tiger(name, weight, animalInput[3], animalInput[4]);
                default:
                    throw new ArgumentException("Invalid animal type!");
            }
        }
    }
}
