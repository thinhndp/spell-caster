using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LTTQProject
{
    class Animation
    {
        int totalFrameCount;
        int beginframe; // chỉ số frame đầu của animation hiện tại
        int curframe;   // chỉ số frame hiện tại
        int endframe;   // chỉ số frame cuối của animation hiện tại
        int animdelay;
        int animcount;
        public Sprite[] sprite; // một instance của class Animation lưu tất cả các sprite của một object

        public Animation(int count = 1, int begin = 0, int end = 0, int delay = 1)
        {
            totalFrameCount = count;
            animcount = 0;
            animdelay = delay;
            beginframe = begin;
            endframe = end;
            curframe = beginframe;

            sprite = new Sprite[count];
        }

        public void SetAnimation(int begin, int end, int delay = 1) {
            animcount = 0;
            animdelay = delay;
            beginframe = begin;
            endframe = end;
            curframe = beginframe;
        }

        void NextFrame(int newframe)
        {
            if (newframe > endframe || newframe < beginframe)
            {
                //state changed or out of frame range
                curframe = beginframe;
            }
            else
            {
                curframe = newframe;
            }
        }

        public void Animate(PaintEventArgs e, int x, int y)
        {
            if (animcount > animdelay)
            {
                animcount = 0;
                NextFrame(curframe + 1);
            }
            else
            {
                animcount++;
            }

            sprite[curframe].Draw(e, x, y);
        }
    }
}
