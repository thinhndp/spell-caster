using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTTQProject
{
    class Dragon : Enemy
    {
        public Dragon(int _x = 100, int _y = 100) :
            base(_x, _y, 0, 4)
        {
            kind = "dragon";

            y -= 100;

            anim = new Animation(11, 0, 10, -1);

            anim.sprite[0] = new Sprite(Properties.Resources.dragon_1, 1.2);
            anim.sprite[1] = new Sprite(Properties.Resources.dragon_2, 1.2);
            anim.sprite[2] = new Sprite(Properties.Resources.dragon_3, 1.2);
            anim.sprite[3] = new Sprite(Properties.Resources.dragon_4, 1.2);
            anim.sprite[4] = new Sprite(Properties.Resources.dragon_5, 1.2);
            anim.sprite[5] = new Sprite(Properties.Resources.dragon_6, 1.2);
            anim.sprite[6] = new Sprite(Properties.Resources.dragon_7, 1.2);
            anim.sprite[7] = new Sprite(Properties.Resources.dragon_8, 1.2);
            anim.sprite[8] = new Sprite(Properties.Resources.dragon_9, 1.2);
            anim.sprite[9] = new Sprite(Properties.Resources.dragon_10, 1.2);
            anim.sprite[10] = new Sprite(Properties.Resources.dragon_11, 1.2);

            life = 5;
            spellRelativeX = 25;
            spellRelativeY = 140;
            GenerateNextWeakSpell();
        }

        public override void Update()
        {
            //movex = movex == -10 ? 0 : -10;
            movex = -7;

            if (y <= 150)
            {
                movey = 4;
            }
            else if (y >= 175)
            {
                movey = -4;
            }

            base.Update(); 
        }
    }
}
