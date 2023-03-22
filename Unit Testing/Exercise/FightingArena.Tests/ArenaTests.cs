namespace FightingArena.Tests
{
    using Microsoft.VisualBasic;
    using NUnit.Framework;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    [TestFixture]
    public class ArenaTests
    {
        Arena arena;
        Warrior attacker;
        Warrior defender;
        

        [SetUp]
        public void SetUp() 
        {
          arena = new Arena();
          attacker = new Warrior("Attacker", 50, 50);
          defender = new Warrior("Defender", 50, 50);
          
        }
        [TearDown]
        public void TearDown() 
        {  
            arena = null;
        }

        [Test]
        public void SetWarriorsTest() 
        { 
            int actual = arena.Warriors.Count;
            int expected = 0;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void WarriorsCountTest()
        {
            arena.Enroll(attacker);

            int actual = arena.Warriors.Count;
            int expected = 1;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void EnrollMethodValidationtionTest() 
        {
            arena.Enroll(defender);
            Assert.That(() => arena.Enroll(defender), Throws.InvalidOperationException
                                                            .With
                                                            .Message
                                                            .EqualTo("Warrior is already enrolled for the fights!"));
        }

        [Test]
        public void FightMethodTest() 
        {
            string attackerName = "Attacker";
            string defenderName = "Defender";
            arena.Enroll(attacker);
            arena.Enroll(defender);    
            arena.Fight(attackerName, defenderName);

            int actual = attacker.HP;
            int expected = 0;

            Assert.AreEqual(actual, expected);

        }

        [Test]
        public void AttackerNameFightMethodTest() 
        {
            arena.Enroll(attacker);
            arena.Enroll(defender);

            string attackerName = "Ivan";
            string defenderName = "Pesho";
           
            Assert.That(() => arena.Fight(attackerName, defenderName), Throws.InvalidOperationException
                                                                  .With
                                                                  .Message
                                                                  .EqualTo($"There is no fighter with name {defenderName} enrolled for the fights!"));
        } 

    }
}
