using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTTQProject
{
    class DeathEater : Enemy
    {
        public DeathEater(int _x = 100, int _y = 100) :
            base(_x, _y) {

            kind = "deatheater";

            anim = new Animation(3, 0, 2, -1);

            y -= 25;

            anim.sprite[0] = new Sprite(Properties.Resources.death_eater_1, 0.5);
            anim.sprite[1] = new Sprite(Properties.Resources.death_eater_2, 0.5);
            anim.sprite[2] = new Sprite(Properties.Resources.death_eater_3, 0.5);

            life = 2;
            spellRelativeX = -20;
            spellRelativeY = 50;
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
