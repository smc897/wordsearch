using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wordsearch
{
    //flesh out word add method
    public class Driver
    {
        int width,height;
        char[,] grid,gridOut;
        List<String> words=new List<String>();
       public int puzzleNum;
        core c=new core();
        fileStuff fs=new fileStuff();

        //create a puzzle
        public void createPuzzle(int ch) {
            width = 0;
            height = 0;
            c = new core();
            fs = new fileStuff();
            words = fs.pullPuzzle(puzzleNum); //fill words array
            WordList wl = new WordList();
            wl.create(words);
            switch (ch) {
                case 1: {
                        width = 20;
                        height = 20;
                        grid = c.initPuzzle(20, 20); //20x20
                        break;
                    }
                case 2:
                    {
                        width = 50;
                        height = 50;
                        grid = c.initPuzzle(50, 50); //20x20
                        break;
                    }
                case 3:
                    {
                        width = 100;
                        height = 100;
                        grid = c.initPuzzle(100, 100); //20x20
                        break;
                    }
                case 4:
                    {
                        width = 200;
                        height = 200;
                        grid = c.initPuzzle(200, 200); //20x20
                        break;
                    }

            }
            Console.WriteLine("creating puzzle...");
            gridOut=c.setWords(grid, wl,width,height); //put words in the puzzle
            Console.WriteLine("...done.");
        }

        //display
        public void display() {
            //display words and grid
            Console.WriteLine("puzzle:");
            for (int y = 0; y < height; y++) {
                for (int x = 0; x < width; x++) {
                    Console.Write(gridOut[x,y]);
                }
                Console.WriteLine();
            }

            //words
            Console.WriteLine("words:");
            foreach (String s in words) Console.WriteLine(s);
        }

        //get the max number of puzzles
        public int getMaxPuzzle() {
            return fs.getMax();
        }
    }
}
