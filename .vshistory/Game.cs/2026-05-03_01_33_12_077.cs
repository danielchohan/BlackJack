using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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
            Setup();
            do
            {
                PlayRound();
            }while(!_player.isBroke());
        }

        public void Setup()
        {
            string playerName;
            uint playerMoney;
            _deck = new Deck();
            _deck.ShuffleDeck();

            Console.WriteLine("Welcome to Blackjack!");
            Console.Write("Enter your name : ");
            playerName = StringValidation(Console.ReadLine());
            Console.Write("Enter your starting money : ");
            playerMoney = BalanceValidation(Console.ReadLine());
            _player = new Player(playerName, playerMoney);
            _dealer = new Dealer();
        }
        public void PlayRound()
        {
            DealInitialCards();
            PlayerTurn();
        }

        public void DealInitialCards()
        {
            for(int i = 0; i <2; i++)
            {
                _player.Hand.AddCard(_deck.DealCards(_player));
                _dealer.Hand.AddCard(_deck.DealCards(_player));
            }
        }

        private void DisplayTable(bool showDealerCard)
        {
            Console.Clear();
            for(int i = 0; i < _dealer.Hand.GetCards().Count; i++)
            {
                if(i == MIN_VAL && !showDealerCard)
                {
                    Console.WriteLine("Dealer's Card: [Hidden]");
                }
                else
                {
                    Console.WriteLine($"Dealer's Card: {_dealer.Hand.GetCards()[i]}");
                }
            }
            foreach (Card card in _player.Hand.GetCards())
            {
                Console.WriteLine($"Player's Card: {card}");
            }
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
                    _player.TakeCard(_deck.DealCards(_player));
                }
                else if (choice != "s")
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice. Please enter 'h' to hit or 's' to stand.");
                    Console.ResetColor();
                }
            } while (choice != "s" && !_player.Hand.IsBust());
        }
        private string StringValidation(string input)
        {
            while (string.IsNullOrEmpty(input))
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Input cannot be empty. Please enter a valid name.");
                Console.ResetColor();
                Console.Write("Enter your name : ");
                input = Console.ReadLine();
            }
            return input;
        }
        private uint BalanceValidation(string input)
        {
            uint balance;
            while (!uint.TryParse(input, out balance) || balance <= 0)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter a positive number for your starting money.");
                Console.ResetColor();
                Console.Write("Enter your starting money : ");
                input = Console.ReadLine();
            }
            return balance;
        }
    }
}