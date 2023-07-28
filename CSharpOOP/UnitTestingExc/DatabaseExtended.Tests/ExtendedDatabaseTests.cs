namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;
    using System.Reflection.Metadata;

    [TestFixture]
    public class ExtendedDatabaseTests
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
        public void AddMethodTest()
        {
            database.Add(new Person(1, "Pesho"));
            Person result = database.FindById(1);
            Assert.AreEqual(1, database.Count);
            Assert.AreEqual(result.Id, 1);
            Assert.AreEqual(result.UserName, "Pesho");
        }

        [Test]
        public void ConstructorLengthTest()
        {
            Person[] people = new Person[17];
            for (int i = 0; i < 17; i++)
            {
                people[i] = new Person(i, $"{i}");
            }
            ArgumentException exc = Assert.Throws<ArgumentException>(
                () => database = new Database(people));
            Assert.That(exc.Message, Is.EqualTo("Provided data length should be in range [0..16]!"));
        }

        [Test]
        public void AddMethodIfTheGivedUsernameExist()
        {
            Person first = new(1, "Fon4o");
            Person second = new(2, "Fon4o");
            database.Add(first);

            InvalidOperationException exc = Assert.Throws<InvalidOperationException>(() => database.Add(second));
            Assert.That(exc.Message, Is.EqualTo("There is already user with this username!"));
        }
        [Test]
        public void AddMethodTheGivenIdExists()
        {
            Person first = new(1, "Fon4o");
            Person second = new(1, "Ger4o");
            database.Add(first);

            InvalidOperationException exc = Assert.Throws<InvalidOperationException>(() => database.Add(second));
            Assert.That(exc.Message, Is.EqualTo("There is already user with this Id!"));
        }

        [Test]
        public void DatabaseCount()
        {
            Person first = new(1, "Fon4o");
            Person second = new(2, "Dimitri");
            database.Add(first);
            database.Add(second);
            Assert.AreEqual(database.Count, 2);
        }

        [Test]
        public void DatabaseLengthTest()
        {
            for (int i = 0; i < 16; i++)
            {
                database.Add(new Person(i, $"{i}"));
            }

            InvalidOperationException exc = Assert.Throws<InvalidOperationException>(() => database.Add(new Person(17, "17")));
            Assert.That(exc.Message, Is.EqualTo("Array's capacity must be exactly 16 integers!"));
        }

        [Test]
        public void RemoveTest()
        {
            database.Add(new Person(1, "Gercho"));
            database.Remove();
            Assert.AreEqual(0, database.Count);
        }

        [Test]
        public void RemoveFromEmptyDatabase()
        {
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void FindByUsername()
        {
            database.Add(new Person(1, "Gercho"));
            Person result = database.FindByUsername("Gercho");
            Assert.AreEqual(result.UserName, "Gercho");
            Assert.AreEqual(result.Id, 1);
        }

        [Test]
        public void FindByUsernameNullOrEmptyEsception()
        {

            ArgumentNullException nullExc = Assert.Throws<ArgumentNullException>(() => database.FindByUsername(null));
            Assert.That(nullExc.ParamName, Is.EqualTo("Username parameter is null!"));

            ArgumentNullException emptyExc = Assert.Throws<ArgumentNullException>(() => database.FindByUsername(string.Empty));
            Assert.That(nullExc.ParamName, Is.EqualTo("Username parameter is null!"));

        }

        [Test]
        public void FindUsernameNotFound()
        {
            database.Add(new Person(1, "Pesho"));

            InvalidOperationException exc = Assert.Throws<InvalidOperationException>(() => database.FindByUsername("Mriko"));
            Assert.That(exc.Message, Is.EqualTo("No user is present by this username!"));
        }

        [Test]
        public void FindByIdNegativeIdException()
        {
            database.Add(new Person(1, "Gogo"));
            long id = -1;
            ArgumentOutOfRangeException exc = Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(id));
            Assert.That(exc.ParamName, Is.EqualTo("Id should be a positive number!"));

        }

        [Test]
        public void FindByIdNotFoundException()
        {
            database.Add(new Person(1, "Gogo"));
            InvalidOperationException exc = Assert.Throws<InvalidOperationException>(() => database.FindById(2));
            Assert.That(exc.Message, Is.EqualTo("No user is present by this ID!"));
        }

        [Test]
        public void FindByIdReturnsCorrectPerson()
        {
            database.Add(new Person(1, "Moncho"));
            Person result = database.FindByUsername("Moncho");

            Assert.AreEqual(result.UserName, "Moncho");
        }
    }
}