using IsbaSatisBlazor.Data.Models.BaseModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsbaSatisBlazor.Data.Mappings
{
    public class ModelBaseMap: IEntityTypeConfiguration<ModelBase>
    {
        public void Configure(EntityTypeBuilder<ModelBase> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(i => i.Id).HasColumnName("Id");
            builder.Property(e => e.CreatedUser).HasMaxLength(50);
            builder.Property(e => e.UpdatedUser).HasMaxLength(50);
            builder.Property(e => e.Decription).HasMaxLength(100);
        }
    }
}
