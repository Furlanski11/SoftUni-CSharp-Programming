using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telephony
{
    public class Smartphone : ISmartphone 
    {
        public void Browsing(string URL)
        {
            foreach (var ch in URL)
            {
                if (Char.IsDigit(ch))
                {
                    throw new ArgumentException("Invalid URL!");
                }
            }
            Console.WriteLine($"Browsing: {URL}!");
        }

        public void Calling(string number)
        {
            foreach (var ch in number)
            {
                if (Char.IsLetter(ch))
                {
                    throw new ArgumentException("Invalid number!");
                }
            }
            Console.WriteLine($"Calling... {number}");
        }
    }
}
