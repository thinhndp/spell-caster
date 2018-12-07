using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LTTQProject
{
    class Sprite
    {
        Image image;
        Graphics g;
        Rectangle rect;
        double scale;

        public Sprite() {

        }

        public Sprite(Image imageToSet, double scaleToSet = 1.0) {
            image = imageToSet;
            scale = scaleToSet;
        }

        public void SetImage(Image imageToSet)
        {
            image = imageToSet;
        }

        public void SetScale(double scaleToSet)
        {
            scale = scaleToSet;
        }

        public void Draw(PaintEventArgs e, int x, int y) {
            rect = new Rectangle(x, y, (int)(image.Width * scale), (int)(image.Height * scale));

            g = e.Graphics;
            g.DrawImage(image, rect);
        }
    }
}
