using NeedForSpeed.Car;
using System;

namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int horsePower = int.Parse(Console.ReadLine());
            double fuel = double.Parse(Console.ReadLine());

            var sportCar = new SportCar(horsePower, fuel);

            

            Console.WriteLine($"Horse power: {sportCar.HorsePower}");
            Console.WriteLine($"Fuel: {sportCar.Fuel}");



        }
    }
}
