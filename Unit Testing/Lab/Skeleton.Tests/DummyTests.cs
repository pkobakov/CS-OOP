using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void Test_DummyLosesHealthAfterAttack() 
        {
            //Arrange
            Dummy dummy = new Dummy(10, 10);
            Axe axe = new Axe(10, 10);

            //Act

            dummy.TakeAttack(axe.AttackPoints);

            //Assert

            Assert.That(dummy.Health, Is.EqualTo(0), "Dummy doesn't loose Health after attack");
        }

        [Test]
        public void Test_DeadDummyThrowsAnExceptionIfAttacked() 
        {

            //Arrange

            Dummy dummy = new Dummy(0,10);
            Axe axe = new Axe(10, 10);

            //Assert
            Assert.That(() => dummy.TakeAttack(axe.AttackPoints), Throws
                                                                       .InvalidOperationException
                                                                       .With
                                                                       .Message
                                                                       .EqualTo("Dummy is dead."));
        }

        [Test]
        public void Test_DeadDummyCanGiveXP() 
        {
            //Arrange
            Dummy dummy = new Dummy(10, 10);
            Axe axe = new Axe(10,10);
            
            //Act

            dummy.TakeAttack(axe.AttackPoints);

            //Assert

            Assert.That(dummy.GiveExperience, Is.EqualTo(10));
        }

        [Test]
        public void Test_AliveDummyCannotGiveXP() 
        {
            //Arrange
            Dummy dummy = new Dummy(20, 20);
            Axe axe = new Axe(10, 10);

            //Act

            dummy.TakeAttack(axe.AttackPoints);

            //Assert

            Assert.That(dummy.GiveExperience,Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."));
        }
    }


}