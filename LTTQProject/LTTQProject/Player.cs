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
        int state;

        public Player(int _x = 100, int _y = 100)
        {
            x = _x;
            y = _y;

            state = 0;

            anim = new Animation(2, 0, 0, 5);

            anim.sprite[0] = new Sprite(Properties.Resources.harry, 0.5);
            anim.sprite[1] = new Sprite(Properties.Resources.harry_cast, 0.5);
            //anim.sprite[0].SetImage(Properties.Resources.harry);
            //anim.sprite[1].SetImage((Image)Properties.Resources.harry_cast);
        }

        public void SetAnimState(int begin, int end, int delay) //set chỉ số frame đầu và frame cuối của animation
        {

        }

        public void Update(PaintEventArgs e)
        {
            anim.Animate(e, x, y);
        }

    }
}
