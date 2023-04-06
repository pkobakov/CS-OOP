using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.BakedFoods.Models;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Drinks.Models;
using Bakery.Models.Tables.Contracts;
using Bakery.Models.Tables.Models;
using Bakery.Utilities.Enums;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Core
{
    public class Controller : IController
    {
        private decimal income;
        private List<IBakedFood> bakedFoods;
        private List<IDrink> drinks;
        private List<ITable> tables;
        
        public Controller()
        {
            bakedFoods = new List<IBakedFood>();
            drinks = new List<IDrink>();
            tables = new List<ITable>();
        }
        //ready
        public string AddDrink(string type, string name, int portion, string brand)
        {
            Enum.TryParse(type, out DrinkType drinkType);
            IDrink drink = drinkType switch
            {
                DrinkType.Tea => new Tea(name, portion, brand),
                DrinkType.Water => new Water(name, portion, brand),
                _ => null
            };

            drinks.Add(drink);

            return string.Format(OutputMessages.DrinkAdded, drink.Name, drink.Brand);
        }
        
        //ready
        public string AddFood(string type, string name, decimal price)
        {
            Enum.TryParse(type, out BakedFoodType foodType);
            IBakedFood food = foodType switch
            {
                BakedFoodType.Bread => new Bread(name, price),
                BakedFoodType.Cake => new Cake(name, price),
                _ => null
            };

            bakedFoods.Add(food);

            return string.Format(OutputMessages.FoodAdded, food.Name, food.GetType().Name);
        }
        
        //ready
        public string AddTable(string type, int tableNumber, int capacity)
        {
            Enum.TryParse(type, out TableType tableType);
            ITable table = tableType switch
            {
                TableType.InsideTable => new InsideTable(tableNumber, capacity),
                TableType.OutsideTable => new OutsideTable(tableNumber, capacity),
                _ => null
            };

            tables.Add(table);

            return string.Format(OutputMessages.TableAdded,table.TableNumber);
        }
        
        //ready
        public string GetFreeTablesInfo()
        {
           var sb = new StringBuilder();
            foreach (var table in tables.Where( t => t.IsReserved == false).ToList() ) 
            {
                sb.AppendLine(table.GetFreeTableInfo());
            }

            return sb.ToString().Trim();   
        }

        //ready
        public string GetTotalIncome()
        {
           
            return $"Total income: {income:f2}lv";
        }

        //ready
        public string LeaveTable(int tableNumber)
        {
            var sb = new StringBuilder();
            ITable table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            decimal bill = table.GetBill();

            table.Clear();

            
            sb.AppendLine($"Table: {tableNumber}");
            sb.AppendLine($"Bill: {bill:f2}");

            income += bill;

            return sb.ToString().Trim();

        }

        //ready
        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            ITable table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            IDrink drink = drinks.FirstOrDefault(d => d.Name == drinkName && d.Brand == drinkBrand);
            if (table == null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

            if (drink == null)
            {
                return string.Format(OutputMessages.NonExistentDrink, drinkName, drinkBrand);
            }

            
                table.OrderDrink(drink);
                return $"Table {tableNumber} ordered {drinkName} {drinkBrand}"; ;
            
        }

        //ready
        public string OrderFood(int tableNumber, string foodName)
        {
            ITable table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            IBakedFood food = bakedFoods.FirstOrDefault(f => f.Name == foodName);
            if (table == null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

            if (food == null)
            {
                return string.Format(string.Format(OutputMessages.NonExistentFood, foodName));
            }
           
                table.OrderFood(food);

                return string.Format(OutputMessages.FoodOrderSuccessful, tableNumber, foodName);
            
        }

        //ready
        public string ReserveTable(int numberOfPeople)
        {
            ITable table = tables.FirstOrDefault(t => t.IsReserved == false && t.Capacity >= numberOfPeople);

            if (table == null)
            {
                return string.Format(OutputMessages.ReservationNotPossible, numberOfPeople);
            }

           
               table.Reserve(numberOfPeople);
               return string.Format(OutputMessages.TableReserved, table.TableNumber, numberOfPeople);
            
        }

    }

}
