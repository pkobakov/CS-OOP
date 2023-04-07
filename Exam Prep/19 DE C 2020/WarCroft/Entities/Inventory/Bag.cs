using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WarCroft.Constants;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        
        private int load;
        private ICollection<Item> items;

        public Bag(int capacity)
        {
            this.Capacity = capacity;
            items = new List<Item>();   
        }


        public int Capacity { get; set; } = 100;

        public int Load => this.items.Sum(i => i.Weight);

        public IReadOnlyCollection<Item> Items => this.items.ToList().AsReadOnly();

        public void AddItem(Item item)
        {
            if ((this.Load + item.Weight) > this.Capacity )
            {
                throw new InvalidOperationException(ExceptionMessages.ExceedMaximumBagCapacity);
            }

            this.items.Add(item);   
        }

        public Item GetItem(string name)
        {
            if (!this.Items.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            }
            if (!this.Items.Any( i => i.GetType().Name == name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ItemNotFoundInBag, name));
            }

            Item item = this.Items.FirstOrDefault(i => i.GetType().Name == name);
            this.items.Remove(item);

            return item;    
        }
    }
}
