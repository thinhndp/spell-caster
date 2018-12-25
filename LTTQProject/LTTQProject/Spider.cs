using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTTQProject
{
    class Spider : Enemy
    {
        public Spider(int _x = 100, int _y = 100) :
            base(_x, _y)
        {
            kind = "spider";

            y += 50;

            anim = new Animation(8, 0, 7, -1);

            anim.sprite[0] = new Sprite(Properties.Resources.spider_1, 0.5);
            anim.sprite[1] = new Sprite(Properties.Resources.spider_2, 0.5);
            anim.sprite[2] = new Sprite(Properties.Resources.spider_3, 0.5);
            anim.sprite[3] = new Sprite(Properties.Resources.spider_4, 0.5);
            anim.sprite[4] = new Sprite(Properties.Resources.spider_5, 0.5);
            anim.sprite[5] = new Sprite(Properties.Resources.spider_6, 0.5);
            anim.sprite[6] = new Sprite(Properties.Resources.spider_7, 0.5);
            anim.sprite[7] = new Sprite(Properties.Resources.spider_8, 0.5);

            life = 3;
            spellRelativeX = 10;
            spellRelativeY = 20;
            GenerateNextWeakSpell();
        }

        public override void Update()
        {

            movex = -7;

            base.Update();
        }
    }
}
