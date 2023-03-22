namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System.Net.Http.Headers;

    [TestFixture]
    public class WarriorTests
    {
        private Warrior warrior;
        private int MIN_ATTACK_HP = 30;

        [SetUp]
        public void Setup() 
        { 
          warrior = new Warrior("Max", 12, 20);
        }

        [TearDown]
        public void TearDown() 
        { 
          warrior = null;
        }

        [Test]
        public void WarriorNameSetTest() 
        {
            string expected = "Max";
            string actual = warrior.Name;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(null)]
        [TestCase(" ")]
        [TestCase("")]
        public void WarriorNameValidationTest( string name ) 
        { 
           Assert.That(() => warrior  = new Warrior(name, 12, 20), Throws.ArgumentException
                                                                         .With
                                                                         .Message
                                                                         .EqualTo("Name should not be empty or whitespace!"));
        }

        [Test]
        public void WarriorSetDamageTest() 
        {
            int expected = 12;
            int actual = warrior.Damage;

            Assert.That (actual, Is.EqualTo(expected)); 
        }

        [TestCase(-1)]
        [TestCase(0)]
        public void WarriorDamageValidationTest(int damage) 
        {
            Assert.That(() => warrior = new Warrior("Max", damage, 12), Throws.ArgumentException
                                                                              .With
                                                                              .Message
                                                                              .EqualTo("Damage value should be positive!"));
        }

        [Test]
        public void WarriorSetHPTest() 
        {
            int expected = 20;
            int actual = warrior.HP;

            Assert.That(actual, Is.EqualTo(expected));    
        }

        [TestCase(-1)]
        public void HPValidationTest(int hp) 
        {
            Assert.That(() => warrior = new Warrior("Attacker", 50, hp), Throws.ArgumentException
                                                                               .With
                                                                               .Message
                                                                               .EqualTo("HP should not be negative!"));
        }

        [TestCase(20)]
        [TestCase(30)]
        public void AttackMethodHPExceptionTest(int warriorHP) 
        {
            Assert.That(() => warrior.Attack(new Warrior("Pit", 24, 50)), Throws.InvalidOperationException
                                                                                .With
                                                                                .Message
                                                                                .EqualTo("Your HP is too low in order to attack other warriors!"));
            warrior = new Warrior("Max", 24, 70);

            Assert.That(() => warrior.Attack(new Warrior("Pit", 24, warriorHP)), Throws.InvalidOperationException
                                                                                       .With
                                                                                       .Message
                                                                                       .EqualTo($"Enemy HP must be greater than {MIN_ATTACK_HP} in order to attack him!"));

            Assert.That(() => warrior.Attack(new Warrior("Pit", 80, 50)), Throws.InvalidOperationException
                                                                                 .With
                                                                                 .Message
                                                                                 .EqualTo("You are trying to attack too strong enemy"));
        }

        [Test]
        public void AttackMethodDecreaseHPTest() 
        {
            warrior = new Warrior("Max", 50, 50);
            var warriorParameter = new Warrior("Pit", 30, 40);

            int expected = 20;
            warrior.Attack(warriorParameter);

            Assert.That(() => warrior.HP, Is.EqualTo(expected));
            Assert.That(warriorParameter.HP, Is.EqualTo(0));
        }

        [TestCase]
        public void AttackMethodDamageSetTest() 
        {
            warrior = new Warrior("Max", 30, 50); 
            var warriorParameter = new Warrior("Pit", 30, 40);

            warrior.Attack(warriorParameter);

            int expeted = 10;

            Assert.That(warriorParameter.HP, Is.EqualTo(expeted));
        }
    }
}