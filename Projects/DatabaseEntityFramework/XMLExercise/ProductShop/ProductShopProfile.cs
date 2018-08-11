using AutoMapper;
using ProductShop.Dto;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductShop
{
    class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            CreateMap<UserDto, User>();
            CreateMap<ProductDto, Product>();
            CreateMap<CategoryDto, Category>();

        }
    }
}
