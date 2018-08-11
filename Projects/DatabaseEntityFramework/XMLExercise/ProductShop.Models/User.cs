﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ProductShop.Models
{
    public class User
    {
        public User()
        {
            this.ProductBought = new List<Product>();
            this.ProductSold = new List<Product>();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Age { get; set; }

        public ICollection<Product> ProductSold { get; set; }
        public ICollection<Product> ProductBought { get; set; }
    }   
}
