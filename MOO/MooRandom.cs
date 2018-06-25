using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOO
{
    public static class MooRandom
    {
        public static Random RND; 
        public static void Init()
        {
            RND = new Random(Environment.TickCount);
        }
        public static int GetRnd(int min, int max)
        {
            return RND.Next(min, max);
        }
    }
}
