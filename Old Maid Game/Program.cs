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
            //d.DisplayDeck();
            d.Shuffle(); //Deck is now created and shuffled, ready for gameplay.

            int numberOfComputerPlayers = 0;
            Console.Write("Input the Number of Computer Players (2 - 5): ");
            numberOfComputerPlayers = Convert.ToInt32(Console.ReadLine());
            List<Player> players = new List<Player>();
            for(int i = 0; i < numberOfComputerPlayers; i++)
            {
               Player cpu = new Player();
               cpu.PlayerName = "Player" + i.ToString();
               players.Add(cpu);
            }
            Player u = new Player();
            players.Add(u);
            u.PlayerName = "User";

            d.DealOut(players);
            Console.WriteLine("\n**** After Dealing Out Cards ****\n");
            foreach(Player p in players)
            {
                Console.WriteLine(p.DisplayHand());
            }

            Console.WriteLine("\n**** After Discarding Pairs & Shuffling Hands ****\n");
            foreach(Player p in players)
            {
                p.DiscardPairs();
                p.shuffleHand();
                Console.WriteLine(p.DisplayHand());
            }

            int x = 8;
        }
    }
}
