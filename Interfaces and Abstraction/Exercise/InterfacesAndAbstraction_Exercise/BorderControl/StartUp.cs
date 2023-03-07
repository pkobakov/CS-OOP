namespace BorderControl
{
    using BorderControl.Contracts;
    using BorderControl.Core;
    using BorderControl.Models;
    using System;
	public class StartUp
	{
		public static void Main(string[] args)
		{
			var engine = new Engine();
			engine.Run();

        }
	}
}
