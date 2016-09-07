using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Old_Maid_Game
{
    class Card
    {
        private int _rank;
        private int _suit;

        public Card(int r, int s)
        {
            _rank = r;
            _suit = s;
        }

        public int Rank
        {
            get
            {
                return _rank;
            }
            set
            {
                _rank = value;
            }
        }

        public int Suit
        {
            get
            {
                return _suit;
            }
            set
            {
                _suit = value;
            }
        }
        
        public override string ToString()
        {
            string suitName;
            string rankName;

            if (_suit > 0 && _suit <= 4 && !(_rank < 1 || _rank > 13))
            {
                if (_suit == 1)
                    suitName = "H";
                else if (_suit == 2)
                    suitName = "S";
                else if (_suit == 3)
                    suitName = "C";
                else
                    suitName = "D";

                if (_rank > 1 && _rank < 10)
                    rankName = _rank.ToString();
                else
                {
                    switch (_rank)
                    {
                        case (10):
                            rankName = "T";
                            break;
                        case (1):
                            rankName = "A";
                            break;
                        case (11):
                            rankName = "J";
                            break;
                        case (12):
                            rankName = "Q";
                            break;
                        default:
                            rankName = "K";
                            break;
                    }
                }
            }

            else
            {
                suitName = "M";
                rankName = "O";
            }

            return rankName + suitName;

        }
    }
}
