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
    public class ProductNoteMap : IEntityTypeConfiguration<ProductNote>
    {
        public void Configure(EntityTypeBuilder<ProductNote> builder)
        {
          builder.Property(c => c.Note).HasMaxLength(100);
            builder.ToTable("ProductNotes");
        }
    }
}
