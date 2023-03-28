using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Computers.Tests
{
    public class Tests
    {
        ComputerManager _manager;
        Computer _computer;
        private const string CannotBeNullMessage = "Can not be null!";
        private const string ExistingComputer = "This computer already exists.";
        private const string NotExistingComputer = "There is no computer with this manufacturer and model.";

        [SetUp]
        public void Setup()
        {
            _manager = new ComputerManager();
            _computer = new Computer("Asus", "Frog", 1500M);    
           
        }
        [TearDown]
        public void TearDown()
        {
            _manager = null;
            _computer = null;    
        }

        [Test]
        public void ComputersCountTest()
        {
            
            int actual = _manager.Computers.Count;
            int expected = 0;

            Assert.That(actual, Is.EqualTo(expected));
            Assert.IsEmpty(_manager.Computers);
        }
        [Test]
        public void AddComputerMethodExceptionTest() 
        {
            Assert.That(() => _manager.AddComputer(null), Throws.ArgumentNullException);
            _manager.AddComputer(_computer);
            Assert.That(() => _manager.AddComputer(_computer), Throws.ArgumentException.With.Message.EqualTo(ExistingComputer));
        }
        [Test]
        public void AddMethodTest() 
        {
            var testComputer = _computer;
           _manager.AddComputer(testComputer);
           int actual = _manager.Count;
           int expected = 1;
            Assert.AreEqual(actual, expected);
            Assert.That(_computer.Manufacturer, Is.EqualTo(testComputer.Manufacturer));
            Assert.That(_computer.Model, Is.EqualTo(testComputer.Model))
;           Assert.That(_computer.Price, Is.EqualTo(testComputer.Price));
            Assert.That(_manager.Computers, Has.Member(testComputer));
        }

        [Test]
        public void GetComputerMethodNullExceptionTest() 
        {
            _manager.AddComputer(_computer);
            Assert.That(() => _manager.GetComputer(null, "Frog"), Throws.ArgumentNullException);
            Assert.That(() => _manager.GetComputer("Asus", null), Throws.ArgumentNullException);
            _computer = new Computer("Lenovo", "Thinkpad", 2300M);
            Assert.That(() => _manager.GetComputer(_computer.Manufacturer, _computer.Model), Throws.ArgumentException.With.Message.EqualTo(NotExistingComputer));
        }

        [Test]
        public void GetComputerMethodTest() 
        {
            _manager.AddComputer(_computer);
            var test = _manager.GetComputer("Asus", "Frog");
            var expected = _computer;
            Assert.AreEqual(_computer.Manufacturer, test.Manufacturer);
            Assert.AreEqual(test.Model, expected.Model);    
            Assert.AreEqual(expected.Price, test.Price);
        }

        [Test]
        public void RemoveComputerMethodNullExceptionTest() 
        {
            
            Assert.That(() => _manager.RemoveComputer(null, "ThinkPad"), Throws.ArgumentNullException);
            Assert.That(() => _manager.RemoveComputer("Lenovo", null), Throws.ArgumentNullException);
        }

        [Test]
        public void RemoveComputerMethodTest() 
        { 
           _manager.AddComputer(_computer);
           var testComputer = _manager.GetComputer("Asus", "Frog");
           var result = _manager.RemoveComputer("Asus", "Frog");
           Assert.AreEqual(testComputer.Manufacturer, result.Manufacturer);
           Assert.AreEqual(testComputer.Model, result.Model);
           Assert.AreEqual(testComputer.Price, result.Price);
           Assert.That(_manager.Count, Is.EqualTo(0));
        }

        [Test]
        public void GetComputersByManufacturerExceptionTest() 
        {
            Assert.That(() => _manager.GetComputersByManufacturer(null), Throws.ArgumentNullException);
        
        }

        [Test]
        public void GetComputersByManufacturerMethodTest() 
        {
            var manufacturer = "Lenovo";
           
            var firstComputer = _computer;
            var secondComputer = new Computer("Lenovo", "ThinkPad", 2300M);
            var thirdComputer = new Computer("Lenovo", "IdeaPad", 1500M);
            var collection = new List<Computer> { firstComputer, secondComputer, thirdComputer };
            
            foreach (var computer in collection) 
            { 
            
               _manager.AddComputer(computer);
            }

            var result = _manager.GetComputersByManufacturer(manufacturer);
            Assert.That(result.Count, Is.EqualTo(2));
        }
    }
}