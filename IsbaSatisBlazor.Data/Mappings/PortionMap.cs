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
    public class PortionMap : IEntityTypeConfiguration<Portion>
    {
        public void Configure(EntityTypeBuilder<Portion> builder)
        {
            builder.Property(c => c.Name).HasMaxLength(50);
           builder.Property(c => c.Price).HasPrecision(10, 2);
            builder.Property(c => c.SupplementaryMaterialMultiplier).HasPrecision(4, 2);
            builder.ToTable("Products");
        }
    }
}
