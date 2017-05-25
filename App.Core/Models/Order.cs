using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string OrderBy { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
