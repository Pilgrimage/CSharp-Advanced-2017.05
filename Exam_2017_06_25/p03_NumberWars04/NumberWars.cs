namespace p03_NumberWars04
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class NumberWars
    {
        public static void Main()
        {
            // Solution from Martin Hadjiev

            var firstPalyerCards = new Queue<string>(Console.ReadLine().Split());
            var secondPlayerCards = new Queue<string>(Console.ReadLine().Split());

            int counter = 0;

            while (firstPalyerCards.Count > 0 && secondPlayerCards.Count > 0 && counter < 1000000)
            {
                counter++;

                var fpCard = firstPalyerCards.Dequeue();
                var spCard = secondPlayerCards.Dequeue();

                var p1 = int.Parse(fpCard.Substring(0, fpCard.Length - 1));
                var p2 = int.Parse(spCard.Substring(0, spCard.Length - 1));

                if (p1 > p2)
                {
                    firstPalyerCards.Enqueue(fpCard);
                    firstPalyerCards.Enqueue(spCard);
                }
                else if (p2 > p1)
                {
                    secondPlayerCards.Enqueue(spCard);
                    secondPlayerCards.Enqueue(fpCard);
                }
                else
                {
                    //  Here we are in WAR XX
                    var cards = new List<string>();
                    cards.Add(fpCard);
                    cards.Add(spCard);

                    WAR:
                    {
                        if (secondPlayerCards.Count < 3 || firstPalyerCards.Count < 3)      // Има ли играч с по-малко от 3 карти
                        {
                            if (secondPlayerCards.Count == firstPalyerCards.Count)      // ??? определя равният брой като равни без сравнение
                            {
                                Console.WriteLine($"Draw after {counter} turns");
                            }
                            else if (secondPlayerCards.Count > firstPalyerCards.Count)      
                            {
                                Console.WriteLine($"Second player wins after {counter} turns"); // GAME Winner
                            }
                            else
                            {
                                Console.WriteLine($"First player wins after {counter} turns");  // GAME Winner
                            }
                            return;
                        }

                        var fpSum = 0;
                        var spSum = 0;

                        for (int i = 0; i < 3; i++)
                        {
                            fpSum += firstPalyerCards.Peek().Last();
                            spSum += secondPlayerCards.Peek().Last();
                            cards.Add(firstPalyerCards.Dequeue());
                            cards.Add(secondPlayerCards.Dequeue());
                        }

                        if (fpSum > spSum)
                        {
                            foreach (var card in cards.OrderByDescending(c => int.Parse(c.Substring(0, c.Length - 1))).ThenByDescending(c => c.Last()))
                            {
                                firstPalyerCards.Enqueue(card);
                            }
                        }
                        else if (spSum > fpSum)
                        {
                            foreach (var card in cards.OrderByDescending(c => int.Parse(c.Substring(0, c.Length - 1))).ThenByDescending(c => c.Last()))
                            {
                                secondPlayerCards.Enqueue(card);
                            }
                        }
                        else
                        {
                            goto WAR;
                        }

                    }

                }
            }   // end of while loop




            if (firstPalyerCards.Count > 0 && secondPlayerCards.Count <= 0)
            {
                Console.WriteLine($"First player wins after {counter} turns");
            }
            else if (firstPalyerCards.Count <= 0 && secondPlayerCards.Count > 0)
            {
                Console.WriteLine($"Second player wins after {counter} turns");
            }
            else if (counter >= 1000000)
            {
                if (firstPalyerCards.Count > secondPlayerCards.Count)
                {
                    Console.WriteLine($"First player wins after {counter} turns");
                }
                else if (secondPlayerCards.Count > firstPalyerCards.Count)
                {
                    Console.WriteLine($"Second player wins after {counter} turns");
                }
                else
                {
                    Console.WriteLine($"Draw after {counter} turns");
                }
            }
            else
            {
                Console.WriteLine($"Draw after {counter} turns");
            }



        }
    }
}
