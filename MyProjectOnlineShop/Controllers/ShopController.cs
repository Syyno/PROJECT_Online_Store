using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyProjectOnlineShop.Data;
using MyProjectOnlineShop.Data.Entities;
using MyProjectOnlineShop.Services;
using SessionExtensions = Microsoft.AspNetCore.Http.SessionExtensions;

namespace MyProjectOnlineShop.Controllers
{
    public class ShopController : Controller
    {
        private readonly DataManager _dataManager;

        public ShopController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }
        public IActionResult Cart()
        {
            List<Product> products = new List<Product>();

            if (HttpContext.Session.Get<Cart>("cart") != null)
            {
                Cart cart = HttpContext.Session.Get<Cart>("cart");
                Dictionary<string,string> productDictionary = cart.CartItems;

                foreach (var pair in productDictionary)
                {
                    Product prod = _dataManager.ProductOperations.GetProductById(Guid.Parse(pair.Key));
                    products.Add(prod);
                    string key = pair.Key;
                    int qty = Int32.Parse(pair.Value);
                    ViewData[key] = qty;
                }
            }

            return View(products);
        }

        [HttpPost]
        public IActionResult RefreshCart(List<int> quantity, List<Guid> product, List<Guid> include)
        {
            Cart cart = HttpContext.Session.Get<Cart>("cart");
            for (int i = 0; i < product.Count; i++)
            {
                if (include.Contains(product[i]))
                {

                    int? qty = Convert.ToInt32(quantity[i]);
                    Product pr = _dataManager.ProductOperations.GetProductById(product[i]);
                    if (qty > pr.Quantity)
                    {
                        qty = pr.Quantity;
                    }
                    cart.CartItems[product[i].ToString()] = qty.ToString();
                }
                else
                {
                    cart.CartItems.Remove($"{product[i].ToString()}");
                }
            }
            HttpContext.Session.Set<Cart>("cart", cart);

            return RedirectToAction("Cart");
        }

        public IActionResult Checkout(Customer customer)
        {
            Order order = _dataManager.ProductOperations.GetOrderById(customer.OrderId);
            customer.Order = order;
            HttpContext.Session.Set<Customer>("customer", customer);

            if (ModelState.IsValid)
            {
                Cart cart = HttpContext.Session.Get<Cart>("cart");
                if (cart != null)
                {
                    foreach (var pair in cart.CartItems)
                    {
                        Product product = _dataManager.ProductOperations.GetProductById(Guid.Parse(pair.Key));
                        product.Quantity -= Int32.Parse(pair.Value);
                        _dataManager.ProductOperations.AddOrUpdateProduct(product);
                    }
                }

                _dataManager.ProductOperations.AddCustomer(customer);
                HttpContext.Session.Remove("cart");
                HttpContext.Session.Remove("customer");
                return RedirectToAction("Index", "Home");
            }

            return View(customer);
        }

        [HttpPost]
        public IActionResult CreateOrder(decimal total)
        {
            Cart cart = HttpContext.Session.Get<Cart>("cart");
            Order order = new Order() {Sum = total, Id = Guid.NewGuid()};
            List<CustomerCart> customerCart = new List<CustomerCart>();
            
            foreach (var productIdQuantityPair in cart.CartItems)
            {
                CustomerCart tmpCart = new CustomerCart()
                {
                    Order = order, ProductBaseId = Guid.Parse(productIdQuantityPair.Key),
                    Quantity = Int32.Parse(productIdQuantityPair.Value), Id = Guid.NewGuid(), OrderId = order.Id
                };
                customerCart.Add(tmpCart);
            }
            _dataManager.ProductOperations.AddOrder(order);
            _dataManager.ProductOperations.AddCustomerCart(customerCart);

            Customer customer = new Customer() {Id = Guid.NewGuid(), OrderId = order.Id};
            return RedirectToAction("Checkout", customer);
        }
    }
}
