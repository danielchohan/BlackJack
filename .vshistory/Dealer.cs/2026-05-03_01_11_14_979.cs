using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    internal class Dealer
    {

        #region Constants
        private const byte DEALER_HIT_THRESHOLD = 17;
        #endregion
        #region Data Members
        private Hand _hand;
        #endregion

        #region Constructor
        public Dealer()
        {
           Hand = new Hand();
        }
        #endregion
        #region Properties
        public Hand Hand
        {
            get { return _hand; }
            private set { _hand = value; }
        }
        #endregion

        #region Methods

        public void TakeCard(Card card)
        {
            Hand.AddCard(card);
        }

        public bool ShouldHit()
        {
            return Hand.GetTotalHandValue() < DEALER_HIT_THRESHOLD; // Return true if GetHandValue is less than 17 and dealer will hit, else return false and don't hit.
        }

        #endregion
    }
}
