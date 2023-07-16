using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void AxeLosingDurabilityPointsAfterHit()
        {
            Axe axe = new(10, 10);
            Dummy dummy = new(10, 10);

            axe.Attack(dummy);

            Assert.That(axe.DurabilityPoints, Is.EqualTo(9), "Axe Durability doesn't change after attack.");
        }

        [Test]
        public void AttackingWithBrokenWeapon()
        {
            Axe axe = new(10, 0);
            Dummy dummy = new(10, 10);

            Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));
        }
    }
}