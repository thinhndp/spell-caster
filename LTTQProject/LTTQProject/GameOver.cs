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
    public partial class GameOver : Form
    {
        public GameOver(int score = 0)
        {
            InitializeComponent();
            textBox1.Text = score.ToString();
            textBox1.Location = new Point(this.Width / 2 + 20, this.Height / 2);
        }

        private void GameOver_MouseClick(object sender, MouseEventArgs e)
        {
            this.Dispose();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            this.Dispose();
        }
    }
}
