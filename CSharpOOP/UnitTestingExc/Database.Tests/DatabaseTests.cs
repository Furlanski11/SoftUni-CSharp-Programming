namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        private Database database;
        [SetUp]
        public void SetUp()
        {
             database = new Database();
        }
        [TearDown]
        public void TearDown()
        {
            database = null;
        }

        [Test]
        public void CanAddElements()
        {
            database.Add(5);
            int[] result = database.Fetch();
            Assert.AreEqual(1, database.Count);
            Assert.AreEqual(5, result[0]);
            Assert.AreEqual(1, result.Length);
            
        }
        [Test]
        public void ConstrctorTest()
        {
            int[] array = new int[16] {1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16};
            
            database = new Database(array);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(
                ()=> database.Add(17));
            Assert.That(exception.Message, Is.EqualTo("Array's capacity must be exactly 16 integers!"));
        }
        [Test]
        public void CanRemoveElements()
        {
            database.Add(1);
            database.Add(2);
            database.Remove();
            int[] array = database.Fetch();
            Assert.AreEqual(1, database.Count);
            Assert.That(array[0], Is.EqualTo(1));
        }
        [Test]
        public void RemovingElementsFromEmptyDatabaseException()
        {
            InvalidOperationException exc = Assert.Throws<InvalidOperationException>
                (() => database.Remove());
            Assert.That(exc.Message, Is.EqualTo("The collection is empty!"));
        }
        [Test]
        public void FecthTest()
        {
            database.Add(1);
            database.Add(2);
            int[] array = database.Fetch();
            Assert.AreEqual(2, array.Length);
            Assert.AreEqual(array[0], 1);
            Assert.AreEqual(array[1], 2);
        }

    }
}
