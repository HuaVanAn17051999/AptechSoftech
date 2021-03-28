using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Entities;

namespace WebApplication.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        anhvSql db = new anhvSql();
        public ActionResult Index()
        {
            var listCategory = db.Categories.ToList();
            return View(listCategory);
        }
    }
}