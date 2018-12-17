using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LTTQProject
{
    class Enemy
    {
        protected Animation anim;
        protected int x, y;
        protected int movex, movey;
        protected int state;
        protected string kind;
        protected Spell curWeakSpell;
        protected int spellRelativeX, spellRelativeY; //Variables for spell circle position relative to enemy position

        public int life;

        public Enemy(int _x = 100, int _y = 100, int _movex = 0, int _movey = 0)
        {
            x = _x;
            y = _y;

            movex = _movex;
            movey = _movey;

            state = 0;

            life = 1; //default
            spellRelativeX = -1;
            spellRelativeY = 1;
            //GenerateNextWeakSpell();
        }

        public void SetAnimState(int newState, int begin, int end, int delay = 1) //set chỉ số frame đầu và frame cuối của animation
        {
            state = newState;
            anim.SetAnimation(begin, end, delay);
        }

        public void GenerateNextWeakSpell() {
            if (life <= 0)
                return; //just in case
            curWeakSpell = new Spell(x + spellRelativeX, y + spellRelativeY, life);
        }

        public void Draw(PaintEventArgs e)
        {
            anim.Animate(e, x, y);
            curWeakSpell.Draw(e, x + spellRelativeX, y + spellRelativeY);
        }


        public virtual void Update()
        {
            x += movex;
            y += movey;
        }

        public bool TouchPlayer(Player player) {
            return x <= player.GetX();
        }

        public string GetKind() {
            return kind;
        }

        public int GetX() {
            return x;
        }

        public void Damaged() {
            life--;
            if (life > 0)
            {
                GenerateNextWeakSpell();
            }
        }

        public void TookSpell(String attemp) {
            if (curWeakSpell.IsSuccesfullyCasted(attemp)) {
                Damaged();
            }
        }
    }
}
