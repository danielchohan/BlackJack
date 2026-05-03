namespace BlackJack
{
    internal class Hand
    {

        #region Constants
        private const byte MAX_HAND_VALUE = 21;
        private const byte MIN_VAL = 0;
        private const byte ACE_VALUE_SUBTRACT = 10;
        private const byte MIN_HAND_SIZE = 2;
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
            if(card == null)
            {
                throw new ArgumentNullException("card", "Card cannot be null.");
            }
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
            return GetTotalHandValue() > MAX_HAND_VALUE; // Return true if GetHandValue is greater than 21, else return false.
        }

        public bool IsBlackJack()
        {
            return GetTotalHandValue() == MAX_HAND_VALUE && _cards.Count == MIN_HAND_SIZE; // Returns true if GetHandValue is equal to 21 and the hand contains only 2 cards, else return false.
        }
        public void ClearHand()
        {
            _cards.Clear();
        }
        public List<Card> GetCards() // Allows Game class to access the cards in the hand for display purposes.
        {
            return _cards;
        }
        #endregion
    }
}
