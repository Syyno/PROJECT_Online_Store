using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProjectOnlineShop.Data.Entities
{
    public class Cart
    {
        public Dictionary<string, string> CartItems { get; set; } = new Dictionary<string, string>();
    }
}
