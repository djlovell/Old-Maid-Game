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
            _deck[52] = new Card(14, 5);
        }

        public Card[] CardsInDeck
        {
            get
            {
                return _deck;
            }
        }

        /// <summary>
        /// Display cards in deck, was used to debug deck creation
        /// </summary>
        public void DisplayDeck()
        {
            foreach (Card c in _deck)
            {
                Console.WriteLine(c.ToString() + "(" + c.Rank.ToString() + ")");
            }
        }

        public void Shuffle()
        {
            Actions a = new Actions();
            a.Shuffle(_deck);
        }

        public void DealOut(List<Player> players)
        {
            int deckIndex = 52;

            while (deckIndex >= 0)
            {
                foreach (Player p in players)
                {
                    if (deckIndex >= 0)
                    {
                        p.AddCard(CardsInDeck[deckIndex]);
                        deckIndex--;
                    }
                }
            }
        }



    }
}
