using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wordsearch
{
    public class fileStuff
    {
        public const String INPUTFILENAME = "words.txt";
        public String[] str = File.ReadAllLines(INPUTFILENAME);

        public List<String> pullPuzzle(int num) {
            List<String> lst = new List<String>();
            try
            {
             
                int Index = 0;
                int puzzle = 1;
           
                do
                {
                    String count = str[Index]; //count of words
                    int countInt = Int32.Parse(count);
                    Index++;
                    Console.WriteLine($"count: {countInt}");
                    for (int c = 0; c < countInt; c++)
                    {
                        if (puzzle == num)
                        {
                            lst.Add(str[Index]);
                            Console.WriteLine($"str[index]: {str[Index]}");
                        }
                        Index++;
                    }
                    puzzle++;
                } while (Index < str.Length);

            }
            catch (Exception e) {
                Console.WriteLine("Exception in opening file.");
            }
            return lst;
        } //unit test this
        public int getMax() {
            int puzzle = 1;
            try
            {
                int Index = 0;
                puzzle = 0;

                do
                {
                    String count = str[Index]; //count of words
                    int countInt = Int32.Parse(count);
                    Index++;
                    Console.WriteLine($"count: {countInt}");
                    for (int c = 0; c < countInt; c++)
                    {
                        Index++;
                    }
                    puzzle++;
                } while (Index < str.Length);

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception in opening file.");
            }
            Console.WriteLine($"puzzle is: {puzzle}");
            return puzzle;
        } //unit test
    }
}
