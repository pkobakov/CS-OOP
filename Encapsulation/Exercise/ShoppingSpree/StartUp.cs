namespace ShoppingSpree
{
    using ShoppingSpree.Models;
    using System;
	public class StartUp
	{

		public static void Main(string[] args)
		{
			
			try
			{
                Engine engine = new Engine();
                engine.Run();
            }
			catch (Exception m)
			{

                Console.WriteLine(m.Message);
            }

		}
	}
}
