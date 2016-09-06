using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Old_Maid_Game
{
    class Deck
    {
        private Card[] _deck;

        public Deck()
        {
            _deck = new Card[53];
            int index = 0;

            for(int s = 1; s < 5; s++)
            {
                for(int r = 1; r < 14; r++)
                {
                    _deck[index] = new Card(r, s);
                    index++;
                }
            }
            _deck[52] = new Card(5, 14);
        }

        public void DisplayDeck()
        {
            foreach (Card cd in _deck)
            {
                Console.WriteLine(cd.ToString());
            }
        }

        public void Shuffle()
        {
            Actions a = new Actions();
            a.Shuffle(_deck);
        }

       
    }
}
