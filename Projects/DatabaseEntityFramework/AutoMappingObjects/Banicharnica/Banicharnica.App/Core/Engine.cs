using Banicharnica.App.Core.Contracts;
using Banicharnica.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Banicharnica.App.Core
{
    public class Engine : IEngine
    {
        private readonly IServiceProvider serviceProvider;
        public Engine(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }
        public void Run()
        {
            var initializeDb = this.serviceProvider.GetService<IDbInitializerService>();
            initializeDb.InitializeDatabase();

            var commandIntrepreter = this.serviceProvider.GetService<ICommandIntepreter>();

            while (true)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string result = commandIntrepreter.Read(input);
                Console.WriteLine(result);


            }
        }
    }
}
