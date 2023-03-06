namespace Telephony
{
	using System;
    using System.Text.RegularExpressions;
    using System.Threading.Channels;
    using Telephony.Core;
    using Telephony.Models;

    public class StartUp
	{
		public static void Main(string[] args)
		{
		    Engine engine = new Engine();	
			engine.Run();
		}
	}
}
