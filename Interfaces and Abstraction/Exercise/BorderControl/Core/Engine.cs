using BorderControl.Contracts;
using BorderControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorderControl.Core
{
    public class Engine : IEngine
    {
        public void Run()
        {
            string[] commandLines = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            IIdentifiable identifiable;
            List<string> ids = new List<string>();


            while (commandLines[0] != "End")
            {


                if (commandLines.Length == 3)
                {

                    string name = commandLines[0];
                    int age = int.Parse(commandLines[1]);
                    string id = commandLines[2];

                    identifiable = new Citizen(name, age, id);
                    ids.Add(id);
                }

                else
                {
                    string model = commandLines[0];
                    string id = commandLines[1];
                    identifiable = new Robot(model, id);
                    ids.Add(id);
                }

                commandLines = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            }

            string code = Console.ReadLine();
            List<string> result = new List<string>();

            foreach (string id in ids)
            {
                if (id.Substring(id.Length - code.Length) == code)
                {
                    result.Add(id);
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, result));
        }
    }
}
