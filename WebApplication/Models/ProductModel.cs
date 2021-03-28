using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string ImagePath { get; set; }
        public HttpPostedFileBase UploadFile { get; set; }
    }
}