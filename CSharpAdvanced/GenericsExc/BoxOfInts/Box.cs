using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxOfInts
{
    public class Box<T>
    {
        private List<T> Ints;

        public Box()
        {
            Ints = new List<T>();
        }
        public void Add(T item)
        {
            Ints.Add(item);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in Ints)
            {
                sb.AppendLine($"{item.GetType()}: {item}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
