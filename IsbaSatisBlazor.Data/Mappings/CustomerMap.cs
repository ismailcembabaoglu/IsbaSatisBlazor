using IsbaSatisBlazor.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsbaSatisBlazor.Data.Mappings
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
          builder.Property(c => c.CustomerName).HasMaxLength(50);
          builder.Property(c => c.CustomerSurname).HasMaxLength(50);
          builder.Property(c => c.CardNumber).HasMaxLength(20);
          builder.Property(c => c.Company).HasMaxLength(100);

           builder.ToTable("Customers");
        }
    }
}
