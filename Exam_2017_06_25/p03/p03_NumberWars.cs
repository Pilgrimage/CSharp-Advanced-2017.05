namespace p03
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using System.Linq;

    public class Card
    {
        public int Num { get; set; }
        public char Letter { get; set; }
        public Card(int cardNum, char cardLet)
        {
            this.Num = cardNum;
            this.Letter = cardLet;
        }
    }
    public class p03_NumberWars
    {
        public static Queue<Card> player1 = new Queue<Card>();
        public static Queue<Card> player2 = new Queue<Card>();
        public static List<Card> desk = new List<Card>();

        public static void Main()
        {
            string pattern = @"(\d+)(\w)";

            int turns = 0;
            string winner = "";

            Regex regex = new Regex(pattern);
            string player1cards = Console.ReadLine();
            string player2cards = Console.ReadLine();

            MatchCollection matches = regex.Matches(player1cards);

            foreach (Match match in matches)
            {
                player1.Enqueue(new Card(int.Parse(match.Groups[1].Value), char.Parse(match.Groups[2].Value)));
            }

            matches = regex.Matches(player2cards);

            foreach (Match match in matches)
            {
                player2.Enqueue(new Card(int.Parse(match.Groups[1].Value), char.Parse(match.Groups[2].Value.ToLower())));
            }


            // Start the Game

            while (player1.Count > 0 &&
                   player2.Count > 0 &&
                   turns < 1000000)
            {
                turns++;

                Card card1 = player1.Dequeue();
                Card card2 = player2.Dequeue();

                if (card1.Num > card2.Num)
                {
                    if (CardComparator(card1, card2) == 1)
                    {
                        player1.Enqueue(card2);
                        player1.Enqueue(card1);
                    }
                    else
                    {
                        player1.Enqueue(card1);
                        player1.Enqueue(card2);
                    }
                }
                else if (card1.Num < card2.Num)
                {
                    if (CardComparator(card1, card2) == -1)
                    {
                        player2.Enqueue(card2);
                        player2.Enqueue(card1);
                    }
                    else
                    {
                        player2.Enqueue(card1);
                        player2.Enqueue(card2);
                    }
                }
                else
                {
                    // WAR
                    desk.Add(card1);
                    desk.Add(card2);
                    //int result;
                    //int count = 3;

                    while (true)
                    {
                        int count = 3;
                        if (player1.Count < 3 || player2.Count < 3)
                        {
                            if (player1.Count > player2.Count)
                            {
                                Console.WriteLine($"First player wins after {turns} turns");
                                return;
                            }
                            else if (player1.Count < player2.Count)
                            {
                                Console.WriteLine($"Second player wins after {turns} turns");
                                return;
                            }
                            else
                            {
                                count = player1.Count;
                            }
                        }

                        var player1war = 0;
                        var player2war = 0;

                        // player1
                        for (int i = 0; i < count; i++)
                        {
                            Card card = player1.Dequeue();
                            player1war += card.Letter;
                            desk.Add(card);
                        }

                        // player2
                        for (int i = 0; i < count; i++)
                        {
                            Card card = player2.Dequeue();
                            player2war += card.Letter;
                            desk.Add(card);
                        }

                        if (player1war > player2war)
                        {
                            player1 = AddCards(player1);
                            desk.Clear();
                            break;
                        }
                        else if (player1war < player2war)
                        {
                            player2 = AddCards(player2);
                            desk.Clear();
                            break;
                        }
                        else if (player1.Count == 0 && player2.Count == 0)
                        {
                            Console.WriteLine($"Draw after {turns} turns");
                            return;
                        }

                    }


                }







            }

            if (player1.Count > player2.Count)
            {
                Console.WriteLine($"First player wins after {turns} turns");
            }
            else if (player1.Count < player2.Count)
            {
                Console.WriteLine($"Second player wins after {turns} turns");
            }
            else
            {
                Console.WriteLine($"Draw after {turns} turns");
            }


        }

        public static int CardComparator(Card card1, Card card2)
        {
            if (card1.Num > card2.Num)
            {
                return 1;
            }
            else if (card1.Num < card2.Num)
            {
                return -1;
            }
            else
            {
                if (card1.Letter > card2.Letter)
                {
                    return 1;
                }
                else if (card1.Letter < card2.Letter)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }


        //public static int War()
        //{
        //    int count = 3;

        //    if (player1.Count < 3 || player2.Count < 3)
        //    {
        //        if (player1.Count > player2.Count)
        //        {
        //            //player 1 wins
        //            return 1;
        //        }
        //        else if (player1.Count < player2.Count)
        //        {
        //            //player 2 wins
        //            return -1;
        //        }
        //        else
        //        {
        //            count = player1.Count;
        //        }
        //    }

        //    var player1war = 0;
        //    var player2war = 0;

        //    // player1
        //    for (int i = 0; i < count; i++)
        //    {
        //        Card card = player1.Dequeue();
        //        player1war += card.Letter;
        //        desk.Add(card);
        //    }

        //    // player2
        //    for (int i = 0; i < count; i++)
        //    {
        //        Card card = player2.Dequeue();
        //        player2war += card.Letter;
        //        desk.Add(card);
        //    }

        //    if (player1war > player2war)
        //    {
        //        return 1;
        //    }
        //    else if (player1war < player2war)
        //    {
        //        return -1;
        //    }
        //    else
        //    {
        //        return 0;
        //    }
        //}


        public static Queue<Card> AddCards(Queue<Card> player)
        {
            Queue<Card> result = new Queue<Card>(player);

            foreach (Card card in desk.OrderByDescending(x => x.Num).ThenByDescending(x => x.Letter))
            {
                result.Enqueue(card);
            }

            return result;
        }
    }
}
