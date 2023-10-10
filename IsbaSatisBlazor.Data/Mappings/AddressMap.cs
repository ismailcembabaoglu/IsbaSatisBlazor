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
    public class AddressMap : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
          builder.Property(c => c.City).HasMaxLength(30);
          builder.Property(c => c.County).HasMaxLength(30);
          builder.Property(c => c.FullAddress).HasMaxLength(200);
          builder.Property(c => c.District).HasMaxLength(30);
          builder.ToTable("Addreses");
        }
    }
}
