using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace PersonsInfo
{
    public static class Engine
    {
        public static void Run() 
        {


            var lines = int.Parse(Console.ReadLine());
            var persons = new List<Person>();
            for (int i = 0; i < lines; i++)
            {
                var data = Console.ReadLine().Split();
                var person = new Person(data[0], data[1], int.Parse(data[2]), decimal.Parse(data[3]));
                persons.Add(person);
            }

            var parcentage = decimal.Parse(Console.ReadLine());
            persons.ForEach(p => p.IncreaseSalary(parcentage));
            persons.ForEach(p => Console.WriteLine(p.ToString()));



        }
    }
}
