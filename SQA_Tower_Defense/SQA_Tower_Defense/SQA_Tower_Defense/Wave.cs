using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQA_Tower_Defense
{
    public class Wave
    {

        Stack<Enemy> waveEnemies;
        int updateTimer;

        public Wave(Enemy enemy, int count)
        {
            updateTimer = 0;

            waveEnemies = new Stack<Enemy>();



            
            for (int i = 0; i < count; i++)
            {
                waveEnemies.Push(enemy);
            }

        }

        //Wasn't sure how we wanted to do this part :(
     /*   public Enemy Update()
        {
            updateTimer++;
            if (updateTimer == 10)
            {
                updateTimer = 0;

                return waveEnemies.Pop();

            }
            else
            {
                return null;
            }


        } 
      * 
      * */
        
    }
}
