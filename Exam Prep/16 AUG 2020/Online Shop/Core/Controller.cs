using OnlineShop.Common.Constants;
using OnlineShop.Common.Enums;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private readonly ICollection<IComputer> computers;
        private readonly ICollection<IComponent> components;
        private readonly ICollection<IPeripheral> peripherals;
        public Controller()
        {
            this.computers = new List<IComputer>();
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();

        }



        //ready
        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {

            if (components.Any(c => c.Id == id))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingComponentId));

            }

            IComponent component = CreateComponent(id, componentType, manufacturer, model, price, overallPerformance, generation);
            IComputer computer = FindComputer(computerId);
            computer.AddComponent(component);
            components.Add(component);
            

            return string.Format(SuccessMessages.AddedComponent, componentType, id, computerId);
        }
        //ready
        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            if (computers.Any(c => c.Id == id)) 
            {
                throw new ArgumentException(ExceptionMessages.ExistingComputerId);
            }

            IComputer computer = CreateComputer(computerType, id, manufacturer, model, price);
            computers.Add(computer);
            return string.Format(SuccessMessages.AddedComputer, id);
        }
        // ready
        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            if (peripherals.Any(p => p.Id == id))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingPeripheralId));
            }

            IPeripheral peripheral = CreatePeripheral(id, peripheralType, manufacturer, model, price, overallPerformance, connectionType);
            IComputer computer = FindComputer(computerId);
            computer.AddPeripheral(peripheral);
            peripherals.Add(peripheral);

            return string.Format(SuccessMessages.AddedPeripheral, peripheralType, id, computerId);
        }
        //ready
        public string BuyBest(decimal budget)
        {
            IComputer computer = computers.OrderByDescending(c => c.OverallPerformance).Where(c => c.Price <= budget).FirstOrDefault();
            if (computer == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CanNotBuyComputer, budget));
            }

            string outPut = computer.ToString();
            computers.Remove(computer);
            return outPut;
        }

        //ready
        public string BuyComputer(int id)
        {
            IComputer computer = FindComputer(id);
            string outPut = computer.ToString();
            computers.Remove(computer);

            return outPut;
        }
        //ready
        public string GetComputerData(int id)
        {
            IComputer computer = FindComputer(id);
            return computer.ToString();
        }
        //ready
        public string RemoveComponent(string componentType, int computerId)
        {
            IComputer computer = FindComputer(computerId);
            IComponent component = computer.RemoveComponent(componentType);
            components.Remove(component);

            return string.Format(SuccessMessages.RemovedComponent, componentType, component.Id);

        }
        //ready
        public string RemovePeripheral(string peripheralType, int computerId)
        {
            IComputer computer = FindComputer(computerId);
            IPeripheral peripheral = computer.Peripherals.FirstOrDefault(p => p.GetType().Name == peripheralType); 
            
            computer.RemovePeripheral(peripheralType);
            peripherals.Remove(peripheral);

            return String.Format(SuccessMessages.RemovedPeripheral, peripheralType, peripheral.Id);
        }
        //ready
        private IComponent CreateComponent(int id, string type, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            Enum.TryParse(type, out ComponentType componentType);
            IComponent component = componentType switch
            {
                ComponentType.CentralProcessingUnit => new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation),
                ComponentType.Motherboard => new Motherboard(id, manufacturer, model, price, overallPerformance, generation),
                ComponentType.VideoCard => new VideoCard(id, manufacturer, model, price, overallPerformance, generation),
                ComponentType.SolidStateDrive => new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation),
                ComponentType.RandomAccessMemory => new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation),
                ComponentType.PowerSupply => new PowerSupply(id, manufacturer, model, price, overallPerformance, generation),
                _ => throw new ArgumentException(string.Format(ExceptionMessages.InvalidComponentType))
            };

            return component;
        }
        //ready
        private  IPeripheral CreatePeripheral(int id, string type, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            Enum.TryParse(type, out PeripheralType peripheralType);

            IPeripheral peripheral = peripheralType switch
            {
                PeripheralType.Keyboard => new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType),
                PeripheralType.Mouse => new Mouse(id, manufacturer, model, price, overallPerformance, connectionType),
                PeripheralType.Monitor => new Monitor(id, manufacturer, model, price, overallPerformance, connectionType),
                PeripheralType.Headset => new Headset(id, manufacturer, model, price, overallPerformance, connectionType),
                _ => throw new ArgumentException(string.Format(ExceptionMessages.InvalidPeripheralType))
            };

            return peripheral;
        }
        //ready
        private IComputer CreateComputer(string computerType, int id, string manufacturer, string model, decimal price) 
        {

           Enum.TryParse(computerType, out ComputerType type);
            IComputer computer = type switch
            {
                ComputerType.Laptop => new Laptop(id, manufacturer, model, price),
                ComputerType.DesktopComputer => new DesktopComputer(id, manufacturer, model, price),
                _ => throw new ArgumentException(ExceptionMessages.InvalidComputerType)
            };

            return computer;
        }
        //ready
        private IComputer FindComputer(int computerId)
        => computers.Any(c => c.Id == computerId) ? computers.FirstOrDefault(c => c.Id == computerId) : throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
    }
}
