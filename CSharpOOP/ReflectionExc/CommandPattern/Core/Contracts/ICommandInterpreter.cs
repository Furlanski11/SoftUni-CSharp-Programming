using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Core.Contracts
{
    public interface ICommandInterpreter
    {
        string Read(string args);
    }
}
