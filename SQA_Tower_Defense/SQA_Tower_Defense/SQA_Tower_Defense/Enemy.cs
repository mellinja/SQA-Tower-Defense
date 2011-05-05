using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SQA_Tower_Defense
{

    //Enemies main goal is to destroy Castles and towers. 
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
    
        //Constructs the Enemy class, throws 2 exceptions (ArgumentOurOfRangeException and ArgumentNullArgument) (15 lines)
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

        //Moves the enemy buy 1 unit down and 1 unit left (1 line)
        public void Move() 
        {
            this.location = new Rectangle(location.X + 1, location.Y + 1, location.Height, location.Width);
            
        }


        //Moves an enemy to the specified point (1 line)
        public void moveTo(int x, int y)
        {
            this.location = new Rectangle(x, y, this.location.Width, this.location.Height);

        }


        //Getters and setters for fields in the Enemy class (8 lines)
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
