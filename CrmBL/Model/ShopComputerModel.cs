using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CrmBL.Model
{
    public class ShopComputerModel
    {
        Generator Generator = new Generator();
        Random rnd = new Random();
        bool isWorking = false;
        List<Task> tasks = new List<Task>();

        public List<CashDesk> CashDesks { get; set; } = new List<CashDesk>();
        public List<Cart> Carts { get; set; } = new List<Cart>();
        public List<Check> Cheks { get; set; } = new List<Check>();
        public List<Sell> Sells { get; set; } = new List<Sell>();
        public Queue<Seller> Sellers { get; set; } = new Queue<Seller>();

        public int CustomerSpeed { get; set; } = 100;
        public int CashDeskSpeed { get; set; } = 100;

        public ShopComputerModel()
        {
            var sellers = Generator.GetNewSellers(20);
            Generator.GetNewProducts(1000);
            Generator.GetNewCustomers(100);

            foreach(var seller in sellers)
            {
                Sellers.Enqueue(seller);
            }

            for(int i= 0; i < 3; i++)
            {
                CashDesks.Add(new CashDesk(CashDesks.Count, Sellers.Dequeue(), null));
            }

            
        }
        
        public void Start()
        {
            isWorking = true;
            tasks.Add(new Task(() => CreateCarts(10)));
            tasks.AddRange(CashDesks.Select(c => new Task(() => CashDeskWork(c))));
            foreach(var task in tasks)
            {
                task.Start();
            } 
        }

        public void Stop()
        {
            isWorking = false;
            //foreach (var task in tasks) 
            //{
            //    task.;           дальше все заменили на какую-то флаговую функцию token
            //}                    которая все равно не помогла решить ошибку с остановкой потоков
        }                       //  смотреть 5 видео с 1:31

        private void CashDeskWork(CashDesk cashDesk)
        {
            while(isWorking)
            if(cashDesk.Count > 0)
            {
                cashDesk.Dequeue();
                Thread.Sleep(CashDeskSpeed);
            }
        }

        private void CreateCarts(int customerCounts)
        {
            while (isWorking)
            {
                var customers = Generator.GetNewCustomers(customerCounts);

                foreach (var customer in customers)
                {
                    var cart = new Cart(customer);
                    foreach (var product in Generator.GetRandomProducts(10, 30))
                    {
                        cart.Add(product);
                    }
                    
                    var cash = CashDesks[rnd.Next(CashDesks.Count)];
                    cash.Enqueue(cart);
                }

                Thread.Sleep(CustomerSpeed);
            }
        }
    }
}
