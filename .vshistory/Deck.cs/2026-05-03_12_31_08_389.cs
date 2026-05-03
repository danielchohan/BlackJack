using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    internal class Deck
    {

        #region Constants
        private const byte DECK_SIZE = 52;
        private const byte MIN_VAL = 0;
        #endregion
        #region Data Members
        private List<Card> cards;
        private Random rand;
        #endregion

        #region Constructors
        public Deck()
        {
            cards = new List<Card>(DECK_SIZE);
            rand = new Random();
            BuildDeck();
            ShuffleDeck();
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
                cards[k] = cards[n];
                cards[n] = value;
            }
        }
        
        public Card DealCards()
        {
            // If there are no cards left in the deck, we need to build and shuffle a new one before dealing
            if (cards.Count == MIN_VAL)
            {
                BuildDeck();
                ShuffleDeck();
            }
            Card topCard = cards. FirstOrDefault();
            cards.Remove(topCard);
            return topCard;
        }
        public int CardsRemaining()
        {
            return cards.Count;
        }
        #endregion
    }
}
