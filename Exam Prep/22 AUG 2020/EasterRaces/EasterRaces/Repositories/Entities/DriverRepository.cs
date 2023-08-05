using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasterRaces.Repositories.Entities
{
    public class DriverRepository : Repository<IDriver>
    {    
        private ICollection<IDriver> drivers;
        public DriverRepository() 
        { 
            drivers = new List<IDriver>();
        }
    }
}
