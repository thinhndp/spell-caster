using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace LTTQProject
{
    public static class Utilities
    {
        public static readonly Random rand = new Random();
        public static SoundPlayer backgroundSoundPlayer = new SoundPlayer(Properties.Resources.theme);
        public static SoundPlayer spellSoundPlayer = new SoundPlayer();
        //public static RecordPlayer rp = new RecordPlayer();

        public static int RandomGenerator(int low, int high) {
            return rand.Next(low, high);
        }

        public static void PlayBackgroundSound() {
            backgroundSoundPlayer.PlayLooping();
        }

        public static void PlaySpellSound() {
            Stream sound = Properties.Resources.spellsound;
            sound.Position = 0;
            spellSoundPlayer.Stream = null;
            spellSoundPlayer.Stream = sound;
            spellSoundPlayer.Play();
        }
    }
}
