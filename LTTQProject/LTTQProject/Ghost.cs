using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTTQProject
{
    class Ghost : Enemy
    {
        public Ghost(int _x = 100, int _y = 100) :
            base(_x, _y)
        {
            kind = "ghost";

            y += 10;

            anim = new Animation(5, 0, 4, -1);

            anim.sprite[0] = new Sprite(Properties.Resources.ghost_1, 0.3);
            anim.sprite[1] = new Sprite(Properties.Resources.ghost_2, 0.3);
            anim.sprite[2] = new Sprite(Properties.Resources.ghost_3, 0.3);
            anim.sprite[3] = new Sprite(Properties.Resources.ghost_4, 0.3);
            anim.sprite[4] = new Sprite(Properties.Resources.ghost_5, 0.3);

            life = 2;
            spellRelativeX = -50;
            spellRelativeY = 50;
            GenerateNextWeakSpell();
        }

        public override void Update()
        {

            movex = -5;

            base.Update();
        }
    }
}
