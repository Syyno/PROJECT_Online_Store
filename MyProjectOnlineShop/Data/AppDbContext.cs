using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyProjectOnlineShop.Data.Entities;
using MyProjectOnlineShop.Services;

namespace MyProjectOnlineShop.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<AdditionalPicture> AdditionalPicture { get; set; }
        public DbSet<ProductRatings> ProductRatings { get; set; }
        public DbSet<ProductReview> ProductReview { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<CustomerCart> CustomerCart { get; set; }
        public DbSet<Customer> Customer { get; set; }

        public AppDbContext() { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "014050AE-8FAA-4EA6-A0A4-DF7385C578E2",
                Name = "admin", 
                NormalizedName = "ADMIN"
            });

            builder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "0DEC5C45-E146-4562-883A-2499CB6A7F27",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                SecurityStamp = string.Empty,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "qwerty")
            });

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "014050AE-8FAA-4EA6-A0A4-DF7385C578E2",
                UserId = "0DEC5C45-E146-4562-883A-2499CB6A7F27"
            });

            builder.Entity<Product>().HasData(new List<Product>(6)
            {
                new Product()
                {
                    Id = new Guid("7336CBB0-8170-48FB-BB6B-EA7EF1D1A87C"),
                    Name = "Modern chair",
                    DescriptionFull = "White modern chair",
                    Price = 200,
                    Quantity = 10,
                    //ImgPath = "pro-big-1.jpg"
                    ImgPath = "1.jpg"
                },
                new Product()
                {
                    Id = new Guid("20B98CE5-FC42-44EE-805F-26E35A51B056"),
                    Name = "Plant pot",
                    DescriptionFull = "Plant pot for your favorite plants",
                    Price = 25,
                    Quantity = 18,
                    //ImgPath = "pro-big-4.jpg"
                    ImgPath = "5.jpg"

                },
                new Product()
                {
                    Id = new Guid("2610D2D4-E4D7-417F-84DF-CA3D4752F981"),
                    Name = "Backless chair",
                    DescriptionFull = "Chair for minimalists",
                    Price = 225,
                    Quantity = 7,
                    //ImgPath = "pro-big-3.jpg"
                    ImgPath = "7.jpg"
                },
                new Product()
                {
                    Id = new Guid("7BE540CB-3E09-4AB2-B6E3-50217FF52CF1"),
                    Name = "Modern table",
                    DescriptionFull = "White modern table",
                    Price = 330,
                    Quantity = 11,
                    //ImgPath = "6.jpg"
                    ImgPath = "product4.jpg"

                },
                new Product()
                {
                    Id = new Guid("F3A7412C-C5E5-4822-A60D-155E1DD060E0"),
                    Name = "Rocking chair",
                    DescriptionFull = "Extra comfortable chair",
                    Price = 290,
                    Quantity = 6,
                    //ImgPath = "pro-big-2.jpg"
                    ImgPath = "8.jpg"

                },
                new Product()
                {
                    Id = new Guid("E4266357-FD88-4F35-BFAE-8CE79A3C7DFA"),
                    Name = "Hanging lamp",
                    DescriptionFull = "Let there be light",
                    Price = 50,
                    Quantity = 22,
                    ImgPath = "product6.jpg"
                }
            });

            builder.Entity<AdditionalPicture>().HasData(new List<AdditionalPicture>()
            {
                new AdditionalPicture()
                {
                    ProductBaseId = Guid.Parse("7336CBB0-8170-48FB-BB6B-EA7EF1D1A87C"),
                    Id = Guid.NewGuid(),
                    AdditionalImgPath = "pro-big-2.jpg"
                },
                new AdditionalPicture()
                {
                    ProductBaseId = Guid.Parse("7336CBB0-8170-48FB-BB6B-EA7EF1D1A87C"),
                    Id = Guid.NewGuid(),
                    AdditionalImgPath = "pro-big-3.jpg"
                },
                new AdditionalPicture()
                {
                    ProductBaseId = Guid.Parse("20B98CE5-FC42-44EE-805F-26E35A51B056"),
                    Id = Guid.NewGuid(),
                    AdditionalImgPath = "pro-big-1.jpg"
                },
                new AdditionalPicture()
                {
                    ProductBaseId = Guid.Parse("20B98CE5-FC42-44EE-805F-26E35A51B056"),
                    Id = Guid.NewGuid(),
                    AdditionalImgPath = "pro-big-3.jpg"
                },
                new AdditionalPicture()
                {
                    ProductBaseId = Guid.Parse("2610D2D4-E4D7-417F-84DF-CA3D4752F981"),
                    Id = Guid.NewGuid(),
                    AdditionalImgPath = "pro-big-1.jpg"
                },
                new AdditionalPicture()
                {
                    ProductBaseId = Guid.Parse("2610D2D4-E4D7-417F-84DF-CA3D4752F981"),
                    Id = Guid.NewGuid(),
                    AdditionalImgPath = "pro-big-2.jpg"
                },
                new AdditionalPicture()
                {
                    ProductBaseId = Guid.Parse("7BE540CB-3E09-4AB2-B6E3-50217FF52CF1"),
                    Id = Guid.NewGuid(),
                    AdditionalImgPath = "4.jpg"
                },
                new AdditionalPicture()
                {
                    ProductBaseId = Guid.Parse("7BE540CB-3E09-4AB2-B6E3-50217FF52CF1"),
                    Id = Guid.NewGuid(),
                    AdditionalImgPath = "3.jpg"
                },

                new AdditionalPicture()
                {
                    ProductBaseId = Guid.Parse("F3A7412C-C5E5-4822-A60D-155E1DD060E0"),
                    Id = Guid.NewGuid(),
                    AdditionalImgPath = "pro-big-1.jpg"
                },
                new AdditionalPicture()
                {
                    ProductBaseId = Guid.Parse("F3A7412C-C5E5-4822-A60D-155E1DD060E0"),
                    Id = Guid.NewGuid(),
                    AdditionalImgPath = "pro-big-3.jpg"
                },
                new AdditionalPicture()
                {
                    ProductBaseId = Guid.Parse("E4266357-FD88-4F35-BFAE-8CE79A3C7DFA"),
                    Id = Guid.NewGuid(),
                    AdditionalImgPath = "pro-big-4.jpg"
                },
                new AdditionalPicture()
                {
                    ProductBaseId = Guid.Parse("E4266357-FD88-4F35-BFAE-8CE79A3C7DFA"),
                    Id = Guid.NewGuid(),
                    AdditionalImgPath = "pro-big-2.jpg"
                }
            });
        }

    }
}
