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
        public Player(string name_, uint chips_) 
        {
            Name = name_;
            Chips = chips_;
        }
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


    }
}
