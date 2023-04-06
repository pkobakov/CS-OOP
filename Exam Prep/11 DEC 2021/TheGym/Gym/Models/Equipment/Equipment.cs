using Gym.Models.Equipment.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Models.Equipment
{
    public abstract class Equipment : IEquipment
    {
        
        public Equipment(double weight, decimal price)
        {
            this.Weight = weight;
            this.Price = price;
        }
        public double Weight { get; private set; }

        public decimal Price { get; private set; }
    }
}
