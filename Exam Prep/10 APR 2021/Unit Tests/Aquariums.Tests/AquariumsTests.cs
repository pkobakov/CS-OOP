namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;
    using System.Text;

    public class AquariumsTests
    {
        Fish fish;
        Aquarium aquarium;

        [SetUp]
        public void SetUp()
        {
            fish = new Fish("Nemo");
            aquarium = new Aquarium("Coral", 3);
        }

        [TearDown]
        public void TearDown()
        {
            fish = null;
            aquarium = null;
        }

        [Test]
        public void AquariumConstructorTest()
        {
            Assert.AreEqual(aquarium.Name, "Coral");
            Assert.AreEqual(aquarium.Capacity, 3);
            Assert.AreEqual(aquarium.Count, 0);
        }

        [Test]
        public void NameValidationTest()
        {
            Assert.That(() => aquarium = new Aquarium(null, 3), Throws.ArgumentNullException);
        }

        [Test]
        public void CapacityValidationTest()
        {
            Assert.That(() => aquarium = new Aquarium("Coral", -1), Throws.ArgumentException.With.Message.EqualTo("Invalid aquarium capacity!"));
        }

        [Test]
        public void AddValidationTest()
        {
            aquarium = new Aquarium("Coral", 1);
            aquarium.Add(fish);
            Assert.That(() => aquarium.Add(fish), Throws.InvalidOperationException);
        }

        [Test]
        public void AddFishTest()
        {
            aquarium.Add(fish);
            Assert.AreEqual(aquarium.Count, 1);
        }

        [Test]
        public void RemoveFishValidationTest()
        {
            Assert.That(() => aquarium.RemoveFish("Nemo"), Throws.InvalidOperationException);
        }

        [TestCase("Nemo")]
        public void RemoveFishTest(string fishName)
        {
            aquarium.Add(fish);
            aquarium.RemoveFish(fishName);

            Assert.AreEqual(aquarium.Count, 0);
        }

        [TestCase("Nemo")]
        public void SellFishValidationTest(string fishName)
        {
            Assert.That(() => aquarium.SellFish(fishName), Throws.InvalidOperationException);
        }

        [TestCase("Nemo")]
        public void SellFishTest(string fishName)
        {
            aquarium.Add(fish);
            Assert.That(() => aquarium.SellFish(fishName), Is.EqualTo(fish));

            Assert.False(fish.Available);
        }

        [Test]
        public void ReportTest()
        {
            aquarium.Add(fish);
            var testFish = new Fish("Dory");

            aquarium.Add(testFish);

            var expected = "Fish available at Coral: Nemo, Dory";
            var actual = aquarium.Report();

            Assert.AreEqual(expected, actual);
            
        }
    }
}
