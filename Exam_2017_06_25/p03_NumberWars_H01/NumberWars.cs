namespace p03_NumberWars_H01
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using System.Linq;

    public class Card
    {
        public int Num { get; set; }
        public char Letter { get; set; }

        public Card(int num, char letter)
        {
            this.Num = num;
            this.Letter = letter;
        }
    }

    public class NumberWars
    {
        public static Queue<Card> player1 = new Queue<Card>();
        public static Queue<Card> player2 = new Queue<Card>();
        public static List<Card> desk = new List<Card>();

        public static void Main()
        {

            int turns = 0;
            bool player1win = false;
            bool player2win = false;

            string pattern = @"(\d+)(\w)";
            Regex regex = new Regex(pattern);

            // Fill collection of player 1
            string player1input = Console.ReadLine();
            MatchCollection matches = regex.Matches(player1input);
            foreach (Match match in matches)
            {
                player1.Enqueue(new Card(int.Parse(match.Groups[1].Value), char.Parse(match.Groups[2].Value.ToLower())));
            }

            // Fill collection of player 2
            string player2input = Console.ReadLine();
            matches = regex.Matches(player2input);
            foreach (Match match in matches)
            {
                player2.Enqueue(new Card(int.Parse(match.Groups[1].Value), char.Parse(match.Groups[2].Value.ToLower())));
            }


            // Start the Game

            while (player1.Count > 0 && player2.Count > 0 && player1win == false && player2win == false)
            {
                if (turns > 1000000)
                {
                    break;
                }
                Card card1 = player1.Dequeue();
                Card card2 = player2.Dequeue();
                desk.Add(card1);
                desk.Add(card2);

                if (card1.Num > card2.Num)
                {
                    // player 1 win
                    player1 = AddCards(player1);
                    desk.Clear();
                }
                else if (card1.Num < card2.Num)
                {
                    // player 2 win
                    player2 = AddCards(player2);
                    desk.Clear();
                }
                else
                {
                    // players in WAR

                    while (!player1win && !player2win)
                    {
                        int count = 3;          // number of cards in war by default

                        // Check for end of Game
                        if (player1.Count < 3 || player2.Count < 3)
                        {
                            if (player1.Count > player2.Count)
                            {
                                player1win = true; // Player 1 wins game
                                Print(turns);
                                //player1.Clear();
                                //break;
                                return;
                            }
                            else if (player1.Count < player2.Count)
                            {
                                player2win = true; // Player 2 wins game
                                Print(turns);
                                //player2.Clear();
                                //break;
                                return;
                            }
                            else if (player1.Count == 0 && player2.Count == 0)
                            {
                                Print(turns);
                                //break;
                                return;
                            }
                            else
                            {
                                count = player1.Count;
                            }
                        }

                        // ********** Start of active WAR **********

                        var player1war = 0;
                        var player2war = 0;

                        // calculate player1
                        for (int i = 0; i < count; i++)
                        {
                            Card card = player1.Dequeue();
                            player1war += card.Letter;
                            desk.Add(card);
                        }

                        // calculate player2
                        for (int i = 0; i < count; i++)
                        {
                            Card card = player2.Dequeue();
                            player2war += card.Letter;
                            desk.Add(card);
                        }


                        if (player1war > player2war)
                        {
                            // Player 1 wins the war
                            player1 = AddCards(player1);
                            desk.Clear();
                            player1win = true;
                        }
                        else if (player1war < player2war)
                        {
                            // Player 2 wins the war
                            player2 = AddCards(player2);
                            desk.Clear();
                            player2win = true;
                        }
                        else if (player1.Count == 0 && player2.Count == 0)
                        {
                            Print(turns);
                            //break;
                            return;
                        }

                    }

                }

                turns++;
            }


            Print(turns);
        }



        public static Queue<Card> AddCards(Queue<Card> player)
        {
            Queue<Card> result = new Queue<Card>(player);
            foreach (Card card in desk.OrderByDescending(x => x.Num).ThenByDescending(x => x.Letter))
            {
                result.Enqueue(card);
            }
            return result;
        }


        public static void Print(int turns)
        {
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

    }
}
