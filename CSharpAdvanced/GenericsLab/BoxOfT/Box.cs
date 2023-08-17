using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxOfT
{
    public class Box<T>
    {
        private int count;
        private List<T> list = new();

        

        public void Add(T item)
        {
            list.Add(item);
            count++;
        }
        public T Remove()
        {
            T removedElement = list[count-1];
            list.Remove(removedElement);
            count--;
            return removedElement;
            
        }
        public int Count { get { return count; } }
    }
}
