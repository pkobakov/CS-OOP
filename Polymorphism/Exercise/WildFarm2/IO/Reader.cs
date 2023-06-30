using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.IO.Contracts;

namespace WildFarm.IO
{
    public class Reader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();

        }
    }
}
