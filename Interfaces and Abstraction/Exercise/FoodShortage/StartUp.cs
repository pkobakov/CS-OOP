namespace FoodShortage
{
    using FoodShortage.Core;
    using System;
	public class StartUp
	{
		public static void Main(string[] args)
		{
            Engine engine = new Engine();
            engine.Run();
        }
	}
}
