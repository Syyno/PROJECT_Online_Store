using System;
using System.Collections.Generic;
using System.Linq;
using MyProjectOnlineShop.Data.Entities;
using MyProjectOnlineShop.Services;

namespace MyProjectOnlineShop.Data.Repositories.Interfaces
{
    public interface IProductOperations
    {
        void AddOrUpdateProduct(Product product);
        IQueryable<Product> GetAllProducts();
        Product GetProductById(Guid id);
        void DeleteProductById(Guid id);
        void AddAdditionalPictures(List<AdditionalPicture> pictures);
        List<AdditionalPicture> GetAdditionalPictures(Product product);
        void DeleteAdditionalPictureById(Product model, Guid id);
        void AddRating(Guid id, int rating);
        ProductRatings GetRating(Product model);
        void DeleteRating(Product model);
        void AddReview(ProductReview productReview);
        List<ProductReview> GetReviews(Product product);
        void DeleteReview(Guid id);
        void AddOrder(Order order);
        Order GetOrderById(Guid id);
        void AddCustomer(Customer customer);
        void AddCustomerCart(List<CustomerCart> customerCarts);
        void UpdateOrder(Order order);
    }
}
