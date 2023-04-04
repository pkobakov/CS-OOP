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
            //IEngine engine = new Engine();
            //engine.Run();

            var vessel = new Submarine("Submar", 65, 12);
           
            vessel.ToggleSubmergeMode();

            Console.WriteLine(vessel.ToString());

            vessel.ToggleSubmergeMode();

            Console.WriteLine(vessel.ToString());
        }
    }
}