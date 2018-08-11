using AutoMapper;
using ProductShop.Data;
using ProductShop.Dto;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Xml.Serialization;

namespace ProductShop
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });
            var mapper = config.CreateMapper();
            var categoryProducts = new List<CategoryProduct>();
            for (int productId = 201; productId <= 400; productId++)
            {
                var categoryId = new Random().Next(1, 12);

                var categoryProduct = new CategoryProduct()
                {
                    ProductId = productId,
                    CategoryId = categoryId
                };
                categoryProducts.Add(categoryProduct);
            }
         
            var context = new ProductShopContext();
            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

        }

        public static bool IsValid(object obj)
        {
            var validationCotext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResults = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, validationCotext, validationResults, true);
        }
    }
}
