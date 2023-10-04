using IsbaSatisBlazor.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsbaSatisBlazor.Data.Context
{
    public class IsbaSatisDbContext:DbContext
    {
        public IsbaSatisDbContext(DbContextOptions<IsbaSatisDbContext> options) : base(options)
        {
                
        }
        public virtual DbSet<Users> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("Users");

                entity.HasKey(i => i.Id);

                entity.Property(i => i.Id).HasColumnName("Id");
                entity.Property(i => i.FirstName).HasColumnName("FirstName").HasMaxLength(100);
                entity.Property(i => i.LastName).HasColumnName("LastName").HasMaxLength(100);
                entity.Property(i => i.EMailAddress).HasColumnName("EMailAddress").HasMaxLength(100);
                entity.Property(i => i.Password).HasColumnName("Password").HasMaxLength(250);

                entity.Property(i => i.CreateDate).HasColumnName("CreateDate");

                entity.Property(i => i.IsActive).HasColumnName("isactive");
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
