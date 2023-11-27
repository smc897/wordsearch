using wordsearch;

namespace testcore
{
    public class UnitTest1
    {
        [Fact]
        public void testInitPuzzle()
        {
            core C = new core();
            char[,] grid = C.initPuzzle(20, 20);
            Assert.NotNull(grid);
        }

        [Theory]
        [InlineData(0,0,0,20,20,5,true)]
        [InlineData(8, 8, 1, 20, 20, 5, false)]
        [InlineData(18, 18, 3, 20, 20, 10, true)]
        public static void testCheckBounds(long x, long y, long rot, int width, int height, int length, bool exp) {
            core c = new core();
            bool actual = c.checkBounds(x, y, rot, width, height, length);
            Assert.Equal(exp, actual);
        }

        [Theory]
        [InlineData("hello")]
        [InlineData("goodbye")]
        public void testInitWords(String word) {
            core C = new core();
            WordList wl = new WordList();
            List<String> lst = new List<String>();
            lst.Add(word);
            wl.create(lst);
            char[,] gridIn = new char[100, 100];
            char[,] grid = C.setWords(gridIn,wl,100,100);
            Assert.NotNull(grid);
        } 
    }
}