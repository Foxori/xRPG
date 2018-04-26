using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
   public static class RandomNumGen
    {
        private static readonly Random numGen = new Random();
        public static int NumBetween (int minValue, int maxValue)
        {
            return numGen.Next(minValue, maxValue + 1);
        }
    }
}
