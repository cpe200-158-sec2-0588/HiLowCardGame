using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiLowCardGame
{
    class Player
    {

        public String Name { get;}

        private int score;

        public int Score
        {
            get { return score; }
        }

        public Deck deck { get;}

        public Player(String Name, Deck deck)
        {
            this.Name = Name;
            this.deck = deck;
            this.score = 0;
        }

        public void ReturnCard(Card[] cards)
        {
            foreach (Card card in cards)
                deck.AddCard(card);
        }

        public Card Draw()
        {
            return deck.Draw();
        }

        public Card[] PeekCard(int number)
        {
            List<Card> cards = new List<Card>();
            Deck tmp = new Deck(deck);
            for (int i = 0; i < number; i++)
            {
                if(!tmp.isEmpty())
                    cards.Add(tmp.RemoveLast());
            }
            return cards.ToArray<Card>() ;
        }

        public void ThrowCard(int number)
        {
            for (int i = 0; i < number; i++)
            {
                if (!deck.isEmpty())
                    deck.RemoveLast();
            }
        }

        public void GetCard(int giveCards)
        {
            ThrowCard(giveCards);
            score += giveCards;
            Console.WriteLine(Name + " wins " + giveCards + (giveCards > 1 ? " cards" : " card"));
        }

        public int GiveCard(int cards)
        {
            ThrowCard(cards);
            return cards;
        }
    }
}
