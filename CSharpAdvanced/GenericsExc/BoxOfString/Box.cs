using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxOfString
{
    public class Box<T>
    {
        private List<T> strings;

        public Box()
        {
            strings = new List<T>();
        }
        public void Add(T item)
        {
            strings.Add(item);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in strings)
            {
                sb.AppendLine($"{item.GetType()}: {item}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
