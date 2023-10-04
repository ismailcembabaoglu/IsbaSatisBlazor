using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
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
            String connectionString = "Server=DESKTOP-SLOIL0F;Database=IsbaSatisBlazor;User Id=sa;Password=17421742;TrustServerCertificate=True;";

            var builder = new DbContextOptionsBuilder<IsbaSatisDbContext>();

            builder.UseSqlServer(connectionString);

            return new IsbaSatisDbContext(builder.Options);
        }
    }
}
