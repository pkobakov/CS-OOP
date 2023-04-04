using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        private Smartphone smartPhone;
        private Shop shop;
        [SetUp]
        public void Setup() 
        {
            smartPhone = new Smartphone("Nokia", 100 );
            shop = new Shop(30);
        }
        [TearDown]
        public void TearDown() 
        { 
            smartPhone = null;
            shop = null;
        }

        [Test]
        public void ConstructorTest() 
        {
            Assert.AreEqual(shop.Count, 0);
        }

        [TestCase(-1)]
        public void CapacityValodationTest(int capacity)
        {
            Assert.That(()=> shop = new Shop(capacity), 
                Throws.ArgumentException.With.Message.EqualTo("Invalid capacity."));
        }

        [Test] 
        public void CapacityTest() 
        {
            Assert.AreEqual(shop.Capacity, 30);
        }

        [Test]
        public void AddPhoneExceptionTest()
        {
            shop.Add(smartPhone);
            Assert.That(() => shop.Add(smartPhone), 
                Throws.InvalidOperationException.With.Message.EqualTo($"The phone model {smartPhone.ModelName} already exist."));

            shop = new Shop(1);
            shop.Add(smartPhone);
            Assert.That(() => shop.Add(new Smartphone("Morola", 100)),
                Throws.InvalidOperationException.With.Message.EqualTo("The shop is full."));
        }

        [Test]
        public void AddPhoneTest() 
        {
            shop.Add(smartPhone);
            Assert.That(shop.Count, Is.EqualTo(1));
        }

        [Test]
        public void RemovePhoneExceptionTest() 
        {
            shop.Add(smartPhone);
            string modelName = "TestPhone";

            Assert.That(() => shop.Remove(modelName), 
                Throws.InvalidOperationException.With.Message.EqualTo($"The phone model {modelName} doesn't exist."));
        }

        [Test]
        public void RemovePhoneTest() 
        {
            string modelName = "Nokia";
            shop.Add(smartPhone);
            shop.Remove(modelName);
            Assert.That(shop.Count, Is.EqualTo(0));
        }

        [TestCase("Nokia", 30)]
        
        public void TestPhoneExceptionTest(string modelName, int batteryUsage) 
        {
            Assert.That(() => shop.TestPhone(modelName, batteryUsage), 
                Throws.InvalidOperationException.With.Message.EqualTo($"The phone model {modelName} doesn't exist."));
           
            shop.Add(smartPhone);
            Assert.That(() => shop.TestPhone(modelName, 120), 
                Throws.InvalidOperationException.With.Message.EqualTo($"The phone model {modelName} is low on batery."));
        }

        [TestCase("Nokia", 30)]
        public void TestPhoneMethodTest(string modelName, int batteryUsage) 
        {
            shop.Add(smartPhone);
            shop.TestPhone(modelName, batteryUsage);
            Assert.AreEqual(smartPhone.CurrentBateryCharge, 70);
        }

        [TestCase("Nokia")]
        public void ChargePhoneExceptionTest(string modelName) 
        {
            Assert.That(() => shop.ChargePhone(modelName), 
                Throws.InvalidOperationException.With.Message.EqualTo($"The phone model {modelName} doesn't exist."));
        }

        [TestCase("Nokia")]
        public void ChargePhoneTest(string modelName) 
        {
            shop.Add(smartPhone);
            shop.TestPhone(modelName, 30);
            shop.ChargePhone(modelName);
            Assert.AreEqual(smartPhone.CurrentBateryCharge, 100);
        }


    }
}