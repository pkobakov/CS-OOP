namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        private Car car;
        private const string MakeEmptyOrNullException = "Make cannot be null or empty!";
        private const string ModelEmptyOrNullException = "Model cannot be null or empty!";
        private const string FuelConsumptionZeroOrNegativeException = "Fuel consumption cannot be zero or negative!";
        private const string FuelAmountCannotBeNegativeException = "Fuel amount cannot be negative!";
        private const string FuelAmountZeroOrNegativeException = "Fuel amount cannot be zero or negative!";
        private const string FuelCapacityNegativeOrZeroException = "Fuel capacity cannot be zero or negative!";
        private const string NotEnoughFuelAmountException = "You don't have enough fuel to drive!";


        [SetUp]
        public void SetUp()
        {
            car = new Car("BMW", "320i", 9.6, 65);

        }
        [TearDown]
        public void TearDown()
        {
            car = null;
        }

        [Test]
        public void Test_FuelAmount()
        {

            double expected = 0;
            double actual = car.FuelAmount;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(null)]
        [TestCase("")]
        public void Test_MakePropertyValidation(string make)
        {

            Assert.That(() => car = new Car(make, "320i", 10d, 45), Throws.ArgumentException
                                        .With
                                        .Message
                                        .EqualTo(MakeEmptyOrNullException));
        }

        [Test]
        public void Test_SetMakeProperty()
        {
            string expected = "BMW";
            string actual = car.Make;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase("")]
        [TestCase(null)]
        public void Test_ModelPropertyValidation(string model)
        {
            Assert.That(() => car = new Car("BMW", model, 10, 45), Throws.ArgumentException
                                        .With
                                        .Message
                                        .EqualTo(ModelEmptyOrNullException));
        }

        [Test]
        public void Test_SetModelProperty()
        {
            string expected = "320i";
            string actual = car.Model;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void Test_ZeroOrNegativeFuelConsumption(double consumtion)
        {
            Assert.That(() => car = new Car("m", "s", consumtion, 9.8), Throws.ArgumentException
                                                                      .With
                                                                      .Message
                                                                      .EqualTo(FuelConsumptionZeroOrNegativeException));

        }

        [Test]
        public void Test_SetFuelConsumption()
        {
            double expected = 9.6;
            double actual = car.FuelConsumption;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void Test_FuelCapacityCannotBeZeroOrNegative(double fuelCapacity)
        {
            Assert.That(() => car = new Car("m", "s", 9.6, fuelCapacity), Throws.ArgumentException
                                                                       .With
                                                                       .Message
                                                                       .EqualTo(FuelCapacityNegativeOrZeroException));

        }

        [Test]
        public void Test_SetFuelCapacity()
        {
            double expected = 65;
            double actual = car.FuelCapacity;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void Test_FuelAmountParameterInRefuelMethodCannotBeZeroOrNegative(double fuelAmount)
        {
            Assert.That(() => car.Refuel(fuelAmount), Throws.ArgumentException
                                                    .With
                                                    .Message
                                                    .EqualTo(FuelAmountZeroOrNegativeException));
        }

        [TestCase(65)]
        [TestCase(70)]
        public void Test_RefuelMethod(double refuelAmount) 
        {
            double expected = 65;
            car.Refuel(refuelAmount);
            double actual = car.FuelAmount;

            Assert.That (actual, Is.EqualTo(expected));
        }



        [Test]
        public void Test_NotEnoughFuelThrowsException() 
        {
            Assert.That(() => car.Drive(10), Throws.InvalidOperationException
                 .With.Message.EqualTo(NotEnoughFuelAmountException));
        
        }

        [Test]
        public void Test_DriveMethod() 
        {
            car.Refuel(50);
            car.Drive(50);

            double actual = car.FuelAmount;
            double expected = 45.20;   

            Assert.That(actual, Is.EqualTo(expected));
        }


    }
}