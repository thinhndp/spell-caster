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
        protected int damaged_t;
        protected bool isTakingDamaged;
        public bool isKilled;

        public int life;

        public Enemy(int _x = 100, int _y = 100, int _movex = 0, int _movey = 0)
        {
            x = _x;
            y = _y;

            movex = _movex;
            movey = _movey;

            isKilled = false;
            isTakingDamaged = false;
            damaged_t = -1;

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
            if (isTakingDamaged && life <= 0) {
                if (damaged_t % 2 == 0)
                {
                    anim.SetColor(1, 1, 1, 0); 
                }
                else
                {
                    anim.SetColor(1, 1, 1, 0.75f);
                }
                anim.FreezeAnimation();
                anim.Animate(e, x, y);
            }
            else if (isTakingDamaged)
            {
                //float a = 1.0f;
                if (damaged_t % 2 == 0)
                {
                    anim.SetColor(curWeakSpell.spellColor[0],   //r
                                  curWeakSpell.spellColor[1],   //g
                                  curWeakSpell.spellColor[2],   //b
                                  1);                           //a
                }
                else
                {
                    anim.SetColor(1, 1, 1, 1);
                }
                anim.FreezeAnimation();
                anim.Animate(e, x, y);
            }
            else
            {
                anim.Animate(e, x, y);
                curWeakSpell.Draw(e, x + spellRelativeX, y + spellRelativeY);
            }
           
        }


        public virtual void Update()
        {
            if (isTakingDamaged)
            {
                if (damaged_t > 4) //damaged time
                { 
                    isTakingDamaged = false;
                    damaged_t = -1;
                    if (life > 0)
                    {
                        GenerateNextWeakSpell();
                    }
                    else {
                        isKilled = true;
                    }
                }
                else {
                    damaged_t++;
                    if (life > 0)
                    {
                        x += 7; //knock back
                    }

                }
            }
            else
            {
                x += movex;
                y += movey;
            }
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
            //anim->sprite[anim->cu]
            isTakingDamaged = true;
            damaged_t = 0;
            life--;
            //if (life > 0)
            //{
            //    GenerateNextWeakSpell();
            //}
        }

        public void TookSpell(String attemp) {
            if (curWeakSpell.IsSuccesfullyCasted(attemp) && life > 0) {
                Damaged();
            }
        }
    }
}
