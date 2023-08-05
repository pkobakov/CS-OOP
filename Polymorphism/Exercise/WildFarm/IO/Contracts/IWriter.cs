using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm.IO.Contracts
{
    public interface IWriter
    {
        void WriteLine(string output);
    }
}
