using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LTTQProject
{
    public partial class MainGame : Form
    {
        Game game;
        public MainGame()
        {
            InitializeComponent();
            this.Size = new Size(800, 500);
            game = new Game(this);
            this.BackgroundImage = Properties.Resources.background;
            timer1.Start();
        }

        private void MainGame_Paint(object sender, PaintEventArgs e)
        {
            game.Draw(e);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            game.Update(this, button1, timer1);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            game.CastSpell();
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            game.EndCast();
        }

        private void button2_MouseDown(object sender, MouseEventArgs e)
        {
            game.CastSpell(button2.Text);
        }

        private void button2_MouseUp(object sender, MouseEventArgs e)
        {
            game.EndCast();
        }

        private void button3_MouseDown(object sender, MouseEventArgs e)
        {
            game.CastSpell(button3.Text);
        }

        private void button3_MouseUp(object sender, MouseEventArgs e)
        {
            game.EndCast();
        }

        private void button4_MouseDown(object sender, MouseEventArgs e)
        {
            game.CastSpell(button4.Text);
        }

        private void button4_MouseUp(object sender, MouseEventArgs e)
        {
            game.EndCast();
        }
    }
}
