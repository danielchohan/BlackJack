namespace BlackJack
{
    internal class Game
    {
        #region Constants
        private byte MIN_VAL = 0;
        #endregion
        #region Data Members

        private Deck _deck;
        private Player _player;
        private Dealer _dealer;

        #endregion
        public void Start()
        {
            bool keepPlaying = true;
            string input;

            while (keepPlaying)
            {
                Setup();
                do
                {
                    PlayRound();
                } while (!_player.isBroke() && PlayAgain());

                if(_player.isBroke())
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You are broke! Do you want to restart from scratch and try your hand again? (y/n) : ");
                    Console.ResetColor();
                    input = Console.ReadLine().ToLower();
                    if (input == "y'")
                    {
                        keepPlaying = true;
                    }
                    else
                    {
                        keepPlaying = false;
                    }
                }
            }
        }

        public void Setup()
        {
            string playerName;
            uint playerMoney;
            _deck = new Deck();
            _deck.ShuffleDeck();

            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.WriteLine("BLACKJACK CREATED BY DANIEL CHOHAN");
            Console.ResetColor();
            Console.WriteLine("-----------------------------------------------------------------------------");
            Console.WriteLine($"Starting Chips  |  Up to you! I recommend 500 for a fair experience.");
            Console.WriteLine($"Min Bet         |  1  ");
            Console.WriteLine($"Blackjack Pays  |  1.5x");
            Console.WriteLine("First to 21 wins. Dealer must hit until reaching 17 or higher.");
            Console.WriteLine("-----------------------------------------------------------------------------");

            Console.WriteLine($"The time is currently {DateTime.Now}. Happy gambling!");
            Console.WriteLine("\n");
            Console.Write("Enter your name : ");
            playerName = StringValidation(Console.ReadLine());
            Console.Write("Enter your starting money : ");
            playerMoney = BalanceValidation(Console.ReadLine());
            _player = new Player(playerName, playerMoney);
            _dealer = new Dealer();
        }
        public void PlayRound()
        {
            Console.Clear();
            Console.WriteLine($"Starting a new round! Your current chips: {_player.Chips}");
            Console.WriteLine("Place your bet : ");
            uint bet = BalanceValidation(Console.ReadLine());
            _player.PlaceBet(bet);

            DealInitialCards();

            DisplayTable(false);

            PlayerTurn();
            DealersTurn();

            DisplayTable(true);

            DetermineOutcome();

            _player.Hand.ClearHand();
            _dealer.Hand.ClearHand();

        }

        public void DealInitialCards()
        {
            for (int i = 0; i < 2; i++)
            {
                _player.Hand.AddCard(_deck.DealCards());
                _dealer.Hand.AddCard(_deck.DealCards());
            }
        }

        private void DisplayTable(bool showDealerCard)
        {
            Console.Clear();
            Console.WriteLine($"Player: {_player.Name} | Chips: {_player.Chips} | Current Bet: {_player.CurrentBet}");
            Console.WriteLine($"Player's Total Hand Value is {_player.Hand.GetTotalHandValue()}");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine(showDealerCard ? $"Dealer's Total Hand Value is: {_dealer.Hand.GetTotalHandValue()}" : "Dealer's Hand: [One Card Hidden]");
            Console.WriteLine($"Cards Remaining in Deck: {_deck.CardsRemaining()}");
            Console.WriteLine("--------------------------------------------");
            for (int i = 0; i < _dealer.Hand.GetCards().Count; i++)
            {
                if (i == MIN_VAL && !showDealerCard)
                {
                    Console.Write("Dealer's Card: ");
                    Console.WriteLine("[Hidden]");
                }
                else
                {

                    Console.Write("Dealer's Card:");
                    DisplayCard(_dealer.Hand.GetCards()[i]);
                }
            }
            Console.WriteLine("\n");
            foreach (Card card in _player.Hand.GetCards())
            {
                Console.Write("Player's Card:");
                DisplayCard(card);
            }
            Console.WriteLine("--------------------------------------------");
        }

        private void PlayerTurn()
        {
            string choice;
            do
            {
                DisplayTable(false);
                Console.Write("Do you want to hit or stand? (h/s) : ");
                choice = Console.ReadLine().ToLower();
                if (choice == "h")
                {
                    _player.TakeCard(_deck.DealCards());
                }
                else if (choice != "s")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice. Please enter 'h' to hit or 's' to stand.");
                    Console.ResetColor();
                }
            } while (choice != "s" && !_player.Hand.IsBust());
        }

        private void DealersTurn()
        {
            while (_dealer.ShouldHit())
            {
                _dealer.TakeCard(_deck.DealCards());
                DisplayTable(true);
            }
        }

        private void DetermineOutcome()
        {
            if (_player.Hand.IsBlackJack() && _dealer.Hand.IsBlackJack())
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("It's a push! Both player and dealer have Blackjack, your chips are returned.");
                Console.ResetColor();
                _player.PushBet();
            }
            else if (_player.Hand.IsBlackJack() && !_dealer.Hand.IsBlackJack())
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Congratulations! You win with a Blackjack!");
                Console.ResetColor();
                _player.WinBlackJack();
            }
            else if (!_player.Hand.IsBlackJack() && _dealer.Hand.IsBlackJack())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Dealer has Blackjack! You lose.");
                Console.ResetColor();
                _player.LoseBet();
            }
            else if (_player.Hand.IsBust())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You busted! You lose.");
                Console.ResetColor();
                _player.LoseBet();
            }
            else if (_dealer.Hand.IsBust())
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Dealer has busted! You win!");
                Console.ResetColor();
                _player.WinBet();
            }
            else if (_player.Hand.GetTotalHandValue() > _dealer.Hand.GetTotalHandValue())
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Congratulations! You won with a higher hand value than the dealer!");
                Console.ResetColor();
                _player.WinBet();
            }
            else if (_player.Hand.GetTotalHandValue() < _dealer.Hand.GetTotalHandValue())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Dealer wins with a higher hand value! You lose.");
                Console.ResetColor();
                _player.LoseBet();
            }
            else if (_player.Hand.GetTotalHandValue() == _dealer.Hand.GetTotalHandValue())
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("It's a push! Both player and dealer have the same hand value, your chips are returned.");
                Console.ResetColor();
                _player.PushBet();
            }
            Console.WriteLine("---PRESS ANY KEY TO CONTINUE---");
            Console.ReadKey();
        }

        private bool PlayAgain()
        {
            Console.Write("Do you want to play another round? (y/n) : ");
            string input = Console.ReadLine().ToLower();
            while (input != "y" && input != "n")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter 'y' for yes or 'n' for no.");
                Console.ResetColor();
                Console.Write("Do you want to play another round? (y/n) : ");
                input = Console.ReadLine().ToLower();
            }
            return input == "y";
        }

        private void DisplayCard(Card card)
        {
            switch (card.CardSuit)
            {
                case Card.Suit.Hearts:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("♥ ");
                    break;
                case Card.Suit.Diamonds:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("♦ ");
                    break;
                case Card.Suit.Clubs:
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("♣ ");
                    break;
                case Card.Suit.Spades:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("♠ ");
                    break;
            }
            Console.WriteLine(card.ToString());
            Console.ResetColor();
        }

        private string StringValidation(string input)
        {
            while (string.IsNullOrEmpty(input))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Input cannot be empty. Please enter a valid name.");
                Console.ResetColor();
                Console.Write("Enter your name : ");
                input = Console.ReadLine();
            }
            foreach (char c in input)
            {
                if (char.IsDigit(c))
                {
                    throw new ArgumentException("Name cannot contain numbers. Please enter a valid name.");
                }
            }
            return input;
        }
        private uint BalanceValidation(string input)
        {
            uint balance;
            while (!uint.TryParse(input, out balance) || balance <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter a positive number for your starting money.");
                Console.ResetColor();
                Console.Write("Enter your starting money : ");
                input = Console.ReadLine();
            }
            return balance;
        }
    }
}