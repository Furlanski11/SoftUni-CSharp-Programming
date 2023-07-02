using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomStack
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            StackOfStrings customStack = new();

            customStack.AddRange(new List<string>() { "1", "2", "3"});
            Console.WriteLine(customStack.IsEmpty());

        }
    }
}
