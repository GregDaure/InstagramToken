using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Instagram.Entity.Models;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Instagram.Entity.Context
{
    public partial class SoFoodMelContext : DbContext
    {
        public SoFoodMelContext()
        {
        }

        public SoFoodMelContext(DbContextOptions<SoFoodMelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<WpOptions> WpOptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WpOptions>(entity =>
            {
                entity.HasKey(e => e.OptionId)
                    .HasName("PRIMARY");

                entity.ToTable("wp_options");

                entity.HasIndex(e => e.Autoload)
                    .HasName("autoload");

                entity.HasIndex(e => e.OptionName)
                    .HasName("option_name")
                    .IsUnique();

                entity.Property(e => e.OptionId)
                    .HasColumnName("option_id")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.Autoload)
                    .IsRequired()
                    .HasColumnName("autoload")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("'yes'");

                entity.Property(e => e.OptionName)
                    .IsRequired()
                    .HasColumnName("option_name")
                    .HasMaxLength(191)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.OptionValue)
                    .IsRequired()
                    .HasColumnName("option_value")
                    .HasColumnType("longtext");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
