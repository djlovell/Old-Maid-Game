/* Actions.cs
 * Author: Daniel Lovell 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Old_Maid_Game
{
    /// <summary>
    /// Defines a class for game Actions...this never got used and is mostly residual, 
    /// asides from being called to shuffle the deck. I should delete it altogether.
    /// </summary>
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
