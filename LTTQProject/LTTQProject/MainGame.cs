using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tesseract;

namespace LTTQProject
{
    public partial class MainGame : Form
    {
        Game game;

        //Draw
        Graphics g; //Draw on bitmap
        Graphics h; //Draw on screen
        Point sp = new Point(0, 0);
        Point ep = new Point(0, 0);
        Pen blackPen = new Pen(Color.Black, 10); //Draw on bitmap
        Pen whitePen = new Pen(Color.White, 10); //Draw on screen
        Bitmap bmp = null;
        int drawWidth;
        int mul = 6; //Duplicating bitmap -mul- times
        Point minCorner = new Point(0, 0);
        Point maxCorner = new Point(0, 0);

        //OCR
        TesseractEngine engine = new TesseractEngine("./tessdata", "eng", EngineMode.Default);
        Page page;
        String attemp;


        public MainGame()
        {
            InitializeComponent();
            this.Size = new Size(800, 500);
            game = new Game(this);
            this.BackgroundImage = Properties.Resources.background;
            timer1.Interval = 100; //update rate

            //Draw
            bmp = new Bitmap(this.Width, this.Height);
            g = Graphics.FromImage(bmp);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            blackPen.StartCap = blackPen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            whitePen.StartCap = whitePen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            g.Clear(Color.White);
            h = this.CreateGraphics();

            //Sound
            Utilities.PlayBackgroundSound();

            //Tick
            timer1.Start();
        }

        private void MainGame_Paint(object sender, PaintEventArgs e)
        {
            game.Draw(e);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //if (timer1.)
            game.Update(this, timer1);
        }

        private void MainGame_MouseDown(object sender, MouseEventArgs e)
        {
            //Draw
            sp = e.Location;
            minCorner = e.Location;
            maxCorner = e.Location;
            

            //Game
            game.HarryCastSpell();
        }

        private void MainGame_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ep = e.Location;
                
                //Bitmap
                g.DrawLine(blackPen, sp, ep);

                //Screen
                //h = this.CreateGraphics();
                h.DrawLine(whitePen, sp, ep);

                //For cropping
                minCorner.X = Math.Min(minCorner.X, ep.X);
                minCorner.Y = Math.Min(minCorner.Y, ep.Y);
                maxCorner.X = Math.Max(maxCorner.X, ep.X);
                maxCorner.Y = Math.Max(maxCorner.Y, ep.Y);

            }
            sp = ep;
        }

        private void MainGame_MouseUp(object sender, MouseEventArgs e)
        {
            //textBox1.Text = savepath;
            //bmp.Save(savepath, System.Drawing.Imaging.ImageFormat.Png);

            //Crop bitmap
            int epsilon = 50;
            int width = maxCorner.X - minCorner.X;
            int height = maxCorner.Y - minCorner.Y;
            Rectangle rect = new Rectangle();
            rect.X = minCorner.X - epsilon;
            rect.Y = minCorner.Y - epsilon;
            rect.Width = width + epsilon * 2;
            rect.Height = height + epsilon * 2;
            if (rect.X < 0)
            {
                rect.X = 0;
            }
            if (rect.Y < 0)
            {
                rect.Y = 0;
            }
            Bitmap bmpToCrop;
            bmpToCrop = bmp.Clone(rect, bmp.PixelFormat);

            //Duplicate bitmap (for more precise recognition)
            Bitmap bmpToDuplicate;
            bmpToDuplicate = DuplicateBitmap(bmpToCrop, 0, 0, mul);

            //Save image (for debugging)
            string savepath = System.AppDomain.CurrentDomain.BaseDirectory;
            savepath += "pattern.png";
            bmpToDuplicate.Save(savepath, System.Drawing.Imaging.ImageFormat.Png);

            //OCR
            page = engine.Process(bmpToDuplicate, PageSegMode.Auto);
            attemp = page.GetText();
            page.Dispose();


            textBox1.Text = attemp;

            //Game
            game.HarryEndCast();
            game.CastSpell(attemp);

            //Clear
            //panel1.Invalidate();
            g.Clear(Color.White);
            //h.Clear(this.BackColor);
        }

        private Bitmap DuplicateBitmap(Bitmap source, int x, int y, int mul)
        {
            Bitmap result = new Bitmap(source.Width * mul, source.Height);
            Graphics g = Graphics.FromImage(result);
            int width = source.Width;

            for (int i = 0; i < mul; i++)
            {
                int temp_x = x + width * i;
                g.DrawImage(source, temp_x, y);
            }
            return result;
        }
    }
}
