using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyProjectOnlineShop.Data;
using MyProjectOnlineShop.Data.Entities;
using MyProjectOnlineShop.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MyProjectOnlineShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly DataManager _dataManager;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ProductsController(DataManager dataManager, IWebHostEnvironment hostEnvironment)
        {
            _dataManager = dataManager;
            _hostEnvironment = hostEnvironment;
        }
        public IActionResult Edit(Guid id)
        {
            Product entity;
            if (id == default)
            {
                entity = new Product();
            }
            else
            {
                entity = _dataManager.ProductOperations.GetProductById(id);
                var pics = _dataManager.ProductOperations.GetAdditionalPictures(entity);
                entity.AdditionalPictures = pics;
                _dataManager.ProductOperations.AddOrUpdateProduct(entity);

            }
            return View(entity);
        }

        [HttpPost]
        public IActionResult Edit(Product model, IFormFile titleImageFile, List<IFormFile> additionalImg)
        {
            if (ModelState.IsValid)
            {
                if (titleImageFile != null)
                {
                    model.ImgPath = titleImageFile.FileName;
                    using (var stream = new FileStream(Path.Combine(_hostEnvironment.WebRootPath, "img/product-img/", titleImageFile.FileName), FileMode.Create))
                    {
                        titleImageFile.CopyTo(stream);
                    }
                }

                _dataManager.ProductOperations.AddOrUpdateProduct(model);

                if (additionalImg != null)
                {
                    List<AdditionalPicture> pictures = new List<AdditionalPicture>();
                    foreach (var picture in additionalImg)
                    {
                        pictures.Add(new AdditionalPicture() { AdditionalImgPath = picture.FileName, ProductBase = model });
                        using (var stream = new FileStream(Path.Combine(_hostEnvironment.WebRootPath, "img/product-img/", picture.FileName), FileMode.Create))
                        {
                            picture.CopyTo(stream);
                        }
                    }
                    _dataManager.ProductOperations.AddAdditionalPictures(pictures);
                }

                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            _dataManager.ProductOperations.DeleteProductById(id);
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
        }


        [HttpPost]
        public IActionResult DeleteAdditionalPicture(string model, string picture)
        {
            Product product = _dataManager.ProductOperations.GetAllProducts()
                .FirstOrDefault(p => p.Id.ToString() == model);
            if (product != null)
            {
                _dataManager.ProductOperations.DeleteAdditionalPictureById(product, Guid.Parse(picture));
            }

            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
        }

        [HttpPost]
        public IActionResult DeleteReviews(Guid id)
        {
            _dataManager.ProductOperations.DeleteReview(id);
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
        }

        [HttpPost]
        public IActionResult DeleteRating(Guid id)
        {
            _dataManager.ProductOperations.DeleteRating(_dataManager.ProductOperations.GetProductById(id));
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
        }
    }
}