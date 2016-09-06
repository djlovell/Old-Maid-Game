using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Old_Maid_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck d = new Deck();
            d.DisplayDeck();
            d.Shuffle(); //Deck is now created and shuffled, ready for gameplay.

            int numberOfPlayers = 0;
            Console.Write("Input the Number of Computer Players (2 - 5): ");
            numberOfPlayers = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(numberOfPlayers.ToString());
        }
    }
}
