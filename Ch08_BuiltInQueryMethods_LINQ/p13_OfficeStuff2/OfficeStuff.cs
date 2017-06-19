namespace p13_OfficeStuff2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class OfficeStuff
    {
        public static void Main()
        {
            // one line solution

            List<Order> orders = new List<Order>();

            int orderCounts = int.Parse(Console.ReadLine());


            for (int i = 0; i < orderCounts; i++)
            {
                string[] order = Console.ReadLine()
                    .Trim('|')
                    .Split('-')
                    .Select(x => x.Trim())
                    .ToArray();

                orders.Add(new Order(order[0], order[2], int.Parse(order[1])));
            }


            orders
                .GroupBy(c => c.CompanyName)
                .OrderBy(c => c.Key)
                .Select(gr => gr
                    .GroupBy(p => p.ProductName)
                    .Select(x => new
                    {
                        CompanyName = gr.Key,
                        ProductName = x.Key,
                        Amount = x.Sum(y => y.Amount)
                    }))
                .ToList()
                .ForEach(list => Console.WriteLine($"{list.Select(x=>x.CompanyName).First()}: {string.Join(", ", list.Select(prod => $"{prod.ProductName}-{prod.Amount}"))}"));

        }
    }

    public class Order
    {
        public string CompanyName { get; set; }
        public string ProductName { get; set; }
        public int Amount { get; set; }

        public Order(string companyName, string productName, int amount)
        {
            this.CompanyName = companyName;
            this.ProductName = productName;
            this.Amount = amount;
        }
    }
}
