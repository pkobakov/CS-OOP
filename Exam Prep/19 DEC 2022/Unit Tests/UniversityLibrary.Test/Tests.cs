namespace UniversityLibrary.Test
{
    using Microsoft.VisualBasic;
    using NUnit.Framework;
    using System.Linq;
    using System.Security;

    public class Tests
    {
        TextBook book;
        UniversityLibrary library;

        [SetUp]
        public void Setup()
        { 
            book = new TextBook("Pod igoto", "Ivan Vazov","Novel");
            library = new UniversityLibrary();
        }

        [TearDown]
        public void Teardown() 
        { 
            library = null;
        }

        [Test]
        public void TestLibraryContructor()
        {
            Assert.That(library.Catalogue.Count, Is.EqualTo(0));
        }

        [Test]
        public void TestAddBookToLibraryMethod() 
        {
            string actual = library.AddTextBookToLibrary(book);
            
            string expected = book.ToString();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestLoanTextBookMethod () 
        {
            string studentName = "Pesho";
            library.AddTextBookToLibrary(book);
            
            var testBook = library.Catalogue.FirstOrDefault( b => b.InventoryNumber == 1 );
            testBook.Holder = studentName;
            string result = library.LoanTextBook(1, studentName);
            Assert.That(result, Is.EqualTo($"{studentName} still hasn't returned {book.Title}!"));

            testBook.Holder = string.Empty;
            Assert.That(() => library.LoanTextBook(1, studentName), Is.EqualTo($"{book.Title} loaned to {studentName}."));
            Assert.That(testBook.Holder, Is.EqualTo(studentName));
        }

        [Test]
        public void TestReturnTextBook() 
        {
            library.AddTextBookToLibrary(book);
            var testBook = library.Catalogue.FirstOrDefault( b => b.InventoryNumber == 1);
           
            
            Assert.That(() => library.ReturnTextBook(1), Is.EqualTo($"{testBook.Title} is returned to the library."));
            Assert.That(testBook.Holder, Is.EqualTo(string.Empty));
        }
    }
}