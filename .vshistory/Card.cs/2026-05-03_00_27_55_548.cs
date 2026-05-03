using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    internal class Card
    {

        public Suit CardSuit { get; private set; }
        public Rank CardRank { get; private set; }
        public enum Suit
        {
            Hearts,
            Diamonds,
            Clubs,
            Spades
        }
        public enum Rank
        {
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5,
            Six = 6,
            Seven = 7,
            Eight = 8,
            Nine = 9,
            Ten = 10,
            Jack = 10,
            Queen = 10,
            King = 10,
            Ace = 11
        }
        public Card(Suit cardSuit_, Rank cardRank_)
        {
            CardSuit = cardSuit_;
            CardRank = cardRank_;
        }
        public uint GetValue()
        {
            return (uint)CardRank;
        }


   
    }
}
