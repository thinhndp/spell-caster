using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LTTQProject
{
    class Game
    {
        Player harry;

        public Game() {

        }

        public Game(Form form) {
            harry = new Player(10, 10);
        }

        public void Draw(PaintEventArgs e)
        {
            harry.Update(e);
        }

        public void GameEnd() {

        }
    }
}
