
namespace Banicharnica.Services
{
    using Banicharnica.Data;
    using Banicharnica.Services.Contracts;
    using Microsoft.EntityFrameworkCore;
    using System;

    public class DbInitializerService : IDbInitializerService
    {
        private readonly BanicharnicaContext context;
        public DbInitializerService(BanicharnicaContext context)
        {
            this.context = context;
        }
        public void InitializeDatabase()
        {
            this.context.Database.Migrate();
        }
    }
}
