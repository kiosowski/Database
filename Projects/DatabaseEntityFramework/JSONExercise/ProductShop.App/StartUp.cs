namespace ProductShop.App
{
    using AutoMapper;
    using Data;
    using Models;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.IO;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });
            var mapper = config.CreateMapper();

            //var context = new ProductShopContext();
            //string usersJson = File.ReadAllText("../../Json/users.json");
            //List<User> users = JsonConvert.DeserializeObject<List<User>>

        }
    }
}
