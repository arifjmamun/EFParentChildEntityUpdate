using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using App.Core.Context;
using App.Core.Models;

namespace App.Core.Repo
{
    public class OrderRepo
    {
        public bool Insert(Order order)
        {
            using (ProductContext db = new ProductContext())
            {
                db.Orders.Add(order);
                return db.SaveChanges() > 0;
            }
        }

        public bool Edit(Order order)
        {
            using (ProductContext db = new ProductContext())
            {
                // getting exisitng data parent with child
                var exOrder = db.Orders.FirstOrDefault(x => x.OrderId == order.OrderId);
                
                if (exOrder != null)
                {
                    exOrder.OrderBy = order.OrderBy;
                    //add new child with "EntityState.Added" Mode
                    order.OrderItems.ToList().ForEach(o =>
                    {
                        if (exOrder.OrderItems.Any(x => x.OrderId == order.OrderId && x.OrderItemId != o.OrderItemId))
                        {
                            db.Entry(o).State = EntityState.Added;
                            exOrder.OrderItems.Add(o);
                        }

                    });

                    // update specific child that satisfy condition
                    var exItem = exOrder.OrderItems.FirstOrDefault(x => x.OrderItemId == 10);
                    if (exItem != null)
                    {
                        exItem.Price = 1800;
                        exItem.ItemName = "RichMan Shirt";

                        db.Entry(exItem).State = EntityState.Modified;
                        exOrder.OrderItems.Add(exItem);
                    }

                    //now finally attach the exisitng modified parent
                    //set entity state "EntityState.Modified"
                    db.Orders.Attach(exOrder);
                    db.Entry(exOrder).State = EntityState.Modified;
                    return db.SaveChanges() > 0;
                }
                return false;
            }
        }
    }
}
