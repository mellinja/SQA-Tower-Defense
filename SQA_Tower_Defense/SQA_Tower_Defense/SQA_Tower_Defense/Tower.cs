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
        Rectangle location;
        protected List<Enemy> nearbyEnemies;


        public Tower (String name, int health, int damage, int cost, int range, Rectangle location)
        {
            this.name = name;
            this.location = location;
            this.health = health;
            this.attackDamage = damage;
            this.cost = cost;
            this.range = range;

            this.nearbyEnemies = new List<Enemy>();
        }

        public void AddNearbyEnemy(Enemy enemy)
        {
            nearbyEnemies.Add(enemy);
        }

        public void AttackEnemy()
        {
            if(nearbyEnemies.Count > 0)
                nearbyEnemies[0].Health -= this.attackDamage;
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
        
    }
}
