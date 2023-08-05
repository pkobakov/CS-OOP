using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite.Models
{
    public class SingleGift : GiftBase
    {
        public SingleGift(string name, int price) : base(name, price)
        {
        }

        public override int CalculatePrice()
        {
            Console.WriteLine($"{this.name} with the price {this.price}");
            return this.price;
        }
    }
}
