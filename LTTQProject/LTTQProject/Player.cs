using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LTTQProject
{
    class Player
    {
        Animation anim;
        int x, y;
        int movex, movey;
        int state;

        public Player(int _x = 100, int _y = 100)
        {
            x = _x;
            y = _y;

            movex = 0;
            movey = 0;

            state = 0;

            anim = new Animation(2, 0, 0, 5);

            anim.sprite[0] = new Sprite(Properties.Resources.harry, 0.5);
            anim.sprite[1] = new Sprite(Properties.Resources.harry_cast, 0.5);
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


        public void Update()
        {
            if (y <= 270)
            {
                movey = 3;
            }
            else if (y >= 300) {
                movey = -4;
            }

            y += movey;
        }

        public void CastSpell()
        {
            //int n = state == 0 ? 1 : 0;
            SetAnimState(1, 1, 1);
            //SetAnimState(n, n, n);
        }

        public void EndCast()
        {
            SetAnimState(0, 0, 0);
        }

        public int GetX() {
            return x;
        }
    }
}
