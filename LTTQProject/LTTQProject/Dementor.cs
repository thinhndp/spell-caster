﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTTQProject
{
    class Dementor : Enemy
    {
        public Dementor(int _x = 100, int _y = 100) :
            base(_x, _y, 0,  4)
        {
            kind = "dementor";

            anim = new Animation(2, 0, 1, 0);

            y -= 50;

            anim.sprite[0] = new Sprite(Properties.Resources.dementor_1, 0.17);
            anim.sprite[1] = new Sprite(Properties.Resources.dementor_2, 0.17);

            life = 4;
            spellRelativeX = 10;
            spellRelativeY = 50;
            GenerateNextWeakSpell();
        }

        public override void Update()
        {
            //movex = movex == -10 ? 0 : -10;
            movex = -7;

            if (y <= 200)
            {
                movey = 4;
            }
            else if (y >= 240)
            {
                movey = -4;
            }

            base.Update();
        }
    }
}
