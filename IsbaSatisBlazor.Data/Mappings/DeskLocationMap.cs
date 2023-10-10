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
    public class DeskLocationMap : IEntityTypeConfiguration<DeskLocation>
    {
        public void Configure(EntityTypeBuilder<DeskLocation> builder)
        {
            builder.ToTable("DeskLocations");
        }
    }
}
