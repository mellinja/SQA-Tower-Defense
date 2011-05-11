using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SQA_Tower_Defense;
using Microsoft.Xna.Framework;

namespace ClassTests
{
    [Ignore()]
    [TestFixture()]
    class EnemyMovementTestsWithCastle
    {
        /*
        Map map;
        Rectangle rec;
        Tower tower;
        Enemy enemy;
        [SetUp()]
        public void SetUp()
        {

            map = new Map("normal", 100000, 1);
            rec = new Rectangle(0, 0, 5, 5);
            tower = new Tower("basic", 10, 20, 30, 40, new Rectangle(6, 5, 1, 1));
            enemy = new Enemy(10, 1.0f, "basic", 20, new Rectangle(rec.X + 5, rec.Y + 5, rec.Width, rec.Height));
        }


        //enemies follow up-dowm movement first, then left-right
        [Test()]
        public void TestEnemiesMoveToCastleUpDown()
        {
            Map.addCastle(new Castle(100,new Rectangle(100,100,1,1)));
            map.SpawnEnemy(enemy);
            map.Update();
            Assert.AreEqual(map.enemiesOnMap[0].Location, new Rectangle(6, 5, rec.Width, rec.Height));
        }


        //enemies is in line with Castle, enemy moves left/right
        [Test()]
        public void TestEnemiesMoveToCastleLeftRight()
        {
            Map.addCastle(new Castle(100, new Rectangle(5, 100, 1, 1)));
            map.SpawnEnemy(enemy);
            map.Update();
            Assert.AreEqual(map.enemiesOnMap[0].Location, new Rectangle(5, 6, rec.Width, rec.Height));
        }

        //Tower in enemy path causes it to move left or right
        [Test()]
        public void TestEnemiesMoveToCastleLeftRightWhenPathBlocked()
        {
            Map.addCastle(new Castle(100, new Rectangle(100, 100, 1, 1)));
            map.SpawnEnemy(enemy);
            map.PlaceTower(tower);
            map.Update();
            Assert.AreEqual(map.enemiesOnMap[0].Location, new Rectangle(5, 6, rec.Width, rec.Height));
        }

        //Tower in enemy path causes it to move up if on same level as castle (-x-direction)
        [Test()]
        public void TestEnemiesMoveToCastleUpWhenPathBlocked()
        {
            Map.addCastle(new Castle(100, new Rectangle(1, 100, 1, 1)));
            map.SpawnEnemy(enemy);
            tower.Location = new Rectangle(5, 6, 1, 1);
            map.PlaceTower(tower);
            map.Update();
            Assert.AreEqual(map.enemiesOnMap[0].Location, new Rectangle(4, 5, rec.Width, rec.Height));
        }
        //Tower in enemy path causes it to move down if on same level as castle and up is blocked (x-direction)
        [Test()]
        public void TestEnemiesMoveToCastleDownWhenPathBlocked()
        {
            Map.addCastle(new Castle(100, new Rectangle(1, 100, 1, 1)));
            map.SpawnEnemy(enemy);
            tower.Location = new Rectangle(5, 6, 1, 1);
            map.PlaceTower(tower);
            map.PlaceTower(new Tower("",1,1,1,1,new Rectangle(4,5,1,1);
            map.Update();
            Assert.AreEqual(map.enemiesOnMap[0].Location, new Rectangle(6, 5, rec.Width, rec.Height));
        }


        //Test that enemies that are surrounded don't move
        [Test()]
        public void TestSurroundedEnemiesDontMove()
        {
            map.SpawnEnemy(enemy);
            map.PlaceTower(new Tower("",1,1,1,1,new Rectangle(enemy.Location.X+1,enemy.Location.Y+1,1,1)));
            map.PlaceTower(new Tower("",1,1,1,1,new Rectangle(enemy.Location.X-1,enemy.Location.Y+1,1,1)));
            map.PlaceTower(new Tower("",1,1,1,1,new Rectangle(enemy.Location.X+1,enemy.Location.Y-1,1,1)));
            map.PlaceTower(new Tower("",1,1,1,1,new Rectangle(enemy.Location.X-1,enemy.Location.Y-1,1,1)));
            map.Update();
            Assert.AreEqual(enemy.Location, new Rectangle(5, 5, 5, 5));
        }

            

        //Test That enemies stop when next to castle
        [Test()]
        public void TestEnemiesStopWhenNextToCastle()
        {
            Map.addCastle(new Castle(100, new Rectangle(1, 100, 1, 1)));
            map.SpawnEnemy(new Enemy(1, 1, "basic", 1, new Rectangle(1, 99, 1, 1)));
            map.Update();
            Assert.AreEqual(map.enemiesOnMap[0].Location, new Rectangle(1, 99, 1, 1));
        }
        */


    }
}
