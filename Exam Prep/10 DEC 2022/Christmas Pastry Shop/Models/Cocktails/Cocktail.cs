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


        public string Size { get { return size; } private set { size = value; } }

        public double Price 
        { 
            get { return  price; } 
            private set 
            {
                if (this.Size == "Large")
                {
                    price = value;
                }

                if (this.Size == "Middle")
                {
                    price = 2/3*value;
                }

                if (this.Size == "Small")
                {
                    price = 1 / 3 * value;
                }
            }
        }

        public override string ToString() 
        {
            return $"{this.Name} ({this.Size}) - {this.Price:f2} lv";
        }


    }
}
