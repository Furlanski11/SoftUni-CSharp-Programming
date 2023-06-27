using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telephony
{
    public class StationaryPhone : IStationaryPhone
    {
        public void Calling(string number)
        {
            foreach (var ch in number)
            {
                if (Char.IsLetter(ch))
                {
                    throw new ArgumentException("Invalid number!");
                }
            }

                Console.WriteLine($"Dialing... {number}");
            
        }
    }
}
