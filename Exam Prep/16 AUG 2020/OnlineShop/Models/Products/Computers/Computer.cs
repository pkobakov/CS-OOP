using OnlineShop.Common.Constants;
using OnlineShop.Common.Enums;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private readonly ICollection<IComponent> components;
        private readonly ICollection<IPeripheral> peripherals;
        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance) 
            : base(id, manufacturer, model, price, overallPerformance)
        {
            components = new List<IComponent>();
            peripherals = new List<IPeripheral>();
        }

        public IReadOnlyCollection<IComponent> Components => components.ToList().AsReadOnly();

        public IReadOnlyCollection<IPeripheral> Peripherals => peripherals.ToList().AsReadOnly();

        public override double OverallPerformance 
         => !components.Any() ? base.OverallPerformance : base.OverallPerformance + components.Average(c => c.OverallPerformance);

        public override decimal Price => base.Price + components.Sum(c => c.Price) + peripherals.Sum(p => p.Price);

        public void AddComponent(IComponent component)
        {
            if (components.Any(c => c.GetType().Name == component.GetType().Name)) 
            {
                throw new ArgumentException
                    (string.Format(ExceptionMessages.ExistingComponent, component.GetType().Name, this.GetType().Name, this.Id));
            }

            components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (peripherals.Any(c => c.GetType().Name == peripheral.GetType().Name))
            {
                throw new ArgumentException
                    (string.Format(ExceptionMessages.ExistingComponent, peripheral.GetType().Name, this.GetType().Name, this.Id));
            }

            peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            if (!components.Any( c => c.GetType().Name == componentType) || components.Count == 0)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingComponent, componentType, this.GetType().Name, this.Id));
            }
            var component = components.FirstOrDefault( c => c.GetType().Name == componentType);
            components.Remove(component);
            return component;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            if (!peripherals.Any(c => c.GetType().Name == peripheralType) || peripherals.Count == 0)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingPeripheral, peripheralType, this.GetType().Name, this.Id));
            }
            var peripheral = peripherals.FirstOrDefault(c => c.GetType().Name == peripheralType);
            peripherals.Remove(peripheral);
            return peripheral;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($" Components ({components.Count}):");

            foreach (var component in Components) 
            { 
              sb.AppendLine($"  {component.ToString()}");
            }

            var averageOverallPeripherals = peripherals.Any() ? peripherals.Average(p => p.OverallPerformance) : 0.00; 
            sb.AppendLine($" Peripherals ({peripherals.Count}); Average Overall Performance ({averageOverallPeripherals}):");

            foreach (var peripheral in Peripherals) 
            {
                sb.AppendLine($"  {peripheral.ToString()}");
            }
            return 
                base.ToString() + 
                Environment.NewLine + 
                sb.ToString().Trim();
        }
    }
}
