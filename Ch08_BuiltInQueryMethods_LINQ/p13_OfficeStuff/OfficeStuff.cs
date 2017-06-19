namespace p13_OfficeStuff
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class OfficeStuff
    {
        public static void Main()
        {
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


            var groupedCompanies = orders
                .GroupBy(c => c.CompanyName)
                .OrderBy(c => c.Key);

            foreach (var company in groupedCompanies)
            {
                Console.Write($"{company.Key}: ");
                var products = company
                    .GroupBy(p => p.ProductName)
                    .Select(x => new
                    {
                        ProductName = x.Key,
                        Amount = x.Sum(y => y.Amount)
                    });

                Console.WriteLine(string.Join(", ", products.Select(prod => $"{prod.ProductName}-{prod.Amount}")));
            }
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
