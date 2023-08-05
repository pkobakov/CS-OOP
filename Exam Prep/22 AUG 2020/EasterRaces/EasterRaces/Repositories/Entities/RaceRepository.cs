using EasterRaces.Models.Races.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasterRaces.Repositories.Entities
{
    public class RaceRepository : Repository<IRace>
    {
        private ICollection<IRace> races;
        public RaceRepository() 
        { 
            races = new List<IRace>();
        }
    }
}
