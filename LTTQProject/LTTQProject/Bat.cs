using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTTQProject
{
    class Bat : Enemy
    {
        public Bat(int _x = 100, int _y = 100) :
            base(_x, _y)
        {
            kind = "bat";

            anim = new Animation(4, 0, 3, -1);

            anim.sprite[0] = new Sprite(Properties.Resources.bat_1, 0.5);
            anim.sprite[1] = new Sprite(Properties.Resources.bat_2, 0.5);
            anim.sprite[2] = new Sprite(Properties.Resources.bat_3, 0.5);
            anim.sprite[3] = new Sprite(Properties.Resources.bat_4, 0.5);

            life = 1;
            spellRelativeX = -45;
            spellRelativeY = 30;
            GenerateNextWeakSpell();
        }

        public override void Update()
        {
            //movex = movex == -10 ? 0 : -10;
            movex = -5;

            base.Update();
        }
    }
}
