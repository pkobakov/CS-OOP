using Raiding.Core.Contracts;
using Rаiding.IO;
using Rаiding.IO.Contracts;
using Rаiding.Models;
using Rаiding.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Raiding.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            int n = int.Parse(reader.ReadLine());
            List<IBaseHero> raidGroup = new List<IBaseHero>();
            int heroesPower = 0;

            int length = n;
            int counter = 0;    

            while (counter < length)
            {
                IBaseHero currentHero;
                string name = reader.ReadLine();
                string type = reader.ReadLine();

                try
                {
                    currentHero = CreateHero(name, type);
                    raidGroup.Add(currentHero);
                    counter++;
                }
                catch (ArgumentException ae)
                {

                    writer.WriteLine(ae.Message); 
                    continue;

                }

            }
            

            foreach (IBaseHero currentHero in raidGroup)
            {
                writer.WriteLine(currentHero.CastAbility());
            }

            heroesPower = raidGroup.Sum(h => h.Power);
            int bossPower = int.Parse(reader.ReadLine());

            if (bossPower <= heroesPower)
            {
                writer.WriteLine("Victory!");
            }

            else
            {
                writer.WriteLine("Defeat...");
            }
        }

        private static BaseHero CreateHero(string name, string heroType) 
        {
            return heroType switch 
            {
                nameof(Druid) => new Druid(name),
                nameof(Paladin) => new Paladin(name),
                nameof(Rogue) => new Rogue(name),
                nameof(Warrior) => new Warrior(name),
                _ => throw new ArgumentException("Invalid hero!")

            };
        }
    }
}
