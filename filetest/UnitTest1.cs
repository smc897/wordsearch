using System;
using wordsearch;
using static System.Formats.Asn1.AsnWriter;

namespace filetest
{
    public class UnitTest1
    {
        [Fact]
        public void read() {
            fileStuff fs = new fileStuff();
            //fs.readFile();
            String expected = "10";
            String actual = fs.str[0];
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void testFile()
        {
            fileStuff fs = new fileStuff();
            List<String>? lst = fs.pullPuzzle(1);
            List<String>? lstexp = new List<string>(){ "apple", "orange", "scott", "abby", "banana", "carrot", "potato", "ham", "lemon", "waffle" };

            int index = 0;
            foreach (String i in lst) {
                Assert.Equal(i, lstexp[index]);
                index++;
            }
        }

        [Fact]
        public void testMax() {
            fileStuff fs = new fileStuff();
            int actual= fs.getMax();
            int expected = 2;
            Assert.Equal(expected, actual) ;
        }
    }
}