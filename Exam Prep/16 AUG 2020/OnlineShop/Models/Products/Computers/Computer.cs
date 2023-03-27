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
        private readonly ICollection<IComponent> _components;
        private readonly ICollection<IPeripheral> _peripherals;
        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance) 
            : base(id, manufacturer, model, price, overallPerformance)
        {
            _components = new List<IComponent>();
            _peripherals = new List<IPeripheral>();
        }

        public override double OverallPerformance
         => _components.Count == 0 ? base.OverallPerformance : base.OverallPerformance + Components.Average(c => c.OverallPerformance);

        public override decimal Price => base.Price + Components.Sum(c => c.Price) + Peripherals.Sum(p => p.Price);
        public IReadOnlyCollection<IComponent> Components => _components.ToList().AsReadOnly();

        public IReadOnlyCollection<IPeripheral> Peripherals => _peripherals.ToList().AsReadOnly();

        

        public void AddComponent(IComponent component)
        {
            if (Components.Any(c => c.GetType().Name == component.GetType().Name)) 
            {
                throw new ArgumentException
                    (string.Format(ExceptionMessages.ExistingComponent, component.GetType().Name, this.GetType().Name, this.Id));
            }

            _components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (Peripherals.Any(c => c.GetType().Name == peripheral.GetType().Name))
            {
                throw new ArgumentException
                    (string.Format(ExceptionMessages.ExistingComponent, peripheral.GetType().Name, this.GetType().Name, this.Id));
            }
            
            _peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            if (!Components.Any( c => c.GetType().Name == componentType) || !Components.Any())
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingComponent, componentType, this.GetType().Name, this.Id));
            }
            var component = Components.FirstOrDefault( c => c.GetType().Name == componentType);
            _components.Remove(component);
            return component;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            if (!Peripherals.Any(c => c.GetType().Name == peripheralType) || !Peripherals.Any())
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingPeripheral, peripheralType, this.GetType().Name, this.Id));
            }
            var peripheral = _peripherals.FirstOrDefault(c => c.GetType().Name == peripheralType);
            _peripherals.Remove(peripheral);
            return peripheral;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());

            sb.AppendLine($" Components ({Components.Count}):");

            foreach (var component in Components) 
            { 
              sb.AppendLine($"  {component.ToString()}");
            }

           double averageOverallPeripherals = _peripherals.Any() ? Peripherals.Average(p => p.OverallPerformance) : 0.00; 
            sb.AppendLine($" Peripherals ({Peripherals.Count}); Average Overall Performance ({averageOverallPeripherals:f2}):");

            foreach (var peripheral in Peripherals) 
            {
                sb.AppendLine($"  {peripheral.ToString()}");
            }
            return sb.ToString().Trim();
        }
    }
}
