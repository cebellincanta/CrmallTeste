using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CrmallTeste.Infra.Persistence
{
    public class ContextFactory : IDesignTimeDbContextFactory<CrmallContext>
    {
        
        public CrmallContext CreateDbContext(string[] args)
        {
            

            string connectionString = GetDefaultConnectionString();
            var builder = new DbContextOptionsBuilder<CrmallContext>();
            builder.UseMySQL(connectionString);
            return new CrmallContext(builder.Options);
        }

        private string GetDefaultConnectionString()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connectionString = configuration.GetConnectionString("DefaultConnection");
            return connectionString;
        }

    }
}
