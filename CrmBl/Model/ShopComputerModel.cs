﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CrmBl.Model
{
    public class ShopComputerModel
    {
        private Random rnd = new Random();
        Generator Generator = new Generator();
        private bool isWorking = false;
        public List<CashDesk> CashDesks { get; set; } = new List<CashDesk>();
        public List<Cart> Carts { get; set; } = new List<Cart>();
        public List<Check> Checks { get; set; } = new List<Check>();
        public List<Sell> Sells { get; set; } = new List<Sell>();
        public Queue<Seller> Sellers { get; set; } = new Queue<Seller>();

        public ShopComputerModel()
        {
            var sellers = Generator.GetNewSeller(20);
            Generator.GetNewProducts(100);
            Generator.GetNewCustomer(10);
            foreach (var seller in sellers)
            {
                Sellers.Enqueue(seller);
            }

            for (int i = 0; i < 3; i++)
            {
                CashDesks.Add(new CashDesk(CashDesks.Count, Sellers.Dequeue()));
            }
        }

        public void Start()
        {
            isWorking = true;
            Task.Run(() => CreateCarts(10, 1000));

            var cashDeskTasks = CashDesks.Select(c=>new Task(()=> CashDeskWork(c, 1000)));
            foreach (var task in cashDeskTasks)
            {
                task.Start();
            }
        }

        public void Stop()
        {
            isWorking = false;
        }

        private void CashDeskWork(CashDesk cashDesk, int sleep)
        {
            while (isWorking)
            {
                if (cashDesk.Count > 0)
                {
                    cashDesk.Dequeue();
                    Thread.Sleep(sleep);
                }
            }
        }

        private void CreateCarts(int customerCounts, int sleep)
        {
            while (isWorking)
            {
                var customers = Generator.GetNewCustomer(customerCounts);

                foreach (var customer in customers)
                {
                    var cart = new Cart(customer);
                    foreach (var product in Generator.GetRandomProduct(10,30))
                    {
                        cart.AddProduct(product);
                    }
                    var cash = CashDesks[rnd.Next(CashDesks.Count)]; //TODO
                    cash.Enqueue(cart);
                }

                Thread.Sleep(sleep);
            }

        }
    }
}

