using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame.Models
{
    public class Cards
    {
        private Suits suit;
        private Ranks rank;

        public Suits Suit { get => suit; set => suit = value; }
        public Ranks Rank { get => rank; set => rank = value; }

        public Cards(Suits s, string r)
        {
            suit = s;
            rank = Utility.GetEnumValueFromDescription<Ranks>(r);
        }
    }

    

    public enum Ranks
    {
        [Description("A")]
        Ace=14,
        [Description("K")]
        King=13,
        [Description("Q")]
        Queen=12,
        [Description("J")]
        Jack=11,
        [Description("10")]
        Ten=10,
        [Description("9")]
        Nine=9,
        [Description("8")]
        Eight=8,
        [Description("7")]
        Seven=7,
        [Description("6")]
        Six=6,
        [Description("5")]
        Five=5,
        [Description("4")]
        Four=4,
        [Description("3")]
        Three=3,
        [Description("2")]
        Two=2,
        [Description("1")]
        One=1

    }

    public enum Suits
    {
        H,
        D,
        S,
        C
    }

}
