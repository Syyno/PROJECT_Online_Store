using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProjectOnlineShop.Data.Entities
{
    public class AdditionalPicture
    {
        public Guid Id { get; set; }
        public Product ProductBase { get; set; }
        public Guid ProductBaseId { get; set; }
        public string AdditionalImgPath { get; set; }
    }
}
