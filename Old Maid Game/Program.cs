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
            char repeat = 'n';
            do
            {
                Deck d = new Deck();
                //d.DisplayDeck();
                d.Shuffle(); //Deck is now created and shuffled, ready for gameplay.

                int numberOfComputerPlayers = 0;
                Console.Write("Input the Number of Computer Players (2 - 5): ");
                numberOfComputerPlayers = Convert.ToInt32(Console.ReadLine());
                List<Player> players = new List<Player>();
                for (int i = 0; i < numberOfComputerPlayers; i++)
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
                foreach (Player p in players)
                {
                    Console.WriteLine(p.DisplayHand());
                    p.DiscardPairs();
                    p.shuffleHand();
                }

                Console.WriteLine("\n**** After Discarding Pairs & Shuffling Hands ****\n");

                //Where main game loop starts
                while (players.Count > 1)
                {
                    foreach (Player p in players)
                    {
                        Console.WriteLine(p.DisplayHand());
                    }
                    Console.Write("\nPress <Enter> to continue : ");
                    Console.ReadLine();

                    for (int i = 0; i < players.Count; i++)
                    {
                        Player current = players[i];
                        Player next;
                        if (i == players.Count - 1)
                            next = players[0];
                        else
                            next = players[i + 1];
                        int pickIndex;

                        if (current.PlayerName.Equals("User"))
                        {
                            Console.WriteLine("\n**** User's Turn ****\n");
                            Console.WriteLine(current.DisplayHand());
                            Console.WriteLine(next.DisplayHand());
                            Console.WriteLine(next.DisplayIndices());
                            Console.Write("Pick one card from " + next.PlayerName + " : ");
                            pickIndex = Convert.ToInt32(Console.ReadLine());
                        }
                        else
                        {
                            Random r = new Random();
                            pickIndex = r.Next(next.Hand.Count);
                        }

                        Card pickedCard = next.Hand[pickIndex];
                        current.Hand.Add(pickedCard); //adds next players card to hand
                        next.Hand.RemoveAt(pickIndex); //removes card from next players hand
                        current.DiscardPairs();
                        if(current.Hand.Count == 0)
                        {
                            Console.WriteLine("\n++++ " + current.PlayerName + " has finished ++++\n");
                            players.RemoveAt(i);
                        }
                        Console.WriteLine("\n" + current.PlayerName + " picks up " +
                            (next.PlayerName + "'s").PadRight(9) + " Card at [" +
                            pickIndex.ToString() + "],   Card: " + pickedCard.ToString() + "\n");
                        if (next.Hand.Count == 0)
                        {
                            Console.WriteLine("\n++++ " + next.PlayerName + " has finished ++++\n");
                            if (i + 1 < players.Count)
                                players.RemoveAt(i + 1);
                            else
                                players.RemoveAt(0);
                        }
                        Console.Write("Press <Enter> to continue : ");
                        Console.ReadLine();


                    }//end for 
                    Console.WriteLine("\n***** After Picking *****");
                    foreach (Player p in players)
                    {
                        Console.WriteLine(p.DisplayHand());
                    }
                    if (players.Count > 1)
                        Console.WriteLine("\n#### ROUND COMPLETE --- LET PLAYERS SHUFFLE HANDS ####\n");
                }//end while

                Console.WriteLine("\nXXXXX " + players[0].PlayerName + " is the loser XXXXX\n");
                Console.Write("Would you like to play again? (Y/N)");
                repeat = Console.ReadLine()[0];
            }
            while (repeat.Equals('y') || repeat.Equals('Y'));
            
        }//end Main
    }
}
