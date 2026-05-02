using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    internal class Hand
    {
        private List<Card> Cards { get; set; } = new List<Card>();
        public Hand()
        {
           
        }

        public void AddCard(Card card)
        {
            Cards.Add(card);
        }

        public uint GetHandValue()
        {
            uint handValue = 0;
            foreach (Card card in Cards)
            {
                handValue += card.GetValue();
            }
            return handValue;
        }
    }
}
