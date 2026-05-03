using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    internal class Hand
    {
        private List<Card> _cards;
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
                if(card.CardRank == Card.Rank.Ace && h)
                handValue += card.GetValue();
            }
            return handValue;
        }
    }
}
