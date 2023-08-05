using AquaShop.Models.Decorations.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Decorations
{
    public abstract class Decoration : IDecoration
    {
        private int comfort;
        private decimal price;

        public Decoration(int comfort, decimal price) 
        {
            this.Price = price;
            this.Comfort = comfort;
        }

        public decimal Price
        {
            get => price;
            private set
            {
                price = value;
            }
        }

        public int Comfort
        { 
            get => comfort;
            private set
            { 
               comfort = value; 
            }
        }
    }
}
