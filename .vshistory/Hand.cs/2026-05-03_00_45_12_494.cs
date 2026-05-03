using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    internal class Hand
    {

        #region Constants
        private const uint MAX_HAND_VALUE = 21;
        #region Data Members
        private List<Card> _cards;
        #endregion
        public Hand()
        {
            _cards = new List<Card>();
        }

        public void AddCard(Card card)
        {
            _cards.Add(card);
        }

        public uint GetTotalHandValue()
        {
            uint handValue = 0;
            foreach (Card card in _cards)
            {
                if(card.CardRank == Card.Rank.Ace && handValue + card.GetValue() > MAX_HAND_VALUE)
                {
                    handValue += 1; // Treat Ace as 1 if it would cause the hand to bust
                }
                else
                {
                    handValue += card.GetValue();
                }
            }
            return handValue;
        }
    }
}
