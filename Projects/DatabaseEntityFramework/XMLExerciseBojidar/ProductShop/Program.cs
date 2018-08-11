using ProductShop.Data;
using System;
using AutoMapper;
using System.Xml.Serialization;
using ProductShop.Dtos;
using System.IO;
using ProductShop.Models;
using System.Collections.Generic;

namespace ProductShop
{
    class Program
    {
        static void Main(string[] args)
        {
            Mapper.Initialize(cfg => cfg.AddProfile<ProductShopProfile>());
            var context = new ProductShopContext();
            string path = @"D:\Георги\Software University\Database\Projects\DatabaseEntityFramework\XMLExercise\ProductShop\Xml\users.xml";

            ImportXmlUsers(context, path);
        }

        private static void ImportXmlUsers(ProductShopContext context, string path)
        {
            var xmlString = File.ReadAllText(path);

            var seriazlier = new XmlSerializer(typeof(UserDto[]), new XmlRootAttribute("users"));
            var deserialiedUsers = (UserDto[])seriazlier.Deserialize(new StringReader(xmlString));

            var users = new List<User>();

            foreach (var userDto in deserialiedUsers)
            {
                var user = Mapper.Map<User>(userDto);

                users.Add(user);
                Console.WriteLine($"User {user.FirstName} {user.LastName} successfully added!");

            }

            context.Users.AddRange(users);
            context.SaveChanges();
        }
    }
}
