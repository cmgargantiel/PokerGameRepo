using PokerGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame
{
    class Program
    {
        /*
         * Only the following poker hands are implemented: Flush,Four of a kind, Three of a kind, Full house and High Card
         * Input for cards are expected to be only 5 cards, separated by comma
         */
        static void Main(string[] args)
        {
            List<Player> players = new List<Player>();

            for (int ctr = 0; ctr < 3; ctr++)
            {
                Console.WriteLine($"Player{ctr + 1}");
                Console.Write("Name: ");
                var name = Console.ReadLine();

                List<Cards> sortedCard;
                do
                {
                    Console.Write("Cards at hand: ");
                    var cards = Console.ReadLine().Trim();
                    var cardList = cards.Split(',').Select(x => new { suit = (Suits)Enum.Parse(typeof(Suits), x.Substring(x.Length - 1)), rank = x.Substring(0, x.Length - 1) });
                    sortedCard = cardList.Select(x => new Cards(x.suit, x.rank)).OrderByDescending(x => x.Rank).ThenBy(y => y.Suit).ToList<Cards>();
                } while (sortedCard?.Count != 5);
                

                Player player = new Player(name, sortedCard);
                players.Add(player);
            }

            Evaluate(players);

            Console.Read();
        }

        private static void Evaluate(List<Player> players)
        {
            //evaluate the winner
            var maxValues = players.OrderByDescending(x => x.HandRank.pokerHand).ThenByDescending(y => y.HandRank.value).FirstOrDefault();
            List<Player> winners = players.Where(x => x.HandRank.pokerHand == maxValues.HandRank.pokerHand && x.HandRank.value == maxValues.HandRank.value).ToList<Player>(); //get all with same hand and value in case there are multiple winners

            Console.WriteLine("========================================================");
            Console.WriteLine("Winner(s):");

            for (int ctr = 0; ctr < winners.Count(); ctr++)
            {
                Console.Write($"{winners[ctr].PlayerName}: ");
                Console.Write(Utility.CardToString(winners[ctr].Hand));
                Console.Write($" ({Utility.GetDescriptionFromEnumValue(winners[ctr].HandRank.pokerHand)})\n");
            }
        }
    }
}
