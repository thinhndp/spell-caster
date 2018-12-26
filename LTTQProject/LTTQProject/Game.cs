using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LTTQProject
{
    class Game
    {
        Player harry;
        //DeathEater deathEater;
        //Dementor dementor;
        //Bat bat;
        EnemyManager enemies;

        public Game() {

        }

        public Game(Form form) {
            harry = new Player(10, 300);
            enemies = new EnemyManager(5, 25);
            //Utilities.rand = new Random();
        }

        public void Draw(PaintEventArgs e)
        {
            harry.Draw(e);
            enemies.DrawEnemies(e);
            UI.Draw(e);
        }

        public void HarryCastSpell() {
            harry.CastSpell();
        }

        public void CastSpell() {
            harry.CastSpell();
            enemies.Destroyed();
        }

        public void CastSpell(String attemp) {
            //harry.CastSpell();
            enemies.TookSpell(attemp);
            //Utilities.PlaySpellSound();
        }

        public void HarryEndCast()
        {
            harry.EndCast();
        }

        public void EndCast() {
            harry.EndCast();
        }

        public void Update(Form form, Timer timer) {

            harry.Update();

            enemies.Update();

            if (enemies.TouchPlayer(harry)) {
                GameOver(form, timer);
                return;
            } 

            form.Invalidate();
        }

        public void GameOver(Form form, Timer timer) {
            timer.Stop();
            MessageBox.Show("LOL noob");
            //FormMain fm = new FormMain();
            //fm.Show();
            GameEnd(form);
        }

        public void GameEnd(Form form) {
            form.Dispose();
        }
    }
}
