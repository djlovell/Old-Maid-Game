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
                        removals.Add(j);
                        removals.Add(i);
                    }
                }
            }
            removals.Sort();
            Stack<int> s = new Stack<int>();
            int count = removals.Count;
            for(int l = 0; l < count; l++)
            {
                s.Push(removals[0]);
                removals.RemoveAt(0);
            }
            for(int m = 0; m < s.Count; m++)
            {
                removals.Add(s.Pop());
            }
            //List of removal indices is now sorted in descending order, so removing one at a time won't mess up order.

            foreach(int r in removals)
            {
                Hand.RemoveAt(r);
            }
        }
            
    }
}
