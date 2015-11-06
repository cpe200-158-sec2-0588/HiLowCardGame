using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiLowCardGame
{
    class Card
    {
        public static int DIAMOND = 1;
        public static int CLUB = 2;
        public static int HEART = 3;
        public static int SPADE = 4;

        public int Suit { get; set; }
        public int Rank { get; set; }
  

        public Card(int Suit,int Rank)
        {
            this.Suit = Suit;
            this.Rank = Rank;
        }

        public override string ToString()
        {
            string rank;
            switch (Rank)
            {
                case 1:
                    rank = "A";
                    break;
                case 10:
                    rank = "10";
                    break;
                case 11:
                    rank = "J";
                    break;
                case 12:
                    rank = "Q";
                    break;
                case 13:
                    rank = "K";
                    break;
                default :
                    rank = "" + Rank;
                    break;
            }
            if(Suit == DIAMOND)
                return $"{rank}D";
            else if(Suit == CLUB)
                return $"{rank}C";
            else if(Suit == HEART)
                return $"{rank}H";
            else
                return $"{rank}S";

        }
        
    }
}
