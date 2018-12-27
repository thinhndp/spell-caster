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
    public partial class Intro : Form
    {
        public Intro()
        {
            InitializeComponent();
        }

        private void Intro_Load(object sender, EventArgs e)
        {
            Utilities.PlayIntroSound();
        }

        private void Intro_MouseClick(object sender, MouseEventArgs e)
        {
            MainGame mainGame = new MainGame();
            this.Hide();
            mainGame.ShowDialog();
            this.Show();
            Utilities.PlayIntroSound();
        }

        private void Intro_MouseDown(object sender, MouseEventArgs e)
        {
            
        }
    }
}
