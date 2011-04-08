using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SQA_Tower_Defense;

namespace ClassTests
{  
    [TestFixture()]
    public class EnemyTests
    {
        private Enemy enemy;

        #region TestingHealth

        [Test()]
        public void EnemyHasCorrectHealthAfterInitialized()
        {
            enemy = new Enemy(0, 0.0f, "", 0);
            

        }


        #endregion 
    }
}
