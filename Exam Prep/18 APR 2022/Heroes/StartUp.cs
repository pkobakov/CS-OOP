using System;
using Heroes.Core;
using Heroes.Core.Contracts;
using Heroes.Models.Heroes;

namespace Heroes
{
    public class StartUp
    {
        public static void Main()
        {
            IEngine engine = new Engine();
            engine.Run();

        }
    }
}
