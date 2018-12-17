using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTTQProject
{
    public static class Utilities
    {
        public static readonly Random rand = new Random();

        public static int RandomGenerator(int low, int high) {
            return rand.Next(low, high);
        }
    }
}
