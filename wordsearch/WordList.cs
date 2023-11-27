using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wordsearch
{
    public class WordList
    {
        public List<word> words = new List<word>();

        //update the word, based on text
        public void update(word w,long x,long y, long rot) {
            foreach (word w1 in words) {
                if (w1.str == w.str) {
                    w1.x = x;
                    w1.y = y;
                    w1.rot = rot;
                }
            }
        }

        //create a list of words
        public void create(List<String> wstr) {
            foreach (String s in wstr) {
                word w = new word(0,0,0,s);
                words.Add(w);
            }
        }

        //check collision
        public bool checkCollision(long x, long y, long rot,String s) {
            bool collide = false;
            word w = new word(x, y, rot, s);
                foreach (word w1 in words) {
                    if(!w.Equals(w1))collide = w.collision(w1);
                    if (collide) return true;
                }

            return false;
        }

    }
}
