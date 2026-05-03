using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    internal class Deck
    {
        private List<Card> cards;
        private Random rand;

        public Deck()
        {
            cards = new List<Card>(52);
            rand = new Random();
        }

        public void BuildDeck()
        {

        }
        public void ShuffleDeck()
        {
            int n = cards.Count;
            while(n > 1)
            {
                n--;
                int k = rand.Next(n + 1);
                Card value = cards[k];
                cards[n] = value;
            }
        }
        
        public void DealCards(Player player)
        {

        }
    }
}
