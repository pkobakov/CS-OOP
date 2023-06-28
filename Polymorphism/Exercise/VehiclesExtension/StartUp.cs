namespace VehiclesExtension
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Runtime.ConstrainedExecution;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using VehiclesExtension.Models;
    using VehiclesExtension.Models.Contracts;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            ICar car = null;
            ITruck truck = null;
            IBus bus = null;


            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < 3; i++)
            {
                string[] currentVehicle = Console.ReadLine()
                                                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                                 .ToArray();

                string vehicleType = currentVehicle[0];
                double fuelQuantity = double.Parse(currentVehicle[1]);
                double fuelConspumption = double.Parse(currentVehicle[2]);
                double tankCapacity = double.Parse(currentVehicle[3]);

                switch (vehicleType)
                {
                    case "Car": car = new Car(fuelQuantity, fuelConspumption, tankCapacity); break;
                    case "Truck": truck = new Truck(fuelQuantity, fuelConspumption, tankCapacity); break;
                    case "Bus": bus = new Bus(fuelQuantity, fuelConspumption, tankCapacity); break;
                }
            }

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                try
                {

                    string[] commandLine = Console.ReadLine()
                                                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                                .ToArray();

                    string commandType = commandLine[0];
                    string vehicleType = commandLine[1];
                    double amount = double.Parse(commandLine[2]);

                    switch (commandType)
                    {
                        case "Drive":
                            switch (vehicleType)
                            {
                                case "Car": stringBuilder.AppendLine(car.Drive(amount)); break;
                                case "Truck": stringBuilder.AppendLine(truck.Drive(amount)); break;
                                case "Bus": stringBuilder.AppendLine(bus.Drive(amount)); break;

                            }; break;

                        case "DriveEmpty": stringBuilder.AppendLine(bus.DriveEmpty(amount)); break;

                        case "Refuel":
                            switch (vehicleType)
                            {
                                case "Car": car.Refuel(amount); break;
                                case "Truck": truck.Refuel(amount); break;
                                case "Bus": bus.Refuel(amount); break;
                            }
                       ; break;
                    }
                }
                catch (ArgumentException ae)
                {
                    stringBuilder.AppendLine(ae.Message);
                    continue;
                }
            }

            stringBuilder.AppendLine(car.ToString());
            stringBuilder.AppendLine(truck.ToString());
            stringBuilder.AppendLine(bus.ToString());

            Console.WriteLine(stringBuilder.ToString().TrimEnd());
        }
    }
}