using EasterRaces.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasterRaces.Repositories.Entities
{
    public class CarRepository : Repository<ICar>
    {
        private ICollection<ICar> cars;
        public CarRepository() 
        { 
            cars = new List<ICar>();
        }
    }
}
