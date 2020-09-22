using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SkuManager.AppModels.DataBaseEntities
{
    public partial class SKUContext : DbContext
    {
        public SKUContext()
        {
        }

        public SKUContext(DbContextOptions<SKUContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Promotion> Promotion { get; set; }
        public virtual DbSet<PromotionDetails> PromotionDetails { get; set; }
        public virtual DbSet<PromotionType> PromotionType { get; set; }
        public virtual DbSet<Sku> Sku { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Persist Security Info=True;Integrated Security=SSPI;Initial Catalog=SKU;Data Source=LAPTOP-K01C4MJ2");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Promotion>(entity =>
            {
                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Rate).HasColumnType("money");

                entity.HasOne(d => d.PromotionType)
                    .WithMany(p => p.Promotion)
                    .HasForeignKey(d => d.PromotionTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Promotion_PromotionType");
            });

            modelBuilder.Entity<PromotionDetails>(entity =>
            {
                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Promotion)
                    .WithMany(p => p.PromotionDetails)
                    .HasForeignKey(d => d.PromotionId)
                    .HasConstraintName("FK_PromotionDetails_Promotion");

                entity.HasOne(d => d.Sku)
                    .WithMany(p => p.PromotionDetails)
                    .HasForeignKey(d => d.SkuId)
                    .HasConstraintName("FK_PromotionDetails_Sku");
            });

            modelBuilder.Entity<PromotionType>(entity =>
            {
                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Sku>(entity =>
            {
                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Name).HasMaxLength(10);

                entity.Property(e => e.UnitPrice).HasColumnType("money");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
