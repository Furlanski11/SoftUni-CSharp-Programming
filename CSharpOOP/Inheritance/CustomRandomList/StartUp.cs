using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomRandomList
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            RandomList randomList = new RandomList();

            randomList.Add("dwdq");
            randomList.Add("ssss");
            randomList.Add("bbbb");
            randomList.Add("aaaa");
            Console.WriteLine(randomList.RandomString());
            Console.WriteLine();
            foreach (var item in randomList)
            {
                Console.WriteLine(item);
            }

        }
    }
}
