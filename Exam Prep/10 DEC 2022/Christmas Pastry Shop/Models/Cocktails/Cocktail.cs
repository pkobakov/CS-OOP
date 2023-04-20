using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace ChristmasPastryShop.Models.Cocktails
{
    public abstract class Cocktail : ICocktail
    {
        private string name;
        private string size;
        private double price;
        public Cocktail(string cocktailName, string size, double price)
        {
            this.Name = cocktailName;
            this.Size = size;
            this.Price = price;
        }
        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }
                name = value;
            }
        }


        public string Size 
        {
            get { return size; } private set {  size = value; } 
        }

        public double Price 
        { 
            get { return  price; } 
            private set 
            {
                switch (this.Size)
                {
                    case "Small": price = value/3; break;  
                    case "Middle": price = value - (value/3); break; 
                    default: price = value; break;

                }
            }
        }

        public override string ToString() 
        {
            return $"{this.Name} ({this.Size}) - {this.Price:f2} lv";
        }


    }
}
