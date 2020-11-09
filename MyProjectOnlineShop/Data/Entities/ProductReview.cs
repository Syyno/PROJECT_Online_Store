using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyProjectOnlineShop.Data.Entities
{
    public class ProductReview
    {
        public Guid Id { get; set; }
        public Product ProductBase { get; set; }
        public Guid ProductBaseId { get; set; }
        [Display(Name="Text")]
        public string Text { get; set; }
        [Display(Name = "Author's name")]
        public string Author { get; set; }
    }
}
