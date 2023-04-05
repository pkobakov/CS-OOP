using NUnit.Framework;

namespace Gyms.Tests
{
    public class GymsTests
    {
        Athlete athlete;
        Gym gym;

        [SetUp]
        public void SetUp()
        {
            athlete = new Athlete("Pesho");
            gym = new Gym("Pulse", 50);
        }

        [TearDown]
        public void TearDown() 
        {
            athlete = null;
            gym = null;
        }

        [Test]
        public void ConstructorTest()
        {
            Assert.AreEqual(gym.Name, "Pulse");
            Assert.AreEqual(gym.Capacity, 50);
            Assert.AreEqual(gym.Count, 0);
        }
        [TestCase(-1)]
        public void GymPropertyValidationTest(int capacity)
        {
            
            Assert.That(() => gym = new Gym(null, 50), Throws.ArgumentNullException);
            Assert.That(() => gym = new Gym("Pulse", capacity), 
                Throws.ArgumentException.With.Message.EqualTo("Invalid gym capacity."));
        }

        [Test]
        public void AddAthleteExeptionTest()
        {
            gym = new Gym("Pulse", 1);
            gym.AddAthlete(athlete);
            Assert.That(() => gym.AddAthlete(athlete), Throws.InvalidOperationException);
        }

        [Test]
        public void AddAthleteTest()
        {
            gym.AddAthlete(athlete);
            Assert.AreEqual(gym.Count, 1);
        }

        [TestCase("Pesho")]
        public void RemoveAthleteExceptionTest(string fullName)
        {
            
            Assert.That(() => gym.RemoveAthlete(fullName), Throws.InvalidOperationException);
        }

        [TestCase("Pesho")]
        public void RemoveTest(string fullName)
        {
            gym.AddAthlete(athlete);
            gym.RemoveAthlete(fullName);
            Assert.AreEqual(gym.Count, 0);
        }

        [Test]
        public void InjuredAthleteExceptionTest()
        {
            Assert.That(() => gym.InjureAthlete("Pesho"), Throws.InvalidOperationException);
        }

        [Test]
        public void InjuredAthleteTest()
        {
            gym.AddAthlete(athlete);
            athlete.IsInjured = true;
            Assert.That(() => gym.InjureAthlete("Pesho"), Is.EqualTo(athlete));
        }

        [Test]
        public void GymReportTest()
        {
            gym.AddAthlete(athlete);
            Athlete testAthlete = new Athlete("Gosho");
            gym.AddAthlete(testAthlete);

            string actual = gym.Report();

            Assert.AreEqual(actual, "Active athletes at Pulse: Pesho, Gosho");
        }



    }
}
