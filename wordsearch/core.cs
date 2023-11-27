using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace wordsearch
{
    public class core
    {
        public char [,] initPuzzle(int width, int height) {
            Random rnd = new Random();
            char[,] gr= new char[width, height];
            for (int i = 0; i < height; i++) {
                for (int i1 = 0; i1 < width; i1++) {
                    long cint = rnd.NextInt64(26);
                    char c = (char)(cint + 65);
                    gr[i1, i] = c;
                }
            }
            return gr;
        } //unit test
        public char[,] setWords(char[,] grid, WordList? words, int width, int height) {
            Random rnd = new Random();
            long x = 0;
            long y = 0;
            long rot = 0;
            bool collide = false;
            char[,] gridOut = new char[width, height];
            //transfer to gridout
            for (int i = 0; i < height; i++) {
                for (int i1 = 0; i1 < width; i1++) {
                    gridOut[i1, i] = grid[i1, i];
                }
            }

            foreach (word s in words.words) {
                Console.WriteLine($"starting with: {s.str}");
                do
                {
                    x = rnd.NextInt64(width);
                    y = rnd.NextInt64(height);
                    rot = rnd.NextInt64(8);
                    Console.WriteLine($"x:{x},y:{y},rot:{rot},word:{s.str}");
                    collide = words.checkCollision(x, y, rot,s.str)|checkBounds(x,y,rot,width,height,s.str.Length);
                } while (collide);
                Console.WriteLine($"done with: {s.str}");
                words.update(s,x,y,rot);
                for (int i = 0; i < s.str.Length; i++)
                {
                    gridOut[x, y] = s.str[i];
                    switch (rot)
                    {
                        case 0:
                            {
                                //north
                                y--;
                                break;
                            }
                        case 1:
                            {
                                //northeast
                                y--;
                                x++;
                                break;
                            }
                        case 2:
                            {
                                //east
                                x++;
                                break;
                            }
                        case 3:
                            {
                                //southeast
                                y++;
                                x++;
                                break;
                            }
                        case 4:
                            {
                                //south
                                y++;
                                break;
                            }
                        case 5:
                            {
                                //southwest
                                y++;
                                x--;
                                break;
                            }
                        case 6:
                            {
                                //west
                                x--;
                                break;
                            }
                        case 7:
                            {
                                //northwest
                                y--;
                                x--;
                                break;
                            }

                    }
                }
            }
            return gridOut;
        } //unit test

        //check bounds, working
        public bool checkBounds(long x, long y, long rot, int width, int height, int length) {
            switch (rot) {
                case 0: {
                        //north
                        if (y < length) return true;
                        break;
                    }
                case 1:
                    {
                        //northeast
                        if (x > width-length || y<length) return true;
                        break;
                    }
                case 2:
                    {
                        //east
                        if (x > width - length) return true;
                        break;
                    }
                case 3:
                    {
                        //southeast
                        if (x > width - length || y >height-length) return true;
                        break;
                    }
                case 4:
                    {
                        //south
                        if (y>height-length) return true;
                        break;
                    }
                case 5:
                    {
                        //southwest
                        if (x <length || y >height-length) return true;
                        break;
                    }
                case 6:
                    {
                        //west
                        if (x <length) return true;
                        break;
                    }
                case 7:
                    {
                        //northwest
                        if (x <length || y < length) return true;
                        break;
                    }

            }
            return false;
        }
    }
}
