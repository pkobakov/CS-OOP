using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private UnitCar car;
        private UnitDriver driver;
        private RaceEntry race;

        [SetUp]
        public void Setup()
        {
            car = new UnitCar("Mazda", 500, 3000);
            driver = new UnitDriver("Pesho", car);
            race = new RaceEntry();

        }

        [TearDown]
        public void TearDown() 
        { 
            car = null;
            driver = null;
            race = null;
        }

        [Test]
        public void RaceEntryContructorTest()
        {
            Assert.That(race.Counter, Is.EqualTo(0));
        }

        [Test]
        public void AddDriverExceptionsTest() 
        {

            Assert.That(() => race.AddDriver(null), Throws.InvalidOperationException);
;
            race.AddDriver(driver);
            Assert.That(() => race.AddDriver(driver), Throws.InvalidOperationException);
        }

        [Test]
        public void AddRaceTest() 
        {
            string result = race.AddDriver(driver);
            string expected = $"Driver {driver.Name} added in race.";

            Assert.That(race.Counter, Is.EqualTo(1));
            Assert.AreEqual(expected, result);
        }

        [Test]  
        public void CalculateAverageHorsePowerExceptionsTest() 
        {
            Assert.That(() => race.CalculateAverageHorsePower(), Throws.InvalidOperationException);
        }

        [Test]
        public void CalculateAverageHorsePowerMethodTest()
        {
            var firstDriver = driver;
            var secondDriver = new UnitDriver("Max", new UnitCar("BMW", 650, 4000));
            var thirdDriver = new UnitDriver("Alex", new UnitCar("Honda", 400, 3500));

            race.AddDriver(firstDriver);
            race.AddDriver(secondDriver);
            race.AddDriver(thirdDriver);

            var drivers = new Dictionary<string, UnitCar>();
            drivers.Add("Pesho", new UnitCar("Mazda", 500, 3000));
            drivers.Add("Max", new UnitCar("BMW", 650, 4000));
            drivers.Add("Alex", new UnitCar("Honda", 400, 3500));

            double result = race.CalculateAverageHorsePower();
            double expected = drivers.Values.Select( d => d.HorsePower).Average();

            Assert.AreEqual(expected, result);
            
        }
    }
}