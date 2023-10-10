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
    public class GarsonMap : IEntityTypeConfiguration<Garson>
    {
        public void Configure(EntityTypeBuilder<Garson> builder)
        {
            builder.Property(c => c.Name).HasMaxLength(50);
           builder.Property(c => c.Surname).HasMaxLength(50);

           builder.ToTable("Garsons");
        }
    }
}
