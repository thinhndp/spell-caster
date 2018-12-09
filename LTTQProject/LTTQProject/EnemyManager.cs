using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LTTQProject
{
    class EnemyManager
    {
        //Enemy[] enemiesList; // List of enemies
        List<Enemy> enemiesList = new List<Enemy>();
        int enemyCount; // Current number of enemies spawned on screen
        int maxEnemy; // Restricted number of enemies exist at the same time
        int spawnDelay;
        int spawnCooldown;

        public EnemyManager(int _maxEnemy = 5, int _spawnDelay = 5) {
            maxEnemy = _maxEnemy;
            enemyCount = 0;
            spawnDelay = _spawnDelay;
            spawnCooldown = 0;
        }

        public void DrawEnemies(PaintEventArgs e) {
            foreach (Enemy enemy in enemiesList) {
                enemy.Draw(e);
            }
        }

        public void Update() {
            if (spawnCooldown >= spawnDelay)
            {
                if (enemyCount < maxEnemy)
                {
                    SpawnRandomNewEnemy();
                }
                spawnCooldown = 0;
            }
            else {
                spawnCooldown++;
            }

            foreach (Enemy enemy in enemiesList) {
                enemy.Update();
            }
        }

        public void SpawnRandomNewEnemy(int x = 700, int y = 275, int movex = 0, int movey = 0) {
            Random rnd = new Random();
            int id = rnd.Next(0, 3);

            switch (id) {
                case 0:
                    enemiesList.Add(new Bat(x, y));
                    break;
                case 1:
                    enemiesList.Add(new DeathEater(x, y));
                    break;
                case 2:
                    enemiesList.Add(new Dementor(x, y));
                    break;
                default:
                    enemiesList.Add(new Bat(x, y));
                    break;
            }

            enemyCount++;
        }

        public bool TouchPlayer(Player player) {
            foreach (Enemy enemy in enemiesList) {
                if (enemy.TouchPlayer(player))
                    return true;
            }
            return false;
        }

        public void Destroyed() {
            if (enemyCount == 0)
                return;

            int minx = 10000;
            int imin = 0;
            for (int i = 0; i < enemiesList.Count; i++) {
                if (minx > enemiesList[i].GetX()) {
                    minx = enemiesList[i].GetX();
                    imin = i;
                }
            }

            enemiesList.RemoveAt(imin);
            enemyCount--;
        }
    }
}
