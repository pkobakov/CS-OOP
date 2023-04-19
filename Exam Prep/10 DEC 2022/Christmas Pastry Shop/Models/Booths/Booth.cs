using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Booths
{
    public class Booth : IBooth
    {
        private int boothId;
        private int capacity;

        private IRepository<IDelicacy> delicacyMemu;
        private IRepository<ICocktail> cocktailMenu;
        public Booth(int boothId, int capacity)
        {
            this.BoothId = boothId;
            this.Capacity = capacity;
            this.delicacyMemu = new DelicacyRepository();
            this.cocktailMenu = new CocktailRepository();
            this.CurrentBill = 0;
            this.Turnover = 0;
            this.IsReserved = false;
        }
        public int BoothId { get { return boothId; } private set { boothId = value; } }

        public int Capacity 
        { 
            get { return capacity; }
            private set 
            {
                if (value <= 0) 
                {
                    throw new ArgumentException(ExceptionMessages.CapacityLessThanOne);
                }
                capacity = value;   
            }
        }

        public IRepository<IDelicacy> DelicacyMenu => this.delicacyMemu;

        public IRepository<ICocktail> CocktailMenu => this.cocktailMenu;

        public double CurrentBill { get; private set; }

        public double Turnover { get; private set; }

        public bool IsReserved { get; private set; }

        public void ChangeStatus()
        {
            this.IsReserved = !this.IsReserved;
        }

        public void Charge()
        {
            this.Turnover += this.CurrentBill;
            this.CurrentBill = 0;
        }

        public void UpdateCurrentBill(double amount)
        {
            this.CurrentBill += amount;
        }

        public override string ToString()
        {
            var report = new StringBuilder();

            report.AppendLine($"Booth: {this.BoothId}");
            report.AppendLine($"Capacity: {this.Capacity}");
            report.AppendLine($"Turnover: {this.Turnover:f2} lv");
            report.AppendLine($"-Cocktail menu:");
            foreach (var cocktail in CocktailMenu.Models)
            {
                report.AppendLine($"--{cocktail}");
            }

            report.AppendLine($"-Delicacy menu:");
            foreach (var delicacy in DelicacyMenu.Models)
            {
                report.AppendLine($"--{delicacy}");
            }

            return report.ToString().TrimEnd();
        }
    }
}
