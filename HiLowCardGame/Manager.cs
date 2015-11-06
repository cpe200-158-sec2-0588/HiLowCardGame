using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiLowCardGame
{
    class Manager
    {
        private Player[] player;

        public Manager()
        {

        }

        public void Initial()
        {
            Console.WriteLine("Initialing Game...");
            player = new Player[2];
            Deck deck = new Deck();

            Console.Write("Player 1 Name : ");
            string p1name = Console.ReadLine();
            Console.Write("Player 2 Name : ");
            string p2name = Console.ReadLine();

            deck.CreateDeck();
            deck.ShuffleDeck();

            player[0] = new Player(p1name, deck.SplitDeckFront(2));
            player[1] = new Player(p2name, deck.SplitDeckBack(2));
        }

        public void StartGame()
        {
            Console.WriteLine("Start Game");
            int round = 1;
            while (!isEnd())
            {
                Console.WriteLine("\n\nPress any keys to play Round " + ++round);
                Console.ReadKey();
                Compare(player[0].Draw(), player[1].Draw(), 1);
                Console.WriteLine($"{player[0].Name} has {player[0].Score} Cards ");
                Console.WriteLine($"{player[1].Name} has {player[1].Score} Cards ");
            }
        }

        private bool isEnd()
        {
            if (!(player[0].deck.isEmpty() || player[1].deck.isEmpty()))
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }

        private void Compare(Card p1,Card p2, int time)
        {
            if (time <= 3)
            {
                Console.WriteLine($"{p1} vs {p2} ");
                if (p1.Rank < p2.Rank)
                {
                    player[0].GetCard(player[1].GiveCard(1));
                }
                else if (p1.Rank > p2.Rank)
                {
                    player[1].GetCard(player[0].GiveCard(1));
                }
                else
                {
                    Console.WriteLine("Draw (" + p1 + " , " + p2 + ")");

                    int numberCards = p1.Rank;

                    Card[] p1cards = player[0].PeekCard(numberCards + 1);
                    Card[] p2cards = player[1].PeekCard(numberCards + 1);

                    if (p1cards[p1cards.Length - 1].Rank < p2cards[p2cards.Length - 1].Rank)
                    {
                        player[0].GetCard(player[1].GiveCard(numberCards + 1));
                    }
                    else if (p1cards[p1cards.Length - 1].Rank > p2cards[p2cards.Length - 1].Rank)
                    {
                        player[1].GetCard(player[0].GiveCard(numberCards + 1));
                    }
                    else
                    {
                        Console.WriteLine("Draw (" + p1cards[p1cards.Length - 1] + " , " + p2cards[p2cards.Length - 1] + ") " + time + " round");
                        Console.Write(player[0].Name + " ");
                        player[0].deck.ShuffleDeck();
                        Console.Write(player[1].Name + " ");
                        player[1].deck.ShuffleDeck();
                        Compare(player[0].Draw(), player[1].Draw(), time + 1);
                    }
                }
            }
            else
            {

            }

        }

        public void EndGame()
        {
            Console.WriteLine(WhoWin());
            Console.ReadKey();
        }

        private string WhoWin()
        {
            Console.WriteLine($"Player 1({player[0].Name})" + " " + player[0].Score + " points");
            Console.WriteLine($"Player 2({player[1].Name})" + " " + player[1].Score + " points");
            if (player[0].Score > player[1].Score)
            {
                return $"Player 1({player[0].Name}) wins";
            }
            else if (player[1].Score > player[0].Score)
            {
                return $"Player 1({player[1].Name}) wins";
            }
            else
            {
                return "Draw";
            }
        }
    }
}
