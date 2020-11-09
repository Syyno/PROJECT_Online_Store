using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MyProjectOnlineShop.Data;
using MyProjectOnlineShop.Data.Entities;


namespace MyProjectOnlineShop.Services
{
    public static class Extensions
    {
        public static string CutController(this string str)
        {
            return str.Replace("Controller", "");
        }

        public static void RefreshBase(this AppDbContext db)
        {
            var orders = db.Order.Include(o => o.Customer).ToList();
            var ordersToRemove = new List<Order>();
            foreach (var order in orders)
            {
                if (order.Customer == null)
                {
                    ordersToRemove.Add(order);
                }
            }
            db.Order.RemoveRange(ordersToRemove);
            db.SaveChanges();
        }
    }

    public static class SessionExtensions
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonSerializer.Serialize<T>(value));
        }

        public static T Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonSerializer.Deserialize<T>(value);
        }
    }
}
