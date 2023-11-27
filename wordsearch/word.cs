using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wordsearch
{
    public class word
    {
        public long x, y, rot;
        public String str;
        public List<point>? coords = new List<point>(); //coords in the word

        public word(long x1, long y1, long rot1, string str1) {
            x = x1;
            y = y1;
            rot = rot1;
            str = str1;
            //fill up points array
            fillPoints();
        }

        public bool collision(word w) {
            int index = 0, index1 = 0;
            foreach (point p in coords) {
                index1 = 0;
                foreach (point p1 in w.coords) {
                    if (p.equal(p1) && (str[index] != w.str[index1])) {
                        return true;
                    }
                    index1++;
                }

                index++;
            }

            return false;
        }
        public void update(long xu, long yu, long rotu, String stru) {
            x = xu;
            y = yu;
            rot = rotu;
            str = stru;
            fillPoints();
        }

        //equals
        public bool equal(word w) {
            if (str == w.str && x == w.x && y == w.y && rot == w.rot && str == w.str) return true;
            else return false;
        }

        public void fillPoints()
        {
            long x1 = x;
            long y1 = y;
            coords.Clear();
            for (int i = 0; i < str.Length; i++)
            {
                point p = new point(x1, y1);
                coords.Add(p);

                switch (rot)
                {
                    case 0:
                        {
                            //north
                            y1--;
                            break;
                        }
                    case 1:
                        {
                            //northeast
                            y1--;
                            x1++;
                            break;
                        }
                    case 2:
                        {
                            //east
                            x1++;
                            break;
                        }
                    case 3:
                        {
                            //southeast
                            y1++;
                            x1++;
                            break;
                        }
                    case 4:
                        {
                            //south
                            y1++;
                            break;
                        }
                    case 5:
                        {
                            //southwest
                            y1++;
                            x1--;
                            break;
                        }
                    case 6:
                        {
                            //west
                            x1--;
                            break;
                        }
                    case 7:
                        {
                            //northwest
                            y1--;
                            x1--;
                            break;
                        }

                }
            }
        }
    }
}
