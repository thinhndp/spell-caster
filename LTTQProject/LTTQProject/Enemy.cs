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

        public Enemy(int _x = 100, int _y = 100, int _movex = 0, int _movey = 0)
        {
            x = _x;
            y = _y;

            movex = _movex;
            movey = _movey;

            state = 0;

        }

        public void SetAnimState(int newState, int begin, int end, int delay = 1) //set chỉ số frame đầu và frame cuối của animation
        {
            state = newState;
            anim.SetAnimation(begin, end, delay);
        }

        public void Draw(PaintEventArgs e)
        {
            anim.Animate(e, x, y);
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
    }
}
