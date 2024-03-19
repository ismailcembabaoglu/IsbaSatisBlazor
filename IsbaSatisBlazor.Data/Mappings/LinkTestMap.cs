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
    public class LinkTestMap : IEntityTypeConfiguration<LinkTest>
    {
        public void Configure(EntityTypeBuilder<LinkTest> builder)
        {
            builder.ToTable("Tests");
        }
    }
}
