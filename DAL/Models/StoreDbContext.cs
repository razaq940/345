using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DAL.Models
{
    public partial class StoreDbContext : DbContext
    {
        public StoreDbContext()
        {
        }

        public StoreDbContext(DbContextOptions<StoreDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<Tansaction> Tansactions { get; set; }
        public virtual DbSet<TransactionType> TransactionTypes { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<RoleBase> RoleBases { get; set; }
        public virtual DbSet<OTP> OPTs { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<DescriptionProduct> DescriptionProducts { get; set; }
        public virtual DbSet<CategoryProduct> CategoryProducts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Data Source= (localdb)\\MSSQLLocalDB;Initial Catalog=StoreDb;Integrated Security = True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address");

                entity.Property(e => e.Alamat)
                .IsRequired()
                .IsUnicode(false);

                entity.Property(e => e.KodePos)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);

                entity.Property(e => e.Kelurahan)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

                entity.Property(e => e.Kecamatan)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

                entity.Property(e => e.Kabupaten_Kota)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

                entity.Property(e => e.Provinsi)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

               
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PriceBuy)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.PriceSell)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.FkStore)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("Store");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<Tansaction>(entity =>
            {
                entity.ToTable("Tansaction");

                entity.Property(e => e.TransactionCode)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TransactionType>(entity =>
            {
                entity.ToTable("TransactionType");

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IsActivation).HasDefaultValueSql("((0))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Salt)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.UdatedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<RoleBase>(entity =>
            {
                entity.ToTable("RoleBase");
                entity.Property(e => e.Role)
                    .HasMaxLength(100)
                    .IsUnicode(false);



                
            });

            modelBuilder.Entity<DescriptionProduct>(entity =>
            {
                entity.ToTable("DescriptionProduct");
                entity.Property(e => e.NameDescription)
                    .HasMaxLength(255)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.DescriptionDetail)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.ProductId)
                    .IsRequired()
                    .IsUnicode(false);


            });

            modelBuilder.Entity<CategoryProduct>(entity =>
            {
                entity.ToTable("CategoryProduct");
                entity.Property(e => e.CategoryCode)
                    .HasMaxLength(20)
                    .IsRequired()
                    .IsUnicode(false);
                entity.Property(e => e.Category)
                    .HasMaxLength(100)
                    .IsRequired()
                    .IsUnicode(false);



            });

            modelBuilder.Entity<OTP>(entity =>
            {
                entity.ToTable("OTP");
                entity.Property(e => e.Otp)
                    .HasMaxLength(100)
                    .IsUnicode(false);

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
