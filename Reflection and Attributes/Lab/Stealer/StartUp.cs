namespace Stealer
{
	using System;
    using System.Reflection;

    public class StartUp
	{
		public static void Main(string[] args)
		{
			Spy spy = new Spy();
			string result = spy.StealFieldInfo("Stealer.Hacker", new[] { "username", "password" });
			Console.WriteLine(result);


		}
	}
}
