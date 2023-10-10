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
    public class UsersMap : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
           builder.Property(i => i.FirstName).HasMaxLength(100);
           builder.Property(i => i.LastName).HasMaxLength(100);
           builder.Property(i => i.EMailAddress).HasMaxLength(100);
           builder.Property(i => i.Password).HasMaxLength(250);
            builder.ToTable("Users");
        }
    }
}
