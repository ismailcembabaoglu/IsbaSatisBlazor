using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Npgsql;
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
            var dbDataSource = new NpgsqlDataSourceBuilder(configurationManager.GetConnectionString("PostgreSql"));
            builder.UseNpgsql(dbDataSource.Build());
            return new IsbaSatisDbContext(builder.Options);
        }
    }
}
