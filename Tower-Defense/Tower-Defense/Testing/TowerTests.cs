using System;
using System.Collections.Generic;
using TowerDefense;
using NUnit.Framework;
 

namespace TowerDefense
{
    [TestFixture()]
    public class TowerTests
    {

        [Test()]
        public void testTowerInit()
        {
            Tower t = new Tower("t", 0, 0, 0, 0 );
            Assert.IsNotNull(t);
            
        }

        [Test()]
        public void testTowerGetsHealth()
        {
            Tower t = new Tower("t", 0, 0, 0, 0);
            t.Health = 10;
            Assert.AreEqual(t.Health,10);

        }

        [Test()]
        public void testTowerGetsRange()
        {
            Tower t = new Tower("t", 0, 0, 0, 0);
            t.Range = 10;
            Assert.AreEqual(t.Range, 10);

        }

        [Test()]
        public void testTowerGetsCost()
        {
            Tower t = new Tower("t", 0, 0, 0, 0);
            t.Cost = 10;
            Assert.AreEqual(t.Cost, 10);

        }

        [Test()]
        public void testTowerGetsAttackDamage()
        {
            Tower t = new Tower("t", 0, 0, 0, 0);
            t.AttackDamage = 10;
            Assert.AreEqual(t.AttackDamage, 10);

        }

        [Test()]
        public void testTowerGetsEnemy()
        {
            Tower t = new Tower("t", 0, 0, 0, 0);
            Enemy e = new Enemy(0, 0.0, "e", 0);
            t.AddNearbyEnemy(e);



        }   

    }
}
