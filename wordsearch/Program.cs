using System.Xml.Serialization;

namespace wordsearch {
    public class wordSearch {

        public static void Main(String[] args) {
            Driver D = new Driver();
            int max = D.getMaxPuzzle();
            int choice = 0;
            //get the puzzle num
            do
            {
                Console.WriteLine($"Enter number of puzzle from 1 to {max}");
                D.puzzleNum = Int32.Parse(Console.ReadLine());
            } while (D.puzzleNum < 1 || D.puzzleNum > max);

            //get the size:
            do
            {
                Console.WriteLine("Enter puzzle size: \n1) 20x20\n2) 50x50\n3) 100x100\n4) 200x200 ");
                choice = Int32.Parse(Console.ReadLine());
            } while (choice < 1 || choice > 4);

            //create puzzle
            D.createPuzzle(choice); //fill in an empty puzzle based on size, gets words from file into list
            Console.WriteLine("finished puzzle and words: ");
            D.display();
            String tmp = Console.ReadLine();
        }
    }
}