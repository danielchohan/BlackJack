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
    }
}
