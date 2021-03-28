using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Entities;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        anhvSql db = new anhvSql();
        public ActionResult Index()
        {
            var listProduct = db.Products
                .Select(x => new ProductModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    CategoryName = x.Category.Name,
                    ImagePath = x.ImagePath
                }).ToList();

            return View(listProduct);
        }
        public ActionResult Create()
        {
            ViewBag.ListCategroy = db.Categories.Select(x => new CategoryModel() { Id = x.Id, Name = x.Name });
            return View();
        }
        [HttpPost]
        public ActionResult Create(ProductModel productModel)
        {
            if(ModelState.IsValid)
            {
                var product = new Product()
                {
                    CategoryId = productModel.CategoryId,
                    Name = productModel.Name
                };
                if (productModel.UploadFile != null)
                {
                    productModel.UploadFile.SaveAs(HttpContext.Server.MapPath("~/Content/Images/")
                                                            + productModel.UploadFile.FileName);
                    product.ImagePath = productModel.UploadFile.FileName;
                }
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
          
            return View();
        }
        public ActionResult Delete(int? id)
        {
            if(id != null)
            {
                var product = db.Products.Find(id);
                db.Products.Remove(product);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Edit(int? id)
        {
            var details = db.Products.Find(id);
            var productModel = new ProductModel()
            {
                Name = details.Name,
                ImagePath = details.ImagePath,
                CategoryId = details.CategoryId
            };
            ViewBag.ListCategroy = db.Categories.Select(x => new CategoryModel() { Id = x.Id, Name = x.Name });
            return View(productModel);
        } 
        [HttpPost]
        public ActionResult Edit(int? id, ProductModel productModel)
        {
            if(id != null)
            {
                var details = db.Products.Find(id);
                details.CategoryId = productModel.CategoryId;
                details.Name = productModel.Name;

                if(productModel.UploadFile.ContentLength > 0)
                {
                    productModel.UploadFile.SaveAs(HttpContext.Server.MapPath("~/Content/Images/")
                                                         + productModel.UploadFile.FileName);
                    details.ImagePath = productModel.UploadFile.FileName;
                }

                db.Products.AddOrUpdate(details);
                db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View();
        }
       
        
    
    }
}