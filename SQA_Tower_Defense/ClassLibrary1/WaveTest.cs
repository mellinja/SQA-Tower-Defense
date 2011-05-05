using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SQA_Tower_Defense;
using Microsoft.Xna.Framework;

namespace ClassTests
{
    [TestFixture()]
    class WaveTest
    {
        Wave wave;
        [Test]
        public void WaveInitializes()
        {
            Wave wave = new Wave();
            Assert.IsNotNull(wave); 
        }
        [Test]
        public void WaveHasEnemies()
        {
            wave.spawnEnemy(new Enemy (1,1,"basic",1,new Rectangle()); 
            Assert.AreEqual(wave.EnemyCount(),1); 
        }



    }
}
