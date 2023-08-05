using Easter.Core.Contracts;
using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops;
using Easter.Models.Workshops.Contracts;
using Easter.Repositories;
using Easter.Repositories.Contracts;
using Easter.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Core
{
    public class Controller : IController
    {
        private IRepository<IBunny> bunnies;
        private IRepository<IEgg> eggs;
        private IWorkshop workshop;
        public Controller()
        {
            bunnies = new BunnyRepository();
            eggs = new EggRepository();
        }
        public string AddBunny(string bunnyType, string bunnyName)
        {
            IBunny bunny = bunnyType switch 
            {
                nameof (HappyBunny) => new HappyBunny(bunnyName),
                nameof(SleepyBunny) => new SleepyBunny(bunnyName),
                _=> throw new InvalidOperationException(ExceptionMessages.InvalidBunnyType)
            };

            bunnies.Add(bunny);
            return string.Format(OutputMessages.BunnyAdded, bunnyType, bunnyName);
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            IDye dye = new Dye(power);
            IBunny bunny = this.bunnies.FindByName(bunnyName);

            if (bunny == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentBunny);

            }

            bunny.AddDye(dye);
            return string.Format(OutputMessages.DyeAdded,  power, bunnyName );    
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            IEgg egg = new Egg(eggName, energyRequired);
            this.eggs.Add(egg);

            return string.Format(OutputMessages.EggAdded, eggName);
        }

        public string ColorEgg(string eggName)
        {
     
            IEgg egg = eggs.FindByName(eggName);
            workshop = new Workshop();

            var selectedBunnies = this.bunnies.Models.OrderByDescending(b => b.Energy).Where(b => b.Energy >= 50).ToList();

            if (!selectedBunnies.Any()) 
            {
                throw new InvalidOperationException(ExceptionMessages.BunniesNotReady);
               
            }
            foreach (IBunny bunny in selectedBunnies)
            {
                
                workshop.Color(egg, bunny);

                if (bunny.Energy == 0)
                {
                    this.bunnies.Remove(bunny); 
                }

            }

            if (egg.IsDone())
            {

                return string.Format(OutputMessages.EggIsDone, eggName);
            }

            
            return string.Format(OutputMessages.EggIsNotDone, eggName);
        }

        public string Report()
        {
            var result = new StringBuilder();

            var eggsDone = this.eggs.Models.Where(e => e.IsDone()).ToList();

            result.AppendLine($"{eggsDone.Count} eggs are done!");
            result.AppendLine("Bunnies info:");
            
            foreach (var bunny in bunnies.Models) 
            {


                result.AppendLine($"Name: {bunny.Name}");
                result.AppendLine($"Energy: {bunny.Energy}");
                var dyesList = bunny.Dyes.Where(d => d.Power > 0).ToList();
                result.AppendLine($"Dyes: { dyesList.Count} not finished");
                    
            }

            return result.ToString().Trim();   


                
            

           
        }
    }
}
