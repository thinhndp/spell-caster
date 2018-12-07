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
        }

        private void MainGame_Paint(object sender, PaintEventArgs e)
        {
            game.Draw(e);
        }
    }
}
