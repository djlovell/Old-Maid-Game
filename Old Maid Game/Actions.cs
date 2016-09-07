using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Old_Maid_Game
{
    class Actions
    {
        public void Shuffle(Card[] cardArray)
        {
            Random random = new Random();
            for (int i = cardArray.Length - 1; i >= 0; i--)
            {
                int r = random.Next(cardArray.Length);
                if (r != i)
                {
                    Card temp = cardArray[i];
                    cardArray[i] = cardArray[r];
                    cardArray[r] = temp;
                }
            }
        }

        

    }
}
