using PizzaCalories.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza()
        {
            toppings = new List<Topping>();
        }

        public Pizza(string name) : this() 
        {
            this.Name = name;
          
        }

        public string Name 
        { 
            get => name; 
            private set
            {


                if (value.Length > 15 || string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value)) 
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                  
                }
                name = value;
            }
        }

        public Dough Dough { get => dough; set => dough = value; }
        public int ToppingCount => this.toppings.Count;

        public void AddTopping (Topping topping)
        {
            if (this.ToppingCount > 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            } 

            toppings.Add(topping);
        }
        public IReadOnlyList<Topping> Toppings => toppings.AsReadOnly();

        public double Calories => CalculateCalories();
        public double CalculateCalories() 
        {
            double calories = this.Dough.Calories;
            foreach (var topping in toppings)
            {
                calories += topping.Calories;
            }
           return calories;
        }

        public override string ToString()
        {
            return $"{this.Name} - {Calories:F2} Calories.";
        }


    }
}
