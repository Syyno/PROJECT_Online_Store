using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProjectOnlineShop.Data.Entities
{
    public class CustomerCart
    {
        public Guid Id { get; set; }
        public Order Order { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductBaseId { get; set; }
        public int Quantity { get; set; }
    }
}
