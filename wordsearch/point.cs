using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wordsearch
{
    public class point
    {
        public long x;
        public long y;

        public point(long x1, long y1) {
            x = x1;
            y = y1;
        }

        public bool equal(point p) {
            if (p.x == x && p.y == y) return true;
            return false;
        }
    }
}
