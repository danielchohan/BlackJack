using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    internal class Deck
    {
        #region Data Members
        private List<Card> cards;
        private Random rand;
        #endregion

        #region Constructors
        public Deck()
        {
            cards = new List<Card>(52);
            rand = new Random();
        }
        #endregion

        #region Methods
        public void BuildDeck()
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
            cards.FirstOrDefault().MoveCard(player.Hand);
            cards.Remove(cards.FirstOrDefault());
        }
        #endregion
    }
}
