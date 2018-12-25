using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTTQProject
{
    class Wildfire : Enemy
    {
        public Wildfire(int _x = 100, int _y = 100) :
            base(_x, _y)
        {
            kind = "wildfire";

            y -= 80;

            anim = new Animation(4, 0, 3, 0);

            anim.sprite[0] = new Sprite(Properties.Resources.wildfire_1, 0.8);
            anim.sprite[1] = new Sprite(Properties.Resources.wildfire_2, 0.8);
            anim.sprite[2] = new Sprite(Properties.Resources.wildfire_3, 0.8);
            anim.sprite[3] = new Sprite(Properties.Resources.wildfire_4, 0.8);

            life = 3;
            spellRelativeX = 10;
            spellRelativeY = 140;
            GenerateNextWeakSpell();
        }

        public override void Update()
        {

            movex = -5;

            base.Update();
        }
    }
}
