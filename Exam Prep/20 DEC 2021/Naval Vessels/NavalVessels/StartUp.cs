namespace NavalVessels
{
    using System;
    using Core;
    using Core.Contracts;
    using NavalVessels.Models;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();


        }
    }
}