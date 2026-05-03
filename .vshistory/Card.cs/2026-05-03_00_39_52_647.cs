using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    internal class Card
    {
        #region Data Members
        private Suit _cardSuit;
        private Rank _cardRank;
        #endregion

        #region Constructors and Enums
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
            _cardSuit = cardSuit_;
            _cardRank = cardRank_;
        }
        #endregion

        #region Properties
        public Suit CardSuit 
        { 
           get { return _cardSuit; }
           private set { _cardSuit = value; }
        }
        public Rank CardRank
        {
            get { return _cardRank; }
            private set { _cardRank = value; }
        }
        #endregion

        #region Methods
        public uint GetValue()
        {
            return (uint)_cardRank;
        }
        
        public override string ToString()
        {
            return $"{_cardRank} of {_cardSuit}";
        }
        #endregion
    }
}
