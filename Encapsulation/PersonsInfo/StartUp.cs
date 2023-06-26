using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsInfo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var lines = int.Parse(Console.ReadLine());

            var persons = new List<Person>();
            Team team = new("SoftUni");
            for (int i = 0; i < lines; i++)
            {
                string[] line = Console.ReadLine().Split(" ");
                Person person = new(line[0], line[1], int.Parse(line[2]), decimal.Parse(line[3]));
                team.AddPlayer(person);
            }
            Console.WriteLine(team);
            
        }

    }
}
