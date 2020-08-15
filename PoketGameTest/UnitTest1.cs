using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerGame;
using PokerGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PoketGameTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            List<Player> players = new List<Player>();
            players.Add(new Player("Joe", StringToCards("3H,6H,8H,JH,KH")));
            players.Add(new Player("Jen", StringToCards("3C,3D,3S,8C,10H")));
            players.Add(new Player("Bob", StringToCards("2H,5C,7S,10C,AC")));

            Player expected = new Player();
            expected.PlayerName = "Joe";
            expected.Hand = StringToCards("3H,6H,8H,JH,KH");
            var handValue = new HandValue();
            handValue.pokerHand = PokerHands.Flush;
            handValue.value = 531247;

            

        }

        public List<Cards> StringToCards(string cards)
        {
            return cards.Split(',').Select(x => new { suit = (Suits)Enum.Parse(typeof(Suits), x.Substring(x.Length - 1)), rank = x.Substring(0, x.Length - 1) })
                .Select(x => new Cards(x.suit, x.rank)).OrderByDescending(x => x.Rank).ThenBy(y => y.Suit).ToList<Cards>(); ;
        }
    }
}
