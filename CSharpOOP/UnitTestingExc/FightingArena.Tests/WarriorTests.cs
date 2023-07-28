namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Xml.Linq;

    [TestFixture]
    public class WarriorTests
    {
        private Warrior warrior;
        private const int MIN_ATTACK_HP = 30;

        [SetUp]
        public void SetUp()
        {
            warrior = new Warrior("Konan", 10, 50);
        }

        [TearDown]
        public void TearDown()
        {
            warrior = null;
        }

        [Test]
        public void ConstructorTest()
        {
            Assert.AreEqual(warrior.Name, "Konan");
            Assert.AreEqual(warrior.HP, 50);
            Assert.AreEqual(warrior.Damage, 10);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void EmptyNameException(string name)
        {
            ArgumentException exc = Assert.Throws<ArgumentException>(() => warrior = new Warrior(name, 10, 5));
            Assert.AreEqual(exc.Message, "Name should not be empty or whitespace!");
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void NegativeDamageException(int damage)
        {
            ArgumentException exc = Assert.Throws<ArgumentException>(() => warrior = new Warrior("Konan", damage, 5));
            Assert.AreEqual(exc.Message, "Damage value should be positive!");
        }

        [Test]
        [TestCase(-1)]
        public void NegativeHealthException(int health)
        {
            ArgumentException exc = Assert.Throws<ArgumentException>(() => warrior = new Warrior("Konan", 10, health));
            Assert.AreEqual(exc.Message, "HP should not be negative!");
        }

        [Test]
        public void TooLowHpToAttackEnemy()
        {
            Warrior enemy = new("Enemy", 10, 50);
            warrior = new("Konan", 50, 15);
            InvalidOperationException exc = Assert.Throws<InvalidOperationException>(() => warrior.Attack(enemy));
            Assert.That(exc.Message, Is.EqualTo("Your HP is too low in order to attack other warriors!"));

        }
        [Test]
        public void EnemeyHpMustBeGreaterThanMinDmgToAttackHim()
        {
            Warrior enemy = new("Enemy", 10, 20);
            InvalidOperationException exc = Assert.Throws<InvalidOperationException>(() => warrior.Attack(enemy));
            Assert.That(exc.Message, Is.EqualTo($"Enemy HP must be greater than {MIN_ATTACK_HP} in order to attack him!"));
        }

        [Test]
        public void TryingToAttackEnemyWithLessHelathThanHisDmg()
        {
            Warrior enemy = new("Enemy", 100, 50);
            warrior = new("Konan", 50, 50);
            InvalidOperationException exc = Assert.Throws<InvalidOperationException>(() => warrior.Attack(enemy));
            Assert.That(exc.Message, Is.EqualTo($"You are trying to attack too strong enemy"));
        }

        [Test]
        public void KillSucceed()
        {
            Warrior enemy = new("Enemy", 49, 50);
            warrior = new("Konan", 51, 50);
            warrior.Attack(enemy);
            Assert.AreEqual(0, enemy.HP);
        }

        [Test]
        public void AttackSucceed()
        {
            Warrior enemy = new("Enemy", 49, 50);
            warrior = new("Konan", 49, 50);
            warrior.Attack(enemy);
            Assert.AreEqual(1, enemy.HP);
        }
    }
}