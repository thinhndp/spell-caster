using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LTTQProject
{
    public static class UI
    {
        public static int score;
        static List<Sprite> scoreSprites;
        const int wndHalfX = 400;
        const int wndTopY = 25;
        const int margin = 5;
        const int commonWidth = 33;

        static UI() {
            score = 0;
            scoreSprites = new List<Sprite>();
            scoreSprites.Add(new Sprite(Properties.Resources.score_0, 0.5));
            
        }

        public static int GetScoreNumCount() {
            if (score == 0)
                return 1;
            int result = 0;
            int _score = score;
            while (_score > 0) {
                result++;
                _score /= 10;
            }
            return result;
        }

        public static void UpdateScore(int newScore) {
            score = newScore;
            int numCount = scoreSprites.Count;
            if (numCount < GetScoreNumCount()) {
                scoreSprites.Add(new Sprite(Properties.Resources.score_0, 0.5));
                numCount++;
            }
            int _score = score;
            for (int i = scoreSprites.Count - 1; i >= 0; i--) {
                switch (_score % 10) {
                    case 0:
                        scoreSprites[i].SetImage(Properties.Resources.score_0);
                        break;
                    case 1:
                        scoreSprites[i].SetImage(Properties.Resources.score_1);
                        break;
                    case 2:
                        scoreSprites[i].SetImage(Properties.Resources.score_2);
                        break;
                    case 3:
                        scoreSprites[i].SetImage(Properties.Resources.score_3);
                        break;
                    case 4:
                        scoreSprites[i].SetImage(Properties.Resources.score_4);
                        break;
                    case 5:
                        scoreSprites[i].SetImage(Properties.Resources.score_5);
                        break;
                    case 6:
                        scoreSprites[i].SetImage(Properties.Resources.score_6);
                        break;
                    case 7:
                        scoreSprites[i].SetImage(Properties.Resources.score_7);
                        break;
                    case 8:
                        scoreSprites[i].SetImage(Properties.Resources.score_8);
                        break;
                    case 9:
                        scoreSprites[i].SetImage(Properties.Resources.score_9);
                        break;
                }
                _score /= 10;
            }
        }

        public static void Draw(PaintEventArgs e) {

            int numCount = scoreSprites.Count;
            int x = 0;
            for (int i = 0; i < numCount; i++) {
                if (i == 0)
                {
                    if (numCount % 2 == 0)
                    {
                        x = wndHalfX - ((commonWidth + margin) * numCount / 2 - margin / 2);
                    }
                    else
                    {
                        x = wndHalfX - ((commonWidth + margin) * numCount / 2 + commonWidth / 2);
                    }
                }
                else {
                    x += commonWidth + margin;
                }
                scoreSprites[i].Draw(e, x, wndTopY);
            }
        }
    }
}
