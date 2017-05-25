using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using App.Core.Models;
using App.Core.Repo;

namespace App.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            x:
            System.Console.Clear();
            System.Console.WriteLine(@"Insert\t: Press 1");
            System.Console.WriteLine(@"Edit\t: Press 2");
            int choice = System.Convert.ToInt32(System.Console.ReadLine());
            switch (choice)
            {
                case 1 :
                    Insert();
                    goto x;
                    break;
                case 2:
                    Edit();
                    goto x;
                    break;
                default:
                    System.Console.ReadKey();
                    break;
            }
        }

        private static void Edit()
        {
            OrderRepo orderRepo = new OrderRepo();
            Order order = new Order
            {
                OrderId = 2,
                OrderBy = "Hassan",
                OrderItems = new List<OrderItem>
                {
                    new OrderItem{ItemName = "Smart Watch",Price = 10000, OrderId = 2},
                    new OrderItem{ItemName = "Smart Phone",Price = 20000, OrderId = 2 }
                }
            };

            bool flag= orderRepo.Edit(order);
            if (!flag) System.Console.WriteLine("Data not updated");
            System.Console.WriteLine("Data updated");
            System.Console.ReadKey();
        }

        private static void Insert()
        {
            OrderRepo  orderRepo = new OrderRepo();
            Order order = new Order
            {
                OrderItems = new List<OrderItem>
                {
                    new OrderItem{ItemName = "Pant", Price = 450},
                    new OrderItem{ItemName = "Shirt", Price = 330},
                    new OrderItem{ItemName = "Cap", Price = 220},
                    new OrderItem{ItemName = "Shocks", Price = 200}
                }
            };
            bool flag = orderRepo.Insert(order);
            if(!flag) System.Console.WriteLine("Data not saved");
            System.Console.WriteLine("Data saved");
            System.Console.ReadKey();
        }
    }
}
