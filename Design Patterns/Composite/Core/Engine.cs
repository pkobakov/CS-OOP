using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Composite.Core.Contracts;
using Composite.Models;

namespace Composite.Core
{
    public class Engine : IEngine
    {
        public void Run()
        {
            SingleGift phone = new SingleGift("IPhone", 253);
            SingleGift watch = new SingleGift("Swacth", 344);


            CompositeGift shop = new CompositeGift("Boutique", 0);

            shop.Add(phone);
            shop.Add(watch);
            Console.WriteLine(shop.CalculatePrice());
        }
    }
}
