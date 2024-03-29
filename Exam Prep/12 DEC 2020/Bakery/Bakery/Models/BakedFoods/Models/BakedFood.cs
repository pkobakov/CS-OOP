﻿using Bakery.Models.BakedFoods.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Bakery.Models.BakedFoods.Models
{
    public abstract class BakedFood : IBakedFood
    {
        private string name;
        private int portion;
        private decimal price;
        public BakedFood(string name, int portion, decimal price)
        {
            this.Name = name;
            this.Portion = portion;
            this.Price = price;
        }
        public string Name 
        { 
            get { return name; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidName);
                }
                this.name = value; 
            }
        }

        public int Portion 
        {
            get { return portion; }
            private set 
            { 
                if (value <= 0) 
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPortion);
                }
               this.portion = value; 
            }
        }
        public decimal Price 
        {
            get { return price; }
            private set 
            { 
                if (value <= 0) 
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPrice);
                }
                this.price = value; 
            }
        }

        public override string ToString()
         => $"{this.Name}: {this.Portion}g - {this.Price:f2}";
    }
}
