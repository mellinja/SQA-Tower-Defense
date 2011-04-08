using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SQA_Tower_Defense;

namespace ClassTests
{
    [TestFixture()]
    public class MapTests
    {

        #region Initialization
        [Test()]
        public void MapInitializes()
        {
            Map map = new Map("", 0, 1);
            Assert.IsNotNull(map);

        }


        #endregion

        #region Difficulty Stuff

        [Test()]
        public void MapHasCorrectScoreOnEasy()
        {
            Map map = new Map("", 1, 1);
            Assert.AreEqual(100, map.Score);

        }

        [Test()]
        public void MapHasCorrectMoneyBasedOnDifficulty()
        {
            Map map = new Map("", 0, 1);

        }

        #endregion

        #region Money

        [Test()]
        public void MoneyIncreasesWhenEnemyIsKilled()
        {

        }

        [Test()]
        public void MoneyIncreasesWhenTowerIsSold()
        {

        }


        #endregion

        #region Towers

        [Test()]
        public void TowersCannotBePlacedInOccupiedLocation()
        {

        }

        [Test()]
        public void TowersGetAddedToListWhenPlaced()
        {

        }

        [Test()]
        public void TowersGetRemovedToListWhenSold()
        {

        }

        #endregion

        #region Enemies

        [Test()]
        public void EnemiesGetAddedToListWhenSpawned()
        {

        }

        [Test()]
        public void EnemiesGetRemovedFromListWhenKilled()
        {

        }

        #endregion 




    }
}
