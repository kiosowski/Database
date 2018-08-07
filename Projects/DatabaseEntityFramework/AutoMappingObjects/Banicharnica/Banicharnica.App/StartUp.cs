namespace Banicharnica.App
{
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using Microsoft.EntityFrameworkCore;
    using Banicharnica.Data;
    using Banicharnica.Services.Contracts;
    using Banicharnica.Services;
    using Banicharnica.App.Core.Contracts;
    using Banicharnica.App.Core;
    using Banicharnica.App.Core.Controllers;
    using AutoMapper;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var service = ConfigureService();
            IEngine engine = new Engine(service);
            engine.Run();
        }

        private static IServiceProvider ConfigureService()
        {
            var serviceCollection = new ServiceCollection();

            //Mapper.Initialize(cfg => cfg.AddProfile<BanicharnicaProfile>());

            serviceCollection.AddDbContext<BanicharnicaContext>(opts => opts.UseSqlServer
            (Configuration.ConnectionString));
            serviceCollection.AddAutoMapper(confg => confg.AddProfile<BanicharnicaProfile>());
            serviceCollection.AddTransient<IDbInitializerService, DbInitializerService>();
            serviceCollection.AddTransient<ICommandIntepreter, CommandInterpreter>();
            serviceCollection.AddTransient<IEmployeeController, EmployeeController>();
            serviceCollection.AddTransient<IManagerController, ManagerController>();   



            var serviceProvider = serviceCollection.BuildServiceProvider();
            return serviceProvider;
        }
    }
}
