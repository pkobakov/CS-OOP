using System;

namespace AuthorProblem
{
        [Author("George")]   
        public class StartUp
        {
           
            static void Main(string[] args)
            {
                Greeting();
                Tracker tracker = new Tracker();
                tracker.PrintMethodsByAuthor();
            }

        [Author("Max")]
        private static void Greeting() 
        {

            Console.WriteLine("Hello World!");
        }

    }
    
}