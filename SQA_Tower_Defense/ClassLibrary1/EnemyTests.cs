using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SQA_Tower_Defense;
using Microsoft.Xna.Framework;

namespace ClassTests
{  
    [TestFixture()]
    public class EnemyTests
    {
        private Map map;
        private Rectangle rec;
        private Tower tower;
        private Enemy enemy;

        [SetUp()]
        public void SetUp()
        {
            map = new Map("", 0, 0);
            rec = new Rectangle(0, 0, 5, 5);
            tower = new Tower("", 10, 20, 30, 40, rec);
            enemy = new Enemy(10, 1.0f, "", 20, rec);
        }
        #region Initialization

        [Test()]
        public void EnemyInitializesSuccessfully()
        {
            enemy = new Enemy(10, 1.0f, "", 20, rec);
            Assert.IsNotNull(enemy);
        }


        #endregion

        #region Testing Health

        [Test()]
        public void EnemyHasCorrectHealthAfterInitialized()
        {
            enemy = new Enemy(10, 1.0f, "",20, rec);
            Assert.AreEqual(enemy.Health, 10);

        }

        [Test()]
        public void EnemyHasCorrectHealthAfterDamaged()
        {
            enemy = new Enemy(10, 1.0f, "", 20, rec);
            enemy.Health -= 1;
            Assert.AreEqual(enemy.Health, 9);
        }


        #endregion 

        #region Testing Speed

        [Test()]
        public void EnemyHasCorrectSpeedAfterInitialized()
        {
            enemy = new Enemy(10, 1.0f, "", 20, rec);
            Assert.AreEqual(enemy.Speed, 1.0f);
        }

        [Test()]
        public void EnemyHasCorrectSpeedAfterModified()
        {
            enemy = new Enemy(10, 1.0f, "", 20, rec);
            enemy.Speed *= 0.95f;
            Assert.AreEqual(enemy.Speed, 0.95f);
        }

        #endregion

        #region Testing Type

        [Test()]
        public void EnemyHasCorrectTypeAfterModified()
        {
            enemy = new Enemy(10, 1.0f, "Blah", 20, rec);
            Assert.AreEqual(enemy.Type, "Blah");
        }

        #endregion

        #region Testing Gold

        [Test()]
        public void EnemyHasCorrectGoldAfterInitialized()
        {
            enemy = new Enemy(10, 1.0f, "", 20, rec);
            Assert.AreEqual(enemy.Gold, 20);
        }


        #endregion


    }
}
