using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {
        
        private int tableNumber;
        private int capacity;
        private decimal pricePerPerson;
        private int numberOfPeople;
        private bool isReserved;
        private List<IBakedFood> foodOrders;
        private List<IDrink> drinkOrders;

        public Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
           
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;
            this.foodOrders = new List<IBakedFood>();
            this.drinkOrders = new List<IDrink>();
        }
        public int TableNumber { get => tableNumber; private set { this.tableNumber = value; } }

        public int Capacity 
        { 
            get { return capacity; } 
            private set 
            {
                if (value < 0) 
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTableCapacity);
                }
                this.capacity = value; 
            }
        }

        public int NumberOfPeople
        {
            get { return numberOfPeople; }
            private set 
            {
                if (value < 0)
                { 
                   throw new ArgumentException(ExceptionMessages.InvalidNumberOfPeople);
                }
                this.numberOfPeople = value;
            }
        }

        public decimal PricePerPerson { get => pricePerPerson; private set { this.pricePerPerson = value; } }

        public bool IsReserved { get => isReserved; private set { this.isReserved = value; } }

        public decimal Price => this.NumberOfPeople * this.PricePerPerson;

        public void Clear()
        {
            
            foodOrders.Clear();
           drinkOrders.Clear();
            this.IsReserved = false;
            this.NumberOfPeople = 0;
        }

        public decimal GetBill()
        {
            return foodOrders.Sum(x => x.Price) + drinkOrders.Sum(x => x.Price) + this.Price;
        }

        public string GetFreeTableInfo()
        { 
            var sb = new StringBuilder();
            sb.AppendLine($"Table: {this.TableNumber}");
            sb.AppendLine($"Type: {this.GetType().Name}");
            sb.AppendLine($"Capacity: {this.Capacity}");
            sb.AppendLine($"Price per Person: {this.PricePerPerson}");

            return sb.ToString().Trim();
        }
        

        public void OrderDrink(IDrink drink)
        {
           drinkOrders.Add(drink);
        }

        public void OrderFood(IBakedFood food)
        {
            foodOrders.Add(food);
        }

        public void Reserve(int numberOfPeople)
        {
            this.IsReserved = true;
            this.NumberOfPeople = numberOfPeople;
        }
    }
}
