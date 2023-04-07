using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Repositories.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetWars.Models.Planets
{
    public class Planet : IPlanet
    {
        private string name;
        private double budget;
        private double militaryPower;

        private IRepository<IWeapon> weapons;
        private IRepository<IMilitaryUnit> units;
        public Planet(string name, double budget)
        {
            this.Name = name;
            this.Budget = budget;
            this.weapons = new WeaponRepository();
            this.units = new UnitRepository();
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlanetName);
                }
                this.name = value;
            }

        }

        public double Budget
        {
            get { return budget; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBudgetAmount);
                }
                budget = value;
            }
        }

        public double MilitaryPower 
        { 
            get => CalculateMilitaryPower();
            
        }

        public IReadOnlyCollection<IMilitaryUnit> Army => this.units.Models.ToList().AsReadOnly();

        public IReadOnlyCollection<IWeapon> Weapons => this.weapons.Models.ToList().AsReadOnly();

        public void AddUnit(IMilitaryUnit unit)
        {
            this.units.AddItem(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {
            this.weapons.AddItem(weapon);
        }

        public string PlanetInfo()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Planet: {this.Name}");
            sb.AppendLine($"--Budget: {this.Budget} billion QUID");
            var unitsList = units.Models.Count > 0 ? string.Join(", ", units.Models.Select(u => u.GetType().Name)) : "No units";
            sb.AppendLine($"--Forces: {unitsList}");
            var weaponsList = weapons.Models.Count > 0 ? string.Join(", ", weapons.Models.Select(u => u.GetType().Name)) : "No weapons";
            sb.AppendLine($"--Combat equipment: {weaponsList}");
            sb.AppendLine($"--Military Power: {this.MilitaryPower}");

            return sb.ToString().Trim();
        }

        public void Profit(double amount)
        {
            this.Budget += amount;
        }

        public void Spend(double amount)
        {
            if (this.Budget < amount)
            {
                throw new InvalidOperationException(ExceptionMessages.UnsufficientBudget);
            }
            this.Budget -= amount;
        }

        public void TrainArmy()
        {
            this.units.Models.ToList().ForEach(u => u.IncreaseEndurance());

        }

        private double CalculateMilitaryPower()
        {
            double totalAmount = units.Models.Sum(u => u.EnduranceLevel) + weapons.Models.Sum(w => w.DestructionLevel);
            if (this.units.Models.Any(u => u.GetType().Name == nameof(AnonymousImpactUnit)))
            {
                totalAmount += totalAmount * 0.30;
            }

            if (this.weapons.Models.Any(w => w.GetType().Name == nameof(NuclearWeapon)))
            {
                totalAmount += totalAmount * 0.45;
            }

            
            return Math.Round(totalAmount, 3);

        }
    }
}
