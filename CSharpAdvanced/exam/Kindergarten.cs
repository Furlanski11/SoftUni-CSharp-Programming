using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniKindergarten
{
    public class Kindergarten
    {

        public Kindergarten(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Registry = new();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public List<Child> Registry { get; set; }
        public int ChildrenCount => Registry.Count;

        public bool AddChild(Child child) 
        {
            if(Registry.Count != Capacity) 
            {
                Registry.Add(child);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RemoveChild(string kidToRemove)
        {
            string[] names = kidToRemove.Split(' ');
            foreach (var child in Registry)
            {
                if(child.FirstName == names[0] && child.LastName == names[1])
                {
                    Registry.Remove(child);
                    return true;
                }
            }
            return false;
        }
        public Child GetChild(string kidToFind)
        {
            string[] names = kidToFind.Split(' ');
            foreach (var child in Registry)
            {
                if (child.FirstName == names[0] && child.LastName == names[1])
                {
                    
                    return child;
                }
            }
            return null;

        }

        public string RegistryReport()
        {
            //Registry.OrderByDescending(x => x.Age).ThenBy(y => y.LastName).ThenBy(z => z.FirstName);
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Registered children in {Name}:");
            foreach (var child in Registry.OrderByDescending(x => x.Age).ThenBy(y => y.LastName).ThenBy(z => z.FirstName))
            {
                sb.AppendLine(child.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
