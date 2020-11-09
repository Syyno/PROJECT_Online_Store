using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MyProjectOnlineShop.Services;

namespace MyProjectOnlineShop.Data.Entities
{
    public class Product
    {
        [Required]
        public Guid Id { get; set; }

        [Display(Name = "Наименование товара")]
        [MaxLength(100)]
        [Required]
        public virtual string Name { get; set; }

        [Display(Name = "Полное описание товара")]
        [MaxLength(500)]
        public virtual string DescriptionFull { get; set; }

        [Display(Name = "Фотография товара")]
        [Required]
        public virtual string ImgPath { get; set; }

        [Display(Name = "Дополнительные фотографии товара")]
        public virtual List<AdditionalPicture> AdditionalPictures { get; set; }

        [Display(Name = "Цена товара")]
        [Range(0, 100000)]
        [DataType(DataType.Currency)]
        [Required]
        public decimal Price { get; set; }

        [Display(Name = "Рейтинг товара")]
        public ProductRatings ProductRatings { get; set; }

        [Display(Name = "Отзывы о товаре")]
        public List<ProductReview> ProductReview { get; set; }

        [Display(Name = "Количество на складе")]
        [Range(0, 100000)]
        [Required]
        public int Quantity { get; set; }
    }
}
