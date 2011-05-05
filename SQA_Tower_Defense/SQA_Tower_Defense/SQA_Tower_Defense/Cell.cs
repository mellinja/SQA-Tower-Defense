using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQA_Tower_Defense
{
    public class Cell
    {
        Boolean Occupied;
        Enemy enemy;
        public Cell()
        {
            Occupied = false;
        }

        public void Occupy(Enemy e)
        {
            Occupied = true;
            enemy = e;
        }

        public Boolean isOccupied()
        {
            return Occupied;
        }



    }
}