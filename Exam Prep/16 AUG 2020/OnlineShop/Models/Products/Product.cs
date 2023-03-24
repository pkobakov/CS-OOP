using OnlineShop.Common.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models.Products
{
    public abstract class Product
    {
        private int id;
        private string manufacturer;
        private string model;
        private decimal price;
        private double overallPerformance;
        protected Product (int id, string manufacturer, string model, decimal price, double overallPerformance) 
        { 
            this.Id = id;
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.Price = price;
            this.OverallPerformance = overallPerformance;
        }

        public int  Id 
        { 
            get => id;
            private set 
            {
                if ( value <= 0) 
                { 
                  throw new ArgumentException(string.Format(ExceptionMessages.InvalidProductId));
                }

                id = value;
            } 
        }
        public string Manufacturer 
        { 
            get => manufacturer;
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidManufacturer));
                }
                
                manufacturer = value;
            } 
        }
        public string Model 
        {
            get => model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidModel));
                }

                model = value;
            }
        }
        public virtual decimal Price 
        {  
           get => price;
            private set 
            {
                if(value <= 0) 
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidPrice));
                }

                price = value;
            } 
        }
        public virtual double OverallPerformance 
        { 
            get => overallPerformance;
            private set 
            {
                if (value <= 0) 
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidOverallPerformance));
                }
            } 
        }

        public override string ToString()
        {
            return $"Overall Performance: {overallPerformance:f2}. Price: {price:f2} - {this.GetType().Name}: {manufacturer} {model} (Id: {id})";
        }
    }
}
