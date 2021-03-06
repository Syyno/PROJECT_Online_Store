﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyProjectOnlineShop.Data;

namespace MyProjectOnlineShop.Areas.Admin.Controllers
{
   [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly DataManager _dataManager;

        public HomeController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public IActionResult Index()
        {
            return View(_dataManager.ProductOperations.GetAllProducts());
        }
    }
}
