using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace VendingRetail.Tests
{
    public class Tests
    {
        private CoffeeMat coffeeMat;   
        [SetUp]
        public void Setup()
        {
            coffeeMat = new CoffeeMat(350, 3);
        }

        [TearDown]
        public void Teardown() 
        {
            coffeeMat = null;
        }

        [Test]
        public void TestCoffeeMarCreate()
        {
            Assert.AreEqual(coffeeMat.WaterCapacity, 350);
            Assert.AreEqual(coffeeMat.ButtonsCount, 3);
            Assert.AreEqual(coffeeMat.Income, 0);
        }

        [Test]
        public void TestFillWaterTankMethod() 
        {
            int mililitresFilled = coffeeMat.WaterCapacity - 0;
            string actual = coffeeMat.FillWaterTank();
            string expected = $"Water tank is filled with {mililitresFilled}ml";
            
            Assert.AreEqual(actual, expected);
            Assert.AreEqual(coffeeMat.WaterCapacity, 350);

        }

        [Test]
        public void TestFillWaterTankMethodValidation() 
        {
            coffeeMat = new CoffeeMat(0, 3);
            
            string actual = coffeeMat.FillWaterTank();
            string expected = "Water tank is already full!";

            Assert.AreEqual(actual, expected);
        }

        [Test]
        [TestCase("Mojito", 12)]
        public void TestAddDrinkMethod(string name, double price) 
        {
            bool expectedTrue = true;
            bool actualTrue = coffeeMat.AddDrink(name, price);
            
            Assert.AreEqual(expectedTrue, actualTrue);

            bool expectedFalse = false;
            bool actualFalse = coffeeMat.AddDrink(name, price);
            Assert.AreEqual(expectedFalse, actualFalse);
        }

        [Test]
        [TestCase("Mojito", 12)]
        public void TestBuyDrinkMethod(string name, double price) 
        {
            coffeeMat.FillWaterTank();
            coffeeMat.AddDrink(name, price);

            string expected = $"Your bill is {price:f2}$";
            string actual = coffeeMat.BuyDrink(name);



            Assert.AreEqual(expected, actual);
            Assert.AreEqual(coffeeMat.Income, 12);


            Assert.AreEqual(coffeeMat.FillWaterTank(), $"Water tank is filled with 80ml");
            
        }

        [Test]
        [TestCase("Mojito")]
        public void TestTestBuyDrinkMethodWaterTankLevelValidation(string name) 
        {
            string expected = "CoffeeMat is out of water!";
            string actual = coffeeMat.BuyDrink(name);
            Assert.AreEqual(expected, actual);  
        }

        [Test]
        [TestCase("Mojito")]
        public void TestTestBuyDrinkMethodDrinkNameValidation(string name) 
        {
            coffeeMat.FillWaterTank();

            string expected = $"{name} is not available!";
            string actual = coffeeMat.BuyDrink(name);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase("Mojito", 12)]
        public void TestCollectIncomeMethod(string name, double price) 
        {
            coffeeMat.FillWaterTank();
            coffeeMat.AddDrink(name, price);
            coffeeMat.BuyDrink(name);

            double expected = 12;
            double actual = coffeeMat.CollectIncome();
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(coffeeMat.Income, 0);
        }

    }
}