using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;
        private int capacity;
        private ICollection<IDecoration> decorations;
        private ICollection<IFish> fish;
        public Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.decorations = new List<IDecoration>();
            this.fish = new List<IFish>();
        }
        public string Name
        {
            get { return name; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value)) 
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }
                name = value; 
            }
        }

        public int Capacity 
        {
            get { return  capacity; }
            private set 
            {
                
               capacity = value;
            }
        
        }

        public int Comfort => (int)this.decorations.Sum( d => d.Comfort);

        public ICollection<IDecoration> Decorations => this.decorations.ToList().AsReadOnly();

        public ICollection<IFish> Fish => this.fish.ToList().AsReadOnly();

        public void AddDecoration(IDecoration decoration)
        {
            this.Decorations.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            if (this.Capacity == Fish.Count)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }

            this.fish.Add(fish);    
        }

        public void Feed()
        {
            this.fish.ToList().ForEach(f => f.Eat());
        }

        public string GetInfo()
        {
           var sb = new StringBuilder();
            sb.AppendLine($"{this.Name} ({this.GetType().Name}):");
            string fishes = this.Fish.Count > 0 ? string.Join(", ", this.Fish.Select(f => f.Name)) : "none";
            sb.AppendLine($"Fish: {fishes}");
            sb.AppendLine($"Decorations: {this.Decorations.Count}");
            sb.AppendLine($"Comfort: {this.Comfort}");

            return sb.ToString().Trim(); ;
        }

        public bool RemoveFish(IFish fish)
        {
            return this.Fish.Remove(fish);
        }
    }
}
