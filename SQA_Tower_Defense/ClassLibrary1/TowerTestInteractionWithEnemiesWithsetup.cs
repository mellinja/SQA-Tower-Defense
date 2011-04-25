using System;
using System.Collections.Generic;
using SQA_Tower_Defense;
using NUnit.Framework;
using Microsoft.Xna.Framework;


namespace ClassTests
{
    class TowerTestInteractionWithEnemiesWithsetup
    {

        [Setup()]
        public void SetUp()
        {
            Rectangle towerRange = 5;
            Rectangle towerPosition = new Rectangle(0, 50, 50, 50);
            Rectangle enemyPosition = new Rectangle(0, 0, 25, 25);

            Enemy enemy = new Enemy(10, 1.0f, "Enemy", 10, enemyPosition);
            Tower tower = new Tower("Tower", 1, 1, 1, towerRange, towerPosition);
            Map map = new Map("Gametype", 100, 0);
            map.addTower(tower);
            map.addEnemy(enemy);

        }
        //Verifies that a tower does not attack an enemy outside of its range by checking the health of the enemy
        [Test()]
        public void TowerDoesNotAttackEnemyOutsideItsRange()
        {
            //Move the enemy outside of the tower's range
            enemy.Location = new Rectangle(101, 101, 25, 25);


            //Update method for map causes the towers to add nearby enemies
            map.Update();
            //Update method causes the tower to attack nearest enemy in its range
            tower.Update();

            //Verify that the enemy was not damaged
            Assert.AreEqual(10, enemy.Health);

        }


        //Verifies that a tower will attack an enemy within its range by checking the health of the enemy
        [Test()]
        public void TowerAttacksAnEnemyInItsRange()
        {

            map.Update(); //Update method for map causes the towers to add nearby enemies

            tower.Update(); //Enemy is already within tower's range rectangle; tower's update should attack it

            Assert.AreEqual(9, enemy.Health); //Verify that the enemy has taken one point of damage


        }


        //Verifies that a tower attacking an enemy will stop attacking said enemy once it is out of range
        [Test()]
        public void TowerStopsAttackingEnemyOneItMovesOutsideOfRange()
        {


            map.Update(); //Update method for map causes the towers to add nearby enemies

            tower.Update(); //Enemy is already within tower's range rectangle; tower's update should attack it

            Assert.AreEqual(9, enemy.Health); //Verify that the enemy has taken one point of damage

            enemy.Location = new Rectangle(101, 101, 25, 25); //Move the enemy outside of the tower's range

            for (int i = 0; i < 60; i++)
                tower.Update(); //The tower attacks once every 60 updates -- so force 60 updates on the tower for it to attack again.

            Assert.AreEqual(9, enemy.Health); //Verify that the enemy has not received additional damage

        }

        //Tests that an enemy being attacked by multiple towers is removed from both tower's list of enemies when killed.
        [Test()]
        public void EnemyThatDiesWithinRangeOfTwoTowersGetsRemovedFromBothTowerLists()
        {
            Tower tower2 = new Tower("Tower2", 10, 1, 10, 5, new Rectangle(50, 0, 50, 50)); //Second tower; enemy should still be within its range

            map.addTower(tower2);


            enemy.Health = 2; //Manually set the enemy's health to 2 for the case of this test

            map.Update(); //Update method for map cases both of the towers to add nearby enemies

            Assert.AreEqual(tower.Enemies.Count, 1); //Verify that the first tower's list of enemies has one enemy
            Assert.AreEqual(tower2.Enemies.Count, 1); //Verify that the second tower's list of enemies has one enemy

            tower.Update(); //Update the first tower to attack the enemy
            tower2.Update(); //Update the second tower to attack (and thereby killing) the enemy

            map.Update(); //Update method for map causes both of the towers to update their list of nearby enemies

            Assert.AreEqual(tower.Enemies.Count, 0); //Verify that the first tower's list of enemies is empty
            Assert.AreEqual(tower2.Enemies.Count, 0); //Verify that the second tower's list of enemies is empty

        }



        [Test()]
        public void EnemyMoveOutofRange()
        {
           //enemy can move out of range 
           Enemy enemy2 = new Enemy (10, 1.0f, "basic",10 ,new Rectangle (34,34,54,54)
           tower.AddNearbyEnemy(enemy);
           tower.AddNearbyEnemy(enemy2);
            tower.AttackEnemy(); 
            Assert.AreNotEqual(enemy.Health, 10); 
           Assert.AreEqual(tower.Enemies.Count ,2);
           enemy.Moveto(5, 5);
           tower.Update();
           Assert.AreEqual(tower.Enemies.Count, 1);
 
        }

        [Test()]
        public void MoveBothEnemyOUtofRange()
        {
            //testing that both enemies can move out of range after being attacked
            Enemy enemy2 = new Enemy(10, 1.0f, "basic", 10, new Rectangle(34, 34, 54, 54));
            tower.AddNearbyEnemy(enemy);
            tower.AddNearbyEnemy(enemy2);
            tower.Update();
            Assert.AreNotEqual(enemy.Health, 10);
            Assert.AreEqual(tower.Enemies.Count, 2);
            enemy.Moveto(5, 5);
            tower.Update();
            Assert.AreEqual(tower.Enemies.Count, 1);
            for (int x = 0; x < 59; x++) tower.Update();
            tower.Update();
            Assert.AreNotEqual(enemy2.Health, 10);
            enemy.Moveto(6, 6);
            tower.Update();
            Assert.AreEqual(tower.Enemies.Count, 0);

        }

        [Test()]
        public void attackEvery60()
        {
            //Tests tower attacks once every 60 updates
            Enemy enemy2 = new Enemy(10, 1.0f, "basic", 10, new Rectangle(34, 34, 54, 54));
            tower.AddNearbyEnemy(enemy2);
            tower.Update();
            Assert.AreNotEqual(enemy2.Health, 10);
            int temp = enemy2.Health;
            for (int x = 0; x < 59; x++)
            {
                tower.Update();
                Assert.AreEqual(temp, enemy2.Health);
            }
            tower.Update();
            Assert.AreNotEqual(temp, enemy2.Health);

        }

        [Test()]
        public void twoTowerAttack()
        {
            //Testing that two towers can attack the same enemy
            Tower tower2 = new Tower("", 10, 20, 30, 40, new Rectangle(4,4, 10,10);
            Enemy enemy2 = new Enemy (10, 1.0f, "basic", 10, new Rectangle (34, 34, 54,54)); 
            tower.AddNearbyEnemy(enemy2); 
            tower2.AddNearbyEnemy(enemy2); 
            tower.Update(); 
            int temp = enemy2.Health; 
            Assert.AreNotEqual(enemy2.Health, 10); 
            tower2.Update(); 
            Assert.AreNotEqual(enemy2.Health, temp); 
        }

        [Test()]
        public void EnemyDestroyed()
        {
            //testing that towers can destroy enemeis adn that they are removed from list of the enemeis in the tower's range
            Enemy enemy2 = new Enemy(1, 1.0f, "basic", 10, new Rectangle(34, 34, 54, 54));
            Tower tower2 = new Tower("", 10, 20, 30, 40, new Rectangle(4, 4, 10, 10));
            tower2.AddNearbyEnemy(enemy2);
            tower2.Update();
            Assert.AreEqual(tower2.Enemies.Count, 0);
        }


    }
}
