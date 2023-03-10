using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using WildFarm.IO.Interfaces;

namespace WildFarm.IO
{
    public class Writer : IWriter
    {
        public void Write(string value)
         => Console.WriteLine(value);
    }
}
