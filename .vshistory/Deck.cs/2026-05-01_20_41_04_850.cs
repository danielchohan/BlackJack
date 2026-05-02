using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    internal class Deck
    {
        List<Card> cards = new List<Card>(52);

        public Deck()
        {
            foreach (Card.Suit suit in Enum.GetValues(typeof(Card.Suit)))
            {
                foreach (Card.Rank rank in Enum.GetValues(typeof(Card.Rank)))
                {
                    cards.Add(new Card(suit, rank));
                }
            }
        }
        public void ShuffleDeck()
        {
            Random rand = new Random();
            int n = cards.Count;
            while(n > 1)
            {
                n--;
                int k = rand.Next(n + 1);
                Card value = cards[k];
                cards[n] 
            }
        }
    }
}
