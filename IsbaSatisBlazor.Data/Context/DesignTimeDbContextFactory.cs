using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsbaSatisBlazor.Data.Context
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<IsbaSatisDbContext>
    {
        public IsbaSatisDbContext CreateDbContext(string[] args)
        {
            ConfigurationManager configurationManager = new ConfigurationManager();
            configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../IsbaSatisBlazor/Server"));
            configurationManager.AddJsonFile("appsettings.json");
            var builder = new DbContextOptionsBuilder<IsbaSatisDbContext>();
            builder.UseNpgsql(configurationManager.GetConnectionString("PostgreSql"));
            return new IsbaSatisDbContext(builder.Options);
        }
    }
}
