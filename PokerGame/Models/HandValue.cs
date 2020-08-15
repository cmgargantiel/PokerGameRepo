using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame.Models
{
    public class HandValue
    {
        public PokerHands pokerHand;
        public double value = 0;
        private List<Cards> hand;

        public HandValue(List<Cards> hand)
        {
            this.hand = hand;
            this.pokerHand = GetHandRank();
        }

        public HandValue()
        {
        }

        private PokerHands GetHandRank()
        {
            PokerHands result = PokerHands.HighCard; //min value is the default
            value = GetHighCardValue();

            if (IsFourOfAKind())
            {
                result = PokerHands.FourOfAKind;
            }
            else if (IsFullHouse())
            {
                result = PokerHands.FullHouse;
            }
            else if (IsFlush())
            {
                result = PokerHands.Flush;
            }
            else if (IsThreeOfAKind())
            {
                result = PokerHands.ThreeOfAKind;
            }


            return result;
        }

        private bool IsFourOfAKind()
        {
            bool result = false;
            var cardCount = hand.GroupBy(x => x.Rank).OrderByDescending(y => y.Count());

            if (cardCount.ElementAt(0).Count() == 4)
            {
                value = (int)cardCount.ElementAt(0).Key * 14 + (int)cardCount.ElementAt(1).Key; //ensure that quad gets higher priority
                result = true;
            }

            return result;
        }

        private bool IsThreeOfAKind()
        {
            bool result = false;
            var cardCount = hand.GroupBy(x => x.Rank).OrderByDescending(y => y.Count());

            if (cardCount.ElementAt(0).Count() == 3)
            {
                for(int ctr = cardCount.Count(); ctr > 0 ;ctr--)
                {
                    value += Math.Pow(14, ctr) * (int)cardCount.ElementAt(0).Key; //trio gets highest priority
                }
                result = true;
            }

            return result;
        }

        private bool IsFullHouse()
        {
            bool result = false;
            var cardCount = hand.GroupBy(x => x.Rank).OrderByDescending(y => y.Count());

            if (cardCount.ElementAt(0).Count() == 3 && cardCount.ElementAt(1).Count() == 2)
            {
                value = (int)cardCount.ElementAt(0).Key * 14 + (int)cardCount.ElementAt(1).Key; //ensure that trio gets higher priority
                result = true;
            }

            return result;
        }

        private bool IsFlush()
        {
            //value same as high card
            bool result = false;

            result = hand.GroupBy(x => x.Suit).Count() == 1;

            return result;
        }

        private double GetHighCardValue()
        {
            double val = 0;

            var sorted = hand.OrderBy(x => x.Rank).ToList<Cards>();

            for (int ctr = 0; ctr < sorted.Count; ctr++)
            {
                if (ctr == 0)
                {
                    val += (int)sorted[ctr].Rank;
                }
                val += Math.Pow(14, ctr) * (int)sorted[ctr].Rank;
            }

            return val;
        }
    }

    public enum PokerHands
    {
        [Description("Flush")]
        Flush = 300,
        [Description("Four of a Kind")]
        FourOfAKind = 500,
        [Description("Three of a Kind")]
        ThreeOfAKind = 200,
        [Description("Full House")]
        FullHouse = 400,
        [Description("High Card")]
        HighCard = 0
    }

}
