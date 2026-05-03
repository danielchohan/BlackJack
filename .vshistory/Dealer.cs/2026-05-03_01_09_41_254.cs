using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    internal class Dealer
    {
        #region Data Members
        private Hand _hand;
        #endregion

        #region Constructor
        public Dealer()
        {
           hand = new Hand();
        }
        #endregion
        #region Properties
        public Hand Hand
        {
            get { return _hand; }
            private set { _hand = value; }
        }
    }
}
