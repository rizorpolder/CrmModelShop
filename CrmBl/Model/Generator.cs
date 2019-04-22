using System;
using System.Collections.Generic;

namespace CrmBl.Model
{
    public class Generator
    {

        public List<Customer> Customers { get; set; } = new List<Customer>();
        public List<Product> Products { get; set; } = new List<Product>();
        public List<Seller> Sellers { get; set; } = new List<Seller>();

        private Random rnd = new Random();

        public List<Customer> GetNewCustomer(int count)
        {
            var result = new List<Customer>();
            for (int i = 0; i < count; i++)
            {
                var customer = new Customer()
                {
                    CustomerId = Customers.Count,
                    Name = GetRandomtext()

                };
                Customers.Add(customer);
                result.Add(customer);
            }

            return result;
        }

        public List<Seller> GetNewSeller(int count)
        {
            var result = new List<Seller>();
            for (int i = 0; i < count; i++)
            {
                var seller = new Seller()
                {
                    SellerId = Sellers.Count,
                    Name = GetRandomtext()

                };
                Sellers.Add(seller);
                result.Add(seller);
            }

            return result;
        }

        public List<Product> GetNewProducts(int count)
        {
            var result = new List<Product>();
            for (int i = 0; i < count; i++)
            {
                var product = new Product()
                {
                    ProductId = Products.Count,
                    Name = GetRandomtext(),
                    Count = rnd.Next(10, 1000),
                    Price = (decimal)(rnd.Next(5, 100000) + rnd.NextDouble())

                };
                Products.Add(product);
                result.Add(product);
            }

            return result;
        }

        public List<Product> GetRandomProduct( int min, int max)
        {
            var result = new List<Product>();
            var count = rnd.Next(min, max);
            for (int i = 0; i < count; i++)
            {
                result.Add(Products[rnd.Next(Products.Count - 1)]);
            }

            return result;
        }

        private static string GetRandomtext()
        {
            return Guid.NewGuid().ToString().Substring(0, 5);
        }

    }
}
