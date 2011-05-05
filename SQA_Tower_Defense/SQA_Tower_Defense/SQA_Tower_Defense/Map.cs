using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQA_Tower_Defense
{
    public class Map
    {

        String gametype;
        int money, score;
        int difficulty;
        List<Tower> towersOnMap;
        public List<Enemy> enemiesOnMap;
        List<SaveState> saveStates;
        Wave wave;
        int updateCounter = 0;
        int UPDATE_MAX = 5;


        //Constructs a game Map, which does most of the work load of the game (13 lines)
        public Map(String gametype, int startingMoney, int difficulty)
        {
            if (1 > difficulty || difficulty > 3)
                throw new ArgumentOutOfRangeException();

            if (gametype != "normal")
                throw new ArgumentException();


            if (startingMoney < 0)
                throw new ArgumentOutOfRangeException();

            
            this.gametype = gametype;
            
            this.money = startingMoney;
            
            this.difficulty = difficulty;
            this.score = 0;

            this.towersOnMap = new List<Tower>();
            this.enemiesOnMap = new List<Enemy>();
            this.saveStates = new List<SaveState>();
        }


        //Places a tower if not other towers are at that location if the user has enough money (6 lines)
        public void PlaceTower(Tower tower)
        {
            for (int i = 0; i < towersOnMap.Count; i++)
            {
                if (tower.Location.Intersects(towersOnMap[i].Location))
                    return;
            }
            if (this.money >= tower.Cost)
            {
                towersOnMap.Add(tower);
                money -= tower.Cost;
            }
        }


        //Sells a tower, adding .75 times its original cost to the bank (8 lines)
        public void SellTower(Tower tower)
        {
            towersOnMap.Remove(tower);
            money += (int) (tower.Cost * 0.75);
        }


        //Adds an Enemy to that map (1 line)
        public void SpawnEnemy(Enemy enemy)
        {
            enemiesOnMap.Add(enemy);
        }

        //Removes an enemy, giveing the user its money (2 lines)
        public void KillEnemy(Enemy enemy)
        {
            enemiesOnMap.Remove(enemy);
            money += enemy.Gold;
        }

        //sets Wave w to the current wave of enemies (1 line)
        public void newWave(Wave w)
        {
            this.wave = w;
        }

        //Getters and Setters for the fields of the map class (11 lines)
        #region Getters/Setters
        
        public String Gametype
        {
            get { return this.gametype; }
        }
        public int Money
        {
            get { return this.money; }
            set { this.money = value; }
        }
        public int Score
        {
            get { return this.score; }
            set { this.score = value; }

        }
        public int Difficulty
        {
            get { return this.difficulty; }
        }
        public List<Tower> Towers
        {
            get { return this.towersOnMap; }
            set { this.towersOnMap = value; }
        }
        public List<Enemy> Enemies
        {
            get { return this.enemiesOnMap; }
            set { this.enemiesOnMap = value; }
        }
        public List<SaveState> SaveStates
        {
            get { return this.saveStates; }
        }


        #endregion


        //Save state creation and loading (31 lines)
        #region Save States

        public struct SaveState
        {
            public List<Enemy> enemies;
            public List<Tower> towers;
            public int score;
            public int money;
        }

        public void SaveNextState()
        {
            SaveState nextState = new SaveState();
            nextState.enemies = new List<Enemy>();
            nextState.towers = new List<Tower>();

            for (int i = 0; i < this.Towers.Count; i++)
            {
                nextState.towers.Add(this.Towers[i]);
            }
            for (int i = 0; i < this.Enemies.Count; i++)
            {
                Enemy temp = this.Enemies[i];
                Enemy enemy = new Enemy(temp.Health, temp.Speed, temp.Type, temp.Gold, temp.Location);
                nextState.enemies.Add(enemy);
            }
            nextState.score = this.Score;
            nextState.money = this.Money;
            saveStates.Add(nextState);
        }

        public void LoadPreviousState()
        {

            if (saveStates.Count == 0)
                return;
            SaveState previousState = new SaveState();
            previousState = this.saveStates[saveStates.Count - 1];
            this.Money = previousState.money;
            this.Score = previousState.score;
            this.Towers = new List<Tower>();
            this.Enemies = new List<Enemy>();

            for (int i = 0; i < previousState.towers.Count; i++)
                this.Towers.Add(previousState.towers[i]);
            for (int i = 0; i < previousState.enemies.Count; i++)
            {
                Enemy temp = previousState.enemies[i];
                Enemy enemy = new Enemy(temp.Health, temp.Speed, temp.Type, temp.Gold, temp.Location);
                this.Enemies.Add(enemy);
            }
            this.saveStates.RemoveAt(saveStates.Count - 1);
        }

        #endregion


        //Spawns enemies off the wave stack, then adds enemies to each towers lists, then removes dead enemies (27 lines)
        public void Update()
        {
            foreach (Enemy e in this.enemiesOnMap)
            {
                e.Move();
            }
            updateCounter++;
            if (updateCounter == UPDATE_MAX)
            {
                if (wave != null)
                {
                    Enemy e = wave.getEnemy();
                    if (e != null)
                    {
                        this.enemiesOnMap.Add(e);
                    }
                    else
                    {
                        wave = null;
                    }

                }
            }


            foreach (Tower t in this.towersOnMap)
            {
                List<Enemy> KillEnemyList = new List<Enemy>() ;
                t.Enemies.Clear();
                foreach (Enemy e in this.enemiesOnMap)
                {
                    if (e.Health <= 0)
                    {
                        KillEnemyList.Add(e);
                    }
                    else
                    {
                        double tCenterX = t.Location.X + t.Location.Width / 2;
                        double eCenterX = e.Location.X + e.Location.Width / 2;
                        double tCenterY = t.Location.Y + t.Location.Height / 2;
                        double eCenterY = e.Location.Y + e.Location.Height / 2;

                        double distance = Math.Sqrt((tCenterX - eCenterX) * (tCenterX - eCenterX) + (tCenterY - eCenterY) * (tCenterY - eCenterY));
                        if (t.Range >= distance)
                            t.Enemies.Add(e);
                    }

                }
                foreach (Enemy e in KillEnemyList)
                {
                    KillEnemy(e);
                }

            }

        }
    }
}
