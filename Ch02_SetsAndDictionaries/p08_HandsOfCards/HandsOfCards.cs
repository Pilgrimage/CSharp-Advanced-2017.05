namespace p08_HandsOfCards
{
    using System;
    using System.Collections.Generic;

    public class HandsOfCards
    {
        public static void Main()
        {
            Dictionary<string, HashSet<string>> playTable = new Dictionary<string, HashSet<string>>();

            string playerCards = Console.ReadLine();

            while (playerCards != "JOKER")
            {
                string[] parameters = playerCards.Split(':');
                string playerName = parameters[0];
                string[] playersCards = parameters[1].Split(new char[] { ' ',',' }, StringSplitOptions.RemoveEmptyEntries);

                if (playTable.ContainsKey(playerName))
                {
                    playTable[playerName].UnionWith(playersCards);
                }
                else
                {
                    HashSet<string> newSet = new HashSet<string>(playersCards);
                    playTable.Add(playerName, newSet);
                }

                playerCards = Console.ReadLine();
            }

            foreach (var player in playTable)
            {
                string name = player.Key;
                int cValue = 0;

                foreach (var card in player.Value)
                {
                    cValue += cardValue(card);
                }

                Console.WriteLine($"{name}: {cValue}");
            }

        }

        private static int cardValue(string card)
        {
            int length = card.Length;

            string cardPowerStr = card.Substring(0, length - 1);
            int cardPower = 0;

            if (cardPowerStr.Length == 1 && cardPowerStr[0] <=58)
            {
                cardPower = int.Parse(cardPowerStr);
            }
            else
            {
                switch (cardPowerStr)
                {
                    case "10":
                        cardPower = 10;
                        break;
                    case "J":
                        cardPower = 11;
                        break;
                    case "Q":
                        cardPower = 12;
                        break;
                    case "K":
                        cardPower = 13;
                        break;
                    case "A":
                        cardPower = 14;
                        break;
                }
            }

            char cardMultiplyerStr = card[length - 1]; ;
            int cardMultiplyer = 0;

            switch (cardMultiplyerStr)
            {
                case 'C':
                    cardMultiplyer = 1;
                    break;
                case 'D':
                    cardMultiplyer = 2;
                    break;
                case 'H':
                    cardMultiplyer = 3;
                    break;
                case 'S':
                    cardMultiplyer = 4;
                    break;
            }

            return cardPower * cardMultiplyer;
        }
    }
}
