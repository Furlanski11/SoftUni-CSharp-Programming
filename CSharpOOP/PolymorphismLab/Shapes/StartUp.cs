using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Shape rectangle = new Rectangle(10, 20);
            Shape circle = new Circle(30);

            Console.WriteLine(rectangle.Draw());
            Console.WriteLine(rectangle.CalculateArea());
            Console.WriteLine(rectangle.CalculatePerimeter());
        }
    }
}
