namespace Telephony
{
	using System;
    using Telephony.Contracts;
    using Telephony.Models;

    public class StartUp
	{
		public static void Main(string[] args)
		{


			string[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
			string[] urls = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            ICallable phone;

			foreach (var number in numbers) 
			{
				if (number.Length == 10)
				{
					phone = new SmartPhone();
				}

				else 
				{
					phone = new Stationary();  
				 
				}

			    try
			    {   
                   Console.WriteLine(phone.Call(number));

                }
                catch (ArgumentException ae)
			    {

                   Console.WriteLine(ae.Message);
                }
			
			}

			IBrowsable browser = new SmartPhone();

            foreach (string url in urls)
            {
                try
                {

                     Console.WriteLine(browser.Browse(url));



                }
                catch (ArgumentException ae)
                {

                    Console.WriteLine(ae.Message);
                }
            }
            

			
		}
	}
}
