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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ModelBase>(entity =>
            {
                entity.ToTable("ModelBases");

                entity.HasKey(i => i.Id);

                entity.Property(i => i.Id).HasColumnName("Id");
                entity.Property(e => e.CreatedUser).HasMaxLength(50);
                entity.Property(e => e.UpdatedUser).HasMaxLength(50);
                entity.Property(e => e.Decription).HasMaxLength(100);
            });
            modelBuilder.Entity<Portion>().HasOne(c=>c.Product).WithMany(c => c.Portions).HasForeignKey(c => c.ProductId);
            modelBuilder.Entity<SupplementaryMaterial>().HasOne(c => c.Product).WithMany(c => c.SupplementaryMaterials).HasForeignKey(c => c.ProductId);
            modelBuilder.Entity<Product>().HasOne(c => c.ProductGroup).WithMany(c=>c.Products).HasForeignKey(c=>c.ProductGroupId);
            modelBuilder.Entity<Porsiyon>().HasRequired(c => c.Birim).WithOptional().Map(c => c.MapKey("BirimId"));
            modelBuilder.Entity<UrunNot>().HasRequired(c => c.Urun).WithMany(c => c.UrunNotlari).HasForeignKey(c => c.UrunId);

            //Musteri ilişkileri
            modelBuilder.Entity<Telefon>().HasRequired(c => c.Musteri).WithMany(c => c.Telefonlar).HasForeignKey(c => c.MusteriId);
            modelBuilder.Entity<Adres>().HasRequired(c => c.Musteri).WithMany(c => c.Adresler).HasForeignKey(c => c.MusteriId);
            modelBuilder.Entity<Adisyon>().HasOptional(c => c.Musteri).WithMany(c => c.Adisyonlar).HasForeignKey(c => c.MusteriId);
            //Masa ilişkileri
            modelBuilder.Entity<Masa>().HasRequired(c => c.Konum).WithOptional().Map(c => c.MapKey("KonumId"));
            modelBuilder.Entity<Adisyon>().HasOptional(c => c.Masa).WithMany().HasForeignKey(c => c.MasaId);
            //modelBuilder.Entity<Masa>().HasRequired(c => c.Adisyon).WithMany().HasForeignKey(c=>c.AdisyonId);
            modelBuilder.Entity<Adisyon>().HasOptional(c => c.Garson).WithMany().HasForeignKey(c => c.GarsonId);
            modelBuilder.Entity<UrunHareket>().HasRequired(c => c.Urun).WithMany(c => c.UrunHareketleri).HasForeignKey(c => c.UrunId);
            modelBuilder.Entity<UrunHareket>().HasRequired(c => c.Adisyon).WithMany().HasForeignKey(c => c.AdisyonId);
            modelBuilder.Entity<UrunHareket>().HasRequired(c => c.Adisyon).WithMany(c => c.UrunHareketleri).HasForeignKey(c => c.AdisyonId);
            modelBuilder.Entity<EkMalzemeHareket>().HasRequired(c => c.UrunHareket).WithMany(c => c.EkMalzemeHareketleri).HasForeignKey(c => c.UrunHareketId);
            modelBuilder.Entity<EkMalzemeHareket>().HasRequired(c => c.EkMalzeme).WithMany().HasForeignKey(c => c.EkMalzemeId);
            //Odeme İlişkileri
            modelBuilder.Entity<OdemeHareket>().HasRequired(c => c.OdemeTuru).WithMany(c => c.OdemeHareketleri).HasForeignKey(c => c.OdemeTuruId);
            modelBuilder.Entity<OdemeHareket>().HasRequired(c => c.Adisyon).WithMany(c => c.OdemeHareketleri).HasForeignKey(c => c.AdisyonId);
            modelBuilder.Entity<OdemeTuru>().HasRequired(c => c.OdemeTur).WithMany().HasForeignKey(c => c.OdemeTurId);

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
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
