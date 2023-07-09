using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Animals;
using WildFarm.Foods;
using WildFarm.Interfaces;

namespace WildFarm
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string command = string.Empty;
 List<IAnimal> animals = new List<IAnimal>();
            while((command = Console.ReadLine())!= "End")
            {
                string[] animalInput = command.Split(' ');
                string[] foodInput = Console.ReadLine().Split(' ');

                FoodFactory foodFactory = new FoodFactory();
               IFood food = foodFactory.FoodCreator(foodInput);
                AnimalFactory animalFactory = new AnimalFactory();
               IAnimal animal = animalFactory.AnimalCreator(animalInput);
                Console.WriteLine(animal.AskFood());
                animal.Feed(food);
                
                animals.Add(animal);
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
