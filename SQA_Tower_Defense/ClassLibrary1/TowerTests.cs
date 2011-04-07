using System;
using System.Collections.Generic;
using SQA_Tower_Defense;
using NUnit.Framework;


namespace ClassLibrary1
{
    [TestFixture()]
    public class TowerTests
    {

        [Test()]
        public void testTowerInit()
        {
            Tower t = new Tower(null, null, null, null, null, null);
            Assert.IsNotNull(t);
        }

        [Test()]
        public void testTowerGetsHealth()
        {
            Tower t = new Tower();
            t.setHealth = 10;
            Assert.AreEqual(t.Health,10);

        }

        [Test()]
        public void testTowerGetsRange()
        {
            Tower t = new Tower();
            t.setRange = 10;
            Assert.AreEqual(t.Range, 10);

        }

        [Test()]
        public void testTowerGetsCost()
        {
            Tower t = new Tower();
            t.setCost = 10;
            Assert.AreEqual(t.Cost, 10);

        }

        [Test()]
        public void testTowerGetsAttackDamage()
        {
            Tower t = new Tower();
            t.setAttackDamage = 10;
            Assert.AreEqual(t.AttackDamage, 10);

        }

        [Test()]
        public void testTowerGetsEnemy()
            Tower t = new Tower();
            

    }
}
