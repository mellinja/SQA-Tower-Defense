using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SQA_Tower_Defense
{
    public class Tower
    {
        protected String name;
        
        protected int health;
        protected int attackDamage;
        protected int cost;
        protected int range;
        public int updateCounter;
        Rectangle location;
        protected List<Enemy> nearbyEnemies;
        public int UpdateMax = 60;


        public Tower (String name, int health, int damage, int cost, int range, Rectangle location)
        {

            if (location.Equals(new Rectangle()))
                throw new ArgumentNullException();
            if (range <= 0)
                throw new ArgumentOutOfRangeException();
            if (damage <= 0)
                throw new ArgumentOutOfRangeException();
            if (health <= 0)
                throw new ArgumentOutOfRangeException();

            if (cost <= 0)
                throw new ArgumentOutOfRangeException();


            this.name = name;
            this.location = location;
            this.health = health;
            this.attackDamage = damage;
            this.cost = cost;
            this.range = range;
            this.updateCounter = 0;
            this.nearbyEnemies = new List<Enemy>();
        }

        public void AddNearbyEnemy(Enemy enemy)
        {
            nearbyEnemies.Add(enemy);
        }

        public void AttackEnemy()
        {
            if (nearbyEnemies.Count > 0)
                nearbyEnemies[0].Health -= this.attackDamage;
        }
        public void AttackEnemy(Enemy e)
        {
                e.Health -= this.attackDamage;
        }

        public int Health
        {
            get { return this.health; }
            set { this.health = value; }
        }

        public int AttackDamage
        {
            get { return this.attackDamage; }
            
        }
        public int Cost
        {
            get { return this.cost; }
        }
        public int Range
        {
            get { return this.range; }
        }
        public String Name
        {
            get { return this.name; }
        }
        public List<Enemy> Enemies
        {
            get { return this.nearbyEnemies; }
        }
        public Rectangle Location
        {
            get { return this.location; }
            set { this.location = value; }
        }


        public void Update()
        {
            this.updateCounter++;
            if (this.updateCounter == UpdateMax)
            {
                updateCounter = 0;
                Enemy attacking = this.getCurrentTarget();
                Console.WriteLine(attacking);
                if (attacking != null)
                {
                    attacking.Health -= this.attackDamage;
                    if (attacking.Health <= 0)
                        this.Enemies.Remove(attacking);
                }
            }
        }

        public Enemy getCurrentTarget()
        {
            Enemy attacking = null;
            double distanceToClosest = range;
            for (int i = 0 ; i < Enemies.Count ; i++)
            {
                Enemy e = this.Enemies[i];
            //foreach (Enemy e in Enemies)
            //{
                double tCenterX = this.Location.X;
                double eCenterX = e.Location.X;
                double tCenterY = this.Location.Y;
                double eCenterY = e.Location.Y;

                double distance = Math.Sqrt((tCenterX - eCenterX) * (tCenterX - eCenterX) + (tCenterY - eCenterY) * (tCenterY - eCenterY));

                if (distance <= distanceToClosest)
                {
                    distanceToClosest = distance;
                    attacking = e;
                }
            }
            return attacking;
        }
    }
}
