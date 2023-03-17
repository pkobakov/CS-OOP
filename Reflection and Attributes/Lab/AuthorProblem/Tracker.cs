using System;
using System.Reflection;


namespace AuthorProblem
{
    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            Type type = typeof(StartUp);
            var methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic);
            var authorAttribute = type.GetCustomAttributes(typeof(AuthorAttribute), true).FirstOrDefault() as AuthorAttribute;
            if (authorAttribute!=null) 
            {
                Console.WriteLine("{0} is written by {1}", type.Name, authorAttribute.Name);
            }
            foreach (var method in methods)
            {
                if (method.CustomAttributes.Any(m => m.AttributeType == typeof(AuthorAttribute)))
                {
                    var attributes = method.GetCustomAttributes(false);
                    foreach (AuthorAttribute attribute in attributes)
                    {
                       Console.WriteLine($"{method.Name} is written by {attribute.Name}");
                    }

                }

            }
        }
    }
}
