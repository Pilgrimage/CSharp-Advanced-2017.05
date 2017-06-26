namespace p03_NumberWars03
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class Card
    {
        public Card(int power, char letter)
        {
            this.Power = power;
            this.Letter = Char.ToLower(letter);
        }

        public int Power { get; set; }
        public char Letter { get; set; }
    }



    public class NumberWars
    {
        public static void Main()
        {
            // Solution from tiapko

            var input = Console.ReadLine();
            var player1Cards =
                input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            // player 1 deck
            var player1 = new Queue<Card>();

            foreach (var card in player1Cards)
            {
                var card1 = new Card(int.Parse(card.Substring(0, card.Length - 1)), card[card.Length - 1]);
                player1.Enqueue(card1);
            }

            var input2 = Console.ReadLine();
            var player2Cards =
                input2.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            // player 2 deck
            var player2 = new Queue<Card>();

            foreach (var card in player2Cards)
            {
                var card2 = new Card(int.Parse(card.Substring(0, card.Length - 1)), card[card.Length - 1]);
                player2.Enqueue(card2);
            }

            if (input == input2)
            {
                Console.WriteLine($"Draw after {1} turns");
                return;
            }



            // loops up to 1_000_000 turns
            for (int i = 0; i < 1000000; i++)
            {

                // game card pool
                var cardsPool = new List<Card>();

                // player 1 gets a card
                var p1Card = player1.Dequeue();
                cardsPool.Add(p1Card);

                // player 2 gets a card
                var p2Card = player2.Dequeue();
                cardsPool.Add(p2Card);




                // if power is equal = WAR start
                if (p1Card.Power == p2Card.Power)
                {
                    var p1LetterSum = 0;
                    var p2LetterSum = 0;




                    do
                    {

                        if (player1.Count < 3 && player2.Count > 3)
                        {
                            // p1 wins
                            Console.WriteLine($"Second player wins after {i + 1} turns");
                            return;
                        }

                        if (player1.Count > 3 && player2.Count < 3)
                        {
                            // p1 wins
                            Console.WriteLine($"First player wins after {i + 1} turns");
                            return;
                        }

                        // So here we have two players with more from 3 cards !!!
                        p1LetterSum = 0;
                        p2LetterSum = 0;


                        for (int j = 0; j < 3; j++)
                        {
                            p1Card = player1.Dequeue();
                            cardsPool.Add(p1Card);
                            p1LetterSum += GetNumericValue(p1Card.Letter);

                            p2Card = player2.Dequeue();
                            cardsPool.Add(p2Card);
                            p2LetterSum += GetNumericValue(p2Card.Letter);

                            if (player1.Count == player2.Count && (player1.Count == 0 && player2.Count == 0) && (p1LetterSum == p2LetterSum))
                            {
                                Console.WriteLine($"Draw after {i + 1} turns");
                                return;
                            }
                        }


                    } while (p1LetterSum == p2LetterSum);       // end of do-while



                    if (p1LetterSum > p2LetterSum)
                    {
                        // p1 gets all the cards
                        cardsPool = cardsPool.OrderByDescending(x => x.Power).ThenByDescending(x => x.Letter).ToList();
                        foreach (var card in cardsPool)
                        {
                            player1.Enqueue(card);
                        }
                    }
                    else if (p1Card.Power < p2Card.Power)
                    {
                        // p2 gets all the cards
                        cardsPool = cardsPool.OrderByDescending(x => x.Power).ThenByDescending(x => x.Letter).ToList();
                        foreach (var card in cardsPool)
                        {
                            player2.Enqueue(card);
                        }
                    }


                }




                else
                {
                    if (p1Card.Power > p2Card.Power)
                    {
                        // p1 gets all the cards
                        cardsPool = cardsPool.OrderByDescending(x => x.Power).ThenByDescending(x => x.Letter).ToList();
                        foreach (var card in cardsPool)
                        {
                            player1.Enqueue(card);
                        }
                    }
                    else if (p1Card.Power < p2Card.Power)
                    {
                        // p2 gets all the cards
                        cardsPool = cardsPool.OrderByDescending(x => x.Power).ThenByDescending(x => x.Letter).ToList();
                        foreach (var card in cardsPool)
                        {
                            player2.Enqueue(card);
                        }
                    }
                }


                // if one of them enteres with no cards (or both) 

                if (GetWinner(player1, player2, i))
                {
                    return;
                }
            }




            if ((player1.Count == player2.Count))
            {
                {
                    Console.WriteLine($"Draw after 1000000 turns");
                    return;
                }
            }

            if (player1.Count < player2.Count)
            {
                Console.WriteLine($"Second player wins after 1000000  turns");
            }
            else
            {
                Console.WriteLine($"First player wins after 1000000  turns");

            }


        }






        private static int GetNumericValue(char ch)
        {
            return (int)ch - 96;
        }


        private static bool GetWinner(Queue<Card> player1, Queue<Card> player2, int turns)
        {
            //Console.WriteLine($"HMMMMMMMM{player1.Count} - {player2.Count}");
            if ((player1.Count == player2.Count) && player1.Count == 0)
            {
                Console.WriteLine($"Draw after {turns + 1} turns");
                return true;
            }
            else if (player1.Count == 0 && player2.Count > 0)
            {
                // p2 wins
                Console.WriteLine($"Second player wins after {turns + 1} turns");
                return true;
            }
            else if (player2.Count == 0 && player1.Count > 0)
            {
                // p1 wins
                Console.WriteLine($"First player wins after {turns + 1} turns");
                return true;
            }

            return false;
        }


    }
}
