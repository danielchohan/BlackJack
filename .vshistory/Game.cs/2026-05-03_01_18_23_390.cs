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

        #region Data Members

        private Deck _deck;
        private Player _player;
        private Dealer _dealer;

        #endregion
        public void Start()
        {
            string playerName;
            uint playerMoney;
            _deck = new Deck();
            _deck.ShuffleDeck();

            Console.WriteLine("Welcome to Blackjack!");
            Console.Write("Enter your name : ");
            string name = Console.ReadLine();
            StringValidation(name);


        }

        public string StringValidation(string input)
        {
            while(string.IsNullOrEmpty(input))
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Input cannot be empty. Please enter a valid name.");
                Console.ResetColor();
                Console.Write("Enter your name : ");
                input = Console.ReadLine();
            }


            return input;
        }
    }
}
