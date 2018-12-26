using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LTTQProject
{
    class Sprite
    {
        Bitmap image;
        Graphics g;
        Rectangle rect;
        double scale;
        ImageAttributes imageAttributes = new ImageAttributes();

        public Sprite() {

        }

        public Sprite(Image imageToSet, double scaleToSet = 1.0) {
            image = (Bitmap)imageToSet;
            scale = scaleToSet;
        }

        public void SetImage(Image imageToSet)
        {
            image = (Bitmap)imageToSet;
        }

        public void SetScale(double scaleToSet)
        {
            scale = scaleToSet;
        }

        public int GetWidth() {
            return image.Width;
        }

        public int GetHeight() {
            return image.Height;
        }

        public void SetColor(float r = 1.0f, float g = 1.0f, float b = 1.0f, float a = 1.0f) {
            int height = image.Height;
            int width = image.Width;
            //ImageAttributes imageAttributes = new ImageAttributes();

            float[][] colorMatrixElements = {
                    new float[] {r,  0,  0,  0, 0},        // red scaling factor of 2
                    new float[] {0,  g,  0,  0, 0},        // green scaling factor of 1
                    new float[] {0,  0,  b,  0, 0},        // blue scaling factor of 1
                    new float[] {0,  0,  0,  a, 0},        // alpha scaling factor of 1
                    new float[] {0f, 0f, 0f, 0, 1}};    // three translations of 0.2

            ColorMatrix colorMatrix = new ColorMatrix(colorMatrixElements);

            imageAttributes.SetColorMatrix(
               colorMatrix,
               ColorMatrixFlag.Default,
               ColorAdjustType.Bitmap);
        }

        public void Draw(PaintEventArgs e, int x, int y) {
            rect = new Rectangle(x, y, (int)(image.Width * scale), (int)(image.Height * scale));

            g = e.Graphics;
            g.DrawImage(image, 
                        rect,
                        0, 0,
                        image.Width, image.Height,
                        GraphicsUnit.Pixel,
                        imageAttributes);
        }
    }
}
