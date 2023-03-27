using OnlineShop.Common.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models.Products
{
    public abstract class Product
    {
        private const decimal minPrice = 0.00M;
        private const double minValue = 0.00;
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
                if ( value < 1) 
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
                if(value <= minPrice) 
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
                if (value <= minValue) 
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidOverallPerformance));
                }

                overallPerformance = value;
            } 
        }

        public override string ToString()
        {
            return $"Overall Performance: {OverallPerformance:f2}. Price: {Price:f2} - {this.GetType().Name}: {Manufacturer} {Model} (Id: {Id})";
        }
    }
}
