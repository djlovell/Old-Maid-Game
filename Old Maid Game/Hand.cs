using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Old_Maid_Game
{
    class Hand
    {
        private Card[] _hand;

        public void Shuffle()
        {
            Actions a = new Actions();
            a.Shuffle(_hand);
        }


    }
}
