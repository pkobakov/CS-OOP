namespace Database.Tests
{
    using NUnit.Framework;
    using System.Data;
    using System.Runtime.CompilerServices;

    [TestFixture]
    public class DatabaseTests
    {
        private Database _database; 

        [SetUp]
        public void Setup() 
        {
            _database = new Database(); 
        }

        [TearDown]
        public void Teardown() 
        { 
           _database = null;
        }

        [Test]
        public void Test_AddMethod() 
        {
            //Arrange

            int element = 5 ;
            // Act

            _database.Add(element);
            int[] result = _database.Fetch();   
            

            //Assert

            Assert.AreEqual(1, _database.Count);
            Assert.AreEqual(element, result[0]);
            Assert.AreEqual(1, result.Length);
        }

        [Test]
        public void Test_DataShouldHaveExactlySixteenElements() 
        {
            Database database = new Database(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 } );

            int actual = database.Count;
            int expected = 16;

            Assert.That(actual, Is.EqualTo(expected));

            
        }

        [Test]
        public void Test_AddSeventeenElementToTheArrayThrowsException() 
        {
            //Arrange
            int[] data = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            Database database = new Database(data);

            //Assert

            Assert.That(() => database.Add(17), Throws.InvalidOperationException
                                              .With
                                              .Message
                                              .EqualTo("Array's capacity must be exactly 16 integers!"));

        }

        [Test]
        public void Test_RemoveFromEmptyDatabase() 
        {
            Assert.That(() => _database.Remove(), Throws.InvalidOperationException
                                                        .With
                                                        .Message
                                                        .EqualTo("The collection is empty!"));
        }

        [Test]
        public void Test_RemoveFromDatabase() 
        { 
           int[] data = new int[] { 5, 15  };
           _database = new Database(data);
           _database.Remove();
           int [] resultArray = _database.Fetch();
           int actual = resultArray[resultArray.Length-1];
           int expected = 5;

            Assert.That(1, Is.EqualTo(_database.Count));
            Assert.That(_database.Count, Is.EqualTo(resultArray.Length)); 
            Assert.That(actual, Is.EqualTo(expected));  
        }

        [Test]
        public void Test_FetchMethod() 
        { 
          _database = new Database(1,2,3);
          var result = _database.Fetch();

            Assert.That(new int[] { 1, 2, 3 }, Is.EquivalentTo(result));
            
        }

    }
}
