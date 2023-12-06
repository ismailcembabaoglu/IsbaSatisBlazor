using IsbaSatisBlazor.Data.Mappings;
using IsbaSatisBlazor.Data.Models;
using IsbaSatisBlazor.Data.Models.BaseModel;
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
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Adisyon> Adisyons { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Desk> Desks { get; set; }
        public virtual DbSet<DeskLocation> DeskLocations { get; set; }
        public virtual DbSet<Garson> Garsons { get; set; }
        public virtual DbSet<PaymentMotion> PaymentMotions { get; set; }
        public virtual DbSet<PaymentType> PaymentTypes { get; set; }
        public virtual DbSet<Phone> Phones { get; set; }
        public virtual DbSet<Portion> Portions { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductGroup> ProductGroups { get; set; }
        public virtual DbSet<ProductMotion> ProductMotions { get; set; }
        public virtual DbSet<ProductNote> ProductNotes { get; set; }
        public virtual DbSet<SupplementaryMaterial> SupplementaryMaterials { get; set; }
        public virtual DbSet<SupplementaryMaterialMotion> SupplementaryMaterialMotions { get; set; }
        public virtual DbSet<Unit> Units { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<LinkTest> LinkTests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<ModelBase>().UseTpcMappingStrategy();
            modelBuilder.Entity<Portion>().HasOne(c => c.Product).WithMany(c => c.Portions).HasForeignKey(c => c.ProductId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<SupplementaryMaterial>().HasOne(c => c.Product).WithMany(c => c.SupplementaryMaterials).HasForeignKey(c => c.ProductId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Product>().HasOne(c => c.ProductGroup).WithMany(c => c.Products).HasForeignKey(c => c.ProductGroupId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Portion>().HasOne(c => c.Unit).WithMany(c => c.Portions).HasForeignKey(c => c.UnitId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ProductNote>().HasOne(c => c.Product).WithMany(c => c.ProductNotes).HasForeignKey(c => c.ProductId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ProductMotion>().HasOne(c => c.Portion).WithMany(c => c.ProductMotions).HasForeignKey(c => c.PortionId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<UserRole>().HasOne(c => c.Users).WithMany(c => c.UserRoles).HasForeignKey(c => c.UserId).OnDelete(DeleteBehavior.NoAction);

            //Musteri ilişkileri
            modelBuilder.Entity<Phone>().HasOne(c => c.Customer).WithMany(c => c.Phones).HasForeignKey(c => c.CustomerId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Address>().HasOne(c => c.Customer).WithMany(c => c.Addresses).HasForeignKey(c => c.CustomerId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Adisyon>().HasOne(c => c.Customer).WithMany(c => c.Adisyons).HasForeignKey(c => c.CustomerId).OnDelete(DeleteBehavior.NoAction);
            //Masa ilişkileri
            modelBuilder.Entity<Desk>().HasOne(c => c.DeskLocation).WithMany(c => c.Desks).HasForeignKey(c => c.DeskLocationId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Adisyon>().HasOne(c => c.Desk).WithMany(c => c.Adisyons).HasForeignKey(c => c.DeskId).OnDelete(DeleteBehavior.NoAction);
            //modelBuilder.Entity<Masa>().HasRequired(c => c.Adisyon).WithMany().HasForeignKey(c=>c.AdisyonId);
            modelBuilder.Entity<Adisyon>().HasOne(c => c.Garson).WithMany(c => c.Adisyons).HasForeignKey(c => c.GarsonId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ProductMotion>().HasOne(c => c.Product).WithMany(c => c.ProductMotions).HasForeignKey(c => c.ProductId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ProductMotion>().HasOne(c => c.Adisyon).WithMany(c => c.ProductMotions).HasForeignKey(c => c.AdisyonId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<SupplementaryMaterialMotion>().HasOne(c => c.ProductMotion).WithMany(c => c.SupplementaryMaterialMotions).HasForeignKey(c => c.ProductMotionId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<SupplementaryMaterialMotion>().HasOne(c => c.SupplementaryMaterial).WithMany(c => c.SupplementaryMaterialMotions).HasForeignKey(c => c.SupplementaryMaterialId).OnDelete(DeleteBehavior.NoAction);
            //Odeme İlişkileri
            modelBuilder.Entity<PaymentMotion>().HasOne(c => c.PaymentType).WithMany(c => c.PaymentMotions).HasForeignKey(c => c.PaymentTypeId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<PaymentMotion>().HasOne(c => c.Adisyon).WithMany(c => c.PaymentMotions).HasForeignKey(c => c.AdisyonId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.ApplyConfiguration(new AddressMap());
            modelBuilder.ApplyConfiguration(new AdisyonMap());
            modelBuilder.ApplyConfiguration(new CustomerMap());
            modelBuilder.ApplyConfiguration(new DeskLocationMap());
            modelBuilder.ApplyConfiguration(new DeskMap());
            modelBuilder.ApplyConfiguration(new GarsonMap());
            modelBuilder.ApplyConfiguration(new PaymentMotionMap());
            modelBuilder.ApplyConfiguration(new PaymentTypeMap());
            modelBuilder.ApplyConfiguration(new PhoneMap());
            modelBuilder.ApplyConfiguration(new PortionMap());
            modelBuilder.ApplyConfiguration(new ProductGroupMap());
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new ProductMotionMap());
            modelBuilder.ApplyConfiguration(new ProductNoteMap());
            modelBuilder.ApplyConfiguration(new SupplementaryMaterialMap());
            modelBuilder.ApplyConfiguration(new SupplementaryMaterialMotionMap());
            modelBuilder.ApplyConfiguration(new UnitMap());
            modelBuilder.ApplyConfiguration(new UsersMap());
            modelBuilder.ApplyConfiguration(new ModelBaseMap());
            modelBuilder.ApplyConfiguration(new LinkTestMap());
            modelBuilder.ApplyConfiguration(new UserRoleMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
