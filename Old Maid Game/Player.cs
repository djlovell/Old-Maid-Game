using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Old_Maid_Game
{
    class Player
    {
        private List<Card> _hand;
        private string _name;

        public string PlayerName
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public List<Card> Hand
        {
            get
            {
                return _hand;
            }
            
        }
        public Player()
        {
            _hand = new List<Card>();
        }

        public void shuffleHand()
        {
            Random random = new Random();
            for (int i = _hand.Count -1; i >= 0; i--)
            {
                int r = random.Next(_hand.Count);
                if (r != i)
                {
                    Card temp = _hand[i];
                    _hand[i] = _hand[r];
                    _hand[r] = temp;
                }
            }
        }

        public void AddCard(Card c)
        {
            _hand.Add(c);
        }

        public string DisplayHand()
        {
            StringBuilder temp = new StringBuilder();
            temp.Append(_name.PadRight(7) + " : ");
            foreach(Card c in _hand)
            {
                temp.Append(c.ToString() + " ");
            }
            return temp.ToString();
        }

        public string DisplayIndices()
        {
            StringBuilder temp = new StringBuilder();
            temp.Append("Index".PadRight(7) + " : ");
            int index = 0;
            foreach (Card c in _hand)
            {
                temp.Append(index.ToString().PadLeft(2) + " ");
                index++;
            }
            return temp.ToString();
        }

        public void DiscardPairs()
        {
            bool[] isPair = new bool[Hand.Count];
            List<int> removals = new List<int>();
            for(int i = 0; i < Hand.Count - 1; i++)
            {
                for(int j = i+1; j < Hand.Count; j++)
                {
                    if (!isPair[i] && !isPair[j] && Hand[i].Rank == Hand[j].Rank)
                    {
                        isPair[i] = true;
                        isPair[j] = true;
                        removals.Add(i);
                        removals.Add(j);
                    }
                }
            }
            removals.Sort();
            removals.Reverse();
            
            foreach(int r in removals)
            {
                Hand.RemoveAt(r);
            }
        }
            
    }
}
