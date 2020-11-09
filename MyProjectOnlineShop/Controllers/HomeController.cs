using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyProjectOnlineShop.Data;
using MyProjectOnlineShop.Data.Entities;
using MyProjectOnlineShop.Models;

namespace MyProjectOnlineShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _db;

        public HomeController(ILogger<HomeController> logger, AppDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.Products);
        }
        public IActionResult Search(string search)
        {
            IQueryable<Product> filteredProducts = _db.Products.Where(p => p.Name.ToLower().Trim().Contains(search.Trim().ToLower()));
            return View(filteredProducts);
        }
    }
}
