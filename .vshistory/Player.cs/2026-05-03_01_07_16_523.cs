using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    internal class Player
    {
        #region Constants
        private const byte BLACKJACK_PAYOUT_MULTIPLIER = 2;
        private const double BLACKJACK_SPECIAL_PAYOUT_MULTIPLIER = 2;
        #region Data Members
        private string _name;
        private uint _chips;
        private uint _currentBet;
        private Hand _hand;
        #endregion

        #region Constructors
        public Player(string name_, uint chips_) 
        {
            Name = name_;
            Chips = chips_;
        }
        #endregion

        #region Properties
        public Hand Hand
        {
            get { return _hand; }
            private set { _hand = value; }
        }

        public string Name
        {
            get { return _name; }
            private set { _name = value; }
        }
        public uint Chips
        {
            get { return _chips; }
            private set { _chips = value; }
        }
        #endregion
        #region Methods
        public void PlaceBet(uint betAmount)
        {
            if(betAmount > Chips)
            {
                throw new InvalidOperationException("Bet amount cannot exceed available chips.");
            }
            if(betAmount <= 0)
            {
                throw new ArgumentOutOfRangeException("betAmount", "Bet amount must be greater than zero.");
            }
            Chips -= betAmount;
            _currentBet = betAmount;
        }
        public void WinBet()
        {
            Chips += _currentBet * 2; // Win double the amount of chips.
            _currentBet = 0;
        }

        public void WinBlackJack()
        {
            Chips += (uint)(_currentBet * 2.5); // 2.5x payout for BlackJack.
            _currentBet = 0;
        }

        public void LoseBet()
        {
            _currentBet = 0;
        }

        public void TakeCard(Card card)
        {
            if (Hand == null)
            {
               Hand = new Hand();
            }
            Hand.AddCard(card);
        }

        public bool isBroke()
        {
            return Chips == 0; // Return true if player is broke and has no chips left, else return false.
        }
        #endregion


    }
}
