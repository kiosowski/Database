using System;
using System.Collections.Generic;
using System.Text;

namespace ProductShop.Models
{
    public class Category
    {
        public Category()
        {
            this.Products = new List<CategoryProduct>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<CategoryProduct> Products { get; set; }
    }
}
