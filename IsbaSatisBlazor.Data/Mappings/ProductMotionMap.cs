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
    public class ProductMotionMap : IEntityTypeConfiguration<ProductMotion>
    {
        public void Configure(EntityTypeBuilder<ProductMotion> builder)
        {
           builder.Property(c => c.Amount).HasPrecision(8, 3);
           builder.Property(c => c.UnitPrice).HasPrecision(10, 2);
           builder.Property(c => c.SupplementaryMaterialPrice).HasPrecision(10, 2);
           builder.Property(c => c.Sale).HasPrecision(5, 2);
           builder.Ignore(C => C.TotalPrice);
           builder.Ignore(C => C.SupplementaryMaterialUnitPrice);
            builder.ToTable("ProductMotions");
        }
    }
}
