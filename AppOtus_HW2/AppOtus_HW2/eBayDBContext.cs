using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AppOtus_HW2
{
    public partial class eBayDBContext : DbContext
    {
        public eBayDBContext()
        {
        }

        public eBayDBContext(DbContextOptions<eBayDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Purchese> Purcheses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=eBayDB;Username=postgres;Password=1234");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("categories");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Categoryname)
                    .HasMaxLength(30)
                    .HasColumnName("categoryname");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customers");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Customername)
                    .HasMaxLength(30)
                    .HasColumnName("customername");

                entity.Property(e => e.Customersurname)
                    .HasMaxLength(30)
                    .HasColumnName("customersurname");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("products");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Categoryid).HasColumnName("categoryid");

                entity.Property(e => e.Price)
                    .HasColumnType("money")
                    .HasColumnName("price");

                entity.Property(e => e.Productname)
                    .HasMaxLength(30)
                    .HasColumnName("productname");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.Categoryid)
                    .HasConstraintName("products_categoryid_fkey");
            });

            modelBuilder.Entity<Purchese>(entity =>
            {
                entity.ToTable("purcheses");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Customerid).HasColumnName("customerid");

                entity.Property(e => e.Productid).HasColumnName("productid");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Purcheses)
                    .HasForeignKey(d => d.Customerid)
                    .HasConstraintName("purcheses_customerid_fkey");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Purcheses)
                    .HasForeignKey(d => d.Productid)
                    .HasConstraintName("purcheses_productid_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
