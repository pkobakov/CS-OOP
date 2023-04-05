using System;
using System.Runtime.CompilerServices;
using NUnit.Framework;
using NUnit.Framework.Constraints;

public class HeroRepositoryTests
{
    Hero hero;
    HeroRepository heroRepository;
    
    [SetUp]
    public void SetUp()
    {
        hero = new Hero("Pesho", 4);
        heroRepository = new HeroRepository();
    }

    [Test]
    public void ConstructorTest()
    {
        Assert.AreEqual(heroRepository.Heroes.Count, 0);
    }

    [Test]
    public void CreateHeroExceptionTest()
    {
        Assert.That(() => heroRepository.Create(null), 
            Throws.ArgumentNullException);

        heroRepository.Create(hero);
        Assert.That(() => heroRepository.Create(hero),
            Throws.InvalidOperationException.With.Message.EqualTo($"Hero with name {hero.Name} already exists"));
    }
    [Test]
    public void CreateHeroTest()
    {
        string actual = heroRepository.Create(hero);
        Assert.AreEqual(heroRepository.Heroes.Count, 1);
        Assert.That(actual, Is.EqualTo($"Successfully added hero {hero.Name} with level {hero.Level}"));
       
    }

    [Test]
    public void RemoveExceptionTest()
    {
        Assert.That(() => heroRepository.Remove(null), Throws.ArgumentNullException);
    }

    [Test]
    public void RemoveMethodTest()
    {
        heroRepository.Create(hero);
        bool isRemoved = heroRepository.Remove("Pesho");
        Assert.AreEqual(isRemoved , true);
        Assert.AreEqual(heroRepository.Heroes.Count, 0);
    }

    [Test]
    public void Test()
    {
        Hero testHero = new Hero("Gosho", 8);
        heroRepository.Create(hero);
        heroRepository.Create(testHero);

        Hero result = heroRepository.GetHeroWithHighestLevel();

        Assert.AreEqual(testHero, result);
    }

    [TestCase("Pesho")]
    public void GetHeroTest(string name)
    {
        heroRepository.Create(hero);
        Hero testHero = heroRepository.GetHero(name);
        Assert.AreEqual(hero, testHero);    
    }


}