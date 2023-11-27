using System.Runtime.CompilerServices;
using wordsearch;

namespace testword
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(1, 4, 0, "hello", 0, 2, 2, "hello",true)]
        [InlineData(1, 4, 0, "hello", 3, 2, 2, "hello", false)]
        public static void TestWord(long x, long y, long rot, String str, long x1, long y1, long rot1, String str1,bool res)
        {
            word w = new word(x, y, rot, str);
            word w1 = new word(x1, y1, rot1, str1);
            bool expected = res;
            bool actual = w.collision(w1);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(4, 4, 0, "hi", 4, 4, 4, 3)] //north
        [InlineData(4, 4, 1, "hi", 4, 4, 5, 3)] //ne
        [InlineData(4, 4, 2, "hi", 4, 4, 5, 4)] //e
        [InlineData(4, 4, 3, "hi", 4, 4, 5, 5)] //se
        [InlineData(4, 4, 4, "hi", 4, 4, 4, 5)] //s
        [InlineData(4, 4, 5, "hi", 4, 4, 3, 5)] //sw
        [InlineData(4, 4, 6, "hi", 4, 4, 3, 4)] //w
        [InlineData(4, 4, 7, "hi", 4, 4, 3, 3)] //nw

        public static void testFillPoints(long x, long y, long rot, String str, long x1, long y1, long x2,long y2) {
            word w = new word(x, y, rot, str);
            point p1 = new point(x1, y1);
            point p2 = new point(x2,y2);
            w.fillPoints();
            Assert.True(w.coords[0].equal(p1));
            Assert.True(w.coords[1].equal(p2));
        }

        [Theory]
        [InlineData(1, 3, 1, 3)]
        [InlineData(1, 5, 1, 5)]
        public static void testPointEquals(long x, long y, long x1, long y1) {
            point p1 = new point(x, y);
            point p2 = new point(x1, y1);
            Assert.True(p1.equal(p2));
        }

        [Theory]
        [InlineData(0, 0, 2, "Hello", 0, 0, 2, "Hello")]
        public static void testWordInit(long x, long y, long rot, String str, long x1, long y1, long rot1, String str1) {
            word w = new word(x, y, rot, str);
            Assert.Equal(w.x, x1);
            Assert.Equal(w.y, y1);
            Assert.Equal(w.rot, rot1);
            Assert.Equal(w.str, str1);
        }

        //word list stuff, create
        [Theory]
        [InlineData("hello", "goodbye", 0, 0, 0, 0, 0, 0)]
        public static void testWordListCreate(String word1, String word2, long x, long y, long rot, long x1, long y1, long rot1) {
            List<String> lst = new List<String>();
            WordList wl = new WordList();
            lst.Add(word1);
            lst.Add(word2);
            wl.create(lst); //create the list of words

            List<word> wordsOut = new List<word>();
            foreach (word w in wl.words) wordsOut.Add(w); 

            word word1Out = new word(x, y, rot, word1);
            word word2Out = new word(x1, y1, rot1, word2);

            Assert.True(word1Out.equal(wordsOut[0]));
            Assert.True(word2Out.equal(wordsOut[1]));

            //update
            word w3 = wl.words[1];
            word w4 = new word(1, 2, 3, word2);
            wl.update(w3, 1, 2, 3);
            Assert.True(wl.words[1].equal(w4));

        }
    }
}