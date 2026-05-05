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
        private const byte WIN_MULTIPLIER = 2;
        private const double BLACKJACK_MULTIPLIER = 2.5;
        #endregion

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
            _hand = new Hand();
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
        public uint CurrentBet
        {
            get { return _currentBet; }
            private set { _currentBet = value; }
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

        public void DoubleDown(Card card)
        {
            if (_currentBet == 0)
            {
                throw new InvalidOperationException("No bet placed to double down.");
            }
            if (_currentBet > Chips)
            {
                throw new InvalidOperationException("Not enough chips to double down.");
            }
            Chips -= _currentBet; // Deduct the additional bet amount from the player's chips.
            _currentBet *= 2; // Double the current bet.
        }
        public void WinBet()
        {
            Chips += _currentBet * WIN_MULTIPLIER; // Win double the amount of chips.
            _currentBet = 0;
        }

        public void WinBlackJack()
        {
            Chips += (uint)(_currentBet * BLACKJACK_MULTIPLIER); // 2.5x payout for BlackJack.
            _currentBet = 0;
        }

        public void LoseBet()
        {
            _currentBet = 0;
        }

        public void PushBet()
        {
            Chips += _currentBet; // Return the bet amount to the player in case of a push.
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
