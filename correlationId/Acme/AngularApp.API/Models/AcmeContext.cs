//using System;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata;

//namespace AngularApp.API.Models
//{
//    public partial class AcmeContext : DbContext
//    {
//        public virtual DbSet<Product> Product { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//                #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer(@"Data Source=acme-sql-001.database.windows.net;Initial Catalog=Acme;Persist Security Info=True;User ID=srikanth;Password=Password@123");
//            }
//        }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<Product>(entity =>
//            {
//                entity.Property(e => e.ProductId).ValueGeneratedNever();

//                entity.Property(e => e.ImageUrl).HasMaxLength(50);

//                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

//                entity.Property(e => e.ProductCode).HasColumnType("nchar(10)");

//                entity.Property(e => e.ProductName).HasMaxLength(50);
//            });
//        }
//    }
//}
