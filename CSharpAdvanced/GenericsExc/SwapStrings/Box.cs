using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwapStrings
{
    public class Box<T>
    {
        private List<T> Strings;

        public Box()
        {
            Strings = new List<T>();
        }

        public void Add(T item)
        {
            Strings.Add(item);
        }

        public List<T> Swap(int first, int second)
        {
            T firstItem = Strings[first];
            T secondItem = Strings[second];

            Strings[first] = secondItem;
            Strings[second] = firstItem;

            return Strings;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in Strings)
            {
                sb.AppendLine($"{item.GetType()}: {item}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
