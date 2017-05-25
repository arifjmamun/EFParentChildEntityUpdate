using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public string ItemName { get; set; }
        public double Price { get; set; }

        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}
