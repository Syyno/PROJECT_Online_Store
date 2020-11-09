using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyProjectOnlineShop.Data.Entities;

namespace MyProjectOnlineShop.Services
{
    public class ProductRatings
    {
        public Guid Id { get; set; }
        public Product ProductBase { get; set; }
        public Guid ProductBaseId { get; set; }
        public int? RatingTotal { get; set; }
        public int? VotesCount { get; set; }
        public double? Rating { get; set; }
    }
}
