using Animals.Cats;
using System;
using System.Net;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            while (true) 
            {
                string animalType =Console.ReadLine();

                if (animalType == "Beast!")
                {
                    break;
                }

                string [] animalData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                
                string name = animalData[0];
                int age = Convert.ToInt32(animalData[1]);
                string gender = animalData[2];

                switch (animalType)
                {
                    case "Cat": Cat cat = new Cat(name, age, gender);
                             Console.WriteLine(cat); break;
                    case "Kittens": Kitten kittens = new Kitten(name, age);
                            Console.WriteLine(kittens); break;
                    case "Tomcat": Tomcat tomcat = new Tomcat(name, age);
                        Console.WriteLine(tomcat); break;
                    case "Dog": Dog dog = new Dog(name, age, gender);
                        Console.WriteLine(dog); break;
                    case "Frog": Frog frog = new Frog(name, age, gender);
                        Console.WriteLine(frog); break;
                }
            }

           
        }
    }
}
