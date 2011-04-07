using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SQA_Tower_Defense
{
    class Enemy
    {

        protected int health;
        protected int gold;
        protected double speed;
        protected String type;
        protected Vector2 currentLocation;

        public Enemy(int health, double speed, String type, int gold, Vector2 location)
        {
            this.health = health;
            this.speed = speed;
            this.type = type;
            this.gold = gold;
            this.currentLocation = location;
        }

        public int Health
        {
            get { return this.health; }
            set { this.health = value; }
        }
        public double Speed
        {
            get { return this.speed; }
        }
        public String Type
        {
            get { return this.type; }
        }
        public int Gold
        {
            get { return this.gold; }
        }

    }
}
