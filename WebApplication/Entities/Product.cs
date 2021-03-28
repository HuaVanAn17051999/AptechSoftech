namespace WebApplication.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        public int Id { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        public int? CategoryId { get; set; }

        [StringLength(250)]
        public string ImagePath { get; set; }

        public virtual Category Category { get; set; }
    }
}
