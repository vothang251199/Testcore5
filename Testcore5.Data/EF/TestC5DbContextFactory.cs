using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testcore5.Data.EF
{
    public class TestC5DbContextFactory : IDesignTimeDbContextFactory<TestC5DbContext>
    {
        public TestC5DbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("Testcore5Db");

            var optionsBuilder = new DbContextOptionsBuilder<TestC5DbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new TestC5DbContext(optionsBuilder.Options);
        }
    }
}
