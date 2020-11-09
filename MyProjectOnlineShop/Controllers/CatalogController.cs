using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using MyProjectOnlineShop.Data;
using MyProjectOnlineShop.Data.Entities;
using MyProjectOnlineShop.Services;

namespace MyProjectOnlineShop.Controllers
{
    public class CatalogController : Controller
    {
        private readonly DataManager _dataManager;

        public CatalogController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }
        public IActionResult Item(Guid id)
        {
            if (id != default)
            {
                Product entity = _dataManager.ProductOperations.GetProductById(id);
                List<AdditionalPicture> pics = _dataManager.ProductOperations.GetAdditionalPictures(entity);
                ProductRatings ratings = _dataManager.ProductOperations.GetRating(entity);
                List<ProductReview> reviews = _dataManager.ProductOperations.GetReviews(entity);
                entity.AdditionalPictures = pics;
                entity.ProductRatings = ratings;
                entity.ProductReview = reviews;
                return View("Details", entity);
            }

            return RedirectToAction("Index", "Home");
        }

        
        public IActionResult SubmitRating(Guid id, int rating)
        {
            _dataManager.ProductOperations.AddRating(id, rating);
            var entity = _dataManager.ProductOperations.GetProductById(id);
            return LocalRedirect($"~/Catalog/Item/{id}");
        }

        public IActionResult AddReview(Guid id)
        {
            Product entity = _dataManager.ProductOperations.GetProductById(id);
            ViewBag.entity = entity;
            return View();
        }

        [HttpPost]
        public IActionResult AddReview(string text, string author, Guid model)
        {
            Product entity = _dataManager.ProductOperations.GetProductById(model);
            ProductReview productReview = new ProductReview() {Author = author, ProductBase = entity, ProductBaseId = entity.Id, Text = text};
            _dataManager.ProductOperations.AddReview(productReview);
            return LocalRedirect($"~/Catalog/Item/{model}");
        }

        [HttpPost]
        public IActionResult AddToCart(Guid id, int? quantity)
        {
            Product product = _dataManager.ProductOperations.GetProductById(id);
            if (quantity > product.Quantity)
            {
                quantity = product.Quantity;
            }

            if (HttpContext.Session.Get<Cart>("cart") != null)
            {
                Cart cart = HttpContext.Session.Get<Cart>("cart");
                cart.CartItems[id.ToString()] = quantity.ToString();
                HttpContext.Session.Set<Cart>("cart", cart);
            }
            else
            {
                Cart cart = new Cart() { CartItems = { [id.ToString()] = quantity.ToString() } };
                HttpContext.Session.Set<Cart>("cart", cart);
            }

            return LocalRedirect($"~/Catalog/Item/{id}");
        }
    }
}
