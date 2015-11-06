using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiLowCardGame
{
    class Deck
    {
        static Random random = new Random();

        private Stack<Card> cards;

        public Stack<Card> Cards
        {
            get { return cards; }
            set { cards = value; }
        }

        public Deck(Deck tmp)
        {
            this.cards = new Stack<Card>(tmp.Cards);
        }

        public Deck()
        {
            cards = new Stack<Card>();
        }

        public Deck(Stack<Card> cards)
        {
            this.cards = cards;
        }

        public void CreateDeck()
        {
            Console.WriteLine("Creating Deck...");
            for (int suit = Card.DIAMOND; suit <= Card.SPADE; suit++)
                for (int rank = 1; rank <= 13; rank++)
                    cards.Push(new Card(suit, rank));
        }

        public void ShuffleDeck()
        {
            Console.WriteLine("Shuffling Deck...");
            Card[] card = cards.ToArray();
            for (int n = cards.Count - 1; n > 0; --n)
            {
                int randomCard = random.Next(n + 1);
                Card temp = card[n];
                card[n] = card[randomCard];
                card[randomCard] = temp;
            }
            cards = new Stack<Card>(card);
        }

        public void AddCard(Card card)
        {
            Cards.Push(card);
        }

        public bool isEmpty()
        {
            return (cards.Count <= 0) ? true : false;
        }

        public Card Draw()
        {
            return cards.Peek();
        }

        public Card RemoveLast()
        {
            return cards.Pop();
        }

        private void Show()
        {
            foreach (Card card in cards)
            {
                Console.WriteLine(card);
            }
        }

        public Deck SplitDeckFront(int part)
        {
            return new Deck(new Stack<Card>(cards.Take(cards.Count / part).ToArray()));
        }

        public Deck SplitDeckBack(int part)
        {
            return new Deck(new Stack<Card>(cards.Skip(cards.Count / part).ToArray()));
        }
    }
}
