using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LTTQProject
{
    static class SpellNames
    {
        public const int Descendio = 0;
        public const int Herbivicus = 1;
        public const int ExpectoPatronum = 2;
        public const int Incendio = 3;
        public const int WingardiumLeviosa = 4;
        public const int Revelio = 5;
        public const int Expelliarmus = 6;
        public const int ArrestoMemento = 7;
        public const int Stupify = 8;
        public const int Sectumsempra = 9;
    }

    static class SpellConstants {
        public const double Scale = 0.4;
    }

    class Spell
    {
        Animation lifeCircleAnim;
        Animation spellAnim;
        int x, y;
        int state;
        int spellCode;
        String[] RecogList; //Acceptable recognation

        public Spell(int x, int y, int life, int spell = -1) {
            if (spell == -1) {
                //Pick random spell
                //Random rnd = new Random();
                while (spell != 0 && spell != 4 && spell != 9)
                {
                    //temp
                    //spell = rnd.Next(0, 10);
                    spell = Utilities.RandomGenerator(0, 10);
                }
            }

            spellAnim = new Animation(1, 0, 0, -1);
            lifeCircleAnim = new Animation(1, 0, 0, -1);

            switch (spell) {
                case SpellNames.Descendio:
                    spellAnim.sprite[0] = new Sprite(Properties.Resources.Descendio, SpellConstants.Scale);
                    RecogList = new String[] {"P", "p", "F", "?"};
                    break;
                case SpellNames.WingardiumLeviosa:
                    spellAnim.sprite[0] = new Sprite(Properties.Resources.WingardiumLeviosa, SpellConstants.Scale);
                    RecogList = new String[] { "N", "M", "IV" };
                    break;
                case SpellNames.Sectumsempra:
                    spellAnim.sprite[0] = new Sprite(Properties.Resources.Sectumsempra, SpellConstants.Scale);
                    RecogList = new String[] { "S", "s", "5", "$", "3", "§", "f" };
                    break;
                default:
                    spellAnim.sprite[0] = new Sprite(Properties.Resources.Descendio, SpellConstants.Scale);
                    RecogList = new String[] { "P", "p", "F", "?" };
                    break;
            }

            switch (life) {
                case 1:
                    lifeCircleAnim.sprite[0] = new Sprite(Properties.Resources.life_1, SpellConstants.Scale);
                    break;
                case 2:
                    lifeCircleAnim.sprite[0] = new Sprite(Properties.Resources.life_2, SpellConstants.Scale);
                    break;
                case 3:
                    lifeCircleAnim.sprite[0] = new Sprite(Properties.Resources.life_3, SpellConstants.Scale);
                    break;
                case 4:
                    lifeCircleAnim.sprite[0] = new Sprite(Properties.Resources.life_4, SpellConstants.Scale);
                    break;
                case 5:
                    lifeCircleAnim.sprite[0] = new Sprite(Properties.Resources.life_5, SpellConstants.Scale);
                    break;
                default:
                    lifeCircleAnim.sprite[0] = new Sprite(Properties.Resources.life_1, SpellConstants.Scale);
                    break;
            }

        }

        public void Draw(PaintEventArgs e, int x, int y) {
            spellAnim.Animate(e, x, y);
            lifeCircleAnim.Animate(e, x, y);
        }

        public bool IsSuccesfullyCasted(String attemp) {
            foreach (String recog in RecogList) {
                if (attemp.Contains(recog)) {
                    return true;
                }
            }
            return false;
        }
    }
}
