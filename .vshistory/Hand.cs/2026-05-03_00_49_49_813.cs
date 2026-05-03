namespace BlackJack
{
    internal class Hand
    {

        #region Constants
        private const byte MAX_HAND_VALUE = 21;
        private const byte MIN_VAL = 0;
        private const byte ACE_VALUE_SUBTRACT = 10;
        #endregion

        #region Data Members
        private List<Card> _cards;
        #endregion

        #region Constructor
        public Hand()
        {
            _cards = new List<Card>();
        }
        #endregion


        #region Methods
        public void AddCard(Card card)
        {
            _cards.Add(card);
        }

        public uint GetTotalHandValue()
        {
            uint handValue = 0;
            uint aceCount = 0;
            foreach (Card card in _cards)
            {
                handValue += card.GetValue();
                if (card.CardRank == Card.Rank.Ace)
                {
                    aceCount++;
                }

                while (handValue > MAX_HAND_VALUE && aceCount > MIN_VAL)
                {
                    handValue -= ACE_VALUE_SUBTRACT;
                    aceCount--;
                }
            }
            return handValue;
        }

        public bool IsBust()
        {
            return GetTotalHandValue() > MAX_HAND_VALUE;
        }

        public bool IsBlackJack()
        {
            return GetTotalHandValue() == MAX_HAND_VALUE && _cards.Count == 2;
        }
        #endregion
    }
}
