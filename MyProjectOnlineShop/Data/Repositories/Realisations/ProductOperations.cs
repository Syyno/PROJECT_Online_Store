using Microsoft.EntityFrameworkCore;
using MyProjectOnlineShop.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using MyProjectOnlineShop.Data.Entities;
using MyProjectOnlineShop.Services;

namespace MyProjectOnlineShop.Data.Repositories.Realisations
{
    public class ProductOperations : IProductOperations
    {
        private readonly AppDbContext _db;

        public ProductOperations(AppDbContext db)
        {
            _db = db;
        }

        public void AddOrUpdateProduct(Product product)
        {
            if (product.Id == default)
            {
                _db.Entry(product).State = EntityState.Added;
            }
            else
            {
                _db.Entry(product).State = EntityState.Modified;
            }

            _db.SaveChanges();

        }

        public IQueryable<Product> GetAllProducts()
        {
            return _db.Products;
        }

        public Product GetProductById(Guid id)
        {
            return _db.Products.FirstOrDefault(p => p.Id == id);
        }

        public void DeleteProductById(Guid id)
        {
            Product prod = _db.Products.FirstOrDefault(p => p.Id == id);
            if (prod != null)
            {
                _db.Products.Remove(prod);
                _db.SaveChanges();
            }
        }

        public void AddAdditionalPictures(List<AdditionalPicture> picture)
        {

            foreach (var additionalPicture in picture)
            {
                if (additionalPicture.Id == default)
                {
                    _db.Entry(additionalPicture).State = EntityState.Added;
                }
                else
                {
                    _db.Entry(additionalPicture).State = EntityState.Modified;
                }
            }

            //if (picture.Id == default)
            //{
            //    _db.Entry(picture).State = EntityState.Added;
            //}
            //else
            //{
            //    _db.Entry(picture).State = EntityState.Modified;
            //}

            //_db.AdditionalPictures.Add(picture);
            _db.SaveChanges();
        }

        public List<AdditionalPicture> GetAdditionalPictures(Product product)
        {
            List<AdditionalPicture> pictures = _db.AdditionalPicture.Include(p => p.ProductBase)
                .Where(p => p.ProductBaseId == product.Id).ToList();
            return pictures;
        }

        public void DeleteAdditionalPictureById(Product model, Guid id)
        {
            var picture = _db.AdditionalPicture.FirstOrDefault(p => p.Id == id && p.ProductBase == model);

            if (picture != null)
            {
                _db.AdditionalPicture.Remove(picture);
            }
            _db.SaveChanges();
        }

        public void AddRating(Guid id, int rating)
        {
            var product = _db.Products.Include(p => p.ProductRatings).FirstOrDefault(p => p.Id == id);

            if (product != null)
            {
                if (product.ProductRatings == default)
                {
                    ProductRatings productRatings = new ProductRatings() { ProductBase = product, Rating = rating, ProductBaseId = product.Id, RatingTotal = rating, VotesCount = 1 };
                    _db.Entry(productRatings).State = EntityState.Added;
                    //model.ProductRatings = productRatings;
                    //_db.Entry(model).State = EntityState.Modified;
                }
                else
                {
                    product.ProductRatings.VotesCount += 1;
                    product.ProductRatings.RatingTotal += rating;
                    product.ProductRatings.Rating =
                        product.ProductRatings.RatingTotal / product.ProductRatings.VotesCount;
                    _db.Entry(product).State = EntityState.Modified;
                }
                _db.SaveChanges();
            }
        }

        public ProductRatings GetRating(Product model)
        {
            ProductRatings ratings = _db.ProductRatings.Include(p => p.ProductBase)?
                    .Where(p => p.ProductBaseId == model.Id).FirstOrDefault();
            return ratings;
        }

        public void DeleteRating(Product model)
        {
            ProductRatings ratings = _db.ProductRatings.Include(p => p.ProductBase)
                .Where(p => p.ProductBaseId == model.Id).FirstOrDefault();
            if (ratings != null)
            {
                _db.ProductRatings.Remove(ratings);
                _db.SaveChanges();
            }
            
        }

        public void AddReview(ProductReview productReview)
        {
            _db.Entry(productReview).State = EntityState.Added;
            _db.SaveChanges();
        }

        public List<ProductReview> GetReviews(Product product)
        {
            List<ProductReview> productReviews = _db.ProductReview.Include(p => p.ProductBase)?
                .Where(p => p.ProductBaseId == product.Id).ToList();
            return productReviews;
        }

        public void DeleteReview(Guid id)
        {
            List<ProductReview> productReviews = _db.ProductReview.Include(p => p.ProductBase).Where(p => p.ProductBaseId == id).ToList();
            _db.RemoveRange(productReviews);
            _db.SaveChanges();
        }

        public void AddOrder(Order order)
        {
            //_db.Entry(order).State = EntityState.Added;
            _db.Order.Add(order);
            _db.SaveChanges();
        }

        public Order GetOrderById(Guid id)
        {
           return _db.Order.FirstOrDefault(o => o.Id == id);
        }

        public void AddCustomer(Customer customer)
        {
            _db.Customer.Add(customer);
            _db.SaveChanges();
        }

        public void AddCustomerCart(List<CustomerCart> customerCarts)
        {
            _db.CustomerCart.AddRange(customerCarts);
            _db.SaveChanges();
        }

        public void UpdateOrder(Order order)
        {
            _db.Order.Update(order);
            _db.SaveChanges();
        }
    }
}
