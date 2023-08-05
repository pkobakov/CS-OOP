using Composite.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite.Models
{
    public class CompositeGift : GiftBase, IGiftOperations
    {
        private List<GiftBase> gifts;
        public CompositeGift(string name, int price)
            : base(name,price)
        {
            gifts = new List<GiftBase>();    
        }
        public void Add(GiftBase gift)
        {
            gifts.Add(gift);
        }

        public override int CalculatePrice()
        {
            
            Console.WriteLine($"{this.name} contains the following products with prices:");
            
            return gifts.Sum(g => g.CalculatePrice());
        }

        public void Remove(GiftBase gift)
        {
            gifts.Remove(gift);
        }
    }
}
