using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SQA_Tower_Defense
{
    public class Enemy
    {

        protected int health;
        protected int gold;
        protected double speed;
        protected String type;
        protected Rectangle location;
        protected int xDirection = 1;
        protected int yDirection = 1;
        Random random = new Random();

        public Enemy(int health, double speed, String type, int gold, Rectangle location)
        {

            if (location.Equals(new Rectangle()))
                throw new ArgumentNullException();
            if (gold <= 0)
                throw new ArgumentOutOfRangeException();
            if (speed <= 0)
                throw new ArgumentOutOfRangeException();
            if (health <= 0)
                throw new ArgumentOutOfRangeException();

            if (type != "basic")
                throw new ArgumentException();

            
            this.health = health;
            this.speed = speed;
            this.type = type;
            this.gold = gold;

            this.location = location;
        }

        public void Move()
        {
            if (this.location.X > random.Next(60)*100)
                xDirection *= -1;
            if (this.Location.X < 20)
                xDirection *= -1;
            if (this.Location.Y > random.Next(60)*100)
                yDirection *= -1;
            if (this.Location.Y < 20)
                yDirection *= -1;
            this.location = new Rectangle(location.X + xDirection, location.Y + yDirection, 50, 50);
            
        }

        public int Health
        {
            get { return this.health; }
            set { this.health = value; }
        }
        public double Speed
        {
            get { return this.speed; }
            set { this.speed = value; }
        }
        public String Type
        {
            get { return this.type; }
        }
        public int Gold
        {
            get { return this.gold; }
        }
        public Rectangle Location
        {
            get { return this.location; }
            set { this.Location = value; }
        }

    }
}
