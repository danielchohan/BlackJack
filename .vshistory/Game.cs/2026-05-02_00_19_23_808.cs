using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    internal class Game
    {
        public void Start()
        {
            Deck deck = new Deck();
            deck.ShuffleDeck();
            Player player = new Player();
            Dealer dealer = new Dealer();
        }
    }
}
