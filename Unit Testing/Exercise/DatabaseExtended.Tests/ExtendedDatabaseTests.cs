namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using NUnit.Framework.Constraints;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.InteropServices;

    [TestFixture]
    public class ExtendedDatabaseTests
    {

        private Database _database;
        private const string ArrayMaxLenghtExceptionMessage = "Array's capacity must be exactly 16 integers!";
        private const string ExistingUsernameExceptionMessage = "There is already user with this username!";
        private const string ExistingIdExceptionMessage = "There is already user with this Id!";
        private const string NullUserParameter = "Username parameter is null!";
        private const string NoUserPresentException = "No user is present by this username!";
        private const string NegativeUserIdException = "Id should be a positive number!";
        private const string NonExistingUserIdException = "No user is present by this ID!";
        private const string OutOfRangeException = "Provided data length should be in range [0..16]!";


        [SetUp]
        public void Setup() 
        { 
          _database = new Database();
        }

        [TearDown]
        public void TearDown() 
        {
          _database = null;
        }

        [Test]
        public void Test_OutOfRangeDatabaseArrayThrowsException()
        {
            var data = CreateOutOfRangeArrayOfPersons();

            Assert.That(() => _database = new Database(data), Throws.ArgumentException
                                                                    .With
                                                                    .Message
                                                                    .EqualTo(OutOfRangeException));
        }

        [Test]  
        public void Test_AddPersonMethod() 
        {
            _database.Add(new Person(1, "Ivan"));
            Person result = _database.FindById(1);
            
            Assert.That(result.Id, Is.EqualTo(1));
            Assert.That(result.UserName, Is.EqualTo("Ivan"));
            Assert.That(_database.Count, Is.EqualTo(1));
        }

        [Test]
        public void Test_ThePersonsCollectionShouldContainExactlySixteenElements() 
        { 
           var persons = CreateFullArrayOfPersons();
            _database = new Database(persons);


            Assert.That(() => _database.Add(new Person(17, "Pesho")), 
                                            Throws.InvalidOperationException
                                                  .With
                                                  .Message
                                                  .EqualTo(ArrayMaxLenghtExceptionMessage));
        }

        [Test]
        public void Test_AddExistingUserThrowsException() 
        {
            _database.Add(new Person(1, "Pesho"));


            Assert.That(() => _database.Add(new Person(2, "Pesho")), 
                                            Throws.InvalidOperationException
                                                  .With
                                                  .Message
                                                  .EqualTo(ExistingUsernameExceptionMessage));
        }

        [Test]
        public void Test_AddExistingIdThrowsException()
        {
            _database.Add(new Person(1, "Pesho"));


            Assert.That(() => _database.Add(new Person(1, "Ivan")),
                                            Throws.InvalidOperationException
                                                  .With
                                                  .Message
                                                  .EqualTo(ExistingIdExceptionMessage));
        }

        [Test]  
        public void Test_RemoveMethodThrowsExceptionIfCountIsZero() 
        {

            Assert.That(() => _database.Remove(),
                              Throws
                              .InvalidOperationException);
        }

        [Test]
        public void Test_RemoveMethod() 
        { 
           _database = new Database(CreateFullArrayOfPersons());
            _database.Remove();
            int actual = _database.Count;
            int expected = 15;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Test_NullableInputThrowsException() 
        {
            string test = string.Empty;
            var exception = Assert.Throws<ArgumentNullException>(() =>
                                            _database.FindByUsername(test));

            Assert.That(exception.ParamName, Is.EqualTo(NullUserParameter));
        }

        [Test]
        public void Test_NoUserIsPresent() 
        {
            _database = new Database(CreateTestArrayOfPersons());

            Assert.That(() => _database.FindByUsername("Max"), 
                               Throws.InvalidOperationException
                               .With
                               .Message
                               .EqualTo(NoUserPresentException));
        
        }

        [Test]
        public void Test_FindByUsernameMethod() 
        {
            _database = new Database( CreateTestArrayOfPersons() );
            string testName = "Ivan";

            var result = _database.FindByUsername( testName );

            Assert.That(testName, Is.EqualTo(result.UserName));
        
        }

        [Test]
        public void Test_NegativeUserIdThrowsException() 
        {
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => _database.FindById(-1));
            Assert.That(exception.ParamName, Is.EqualTo(NegativeUserIdException));
        }

        [Test]
        public void Test_NotExistingPersonWithThisIdThrowsException() 
        { 
          _database = new Database( CreateTestArrayOfPersons() );

            Assert.That(() => _database.FindById(5), Throws.InvalidOperationException
                                                           .With
                                                           .Message
                                                           .EqualTo(NonExistingUserIdException));
        }
        
        [Test]
        public void Test_FindByIdMethod() 
        { 
           _database = new Database( CreateTestArrayOfPersons() );
            int id = 2;
            var result = _database.FindById(id);

            Assert.That(result.Id, Is.EqualTo(id));
        }

        private Person[] CreateFullArrayOfPersons() 
        {
            var persons = new Person[16];
            for (int i = 0; i < persons.Length; i++)
            {
                persons[i] = new Person(i, i.ToString());
            }

            return persons;
        }

        private Person[] CreateTestArrayOfPersons() 
         => new Person[] 
         { 
             new Person( 1, "Pesho"),
             new Person( 2, "Ivan" ),
             new Person( 3, "George")
         };

        private Person[] CreateOutOfRangeArrayOfPersons() 
        {
            var persons = new Person[17];

            for (int i = 0; i < persons.Length; i++) 
            {
                persons[i] = new Person(i, i.ToString());
            }  

            return persons;
        }


    }
}