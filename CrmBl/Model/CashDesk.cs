﻿using System;
using System.Collections.Generic;

namespace CrmBl.Model
{
    public class CashDesk
    {
        CrmContext db = new CrmContext();
        public int Number { get; set; }
        public int MaxQueueLength { get; set; }

        public int ExitCustomer { get; set; } = 5;

        public Seller Seller { get; set; }

        public Queue<Cart> Queue { get; set; }

        public bool IsModel { get; set; }

        public CashDesk(int number, Seller seller)
        {
            Number = number;
            Seller = seller;
            Queue = new Queue<Cart>();
            IsModel = true;
        }

        public void Enqueue(Cart cart)
        {
            if (Queue.Count <= MaxQueueLength)
            {
                Queue.Enqueue(cart);
            }
            else
            {
                ExitCustomer++;
            }
        }

        public decimal Dequeue()
        {
            decimal sum = 0;
            var card = Queue.Dequeue();
            if (card != null)
            {
                var check = new Check()
                {
                    SellerId = Seller.SellerId,
                    Seller = Seller,
                    CustomerId = card.Customer.CustomerId,
                    Customer = card.Customer,
                    Created = DateTime.Now
                };
                if (!IsModel)
                {
                    db.Checks.Add(check);
                    db.SaveChanges();
                }
                else
                {
                    check.CheckId = 0;
                }

                var sells = new List<Sell>();

                foreach (Product product in card)
                {
                    if (product.Count > 0)

                    {
                        var sell = new Sell()
                        {
                            CheckId = check.CheckId,
                            Check = check,
                            ProductId = product.ProductId,
                            Product = product
                        };

                        sells.Add(sell);
                        if (!IsModel)
                        {
                            db.Sells.Add(sell);
                        }

                        product.Count--;
                        sum += product.Price;
                    }
                }

                if (!IsModel)
                {
                    db.SaveChanges();
                }
            }

            return sum;
        }
    }
}