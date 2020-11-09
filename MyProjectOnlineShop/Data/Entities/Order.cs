using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MyProjectOnlineShop.Data.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public Customer Customer { get; set; }
        public decimal Sum { get; set; }
        public List<CustomerCart> CustomerCart { get; set; }
    }
}
