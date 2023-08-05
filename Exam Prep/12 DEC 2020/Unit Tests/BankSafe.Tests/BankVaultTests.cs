using NUnit.Framework;
using System;
using System.Linq;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        BankVault bankVault;
        Item item;
        [SetUp]
        public void Setup()
        {
            bankVault = new BankVault();
            item = new Item("Pesho", "1");

        }

        [TearDown]
        public void TearDown() 
        { 
           bankVault = null;
        }

        [Test]
        public void TestBankVaultConstuctor()
        {
            int actual = bankVault.VaultCells.Count;
            Assert.AreEqual(12, actual);
        }

        [Test]
        public void TestAddItemMethodExceptions() 
        {
             
            Assert.That(() => bankVault.AddItem("A20", null), 
                              Throws.ArgumentException
                              .With.Message
                              .EqualTo("Cell doesn't exists!"));

            

            bankVault.AddItem("A4", item);

            Assert.That(() => bankVault.AddItem("A4", item),
                              Throws.ArgumentException
                              .With.Message
                              .EqualTo("Cell is already taken!"));

            
            Assert.That(() => bankVault.AddItem("A1", item), Throws.InvalidOperationException);

            
        }

        [Test]
        public void TestAddItemMethod() 
        {
            Assert.That( () => bankVault.AddItem("A3", item), Is.EqualTo($"Item:{item.ItemId} saved successfully!"));
            Assert.That(bankVault.VaultCells["A3"], Is.EqualTo(item));
        }

        [Test]
        public void TestRemoveItemMethodExceptions() 
        {
            Assert.That(() => bankVault.RemoveItem("A5", item), Throws.ArgumentException
                                                                .With.Message
                                                                .EqualTo("Cell doesn't exists!"));
            bankVault.AddItem("A3", item);

            var testItem = new Item("Gosho", "3");

            Assert.That(() => bankVault.RemoveItem("A3", testItem), Throws.ArgumentException.
                                                                    With.Message
                                                                    .EqualTo($"Item in that cell doesn't exists!"));
        }

        [Test]
        public void TestRemoveItemMethod() 
        {
            bankVault.AddItem("A1", item);
            Assert.That(() => bankVault.RemoveItem("A1", item), Is.EqualTo($"Remove item:{item.ItemId} successfully!"));
            Assert.That(bankVault.VaultCells["A1"], Is.EqualTo(null));
        }

    }
}