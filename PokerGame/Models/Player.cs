using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame.Models
{
    public class Player
    {
        private string playerName;
        private List<Cards> hand;
        private HandValue handValue;

        public Player(string playerName, List<Cards> hand)
        {
            PlayerName = playerName;
            Hand = hand;
            HandRank = GetHandValue();
        }

        public Player()
        {
        }

        private HandValue GetHandValue()
        {
            HandValue handValue = new HandValue(hand);
            return handValue;

        }

        public string PlayerName { get => playerName; set => playerName = value; }
        public List<Cards> Hand { get => hand; set => hand = value; }
        public HandValue HandRank { get => handValue; set => handValue = value; }



    }
}
