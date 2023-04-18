using Easter.Models.Bunnies.Contracts;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Models.Workshops
{
    internal class Workshop : IWorkshop
    {
        public void Color(IEgg egg, IBunny bunny)
        {
           while (!egg.IsDone() && 
                   bunny.Dyes.Any( d => !d.IsFinished()) &&
                   bunny.Energy > 0) 
           {
            
                var dye = bunny.Dyes.FirstOrDefault( d => !d.IsFinished());
                dye.Use();
                egg.GetColored();
                bunny.Work();

            
           }

        }
    }
}
