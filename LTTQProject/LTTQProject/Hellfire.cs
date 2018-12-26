using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTTQProject
{
    class Hellfire : Enemy
    {
        public Hellfire(int _x = 100, int _y = 100) :
            base(_x, _y)
        {
            kind = "hellfire";

            y -= 50;

            anim = new Animation(10, 0, 9, -1);

            anim.sprite[0] = new Sprite(Properties.Resources.hellfire_1, 0.7);
            anim.sprite[1] = new Sprite(Properties.Resources.hellfire_2, 0.7);
            anim.sprite[2] = new Sprite(Properties.Resources.hellfire_3, 0.7);
            anim.sprite[3] = new Sprite(Properties.Resources.hellfire_4, 0.7);
            anim.sprite[4] = new Sprite(Properties.Resources.hellfire_5, 0.7);
            anim.sprite[5] = new Sprite(Properties.Resources.hellfire_6, 0.7);
            anim.sprite[6] = new Sprite(Properties.Resources.hellfire_7, 0.7);
            anim.sprite[7] = new Sprite(Properties.Resources.hellfire_8, 0.7);
            anim.sprite[8] = new Sprite(Properties.Resources.hellfire_9, 0.7);
            anim.sprite[9] = new Sprite(Properties.Resources.hellfire_10, 0.7);

            life = 5;
            spellRelativeX = -15;
            spellRelativeY = 90;
            GenerateNextWeakSpell();
        }

        public override void Update()
        {

            movex = -7;

            base.Update();
        }
    }
}
