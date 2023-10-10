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
    public class AdisyonMap : IEntityTypeConfiguration<Adisyon>
    {
        public void Configure(EntityTypeBuilder<Adisyon> builder)
        {
          builder.Property(c => c.Discount).HasPrecision(5, 2);
          builder.Property(c => c.TotalAmount).HasPrecision(10, 2);
          builder.ToTable("Adisyons");
        }
    }
}
