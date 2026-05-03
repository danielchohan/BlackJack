using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    internal class Player
    {
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
            Chips += _currentBet *2.5
        }


    }
}
