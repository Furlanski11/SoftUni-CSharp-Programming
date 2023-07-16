using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void DummyLoosingHealth()
        {
            Dummy dummy = new(10, 10);

            dummy.TakeAttack(1);

            Assert.That(dummy.Health, Is.EqualTo(9), "Dummy does not loose health!");
        }

        [Test]
        public void DeadDummyAttackedException()
        {
            Dummy dummy = new(0, 10);

            Assert.Throws<InvalidOperationException>(
                () => dummy.TakeAttack(1)
              );

        }

        [Test]
        public void DoesDeadDummyGiveExp()
        {
            Dummy dummy = new(0, 10);

            int exp = dummy.GiveExperience();

            Assert.AreEqual(10, exp);

        }

        [Test]
        public void DoesAliveDummyGiveExp()
        {
            Dummy dummy = new(10, 10);

            Assert.Catch<InvalidOperationException>(() => dummy.GiveExperience());

        }
    }
}